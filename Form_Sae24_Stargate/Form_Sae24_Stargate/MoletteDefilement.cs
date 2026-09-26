using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    /// <summary>
    /// Fait défiler à la molette la liste (de cartes, de missions...) qui est sous la souris,
    /// même si on n'a pas cliqué dedans avant.
    /// Les contrôles qui gèrent déjà la molette (listes déroulantes, tableaux, zones de texte) ne changent pas.
    /// </summary>
    public class MoletteDefilement : IMessageFilter
    {
        private const int WM_MOUSEWHEEL = 0x020A;

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point point);

        public static void Activer()
        {
            Application.AddMessageFilter(new MoletteDefilement());
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != WM_MOUSEWHEEL)
            {
                return false;
            }

            try
            {
                Control survole = Control.FromChildHandle(WindowFromPoint(Cursor.Position));

                //on remonte jusqu'à la première liste qui défile
                for (Control controle = survole; controle != null; controle = controle.Parent)
                {
                    if (GereLaMolette(controle))
                    {
                        return false;
                    }

                    ScrollableControl liste = controle as ScrollableControl;
                    if (liste != null && !(liste is Form) && liste.AutoScroll && liste.VerticalScroll.Visible)
                    {
                        int delta = (short)((long)m.WParam >> 16);
                        int pas = liste.VerticalScroll.SmallChange > 0 ? liste.VerticalScroll.SmallChange * 3 : 60;
                        int y = -liste.AutoScrollPosition.Y - delta / 120 * pas;
                        liste.AutoScrollPosition = new Point(-liste.AutoScrollPosition.X, Math.Max(0, y));
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                //la molette ne doit jamais faire planter l'application
            }
            return false;
        }

        private static bool GereLaMolette(Control controle)
        {
            return controle is ComboBox || controle is DataGridView || controle is TextBoxBase || controle is ListBox
                || controle is ListView || controle is UpDownBase || controle is DateTimePicker;
        }
    }
}

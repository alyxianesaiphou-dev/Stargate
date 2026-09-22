using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    public partial class UserControlBarreChargement : UserControl
    {
        //sert a prevnir que c'est fini
        public event EventHandler ChargementTermine;
        public UserControlBarreChargement()
        {
            InitializeComponent();
            pnlBarreViolette.Width = 0;

            timerChargement.Tick += timerChargement_Tick;
        }

        public void LancerChargement()
        {
            pnlBarreViolette.Width = 0;
            timerChargement.Start();
        }

        private void timerChargement_Tick(object sender, EventArgs e)
        {
            int largeurMax = pnlFondBarre.Width;

            //si la barre violette n'a pas encore atteint le bout
            if (pnlBarreViolette.Width < largeurMax)
            {
                //on l'agrandit de 10 pixels 
                pnlBarreViolette.Width += 3;
            }
            else
            {
                //la barre est pleine, on stop le chrono.
                timerChargement.Stop();

                //on previent la fenetre parent
                ChargementTermine?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

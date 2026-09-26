using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    /// <summary>
    /// Adapte une fenêtre à la taille de l'écran : positions, tailles et textes de tous les contrôles
    /// sont agrandis (ou réduits) dans la même proportion que la fenêtre, et l'espace en trop est
    /// réparti de chaque côté pour que tout reste centré.
    /// Les fenêtres ont été réglées pour un écran 1920 x 1080 à 125 % : sur cet écran rien ne bouge.
    ///
    /// Utilisation : AdaptationEcran.Activer(this); à la fin du constructeur de la fenêtre.
    /// Le code de la fenêtre continue à utiliser les positions et tailles d'origine (celles du concepteur) :
    /// quand il déplace ou redimensionne un contrôle, la mise à l'échelle est refaite automatiquement,
    /// et les contrôles ajoutés plus tard (cartes, étiquettes...) sont agrandis eux aussi.
    /// </summary>
    public class AdaptationEcran
    {
        //zone utile de l'écran pour lequel les fenêtres ont été réglées (barre des tâches enlevée) :
        //un écran 1920 x 1080 avec la mise à l'échelle Windows à 125 %, que l'application voit comme 1536 x 864.
        //(Windows rétrécit les fenêtres dessinées dans Visual Studio à 125 % ; les positions écrites dans le code
        //ont été choisies en tenant compte de ce rétrécissement, c'est cet ensemble qu'on agrandit.)
        private const float largeurReference = 1536f;
        private const float hauteurReference = 824f;

        //état d'origine d'un contrôle, avant mise à l'échelle
        private class Etat
        {
            public Rectangle Bornes;
            public Font Police;
            public Padding Marge;
            public Padding Rembourrage;
            //facteur déjà appliqué aux colonnes d'un tableau ou d'une liste
            public float FacteurColonnes = 1f;
        }

        private static readonly ConditionalWeakTable<Form, AdaptationEcran> adaptations = new ConditionalWeakTable<Form, AdaptationEcran>();
        private static readonly ConditionalWeakTable<Control, Etat> etats = new ConditionalWeakTable<Control, Etat>();
        //contrôles que la fenêtre place elle-même en pixels réels (leurs enfants restent mis à l'échelle)
        private static readonly ConditionalWeakTable<Control, object> placementsLibres = new ConditionalWeakTable<Control, object>();

        private readonly Form fenetre;
        private Size tailleDeBase;
        private float facteur = 1f;
        private Point decalage = Point.Empty;
        //vrai pendant que la mise à l'échelle déplace les contrôles (pour ne pas confondre avec le code de la fenêtre)
        private bool enCours = false;

        private AdaptationEcran(Form fenetre)
        {
            this.fenetre = fenetre;
            this.tailleDeBase = fenetre.ClientSize;

            //la fenêtre a déjà été adaptée à la police de Windows par le concepteur, on gère la suite nous-mêmes
            fenetre.AutoScaleMode = AutoScaleMode.None;
            //la fenêtre ne doit pas grandir toute seule pour suivre ses contrôles agrandis
            fenetre.AutoSize = false;

            foreach (Control enfant in fenetre.Controls)
            {
                Suivre(enfant);
            }
            fenetre.ControlAdded += EnfantAjoute;

            fenetre.Load += FenetreChargee;
            fenetre.Resize += delegate { Appliquer(); };
        }

        /// <summary>
        /// Met toute la fenêtre à l'échelle de l'écran (à appeler à la fin du constructeur)
        /// </summary>
        public static void Activer(Form fenetre)
        {
            AdaptationEcran existante;
            if (!adaptations.TryGetValue(fenetre, out existante))
            {
                adaptations.Add(fenetre, new AdaptationEcran(fenetre));
            }
        }

        /// <summary>
        /// La fenêtre place elle-même ce contrôle, en pixels réels (par exemple collé à un autre contrôle déjà
        /// mis à l'échelle) : sa position et sa taille ne sont plus touchées, mais ses enfants restent mis à l'échelle
        /// </summary>
        public static void PlacementLibre(Control controle)
        {
            object marque;
            if (!placementsLibres.TryGetValue(controle, out marque))
            {
                placementsLibres.Add(controle, new object());
            }
        }

        private static bool EstLibre(Control controle)
        {
            object marque;
            return placementsLibres.TryGetValue(controle, out marque);
        }

        /// <summary>
        /// Facteur d'agrandissement actuel de la fenêtre qui contient ce contrôle (1 si elle n'est pas adaptée)
        /// </summary>
        public static float Facteur(Control controle)
        {
            Form fenetre = controle.FindForm();
            AdaptationEcran adaptation;
            if (fenetre != null && adaptations.TryGetValue(fenetre, out adaptation))
            {
                return adaptation.facteur;
            }
            return 1f;
        }

        /// <summary>
        /// Taille d'origine d'un contrôle ou d'une fenêtre (celle du concepteur), avant mise à l'échelle
        /// </summary>
        public static Size TailleDeBase(Control controle)
        {
            AdaptationEcran adaptation;
            Form fenetre = controle as Form;
            if (fenetre != null && adaptations.TryGetValue(fenetre, out adaptation))
            {
                return adaptation.tailleDeBase;
            }
            Etat etat;
            if (etats.TryGetValue(controle, out etat))
            {
                return etat.Bornes.Size;
            }
            return controle.Size;
        }

        /// <summary>
        /// Position et taille d'origine d'un contrôle (celles du concepteur), avant mise à l'échelle
        /// </summary>
        public static Rectangle BornesDeBase(Control controle)
        {
            Etat etat;
            if (etats.TryGetValue(controle, out etat))
            {
                return etat.Bornes;
            }
            return controle.Bounds;
        }

        //une fenêtre en plein écran a été réglée pour remplir l'écran de référence ;
        //une autre fenêtre est agrandie comme l'écran, sans jamais en dépasser
        private void FenetreChargee(object sender, EventArgs e)
        {
            Rectangle ecran = Screen.FromControl(fenetre).WorkingArea;
            int bordsLargeur = fenetre.Width - fenetre.ClientSize.Width;
            int bordsHauteur = fenetre.Height - fenetre.ClientSize.Height;

            if (fenetre.WindowState == FormWindowState.Maximized)
            {
                tailleDeBase = new Size((int)largeurReference - bordsLargeur, (int)hauteurReference - bordsHauteur);
            }
            else if (fenetre.WindowState == FormWindowState.Normal)
            {
                float facteurEcran = Math.Min(ecran.Width / largeurReference, ecran.Height / hauteurReference);
                float facteurMax = Math.Min((ecran.Width - bordsLargeur) / (float)tailleDeBase.Width,
                                            (ecran.Height - bordsHauteur) / (float)tailleDeBase.Height);
                float facteurFenetre = Math.Min(Math.Max(facteurEcran, 1f), facteurMax);

                fenetre.ClientSize = new Size((int)Math.Round(tailleDeBase.Width * facteurFenetre),
                                              (int)Math.Round(tailleDeBase.Height * facteurFenetre));
                fenetre.Location = new Point(ecran.Left + (ecran.Width - fenetre.Width) / 2,
                                             ecran.Top + (ecran.Height - fenetre.Height) / 2);
            }
            Appliquer();
        }

        /****************************************************************************************/

        //enregistre l'état d'origine d'un contrôle et de ses enfants, et surveille ses changements
        private void Suivre(Control controle)
        {
            Etat etat;
            if (etats.TryGetValue(controle, out etat))
            {
                //déjà connu (retiré puis remis) : on garde son état d'origine
                foreach (Control enfant in controle.Controls)
                {
                    Suivre(enfant);
                }
                return;
            }

            etat = new Etat();
            etat.Bornes = controle.Bounds;
            etat.Marge = controle.Margin;
            etat.Rembourrage = controle.Padding;
            etat.Police = PoliceDeBase(controle);
            etats.Add(controle, etat);

            //c'est la mise à l'échelle qui place les contrôles : on enlève les ancrages à droite et en bas
            if (controle.Dock == DockStyle.None && !DansUneMiseEnPage(controle))
            {
                controle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }

            //un contrôle personnalisé ne doit pas se remettre à l'échelle tout seul quand sa police change
            ContainerControl conteneur = controle as ContainerControl;
            if (conteneur != null)
            {
                conteneur.AutoScaleMode = AutoScaleMode.None;
            }

            controle.LocationChanged += PositionChangee;
            controle.SizeChanged += TailleChangee;
            controle.FontChanged += PoliceChangee;
            controle.ControlAdded += EnfantAjoute;

            foreach (Control enfant in controle.Controls)
            {
                Suivre(enfant);
            }
        }

        //police d'origine : si le contrôle hérite de la police de son parent, c'est celle d'origine du parent
        private static Font PoliceDeBase(Control controle)
        {
            Etat etatParent;
            if (controle.Parent != null && etats.TryGetValue(controle.Parent, out etatParent)
                && controle.Font.Equals(controle.Parent.Font))
            {
                return etatParent.Police;
            }
            return controle.Font;
        }

        //contrôle placé automatiquement par son parent (liste de cartes, tableau de mise en page)
        private static bool DansUneMiseEnPage(Control controle)
        {
            return controle.Parent is FlowLayoutPanel || controle.Parent is TableLayoutPanel;
        }

        private static bool AfficheDuTexte(Control controle)
        {
            return !(controle is Panel || controle is UserControl || controle is SplitContainer);
        }

        //contrôle dont la taille dépend de sa police ou de son texte (elle n'est pas choisie par le code)
        private static bool TailleAutomatique(Control controle)
        {
            if (controle is TextBoxBase)
            {
                TextBoxBase texte = (TextBoxBase)controle;
                return !texte.Multiline;
            }
            return controle.AutoSize || controle is ComboBox || controle is UpDownBase || controle is DateTimePicker;
        }

        private void EnfantAjoute(object sender, ControlEventArgs e)
        {
            Suivre(e.Control);
            if (!enCours && facteur != 1f)
            {
                MettreAEchelle(e.Control);
            }
        }

        //le code de la fenêtre a déplacé un contrôle : la nouvelle position est une position d'origine
        private void PositionChangee(object sender, EventArgs e)
        {
            Control controle = (Control)sender;
            if (enCours || EstLibre(controle) || controle.Dock != DockStyle.None || DansUneMiseEnPage(controle) || ParentDefilant(controle))
            {
                return;
            }
            etats.GetValue(controle, c => new Etat()).Bornes.Location = controle.Location;
            MettreAEchelle(controle, false);
        }

        //le code de la fenêtre a redimensionné un contrôle : la nouvelle taille est une taille d'origine
        private void TailleChangee(object sender, EventArgs e)
        {
            Control controle = (Control)sender;
            if (enCours || EstLibre(controle) || controle.Dock != DockStyle.None || TailleAutomatique(controle))
            {
                return;
            }
            etats.GetValue(controle, c => new Etat()).Bornes.Size = controle.Size;
            MettreAEchelle(controle, false);
        }

        //le code de la fenêtre a changé une police : c'est la nouvelle police d'origine
        private void PoliceChangee(object sender, EventArgs e)
        {
            Control controle = (Control)sender;
            if (enCours)
            {
                return;
            }
            etats.GetValue(controle, c => new Etat()).Police = controle.Font;
            MettreAEchelle(controle, false);
        }

        private static bool ParentDefilant(Control controle)
        {
            ScrollableControl parent = controle.Parent as ScrollableControl;
            return parent != null && parent.AutoScroll;
        }

        /****************************************************************************************/

        //recalcule le facteur d'après la taille de la fenêtre et remet tous les contrôles à l'échelle
        private void Appliquer()
        {
            Size taille = fenetre.ClientSize;
            if (taille.Width <= 0 || taille.Height <= 0 || fenetre.WindowState == FormWindowState.Minimized)
            {
                return;
            }

            facteur = Math.Min(taille.Width / (float)tailleDeBase.Width, taille.Height / (float)tailleDeBase.Height);
            decalage = new Point((int)((taille.Width - tailleDeBase.Width * facteur) / 2),
                                 (int)((taille.Height - tailleDeBase.Height * facteur) / 2));

            fenetre.SuspendLayout();
            foreach (Control enfant in fenetre.Controls)
            {
                MettreAEchelle(enfant);
            }
            fenetre.ResumeLayout(true);
        }

        private void MettreAEchelle(Control controle)
        {
            MettreAEchelle(controle, true);
        }

        private void MettreAEchelle(Control controle, bool avecEnfants)
        {
            Etat etat;
            if (!etats.TryGetValue(controle, out etat))
            {
                return;
            }

            bool dejaEnCours = enCours;
            enCours = true;
            controle.SuspendLayout();
            try
            {
                MettreAEchelleSansEnfants(controle, etat);

                if (avecEnfants)
                {
                    foreach (Control enfant in controle.Controls)
                    {
                        MettreAEchelle(enfant, true);
                    }
                }
            }
            finally
            {
                controle.ResumeLayout(true);
                enCours = dejaEnCours;
            }
        }

        //un souci de mise à l'échelle sur un contrôle ne doit jamais faire planter l'application
        private void MettreAEchelleSansEnfants(Control controle, Etat etat)
        {
            try
            {
                if (EstLibre(controle))
                {
                    return;
                }

                //texte ; un panneau n'affiche pas de texte lui-même : il garde sa police d'origine, pour que
                //les contrôles qu'on y ajoute plus tard ne soient pas agrandis deux fois
                if (etat.Police != null)
                {
                    if (AfficheDuTexte(controle))
                    {
                        controle.Font = new Font(etat.Police.FontFamily, Math.Max(1f, etat.Police.Size * facteur),
                                                 etat.Police.Style, etat.Police.Unit, etat.Police.GdiCharSet);
                    }
                    else
                    {
                        controle.Font = etat.Police;
                    }
                }

                //espaces autour et à l'intérieur (celui des listes de cartes sert à les centrer, il est calculé à part)
                controle.Margin = Agrandir(etat.Marge);
                if (!(controle is FlowLayoutPanel))
                {
                    controle.Padding = Agrandir(etat.Rembourrage);
                }

                //position et taille
                Rectangle bornes = new Rectangle(Arrondir(etat.Bornes.X), Arrondir(etat.Bornes.Y),
                                                 Arrondir(etat.Bornes.Width), Arrondir(etat.Bornes.Height));
                if (controle.Parent == fenetre)
                {
                    bornes.Offset(decalage);
                }

                switch (controle.Dock)
                {
                    case DockStyle.Fill:
                        break;
                    case DockStyle.Top:
                    case DockStyle.Bottom:
                        controle.Height = bornes.Height;
                        break;
                    case DockStyle.Left:
                    case DockStyle.Right:
                        controle.Width = bornes.Width;
                        break;
                    default:
                        if (DansUneMiseEnPage(controle))
                        {
                            if (!controle.AutoSize)
                            {
                                controle.Size = bornes.Size;
                            }
                        }
                        else
                        {
                            ScrollableControl parent = controle.Parent as ScrollableControl;
                            if (ParentDefilant(controle))
                            {
                                bornes.Offset(parent.AutoScrollPosition);
                            }
                            if (controle.AutoSize && !(controle is TextBoxBase))
                            {
                                controle.Location = bornes.Location;
                            }
                            else
                            {
                                controle.Bounds = bornes;
                            }
                        }
                        break;
                }

                MettreColonnesAEchelle(controle, etat);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("AdaptationEcran : " + controle.Name + " : " + ex.Message);
            }
        }

        //colonnes des tableaux et des listes, et hauteur des lignes des tableaux
        private void MettreColonnesAEchelle(Control controle, Etat etat)
        {
            float rapport = facteur / etat.FacteurColonnes;
            if (Math.Abs(rapport - 1f) < 0.001f)
            {
                return;
            }

            DataGridView tableau = controle as DataGridView;
            if (tableau != null)
            {
                foreach (DataGridViewColumn colonne in tableau.Columns)
                {
                    //une colonne qui se dimensionne toute seule (remplissage, contenu) ne se touche pas
                    if (colonne.InheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.None)
                    {
                        continue;
                    }
                    colonne.Width = Math.Max(colonne.MinimumWidth, (int)Math.Round(colonne.Width * rapport));
                }
                tableau.RowTemplate.Height = Math.Max(3, (int)Math.Round(tableau.RowTemplate.Height * rapport));
                foreach (DataGridViewRow ligne in tableau.Rows)
                {
                    ligne.Height = Math.Max(ligne.MinimumHeight, (int)Math.Round(ligne.Height * rapport));
                }
                if (tableau.RowHeadersVisible)
                {
                    tableau.RowHeadersWidth = Math.Max(4, (int)Math.Round(tableau.RowHeadersWidth * rapport));
                }
                if (tableau.ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize)
                {
                    tableau.ColumnHeadersHeight = Math.Max(4, (int)Math.Round(tableau.ColumnHeadersHeight * rapport));
                }
            }

            ListView liste = controle as ListView;
            if (liste != null)
            {
                foreach (ColumnHeader colonne in liste.Columns)
                {
                    if (colonne.Width > 0)
                    {
                        colonne.Width = (int)Math.Round(colonne.Width * rapport);
                    }
                }
            }

            etat.FacteurColonnes = facteur;
        }

        private int Arrondir(int valeur)
        {
            return (int)Math.Round(valeur * facteur);
        }

        private Padding Agrandir(Padding espace)
        {
            return new Padding(Arrondir(espace.Left), Arrondir(espace.Top), Arrondir(espace.Right), Arrondir(espace.Bottom));
        }
    }
}

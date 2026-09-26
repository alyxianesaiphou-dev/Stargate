using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    /// <summary>
    /// Carte du trombinoscope d'un membre : photo centrée et nom en dessous, de taille fixe
    /// (elle ne dépend pas de la police de la fenêtre, pour s'afficher pareil partout).
    /// Un clic déclenche l'événement Clic, un double-clic ouvre la fiche du membre.
    /// </summary>
    public class CarteMembre : Panel
    {
        //taille fixe d'une carte en pixels (cadre de sélection compris)
        public const int Largeur = 160;
        public const int Hauteur = 212;
        public const int Marge = 6;

        //fond conseillé pour un trombinoscope de cartes
        public static readonly Color CouleurTrombinoscope = Color.FromArgb(28, 24, 70);

        private static readonly Color couleurCarte = Color.FromArgb(48, 42, 110);
        private static readonly Color couleurCarteSurvol = Color.FromArgb(72, 64, 150);
        private static readonly Color couleurSelection = Color.HotPink;
        private static readonly Color couleurFondSelection = Color.FromArgb(120, 40, 110);

        //épaisseur du cadre rose de sélection
        private const int bordure = 5;

        private readonly Panel fond;
        private readonly Label lblCoche;
        private bool selectionnee = false;

        public string Matricule { get; private set; }
        public string Nom { get; private set; }
        public bool EstChef { get; private set; }

        public event EventHandler Clic;

        public CarteMembre(string matricule, string nom, bool estChef)
        {
            this.Matricule = matricule;
            this.Nom = nom;
            this.EstChef = estChef;

            //le panneau extérieur sert de bordure : il devient rose quand la carte est sélectionnée
            this.Size = new Size(Largeur, Hauteur);
            this.Margin = new Padding(Marge);
            this.Padding = new Padding(bordure);
            this.BackColor = couleurCarte;

            fond = new Panel();
            fond.Dock = DockStyle.Fill;
            fond.BackColor = couleurCarte;

            PictureBox photo = new PictureBox();
            photo.Size = new Size(130, 130);
            photo.Location = new Point((Largeur - 2 * bordure - photo.Width) / 2, 10);
            photo.SizeMode = PictureBoxSizeMode.Zoom;
            photo.BackColor = Color.Transparent;

            string cheminImage = Path.Combine(Application.StartupPath, "Images", "ImageMetier", matricule + ".png");
            if (File.Exists(cheminImage))
            {
                photo.Image = Image.FromFile(cheminImage);
            }

            Label lblNom = new Label();
            lblNom.AutoSize = false;
            lblNom.Location = new Point(2, 146);
            lblNom.Size = new Size(Largeur - 2 * bordure - 4, 56);
            lblNom.TextAlign = ContentAlignment.TopCenter;
            lblNom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNom.ForeColor = Color.White;
            lblNom.BackColor = Color.Transparent;
            lblNom.Text = nom;

            if (estChef)
            {
                lblNom.Text += "\n★ Chef de mission";
                lblNom.ForeColor = Color.Gold;
            }

            //coche affichée en haut à droite quand la carte est sélectionnée
            lblCoche = new Label();
            lblCoche.AutoSize = false;
            lblCoche.Size = new Size(30, 30);
            lblCoche.Location = new Point(Largeur - 2 * bordure - 34, 4);
            lblCoche.TextAlign = ContentAlignment.MiddleCenter;
            lblCoche.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCoche.ForeColor = Color.White;
            lblCoche.BackColor = couleurSelection;
            lblCoche.Text = "✔";
            lblCoche.Visible = false;

            fond.Controls.Add(lblCoche);
            fond.Controls.Add(photo);
            fond.Controls.Add(lblNom);
            this.Controls.Add(fond);

            //clic, double-clic et survol sur toute la carte
            foreach (Control zone in new Control[] { fond, photo, lblNom, lblCoche })
            {
                zone.Cursor = Cursors.Hand;
                zone.Click += delegate
                {
                    if (Clic != null)
                    {
                        Clic(this, EventArgs.Empty);
                    }
                };
                zone.DoubleClick += delegate
                {
                    FormDetailsMembre fenetreDetails = new FormDetailsMembre(Matricule);
                    fenetreDetails.ShowDialog(this.FindForm());
                };
                zone.MouseEnter += delegate { fond.BackColor = couleurCarteSurvol; };
                zone.MouseLeave += delegate { fond.BackColor = selectionnee ? couleurFondSelection : couleurCarte; };
            }
        }

        public bool Selectionnee
        {
            get { return selectionnee; }
            set
            {
                selectionnee = value;
                this.BackColor = value ? couleurSelection : couleurCarte;
                fond.BackColor = value ? couleurFondSelection : couleurCarte;
                lblCoche.Visible = value;
            }
        }

        /// <summary>
        /// Centre les colonnes de cartes dans un trombinoscope (en laissant la place de la barre de défilement)
        /// </summary>
        public static void CentrerColonnes(FlowLayoutPanel panneau)
        {
            int largeurUtile = panneau.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4;
            int largeurColonne = Largeur + 2 * Marge;
            int nbColonnes = Math.Max(1, largeurUtile / largeurColonne);
            int marge = Math.Max(0, (largeurUtile - nbColonnes * largeurColonne) / 2);
            panneau.Padding = new Padding(marge, 6, 0, 6);
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    /// <summary>
    /// Carte d'une espèce extraterrestre : image, nom, couleur, statut (allié, ennemi, neutre)
    /// et une ligne d'information en bas (planètes, présence ou nombre à capturer).
    /// Taille fixe et mêmes couleurs que CarteMembre et CartePlanete, pour s'afficher pareil sur tous les PC.
    /// Un clic déclenche l'événement Clic.
    /// </summary>
    public class CarteAlien : Panel
    {
        public const int Largeur = 200;
        public const int Hauteur = 296;
        public const int Marge = 8;

        //épaisseur du cadre rose de sélection
        private const int bordure = 5;

        private static readonly Color couleurAllie = Color.FromArgb(40, 150, 85);
        private static readonly Color couleurEnnemi = Color.FromArgb(200, 45, 65);
        private static readonly Color couleurNeutre = Color.FromArgb(105, 105, 130);

        private readonly Panel fond;
        private readonly Label lblCoche;
        private readonly Label lblInfo;
        private bool selectionnee = false;

        public string NomAlien { get; private set; }

        public event EventHandler Clic;

        /// <summary>
        /// Crée la carte à partir d'une ligne de la table dtAlien (voir FormAccueil.remplirTableAlien)
        /// </summary>
        public static CarteAlien DepuisLigne(DataRow ligneAlien, string info)
        {
            return new CarteAlien(ligneAlien["nom"].ToString(), ligneAlien["couleur"].ToString(), ligneAlien["statut"].ToString(), info);
        }

        public CarteAlien(string nom, string couleur, string statut, string info)
        {
            this.NomAlien = nom;

            this.Size = new Size(Largeur, Hauteur);
            this.Margin = new Padding(Marge);
            this.Padding = new Padding(bordure);
            this.BackColor = CarteMembre.couleurCarte;

            fond = new Panel();
            fond.Dock = DockStyle.Fill;
            fond.BackColor = CarteMembre.couleurCarte;

            int largeurFond = Largeur - 2 * bordure;

            PictureBox image = new PictureBox();
            image.Size = new Size(150, 150);
            image.Location = new Point((largeurFond - image.Width) / 2, 10);
            image.SizeMode = PictureBoxSizeMode.Zoom;
            image.BackColor = Color.Transparent;
            image.Image = ChargerImage(nom + ".png");

            Label lblNom = new Label();
            lblNom.AutoSize = false;
            lblNom.Location = new Point(4, 166);
            lblNom.Size = new Size(largeurFond - 8, 26);
            lblNom.TextAlign = ContentAlignment.MiddleCenter;
            lblNom.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNom.ForeColor = Color.White;
            lblNom.BackColor = Color.Transparent;
            lblNom.Text = nom;

            Label lblCouleur = new Label();
            lblCouleur.AutoSize = false;
            lblCouleur.Location = new Point(4, 192);
            lblCouleur.Size = new Size(largeurFond - 8, 20);
            lblCouleur.TextAlign = ContentAlignment.MiddleCenter;
            lblCouleur.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblCouleur.ForeColor = Color.Gainsboro;
            lblCouleur.BackColor = Color.Transparent;
            lblCouleur.Text = "Couleur : " + couleur;

            //statut : pastille de couleur (le degré n'est affiché que dans la fiche détaillée)
            Label lblStatut = new Label();
            lblStatut.AutoSize = false;
            lblStatut.Size = new Size(100, 26);
            lblStatut.TextAlign = ContentAlignment.MiddleCenter;
            lblStatut.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatut.ForeColor = Color.White;
            lblStatut.BackColor = statut == "Allié" ? couleurAllie : (statut == "Ennemi" ? couleurEnnemi : couleurNeutre);
            lblStatut.Text = statut;

            lblStatut.Location = new Point((largeurFond - lblStatut.Width) / 2, 216);

            lblInfo = new Label();
            lblInfo.AutoSize = false;
            lblInfo.Location = new Point(4, 250);
            lblInfo.Size = new Size(largeurFond - 8, 32);
            lblInfo.TextAlign = ContentAlignment.TopCenter;
            lblInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblInfo.ForeColor = Color.Gainsboro;
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Text = info;

            lblCoche = new Label();
            lblCoche.AutoSize = false;
            lblCoche.Size = new Size(30, 30);
            lblCoche.Location = new Point(largeurFond - 34, 4);
            lblCoche.TextAlign = ContentAlignment.MiddleCenter;
            lblCoche.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCoche.ForeColor = Color.White;
            lblCoche.BackColor = CarteMembre.couleurSelection;
            lblCoche.Text = "✔";
            lblCoche.Visible = false;

            fond.Controls.Add(lblCoche);
            fond.Controls.Add(image);
            fond.Controls.Add(lblNom);
            fond.Controls.Add(lblCouleur);
            fond.Controls.Add(lblStatut);
            fond.Controls.Add(lblInfo);
            this.Controls.Add(fond);

            //clic et survol sur toute la carte
            foreach (Control zone in fond.Controls)
            {
                BrancherZone(zone);
            }
            BrancherZone(fond);
        }

        private void BrancherZone(Control zone)
        {
            zone.Cursor = Cursors.Hand;
            zone.Click += delegate
            {
                if (Clic != null)
                {
                    Clic(this, EventArgs.Empty);
                }
            };
            zone.MouseEnter += delegate { fond.BackColor = CarteMembre.couleurCarteSurvol; };
            zone.MouseLeave += delegate { fond.BackColor = selectionnee ? CarteMembre.couleurFondSelection : CarteMembre.couleurCarte; };
        }

        public bool Selectionnee
        {
            get { return selectionnee; }
            set
            {
                selectionnee = value;
                this.BackColor = value ? CarteMembre.couleurSelection : CarteMembre.couleurCarte;
                fond.BackColor = value ? CarteMembre.couleurFondSelection : CarteMembre.couleurCarte;
                lblCoche.Visible = value;
            }
        }

        /// <summary>
        /// Texte de la ligne du bas (planètes, présence, nombre à capturer...)
        /// </summary>
        public string Info
        {
            get { return lblInfo.Text; }
            set { lblInfo.Text = value; }
        }

        public string getNomAlien()
        {
            return NomAlien;
        }

        private static Image ChargerImage(string fichier)
        {
            string chemin = Path.Combine(Application.StartupPath, "Images", "Extraterrestres", fichier);
            return File.Exists(chemin) ? Image.FromFile(chemin) : null;
        }
    }
}

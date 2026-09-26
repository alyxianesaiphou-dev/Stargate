using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    /// <summary>
    /// Carte d'une planète pour la création de mission : image, nom, température, gravité et DataBaz.
    /// Taille fixe et mêmes couleurs que CarteMembre, pour s'afficher pareil sur tous les PC.
    /// Un clic déclenche l'événement Clic.
    /// </summary>
    public class CartePlanete : Panel
    {
        public const int Largeur = 230;
        public const int Hauteur = 300;
        public const int Marge = 8;

        //épaisseur du cadre rose de sélection
        private const int bordure = 5;

        private readonly Panel fond;
        private readonly Label lblCoche;
        private bool selectionnee = false;

        public string NomPlanete { get; private set; }

        public event EventHandler Clic;

        public CartePlanete(string nomPlanete, string temperature, string gravite, string dataBaz)
        {
            this.NomPlanete = nomPlanete;

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
            image.Location = new Point((largeurFond - image.Width) / 2, 12);
            image.SizeMode = PictureBoxSizeMode.Zoom;
            image.BackColor = Color.Transparent;
            image.Image = ChargerImage("Planetes", nomPlanete + ".png");

            Label lblNom = new Label();
            lblNom.AutoSize = false;
            lblNom.Location = new Point(4, 170);
            lblNom.Size = new Size(largeurFond - 8, 28);
            lblNom.TextAlign = ContentAlignment.MiddleCenter;
            lblNom.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblNom.ForeColor = Color.White;
            lblNom.BackColor = Color.Transparent;
            lblNom.Text = nomPlanete;

            //trois informations côte à côte : icône au-dessus, valeur en dessous
            int largeurInfo = (largeurFond - 8) / 3;
            Control[] zonesInfo = new Control[6];

            string texteTemperature = temperature == "?" ? "?" : temperature + " °C";
            string texteGravite = gravite == "?" ? "?" : gravite + " g";
            string texteDataBaz = dataBaz == "1" ? "DataBaz" : (dataBaz == "0" ? "Pas de DataBaz" : "DataBaz ?");

            string[] icones = { Path.Combine("Temperature", IconeTemperature(temperature) + ".png"),
                                Path.Combine("Gravite", "Gravite.png"),
                                Path.Combine("DataBaz", IconeDataBaz(dataBaz) + ".png") };
            string[] textes = { texteTemperature, texteGravite, texteDataBaz };

            for (int i = 0; i < 3; i++)
            {
                PictureBox icone = new PictureBox();
                icone.Size = new Size(36, 36);
                icone.Location = new Point(4 + i * largeurInfo + (largeurInfo - icone.Width) / 2, 208);
                icone.SizeMode = PictureBoxSizeMode.Zoom;
                icone.BackColor = Color.Transparent;
                icone.Image = ChargerImage("Planetes", icones[i]);

                Label valeur = new Label();
                valeur.AutoSize = false;
                valeur.Location = new Point(4 + i * largeurInfo, 246);
                valeur.Size = new Size(largeurInfo, 36);
                valeur.TextAlign = ContentAlignment.TopCenter;
                valeur.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                valeur.ForeColor = Color.Gainsboro;
                valeur.BackColor = Color.Transparent;
                valeur.Text = textes[i];

                zonesInfo[2 * i] = icone;
                zonesInfo[2 * i + 1] = valeur;
            }

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
            fond.Controls.AddRange(zonesInfo);
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

        public string getNomPlanete()
        {
            return NomPlanete;
        }

        private static Image ChargerImage(string dossier, string fichier)
        {
            string chemin = Path.Combine(Application.StartupPath, "Images", dossier, fichier);
            return File.Exists(chemin) ? Image.FromFile(chemin) : null;
        }

        private static string IconeTemperature(string temperature)
        {
            int valeur;
            if (!int.TryParse(temperature, out valeur))
            {
                return "TemperatureInconnue";
            }
            if (valeur < 0)
            {
                return "TemperatureFroid";
            }
            if (valeur > 100)
            {
                return "TemperatureChaud";
            }
            return "TemperatureMoyen";
        }

        private static string IconeDataBaz(string dataBaz)
        {
            if (dataBaz == "1")
            {
                return "PresenceDataBaz";
            }
            if (dataBaz == "0")
            {
                return "AbsenceDataBaz";
            }
            return "InconnuDataBaz";
        }
    }
}

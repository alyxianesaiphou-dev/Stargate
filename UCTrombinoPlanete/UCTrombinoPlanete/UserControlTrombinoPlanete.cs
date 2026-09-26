using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlTrombinoPlanete
{
    //delegate sert à créer un type représentant une méthode -> crée un modèle de fonction.
    public delegate void afficherPlaneteDetail(object sender, EventArgs e);
    public partial class UCTrombPlanete: UserControl
    {
        // Création d’une instance du delegate -> crée une variable capable de stocker une méthode
        public afficherPlaneteDetail afficheur;
        public UCTrombPlanete()
        {
            InitializeComponent();
        }

        public UCTrombPlanete(string nomPlanete, string temp, string gravite, string dtb)
        {
            InitializeComponent();
            //Récupérer le chemin pour les images sur chaque pc
            string cheminPlanete = @"Images\Planetes\" + nomPlanete + ".png";

            picPlanete.Image = Image.FromFile(cheminPlanete);
            lblPlanete.Text = nomPlanete;

            string thermometre = "TemperatureInconnue";
            if (temp != "?")
            {
                int temperature = Convert.ToInt32(temp);
                if (temperature < 0)
                {
                    thermometre = "TemperatureFroid";
                }
                else if (temperature > 100)
                {
                    thermometre = "TemperatureChaud";
                }
                else if (temperature >= 0 && temperature <= 100)
                {
                    thermometre = "TemperatureMoyen";
                }
                temp += "°C";
            }

            string cheminTemperature = @"Images\Planetes\Temperature\" + thermometre + ".png";
            picTemperature.Image = Image.FromFile(cheminTemperature);
            lblTemperature.Text = temp.ToString();

            lblGravite.Text = gravite;

            String iconeDataBaz = "InconnuDataBaz";
            if (dtb != "?")
            {
                int dataBaz = Convert.ToInt32(dtb);
                if (dataBaz == 0)
                {
                    iconeDataBaz = "AbsenceDataBaz";
                }
                if (dataBaz == 1)
                {
                    iconeDataBaz = "PresenceDataBaz";
                }
            }
                
            
            string cheminDataBaz = @"Images\Planetes\DataBaz\" + iconeDataBaz + ".png";
            picDataBaz.Image = Image.FromFile(cheminDataBaz);

            picPlanete.Click += btnPlaneteDetail_Click;
            picTemperature.Click += btnPlaneteDetail_Click;
            picGravite.Click += btnPlaneteDetail_Click;
            picDataBaz.Click += btnPlaneteDetail_Click;
            lblPlanete.Click += btnPlaneteDetail_Click;
            lblGravite.Click += btnPlaneteDetail_Click;
            lblTemperature.Click += btnPlaneteDetail_Click;

            picPlanete.MouseEnter += btnPlaneteDetail_MouseEnter;
            picTemperature.MouseEnter += btnPlaneteDetail_MouseEnter;
            picGravite.MouseEnter += btnPlaneteDetail_MouseEnter;
            picDataBaz.MouseEnter += btnPlaneteDetail_MouseEnter;
            lblPlanete.MouseEnter += btnPlaneteDetail_MouseEnter;
            lblGravite.MouseEnter += btnPlaneteDetail_MouseEnter;
            lblTemperature.MouseEnter += btnPlaneteDetail_MouseEnter;

            picPlanete.MouseLeave += btnPlaneteDetail_MouseLeave;
            picTemperature.MouseLeave += btnPlaneteDetail_MouseLeave;
            picGravite.MouseLeave += btnPlaneteDetail_MouseLeave;
            picDataBaz.MouseLeave += btnPlaneteDetail_MouseLeave;
            lblPlanete.MouseLeave += btnPlaneteDetail_MouseLeave;
            lblGravite.MouseLeave += btnPlaneteDetail_MouseLeave;
            lblTemperature.MouseLeave += btnPlaneteDetail_MouseLeave;
        }

        private void btnPlaneteDetail_Click(object sender, EventArgs e)
        {
            // Si une méthode a bien été assignée au delegate
            if (this.afficheur != null)
            {
                //Appel de la méthode stockée dans dans afficheur
                this.afficheur(sender, e);
            }
        }

        public String getNomPlanete()
        {
            return lblPlanete.Text;
        }

        private void btnPlaneteDetail_MouseEnter(object sender, EventArgs e)
        {
            btnPlaneteDetail.BackColor = System.Drawing.Color.SlateBlue;
            picPlanete.BackColor = System.Drawing.Color.SlateBlue;
            picTemperature.BackColor = System.Drawing.Color.SlateBlue;
            picGravite.BackColor = System.Drawing.Color.SlateBlue;
            picDataBaz.BackColor = System.Drawing.Color.SlateBlue;
            lblPlanete.BackColor = System.Drawing.Color.SlateBlue;
            lblGravite.BackColor = System.Drawing.Color.SlateBlue;
            lblTemperature.BackColor = System.Drawing.Color.SlateBlue;
        }

        private void btnPlaneteDetail_MouseLeave(object sender, EventArgs e)
        {
            btnPlaneteDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            picPlanete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            picTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            picGravite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            picDataBaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblPlanete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblGravite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));

        }
    }
}

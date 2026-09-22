using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Form_Sae24_Stargate
{
    public delegate void clicSurMembre(object sender, System.EventArgs e);
    public partial class UserControlCarteMembre : UserControl
    {
        private string matricule = "";
        public clicSurMembre afficheur;

        public UserControlCarteMembre()
        {
            InitializeComponent();

            picPhoto.Click += btnDetail_Click;
            lblNom.Click += btnDetail_Click;

            this.DoubleClick += eventDoubleClick;
            picPhoto.DoubleClick += eventDoubleClick;
            lblNom.DoubleClick += eventDoubleClick;

            picPhoto.MouseEnter += btnDetail_MouseEnter;
            lblNom.MouseEnter += btnDetail_MouseEnter;

            picPhoto.MouseLeave += btnDetail_MouseLeave;
            lblNom.MouseLeave += btnDetail_MouseLeave;
        }

        public void RemplirInfos(string unMatricule, string unNom)
        {
            matricule = unMatricule;

            lblNom.Text = unNom;

            string nomFichierImage = matricule + ".png";

            string cheminImage = System.IO.Path.Combine(Application.StartupPath, "Images", "ImageMetier", nomFichierImage);


            if (System.IO.File.Exists(cheminImage))
            {
                picPhoto.Image = Image.FromFile(cheminImage);
            }
            else
            {
                picPhoto.Image = null;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            // Si une méthode a bien été assignée au delegate
            if (this.afficheur != null)
            {
                //Appel de la méthode stockée dans dans afficheur
                this.afficheur(sender, e);
            }
        }

        private void eventDoubleClick(object sender, EventArgs e)
        {
            FormDetailsMembre fenetreDetails =
                new FormDetailsMembre(matricule);

            fenetreDetails.ShowDialog();
        }

        private void btnDetail_MouseEnter(object sender, EventArgs e)
        {
            this.btnDetail.BackColor = System.Drawing.Color.SlateBlue;
            this.picPhoto.BackColor = System.Drawing.Color.SlateBlue;
            this.lblNom.BackColor = System.Drawing.Color.SlateBlue;
        }

        private void btnDetail_MouseLeave(object sender, EventArgs e)
        {
            this.btnDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.picPhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
        }

        public string getnom()
        {
            return lblNom.Text;
        }
        public string getMatricule()
        {
            return matricule;
        }

    }
}
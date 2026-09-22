using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlExtraterrestres
{
    //delegate sert à créer un type représentant une méthode -> crée un modèle de fonction.
    public delegate void afficherAlienDetail(object sender, EventArgs e);
    public partial class UCTrombinoExtraterrestre: UserControl
    {
        // Création d’une instance du delegate -> crée une variable capable de stocker une méthode
        public afficherAlienDetail afficheur;
        public UCTrombinoExtraterrestre()
        {
            InitializeComponent();
        }
        public UCTrombinoExtraterrestre(String nom, String couleur, String statut, String planete)
        {
            InitializeComponent();

            string cheminImage = System.IO.Path.Combine(Application.StartupPath, "Images", "Extraterrestres", nom + ".png");
            if (System.IO.File.Exists(cheminImage))
            {
                picExtraterrestre.Image = Image.FromFile(cheminImage);
            }
            else
            {
                picExtraterrestre.Image = null; 
            }
            
            lblNomExtraterrestre.Text = nom;
            lblCouleurExtraterrestre.Text = couleur;
            lblStatut.Text = statut;
            lblPlanete.Text = planete;

            picExtraterrestre.Click += btnInfoAlien_Click;
            lblNomExtraterrestre.Click += btnInfoAlien_Click;
            lblCouleurExtraterrestre.Click += btnInfoAlien_Click;
            lblStatut.Click += btnInfoAlien_Click;
            lblPlanete.Click += btnInfoAlien_Click;

            picExtraterrestre.MouseEnter += btnInfoAlien_MouseEnter;
            lblNomExtraterrestre.MouseEnter += btnInfoAlien_MouseEnter;
            lblCouleurExtraterrestre.MouseEnter += btnInfoAlien_MouseEnter;
            lblStatut.MouseEnter += btnInfoAlien_MouseEnter;
            lblPlanete.MouseEnter += btnInfoAlien_MouseEnter;

            picExtraterrestre.MouseLeave += btnInfoAlien_MouseLeave;
            lblNomExtraterrestre.MouseLeave += btnInfoAlien_MouseLeave;
            lblCouleurExtraterrestre.MouseLeave += btnInfoAlien_MouseLeave;
            lblStatut.MouseLeave += btnInfoAlien_MouseLeave;
            lblPlanete.MouseLeave += btnInfoAlien_MouseLeave;
        }

        public String getNomAlien()
        {
            return lblNomExtraterrestre.Text;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UCTrombinoExtraterrestre_Load(object sender, EventArgs e)
        {

        }

        private void btnInfoAlien_Click(object sender, EventArgs e)
        {
            // Si une méthode a bien été assignée au delegate
            if (this.afficheur != null)
            {
                //Appel de la méthode stockée dans dans afficheur
                this.afficheur(sender, e);
            }
        }

        private void btnInfoAlien_MouseEnter(object sender, EventArgs e)
        {
            this.btnInfoAlien.BackColor = System.Drawing.Color.SlateBlue;
            this.lblCouleurExtraterrestre.BackColor = System.Drawing.Color.SlateBlue;
            this.lblNomExtraterrestre.BackColor = System.Drawing.Color.SlateBlue;
            this.lblPlanete.BackColor = System.Drawing.Color.SlateBlue;
            this.lblStatut.BackColor = System.Drawing.Color.SlateBlue;
            this.picExtraterrestre.BackColor = System.Drawing.Color.SlateBlue;
        }

        private void btnInfoAlien_MouseLeave(object sender, EventArgs e)
        {
            this.btnInfoAlien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCouleurExtraterrestre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNomExtraterrestre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblPlanete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblStatut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.picExtraterrestre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlPlaqueMilitaire
{
    public delegate void afficherInfosMembre(object sender, EventArgs e);
    public partial class UCPlaqueMilitaire : UserControl
    {
        public afficherInfosMembre afficheur;
        public UCPlaqueMilitaire()
        {
            InitializeComponent();
            this.Click += Plaque_Click;
            lblNom.Click += Plaque_Click;
            lblPrenom.Click += Plaque_Click;
            lblGrade.Click += Plaque_Click;
            this.BackgroundImage = Properties.Resources.Plaque_militaire;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public string NomMembre
        {
            get => lblNom.Text;
            set => lblNom.Text = value;
        }

        public string PrenomMembre
        {
            get => lblPrenom.Text;
            set => lblPrenom.Text = value;
        }

        public string GradeMembre
        {
            get => lblGrade.Text;
            set => lblGrade.Text = value;
        }

        private void Plaque_Click(object sender, EventArgs e)
        {
            if (this.afficheur != null)
            {
                this.afficheur(sender, e);
            }
        }
        private void UserControlPlaqueMilitaire_Load(object sender, EventArgs e)
        {

        }
    }
}

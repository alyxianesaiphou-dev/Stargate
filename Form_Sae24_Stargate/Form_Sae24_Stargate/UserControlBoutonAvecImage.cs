using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UserControlBoutonAvecImage
{
    //delegate sert à créer un type représentant une méthode -> crée un modèle de fonction.
    public delegate void afficherFonctionnalitéBouton(object sender, EventArgs e);
    public partial class UCBoutonImage: UserControl
    {
        // Création d’une instance du delegate -> crée une variable capable de stocker une méthode
        public afficherFonctionnalitéBouton afficheur;
        public UCBoutonImage()
        {
            InitializeComponent();
        }

        public String texteBouton
        {
            get { return this.lblBouton.Text; }
            set { this.lblBouton.Text = value; }
        }

        public Image imageBouton
        {
            get { return this.picBouton.Image; }
            set { this.picBouton.Image = value; }
        }

        //Evénement lorsqu'on clique sur le bouton complet
        private void btnImage_Click(object sender, EventArgs e)
        {
            // Si une méthode a bien été assignée au delegate
            if (this.afficheur != null) 
            {
                //Appel de la méthode stockée dans dans afficheur
                this.afficheur(sender, e);
            }
        }

        public void changerCouleur()
        {
            this.btnImage.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.lblBouton.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.picBouton.BackColor = System.Drawing.Color.MediumSlateBlue;
        }

        public void retablirCouleur()
        {
            this.btnImage.BackColor = System.Drawing.Color.White;
            this.lblBouton.BackColor = System.Drawing.Color.White;
            this.picBouton.BackColor = System.Drawing.Color.White;
        }
    }
}

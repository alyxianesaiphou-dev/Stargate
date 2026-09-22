using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlExtraterrestresDetail
{
    
    public partial class UCExtraterrestresDetail : UserControl
    {
        
        public UCExtraterrestresDetail()
        {
            InitializeComponent();
        }


        public UCExtraterrestresDetail(String nom, String couleur, String statut, String planete, String premierContact, String instrumentOuArme, String degre)
        {
            InitializeComponent();
            //Récûperer le chemin pour les images sur chaque pc
            string chemin = @"Images\Extraterrestres\" + nom + ".png";
            picAlien.Image = Image.FromFile(chemin);
            lblNomExtraterrestre.Text = nom;
            lblCouleurExtraterrestre.Text = couleur;
            lblStatut.Text = statut;
            lblPlanete.Text = planete;
            String dateFR = "";
            if (premierContact != string.Empty) 
            {
                dateFR = premierContact.Substring(8, 2) + "/" + premierContact.Substring(5, 2) + "/" + premierContact.Substring(0, 4);
            }
            string deg = "Neutre";
            if (statut == "Allié")
            {
                lblFixArmeInstru.Text = "Instrument :";
                deg = "Bienveillance";
                lblPremierContact.Text = dateFR;
                lblArmeouIntrument.Text = instrumentOuArme;
            }
            if (statut == "Ennemi")
            {
                lblFixContact.Visible = false;
                lblPremierContact.Visible = false;
                lblFixArmeInstru.Text = "Arme :";
                deg = "Malveillance";
                lblDegre.Text = "Niveau d'agressivité : ";
                lblPremierContact.Visible = false;
                lblArmeouIntrument.Text = instrumentOuArme;
            }
            if (statut == "Neutre")
            {
                lblFixArmeInstru.Visible = false;
                lblArmeouIntrument.Visible = false;
                lblFixContact.Visible = false;
                lblPremierContact.Visible = false;
            }
            string cheminDegre = @"Images\Extraterrestres\Degre\" + deg + degre + ".png";
            picDegre.Image = Image.FromFile(cheminDegre);
        }

        
    }
}

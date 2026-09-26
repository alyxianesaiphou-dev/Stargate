using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace UserControlMission
{
    //delegate sert à créer un type représentant une méthode -> crée un modèle de fonction.
    public delegate void afficherDetail(object sender, EventArgs e);
    public partial class UCMission : UserControl
    {
        // Création d’une instance du delegate -> crée une variable capable de stocker une méthode
        public afficherDetail afficher;
        private string numero;
        private string planete;
        public UCMission()
        {
            InitializeComponent();
        }

        public String statutMission
        {
            get { return this.lblStatusMission.Text; }
        }
        public String nomMission
        {
            get { return this.lblNomMision.Text; }
        }


        public UCMission(string nomPlanete, string numeroMission, string dateDépart, string dateRetour, string chefDeMission, string Budget)
        {
            InitializeComponent();

            this.planete = nomPlanete;
            this.numero = numeroMission;

            //Récupérer le chemin pour les images sur chaque pc
            string chemin = @"Images\Planetes\" + nomPlanete + ".png";
            picPlanete.Image = Image.FromFile(chemin);
            grpMission.Text = nomPlanete + numeroMission;
            DateTime Depart = Convert.ToDateTime(dateDépart);
            DateTime Retour = Convert.ToDateTime(dateRetour);
            if (DateTime.Now < Depart)
            {
                lblStatusMission.Text = "A venir";
            }
            else if (DateTime.Now < Retour)
            {
                lblStatusMission.Text = "En cours";
            }
            else
            {
                lblStatusMission.Text = "Terminée";
            }

            lblDateDepart.Text = dateDépart.Substring(8, 2) + "/" + dateDépart.Substring(5, 2) + "/" + dateDépart.Substring(0, 4);
            lblDateRetour.Text = dateRetour.Substring(8, 2) + "/" + dateRetour.Substring(5, 2) + "/" + dateRetour.Substring(0, 4);
            lblChefMission.Text = chefDeMission;
            lblBudget.Text = Budget;

        }

        private void btnInfoMission_Click(object sender, EventArgs e)
        {
            // Si une méthode a bien été assignée au delegate
            if (this.afficher != null)
            {
                //Appel de la méthode stockée dans dans afficheur
                this.afficher(sender, e);
            }
        }
<<<<<<< HEAD
=======

>>>>>>> Alex
        public string getNumero()
        {

            return this.numero;
        }

        public string getPlanete()
        {

            return this.planete;
        }
    }
}

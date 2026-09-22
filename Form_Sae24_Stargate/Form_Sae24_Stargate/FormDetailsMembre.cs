using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Form_Sae24_Stargate
{
    public partial class FormDetailsMembre : Form
    {
        private string matricule;

        public FormDetailsMembre(string leMatricule)
        {
            InitializeComponent();
            matricule = leMatricule;
            

            ChargerLesDonneesDuMembre();
        }

        private void ChargerLesDonneesDuMembre()
        {
            string chemin = System.IO.Path.Combine(Application.StartupPath, "Images", "ImageMetier", matricule + ".png");
            picMembre.Image = Image.FromFile(chemin);
            try
            {
                SQLiteConnection maConnexion = new SQLiteConnection(Connexion.Connec.ConnectionString);

                maConnexion.Open();

                // -------------------------
                // MEMBRE
                // -------------------------
                string reqMembre = "SELECT * FROM Membre WHERE matricule = '" + matricule + "'";
                SQLiteCommand cmdMembre = new SQLiteCommand(reqMembre, maConnexion);
                SQLiteDataReader reader = cmdMembre.ExecuteReader();

                if (reader.Read())
                {
                    lblNom.Text = reader["nom"].ToString() + " " + reader["prenom"].ToString();
                    DateTime dateNaissance = Convert.ToDateTime(reader["dateNaissance"]);
                    lblDate.Text = "Né(e) le : " + dateNaissance.ToString("dd/MM/yyyy");
                }
                reader.Close();

                // -------------------------
                // CIVIL
                // -------------------------
                string reqCivil = "SELECT * FROM Civil WHERE matriculeMembre = '" + matricule + "'";
                SQLiteCommand cmdCivil = new SQLiteCommand(reqCivil, maConnexion);
                SQLiteDataReader readerCivil = cmdCivil.ExecuteReader();

                bool estCivil = false;

                if (readerCivil.Read())
                {
                    estCivil = true;

                    lblSpeGrade.Text = "Spécialité : " + readerCivil["Specialite"].ToString();
                    lblOrigine.Text = "Planète d'origine : " + readerCivil["nomPlaneteOrigine"].ToString();
                    lblOrigine.Visible = true;
                }
                readerCivil.Close();

                // -------------------------
                // MILITAIRE
                // -------------------------
                if (!estCivil)
                {
                    string reqMilitaire = "SELECT * FROM Militaire WHERE matriculeMembre = '" + matricule + "'";
                    SQLiteCommand cmdMilitaire = new SQLiteCommand(reqMilitaire, maConnexion);
                    SQLiteDataReader readerMilitaire = cmdMilitaire.ExecuteReader();

                    if (readerMilitaire.Read())
                    {
                        lblSpeGrade.Text = "Grade : " + readerMilitaire["grade"].ToString();
                        lblOrigine.Visible = false;
                    }

                    readerMilitaire.Close();
                }

                // -------------------------
                // MISSIONS
                // -------------------------
                listBoxMissionsEffectuees.Items.Clear();

                string reqMissions =
                    "SELECT * FROM Composer WHERE matriculeMembre = '" + matricule + "'";

                SQLiteCommand cmdMissions = new SQLiteCommand(reqMissions, maConnexion);
                SQLiteDataReader readerMissions = cmdMissions.ExecuteReader();

                bool aDesMissions = false;

                while (readerMissions.Read())
                {
                    aDesMissions = true;

                    string numMission = readerMissions["numeroMission"].ToString();
                    string planete = readerMissions["nomPlanete"].ToString();

                    listBoxMissionsEffectuees.Items.Add("Mission n°" + numMission + " sur " + planete);
                }

                if (!aDesMissions)
                {
                    listBoxMissionsEffectuees.Items.Add("Aucune mission effectuée pour le moment.");
                }

                readerMissions.Close();

                maConnexion.Close();
                maConnexion.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SQL : " + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

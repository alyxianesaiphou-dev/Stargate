using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Form_Sae24_Stargate
{
    public partial class UserControlMissionDetail : UserControl
    {
        private string planeteActuelle = "";
        private int numeroMissionActuelle = 0;
        private DataSet dataSetGlobal;
        public UserControlMissionDetail()
        {
            InitializeComponent();
        }
        public void ChargerMission(int numeroMission, string planete)
        {
            this.planeteActuelle = planete;
            this.numeroMissionActuelle = numeroMission;

            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;


                string reqMission = @"SELECT * FROM Mission
                                    WHERE numero = " + numeroMission + @"
                                    AND nomPlanete = '" + planete + "'";

                SQLiteCommand cmdMission = new SQLiteCommand(reqMission, maConnexion);

                SQLiteDataReader reader = cmdMission.ExecuteReader();

                double budgetInitial = 0;

                if (reader.Read())
                {
                    lblNomMission.Text = "Mission n°" + numeroMission + " - " + planete.ToUpper();

                    lblDateDep.Text = "Date de départ : " + Convert.ToDateTime(reader["dateDepart"]).ToString("dd/MM/yyyy");

                    lblRetour.Text = "Date de retour prévue : " + Convert.ToDateTime(reader["dateRetour"]).ToString("dd/MM/yyyy");

                    lblDatabaz.Text = "Objectif Databaz : " + reader["objectifDatabaz"].ToString() + " tonnes";

                    rtbFeuilleRoute.Text = reader["feuilleDeRoute"].ToString();

                    if (reader["budget"] != DBNull.Value) budgetInitial = Convert.ToDouble(reader["budget"]);
                }

                reader.Close();

                lblBudget.Text = "Budget initial : " + budgetInitial.ToString("F2") + " €";


                double totalDepenses = 0;

                string reqDep = @"SELECT montant FROM Depense
                                WHERE numeroMission = " + numeroMission + @"
                                AND nomPlanete = '" + planete + "'";

                SQLiteCommand cmdDep = new SQLiteCommand(reqDep, maConnexion);
                SQLiteDataReader readerDep = cmdDep.ExecuteReader();

                while (readerDep.Read())
                {
                    if (readerDep["montant"] != DBNull.Value)
                        totalDepenses += Convert.ToDouble(readerDep["montant"]);
                }

                readerDep.Close();

                double budgetRestant = budgetInitial - totalDepenses;

                if (budgetRestant < 200)
                {
                    lblSolde.ForeColor = Color.Red;
                    lblSolde.Text = "Budget restant : " + budgetRestant.ToString("F2") + " € ";
                }
                else
                {
                    lblSolde.ForeColor = Color.SpringGreen;
                    lblSolde.Text = "Budget restant : " + budgetRestant.ToString("F2") + " €";
                }


                string cheminImage = System.IO.Path.Combine(Application.StartupPath,"Images","Planetes",planete + ".png");

                pbPlanete.SizeMode = PictureBoxSizeMode.Zoom;

                if (System.IO.File.Exists(cheminImage))
                {
                    pbPlanete.Image = Image.FromFile(cheminImage);
                }
                else
                {
                    pbPlanete.Image = null;
                }

                AfficherTrombinoEquipe(numeroMission, planete);
                AfficherObjectifs(numeroMission, planete, maConnexion);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SQL : " + ex.Message);
            }
        }


        private void AfficherTrombinoEquipe(int numeroMission, string planete)
        {
            flptrombi.Controls.Clear();
            flptrombi.BackColor = CarteMembre.CouleurTrombinoscope;
            CarteMembre.CentrerColonnes(flptrombi);

            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;

                //le chef est affiché en premier, puis les autres membres par ordre alphabétique
                string requeteSQL = @"SELECT Membre.matricule, Membre.nom, Membre.prenom,
                                            (Membre.matricule = Mission.matriculeChef) AS estChef
                                        FROM Composer
                                        INNER JOIN Membre ON Composer.matriculeMembre = Membre.matricule
                                        INNER JOIN Mission ON Composer.nomPlanete = Mission.nomPlanete
                                            AND Composer.numeroMission = Mission.numero
                                        WHERE Composer.numeroMission = @numero
                                        AND Composer.nomPlanete = @planete
                                        ORDER BY estChef DESC, Membre.nom";

                SQLiteCommand commande = new SQLiteCommand(requeteSQL, maConnexion);
                commande.Parameters.AddWithValue("@numero", numeroMission);
                commande.Parameters.AddWithValue("@planete", planete);

                SQLiteDataReader lecteur = commande.ExecuteReader();

                while (lecteur.Read())
                {
                    string matricule = lecteur["matricule"].ToString();
                    string nom = lecteur["nom"].ToString() + " " + lecteur["prenom"].ToString();
                    bool estChef = Convert.ToInt32(lecteur["estChef"]) == 1;

                    flptrombi.Controls.Add(new CarteMembre(matricule, nom, estChef));
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SQL : " + ex.Message);
            }
        }
        
        private void AfficherObjectifs(int numeroMission, string planete, SQLiteConnection conn)
        {
            groupBox1.Controls.Clear();

            int yPos = 35;

            string req = @"SELECT ObjectifCapture.objectif, ObjectifCapture.idEspeceEnnemi, Espece.nom
                        FROM ObjectifCapture
                        LEFT JOIN Espece ON ObjectifCapture.idEspeceEnnemi = Espece.id
                        WHERE ObjectifCapture.numeroMission = " + numeroMission + @"
                        AND ObjectifCapture.nomPlanete = '" + planete + "'";

            SQLiteCommand cmd = new SQLiteCommand(req, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string espece;

                if (reader["nom"] != DBNull.Value)
                {
                    espece = reader["nom"].ToString();
                }
                else
                {
                    espece = "Espèce inconnue";
                }

                string objectif = reader["objectif"].ToString();

                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.Text = "• " + espece + " : " + objectif;
                lbl.Location = new Point(15, yPos);
                lbl.Font = new Font("Microsoft Sans Serif", 12);

                groupBox1.Controls.Add(lbl);

                yPos += 30;
            }

            reader.Close();
        }

        public void ActiverModeEdition(bool actif)
        {
            btnEditerMission.Visible = actif;
        }


        private void btnEditerMission_Click(object sender, EventArgs e)
        {
            try
            {
                UCEditionMission ucEdition = new UCEditionMission();
                ucEdition.ChargerPourEdition(this.numeroMissionActuelle, this.planeteActuelle);

                //crée une fenêtre vide
                Form fenetreEdition = new Form();

                // prendre la taille exacte du UserControl
                fenetreEdition.ClientSize = ucEdition.Size;
                fenetreEdition.FormBorderStyle = FormBorderStyle.FixedDialog; //empêche de redimensionner
                fenetreEdition.StartPosition = FormStartPosition.CenterScreen; //centre à l'écran
                fenetreEdition.Text = "Édition de la Mission"; //titre de la fenêtre

                fenetreEdition.Controls.Add(ucEdition);
                ucEdition.Location = new Point(0, 0);

                fenetreEdition.ShowDialog();

                this.ChargerMission(this.numeroMissionActuelle, this.planeteActuelle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ouverture de la fenêtre d'édition : " + ex.Message, "Erreur");
            }
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            try
            {
                UCJournalBord ucJournal = new UCJournalBord();
                ucJournal.ChargerJournal(this.numeroMissionActuelle, this.planeteActuelle, MesDatas.DsGlobal);

                //crée une fenêtre vide
                Form fenetreJournal = new Form();

                //prendre la taille exacte du UserControl
                fenetreJournal.ClientSize = ucJournal.Size;
                fenetreJournal.FormBorderStyle = FormBorderStyle.FixedDialog; //empêche de redimensionner
                fenetreJournal.StartPosition = FormStartPosition.CenterScreen; //centre à l'écran
                fenetreJournal.Text = "Journal de bord"; //titre de la fenêtre

                fenetreJournal.Controls.Add(ucJournal);
                ucJournal.Location = new Point(0, 0);


                fenetreJournal.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ouverture du journal : " + ex.Message, "Erreur");
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            Form fenetreParente = this.FindForm();
            if (fenetreParente != null)
            {
                fenetreParente.Close();
            }
        }
    }
}

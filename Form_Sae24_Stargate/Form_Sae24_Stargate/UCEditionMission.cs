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
    public partial class UCEditionMission : UserControl
    {
        private int numeroEnCours;
        private string planeteEnCours;
        private DataSet dataSetGlobal;

        public UCEditionMission()
        {
            InitializeComponent();
        }

        public void ChargerPourEdition(int numero, string planete)
        {
            this.numeroEnCours = numero;
            this.planeteEnCours = planete;

            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;

                //informateur
                SQLiteCommand cmdInf = new SQLiteCommand("SELECT * FROM Informateur", maConnexion);
                SQLiteDataReader readerInf = cmdInf.ExecuteReader();

                DataTable dtInf = new DataTable();
                dtInf.Load(readerInf);

                cmbInformateur.DataSource = dtInf;
                cmbInformateur.DisplayMember = "nom";
                cmbInformateur.ValueMember = "nomCode";
                cmbInformateur.SelectedIndex = -1;

                readerInf.Close();

                //type dépense
                SQLiteCommand cmdType = new SQLiteCommand("SELECT * FROM TypeDepense WHERE id <> 2", maConnexion);
                SQLiteDataReader readerType = cmdType.ExecuteReader();

                DataTable dtType = new DataTable();
                dtType.Load(readerType);

                cmbTypeDepense.DataSource = dtType;
                cmbTypeDepense.DisplayMember = "libelle";
                cmbTypeDepense.ValueMember = "id";
                cmbTypeDepense.SelectedIndex = -1;

                readerType.Close();

                //espèce
                SQLiteCommand cmdEsp = new SQLiteCommand("SELECT * FROM Allie", maConnexion);
                SQLiteDataReader readerEsp = cmdEsp.ExecuteReader();

                DataTable dtEsp = new DataTable();
                dtEsp.Load(readerEsp);

                cmbEspece.DataSource = dtEsp;
                cmbEspece.DisplayMember = "nom";
                cmbEspece.ValueMember = "idEspece";
                cmbEspece.SelectedIndex = -1;

                readerEsp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement combo : " + ex.Message);
            }
        }


        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;

                double sommePayee = Convert.ToDouble(txtSomme.Text);

                if (cmbInformateur.SelectedValue == null)
                {
                    FormSucces.Afficher("Veuillez sélectionner un informateur.", true);
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtSomme.Text))
                {
                    sommePayee = Convert.ToDouble(txtSomme.Text);
                    
                }
                else
                {
                    FormSucces.Afficher("Veuillez écrire une somme.", true);
                    return;
                }

                double budgetRestant = CalculerBudgetRestant();

                if(sommePayee > budgetRestant)
                {
                    FormSucces.Afficher("Fonds insuffisants ! Il ne reste que " + budgetRestant + " €.", true);
                    return;
                }

                //vérifie le doublon
                string reqVerif =
                    @"SELECT COUNT(*)
                    FROM Contact
                    WHERE nomPlanete = @planete
                    AND numeroMission = @mission
                    AND nomCodeInformateur = @code
                    AND dateC = @date";

                SQLiteCommand cmdVerif = new SQLiteCommand(reqVerif, Connexion.Connec);

                cmdVerif.Parameters.AddWithValue("@planete", planeteEnCours);
                cmdVerif.Parameters.AddWithValue("@mission", numeroEnCours);
                cmdVerif.Parameters.AddWithValue("@code", cmbInformateur.SelectedValue.ToString());
                cmdVerif.Parameters.AddWithValue("@date", dtpDateContact.Value.ToString("yyyy-MM-dd"));

                int dejaContacte = Convert.ToInt32(cmdVerif.ExecuteScalar());

                if (dejaContacte > 0)
                {
                    FormSucces.Afficher("Erreur : Cet informateur a déjà été contacté aujourd'hui pour cette mission.",true);

                    return;
                }


                string req = @"INSERT INTO Contact
                            (nomPlanete, numeroMission, dateC, sommeVersee, appreciation, nomCodeInformateur)
                            VALUES
                            (@planete, @mission, @date, @somme, @app, @code)";

                SQLiteCommand cmd = new SQLiteCommand(req, maConnexion);

                cmd.Parameters.AddWithValue("@planete", planeteEnCours);
                cmd.Parameters.AddWithValue("@mission", numeroEnCours);
                cmd.Parameters.AddWithValue("@date", dtpDateContact.Value.Date);
                cmd.Parameters.AddWithValue("@somme", sommePayee);
                cmd.Parameters.AddWithValue("@app", rtxtAppreciation.Text);
                cmd.Parameters.AddWithValue("@code", cmbInformateur.SelectedValue.ToString());

                cmd.ExecuteNonQuery();

                // DEPENSE
                if (sommePayee > 0)
                {
                    int nouvelIdDepense = 1;

                    string reqMax = "SELECT MAX(id) FROM Depense WHERE nomPlanete = @p AND numeroMission = @m";

                    SQLiteCommand cmdMax = new SQLiteCommand(reqMax, Connexion.Connec);

                    cmdMax.Parameters.AddWithValue("@p", planeteEnCours);
                    cmdMax.Parameters.AddWithValue("@m", numeroEnCours);

                    object resultat = cmdMax.ExecuteScalar();

                    if (resultat != null && resultat != DBNull.Value)
                    {
                        nouvelIdDepense = Convert.ToInt32(resultat) + 1;
                    }

                    string reqDep =
                        @"INSERT INTO Depense
                        (nomPlanete, numeroMission, id, dateD, montant, motif, idTypeDepense)
                        VALUES
                        (@p, @m, @id, @d, @montant, @motif, 2)";

                    SQLiteCommand cmdDep = new SQLiteCommand(reqDep, Connexion.Connec);

                    cmdDep.Parameters.AddWithValue("@p", planeteEnCours);
                    cmdDep.Parameters.AddWithValue("@m", numeroEnCours);
                    cmdDep.Parameters.AddWithValue("@id", nouvelIdDepense);
                    cmdDep.Parameters.AddWithValue("@d", dtpDateContact.Value.ToString("yyyy-MM-dd"));
                    cmdDep.Parameters.AddWithValue("@montant", sommePayee);
                    cmdDep.Parameters.AddWithValue("@motif", "Paiement informateur");

                    cmdDep.ExecuteNonQuery();
                }

                //barre chargement
                FormEcranChargement ecranSombre = new FormEcranChargement();
                ecranSombre.ShowDialog(this);

                ViderChampsContact();

                FormSucces.Afficher("Contact enregistré avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }


        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            ViderChampsContact();
        }

        private void btnNvContact_Click(object sender, EventArgs e)
        {
            gpbNvContact.Visible = true;
            gpbNvDepense.Visible = false;
            gpbNvEvenement.Visible = false;
            gpbEspece.Visible = false;
        }

        private void ViderChampsContact()
        {
            cmbInformateur.SelectedIndex = -1;
            dtpDateContact.Value = DateTime.Now;
            txtSomme.Clear();
            rtxtAppreciation.Clear();
        }

        private void btnNvDepense_Click(object sender, EventArgs e)
        {
            gpbNvDepense.Visible = true;
            gpbNvContact.Visible = false;
            gpbNvEvenement.Visible = false;
            gpbEspece.Visible = false;

        }

        private void btnValiderDepense_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                double sommePayee = Convert.ToDouble(txtMontantDepense.Text);

                if (cmbTypeDepense.SelectedValue == null)
                {
                    FormSucces.Afficher("Veuillez sélectionner un type.", true);
                    return;
                }
                double budgetRestant = CalculerBudgetRestant();

                if(sommePayee > budgetRestant)
                {
                    FormSucces.Afficher("Fonds insuffisants ! Il ne reste que " + budgetRestant + " €.", true);
                    return;
                }

                if ( !string.IsNullOrWhiteSpace(rtxtMotifDepense.Text))
                {
                    FormSucces.Afficher("Veuillez écrire un motif pour la dépense");
                    return;
                }

                string req = @"INSERT INTO Depense
                                (nomPlanete, numeroMission, dateD, montant, motif, idTypeDepense)
                                VALUES
                                (@p, @m, @d, @montant, @motif, @type)";

                SQLiteCommand cmd = new SQLiteCommand(req, maConnexion);

                cmd.Parameters.AddWithValue("@p", planeteEnCours);
                cmd.Parameters.AddWithValue("@m", numeroEnCours);
                cmd.Parameters.AddWithValue("@d", dtpDateDepense.Value.Date);
                cmd.Parameters.AddWithValue("@montant",
                    string.IsNullOrWhiteSpace(txtMontantDepense.Text) ? 0 : Convert.ToDouble(txtMontantDepense.Text));

                cmd.Parameters.AddWithValue("@motif", rtxtMotifDepense.Text);
                cmd.Parameters.AddWithValue("@type", cmbTypeDepense.SelectedValue);

                cmd.ExecuteNonQuery();

                // NEGOCIATION
                if (Convert.ToInt32(cmbTypeDepense.SelectedValue) == 1)
                {
                    string reqNego = @"INSERT INTO Negocier
                                        (nomPlanete, numeroMission, idEspeceAllie, qteDataBaz)
                                        VALUES
                                        (@p, @m, @esp, @qte)";

                    SQLiteCommand cmdNego = new SQLiteCommand(reqNego, maConnexion);

                    cmdNego.Parameters.AddWithValue("@p", planeteEnCours);
                    cmdNego.Parameters.AddWithValue("@m", numeroEnCours);
                    cmdNego.Parameters.AddWithValue("@esp", cmbEspeceAlliee.SelectedValue);
                    cmdNego.Parameters.AddWithValue("@qte", txtQuantite.Text);

                    cmdNego.ExecuteNonQuery();
                }

                FormEcranChargement ecranSombre = new FormEcranChargement();
                ecranSombre.ShowDialog(this);

                ViderChampsDepense();
                
                FormSucces.Afficher("Contact enregistré avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur dépense : " + ex.Message);
            }
        }

        private void btnAnnulerDepense_Click(object sender, EventArgs e)
        {
            ViderChampsDepense();
        }

        private void ViderChampsDepense()
        {
            cmbTypeDepense.SelectedIndex = -1;
            dtpDateDepense.Value = DateTime.Now;
            txtMontantDepense.Clear();
            rtxtMotifDepense.Clear();
        }

        private void btnNvEvenement_Click(object sender, EventArgs e)
        {
            gpbNvDepense.Visible = false;
            gpbNvContact.Visible = false;
            gpbNvEvenement.Visible = true;
            gpbEspece.Visible = false;
        }

        private void btnValiderEvenement_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                string req = @"INSERT INTO JournalDeBord
                            (nomPlanete, numero, dateJ, commentaires)
                            VALUES
                            (@p, @m, @d, @c)";

                SQLiteCommand cmd = new SQLiteCommand(req, maConnexion);

                cmd.Parameters.AddWithValue("@p", planeteEnCours);
                cmd.Parameters.AddWithValue("@m", numeroEnCours);
                cmd.Parameters.AddWithValue("@d", dtpDateEvenement.Value.Date);
                cmd.Parameters.AddWithValue("@c", rtxtCommentaireEvenement.Text);

                cmd.ExecuteNonQuery();

                //barre chargement
                FormEcranChargement ecranSombre = new FormEcranChargement();
                ecranSombre.ShowDialog(this);

                ViderChampsEven();

                FormSucces.Afficher("Contact enregistré avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur journal : " + ex.Message);
            }
        }

        private void btnAnnulerEvenement_Click(object sender, EventArgs e)
        {
            ViderChampsEven();
        }
        private void ViderChampsEven()
        {
            dtpDateEvenement.Value = DateTime.Now;
            rtxtCommentaireEvenement.Clear();
        }

        private void cmbTypeDepense_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSelectionne;
            if (cmbTypeDepense.SelectedValue != null && int.TryParse(cmbTypeDepense.SelectedValue.ToString(), out idSelectionne))
            {
                // afficher le dataBaz
                if (idSelectionne == 1)
                {
                    lblQuantite.Visible = true;
                    txtQuantite.Visible = true;
                    lblEspece.Visible = true;
                    cmbEspeceAlliee.Visible = true;
                }
                else
                {
                    lblQuantite.Visible = false;
                    txtQuantite.Visible = false;
                    lblEspece.Visible = false;
                    cmbEspeceAlliee.Visible = false;
                    txtQuantite.Clear();
                    cmbEspeceAlliee.SelectedIndex = -1;

                }
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

        private void btnCapture_Click(object sender, EventArgs e)
        {
            gpbNvContact.Visible = false;
            gpbNvDepense.Visible = false;
            gpbNvEvenement.Visible = false;
            gpbEspece.Visible = true;
        }

        private void btnValiderCapture_Click(object sender, EventArgs e)
        {
            try
            {
                //vérifie que l'utilisateur a mis plus que 0
                if (cmbEspece.SelectedValue == null || nudNombreCapture.Value <= 0)
                {
                    FormSucces.Afficher("Veuillez sélectionner une espèce et un nombre supérieur à 0.", true);
                    return; 
                }

                SQLiteConnection maConnexion = Connexion.Connec;
                string req = @" INSERT INTO Capturer
                            (numeroMission, nomPlanete, idEspeceEnnemi, nombre)
                            VALUES
                            (@m, @p, @e, @n)";

                SQLiteCommand cmd = new SQLiteCommand(req, maConnexion);

                cmd.Parameters.AddWithValue("@m", numeroEnCours);
                cmd.Parameters.AddWithValue("@p", planeteEnCours);
                cmd.Parameters.AddWithValue("@e", cmbEspece.SelectedValue);
                cmd.Parameters.AddWithValue("@n", (int)nudNombreCapture.Value);

                cmd.ExecuteNonQuery();

                //barre chargement
                FormEcranChargement ecranSombre = new FormEcranChargement();
                ecranSombre.ShowDialog(this);

                ViderChampsCapture();

                FormSucces.Afficher("Contact enregistré avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur capture : " + ex.Message);
            }
        }

        private void btnAnnulerCapture_Click(object sender, EventArgs e)
        {
            ViderChampsCapture();
        }

        private void ViderChampsCapture()
        {
            cmbEspece.SelectedIndex = -1;
            nudNombreCapture.Value = 0;
        }


        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private double CalculerBudgetRestant()
        {
            try
            {
                string requeteSQL = @"SELECT
                                        Mission.budget - IFNULL(SUM(Depense.montant), 0)
                                    FROM Mission
                                    LEFT JOIN Depense
                                        ON Mission.numero = Depense.numeroMission
                                        AND Mission.nomPlanete = Depense.nomPlanete
                                    WHERE Mission.numero = @numero
                                        AND Mission.nomPlanete = @planete";

                SQLiteCommand commande = new SQLiteCommand(requeteSQL, Connexion.Connec);

                commande.Parameters.AddWithValue("@numero", this.numeroEnCours);
                commande.Parameters.AddWithValue("@planete", this.planeteEnCours);

                object resultat = commande.ExecuteScalar();

                if (resultat != null && resultat != DBNull.Value)
                {
                    return Convert.ToDouble(resultat);
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du calcul du budget restant : " + ex.Message);

                return 0;
            }
        }
    }
}

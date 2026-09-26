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

                //type depense
                SQLiteCommand cmdType = new SQLiteCommand("SELECT * FROM TypeDepense WHERE id <> 2", maConnexion);
                SQLiteDataReader readerType = cmdType.ExecuteReader();

                DataTable dtType = new DataTable();
                dtType.Load(readerType);

                cmbTypeDepense.DataSource = dtType;
                cmbTypeDepense.DisplayMember = "libelle";
                cmbTypeDepense.ValueMember = "id";
                cmbTypeDepense.SelectedIndex = -1;

                readerType.Close();

                //espece ennemie (captures)
                SQLiteCommand cmdEsp = new SQLiteCommand(
                    @"SELECT Ennemi.idEspece, Espece.nom
                      FROM Ennemi JOIN Espece ON Espece.id = Ennemi.idEspece
                      ORDER BY Espece.nom", maConnexion);
                SQLiteDataReader readerEsp = cmdEsp.ExecuteReader();

                DataTable dtEsp = new DataTable();
                dtEsp.Load(readerEsp);

                cmbEspece.DataSource = dtEsp;
                cmbEspece.DisplayMember = "nom";
                cmbEspece.ValueMember = "idEspece";
                cmbEspece.SelectedIndex = -1;

                readerEsp.Close();

                //espece alliee (achat de DataBaz)
                SQLiteCommand cmdAllie = new SQLiteCommand(
                    @"SELECT Allie.idEspece, Espece.nom
                      FROM Allie JOIN Espece ON Espece.id = Allie.idEspece
                      ORDER BY Espece.nom", maConnexion);
                SQLiteDataReader readerAllie = cmdAllie.ExecuteReader();

                DataTable dtAllie = new DataTable();
                dtAllie.Load(readerAllie);

                cmbEspeceAlliee.DataSource = dtAllie;
                cmbEspeceAlliee.DisplayMember = "nom";
                cmbEspeceAlliee.ValueMember = "idEspece";
                cmbEspeceAlliee.SelectedIndex = -1;

                readerAllie.Close();
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

                if (cmbInformateur.SelectedValue == null)
                {
                    FormSucces.Afficher("Veuillez sélectionner un informateur.", true);
                    return;
                }

                double sommePayee;
                if (string.IsNullOrWhiteSpace(txtSomme.Text))
                {
                    FormSucces.Afficher("Veuillez écrire une somme.", true);
                    return;
                }
                if (!double.TryParse(txtSomme.Text, out sommePayee) || sommePayee < 0)
                {
                    FormSucces.Afficher("Veuillez écrire une somme valide.", true);
                    return;
                }

                string dateContact = dtpDateContact.Value.ToString("yyyy-MM-dd");
                string codeInformateur = cmbInformateur.SelectedValue.ToString();

                //un seul contact par jour et par mission (clé de la table Contact) :
                //s'il existe déjà, on le met à jour au lieu d'en créer un nouveau
                string reqExiste =
                    @"SELECT sommeVersee
                    FROM Contact
                    WHERE nomPlanete = @planete
                    AND numeroMission = @mission
                    AND date(dateC) = @date";

                SQLiteCommand cmdExiste = new SQLiteCommand(reqExiste, maConnexion);

                cmdExiste.Parameters.AddWithValue("@planete", planeteEnCours);
                cmdExiste.Parameters.AddWithValue("@mission", numeroEnCours);
                cmdExiste.Parameters.AddWithValue("@date", dateContact);

                object ancienneValeur = cmdExiste.ExecuteScalar();
                bool contactExiste = ancienneValeur != null;
                double ancienneSomme = (ancienneValeur == null || ancienneValeur == DBNull.Value) ? 0 : Convert.ToDouble(ancienneValeur);

                //la somme déjà versée pour ce contact est rendue au budget avant de vérifier
                double budgetRestant = CalculerBudgetRestant() + ancienneSomme;

                if (sommePayee > budgetRestant)
                {
                    FormSucces.Afficher("Fonds insuffisants ! Il ne reste que " + budgetRestant + " €.", true);
                    return;
                }

                SQLiteTransaction maTransaction = maConnexion.BeginTransaction();

                try
                {
                    string req;
                    if (contactExiste)
                    {
                        req = @"UPDATE Contact
                            SET dateC = @date, sommeVersee = @somme, appreciation = @app, nomCodeInformateur = @code
                            WHERE nomPlanete = @planete
                            AND numeroMission = @mission
                            AND date(dateC) = @date";
                    }
                    else
                    {
                        req = @"INSERT INTO Contact
                            (nomPlanete, numeroMission, dateC, sommeVersee, appreciation, nomCodeInformateur)
                            VALUES
                            (@planete, @mission, @date, @somme, @app, @code)";
                    }

                    SQLiteCommand cmd = new SQLiteCommand(req, maConnexion, maTransaction);

                    cmd.Parameters.AddWithValue("@planete", planeteEnCours);
                    cmd.Parameters.AddWithValue("@mission", numeroEnCours);
                    cmd.Parameters.AddWithValue("@date", dateContact);
                    cmd.Parameters.AddWithValue("@somme", sommePayee);
                    cmd.Parameters.AddWithValue("@app", rtxtAppreciation.Text);
                    cmd.Parameters.AddWithValue("@code", codeInformateur);

                    cmd.ExecuteNonQuery();

                    // DEPENSE liée au paiement de l'informateur (type 2)
                    string reqDepExiste =
                        @"SELECT rowid FROM Depense
                        WHERE nomPlanete = @p AND numeroMission = @m
                        AND idTypeDepense = 2 AND date(dateD) = @d
                        LIMIT 1";

                    SQLiteCommand cmdDepExiste = new SQLiteCommand(reqDepExiste, maConnexion, maTransaction);

                    cmdDepExiste.Parameters.AddWithValue("@p", planeteEnCours);
                    cmdDepExiste.Parameters.AddWithValue("@m", numeroEnCours);
                    cmdDepExiste.Parameters.AddWithValue("@d", dateContact);

                    object rowidDepense = cmdDepExiste.ExecuteScalar();

                    if (rowidDepense != null && rowidDepense != DBNull.Value)
                    {
                        string reqDep = sommePayee > 0
                            ? "UPDATE Depense SET montant = @montant WHERE rowid = @rowid"
                            : "DELETE FROM Depense WHERE rowid = @rowid";

                        SQLiteCommand cmdDep = new SQLiteCommand(reqDep, maConnexion, maTransaction);

                        cmdDep.Parameters.AddWithValue("@montant", sommePayee);
                        cmdDep.Parameters.AddWithValue("@rowid", rowidDepense);

                        cmdDep.ExecuteNonQuery();
                    }
                    else if (sommePayee > 0)
                    {
                        string reqDep =
                            @"INSERT INTO Depense
                            (nomPlanete, numeroMission, id, dateD, montant, motif, idTypeDepense)
                            VALUES
                            (@p, @m, @id, @d, @montant, @motif, 2)";

                        SQLiteCommand cmdDep = new SQLiteCommand(reqDep, maConnexion, maTransaction);

                        cmdDep.Parameters.AddWithValue("@p", planeteEnCours);
                        cmdDep.Parameters.AddWithValue("@m", numeroEnCours);
                        cmdDep.Parameters.AddWithValue("@id", ProchainIdDepense(maTransaction));
                        cmdDep.Parameters.AddWithValue("@d", dateContact);
                        cmdDep.Parameters.AddWithValue("@montant", sommePayee);
                        cmdDep.Parameters.AddWithValue("@motif", "Paiement informateur");

                        cmdDep.ExecuteNonQuery();
                    }

                    maTransaction.Commit();
                }
                catch
                {
                    maTransaction.Rollback();
                    throw;
                }

                MesDatas.RechargerTables("Contact", "Depense");

                //barre chargement
                FormEcranChargement ecranSombre = new FormEcranChargement();
                ecranSombre.ShowDialog(this);

                ViderChampsContact();

                FormSucces.Afficher(contactExiste ? "Contact mis à jour avec succès !" : "Contact enregistré avec succès !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        /// <summary>
        /// Renvoie le prochain numéro de dépense libre pour la mission en cours
        /// </summary>
        private int ProchainIdDepense(SQLiteTransaction maTransaction)
        {
            string reqMax = "SELECT MAX(id) FROM Depense WHERE nomPlanete = @p AND numeroMission = @m";

            SQLiteCommand cmdMax = new SQLiteCommand(reqMax, Connexion.Connec, maTransaction);

            cmdMax.Parameters.AddWithValue("@p", planeteEnCours);
            cmdMax.Parameters.AddWithValue("@m", numeroEnCours);

            object resultat = cmdMax.ExecuteScalar();

            if (resultat != null && resultat != DBNull.Value)
            {
                return Convert.ToInt32(resultat) + 1;
            }

            return 1;
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

                if (cmbTypeDepense.SelectedValue == null)
                {
                    FormSucces.Afficher("Veuillez sélectionner un type.", true);
                    return;
                }

                double sommePayee;
                if (!double.TryParse(txtMontantDepense.Text, out sommePayee) || sommePayee <= 0)
                {
                    FormSucces.Afficher("Veuillez écrire un montant valide.", true);
                    return;
                }

                if (string.IsNullOrWhiteSpace(rtxtMotifDepense.Text))
                {
                    FormSucces.Afficher("Veuillez écrire un motif pour la dépense.", true);
                    return;
                }

                bool achatDataBaz = Convert.ToInt32(cmbTypeDepense.SelectedValue) == 1;
                int quantiteDataBaz = 0;

                if (achatDataBaz)
                {
                    if (cmbEspeceAlliee.SelectedValue == null)
                    {
                        FormSucces.Afficher("Veuillez sélectionner l'espèce alliée.", true);
                        return;
                    }
                    if (!int.TryParse(txtQuantite.Text, out quantiteDataBaz) || quantiteDataBaz <= 0)
                    {
                        FormSucces.Afficher("Veuillez écrire une quantité de DataBaz valide (nombre entier).", true);
                        return;
                    }
                }

                double budgetRestant = CalculerBudgetRestant();

                if (sommePayee > budgetRestant)
                {
                    FormSucces.Afficher("Fonds insuffisants ! Il ne reste que " + budgetRestant + " €.", true);
                    return;
                }

                SQLiteTransaction maTransaction = maConnexion.BeginTransaction();

                try
                {
                    string req = @"INSERT INTO Depense
                                    (nomPlanete, numeroMission, id, dateD, montant, motif, idTypeDepense)
                                    VALUES
                                    (@p, @m, @id, @d, @montant, @motif, @type)";

                    SQLiteCommand cmd = new SQLiteCommand(req, maConnexion, maTransaction);

                    cmd.Parameters.AddWithValue("@p", planeteEnCours);
                    cmd.Parameters.AddWithValue("@m", numeroEnCours);
                    cmd.Parameters.AddWithValue("@id", ProchainIdDepense(maTransaction));
                    cmd.Parameters.AddWithValue("@d", dtpDateDepense.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@montant", sommePayee);
                    cmd.Parameters.AddWithValue("@motif", rtxtMotifDepense.Text);
                    cmd.Parameters.AddWithValue("@type", cmbTypeDepense.SelectedValue);

                    cmd.ExecuteNonQuery();

                    // NEGOCIATION : un nouvel achat au même allié s'ajoute à la quantité déjà achetée
                    if (achatDataBaz)
                    {
                        string reqNego = @"INSERT INTO Negocier
                                            (nomPlanete, numeroMission, idEspeceAllie, qteDataBaz)
                                            VALUES
                                            (@p, @m, @esp, @qte)
                                            ON CONFLICT(nomPlanete, numeroMission, idEspeceAllie)
                                            DO UPDATE SET qteDataBaz = qteDataBaz + excluded.qteDataBaz";

                        SQLiteCommand cmdNego = new SQLiteCommand(reqNego, maConnexion, maTransaction);

                        cmdNego.Parameters.AddWithValue("@p", planeteEnCours);
                        cmdNego.Parameters.AddWithValue("@m", numeroEnCours);
                        cmdNego.Parameters.AddWithValue("@esp", cmbEspeceAlliee.SelectedValue);
                        cmdNego.Parameters.AddWithValue("@qte", quantiteDataBaz);

                        cmdNego.ExecuteNonQuery();
                    }

                    maTransaction.Commit();
                }
                catch
                {
                    maTransaction.Rollback();
                    throw;
                }

                MesDatas.RechargerTables("Depense", "Negocier");

                FormEcranChargement ecranSombre = new FormEcranChargement();
                ecranSombre.ShowDialog(this);

                ViderChampsDepense();
                
                FormSucces.Afficher("Dépense enregistrée avec succès !");
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
            txtQuantite.Clear();
            cmbEspeceAlliee.SelectedIndex = -1;
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
                if (string.IsNullOrWhiteSpace(rtxtCommentaireEvenement.Text))
                {
                    FormSucces.Afficher("Veuillez écrire un commentaire pour l'événement.", true);
                    return;
                }

                SQLiteConnection maConnexion = Connexion.Connec;
                string req = @"INSERT INTO JournalDeBord
                            (nomPlanete, numero, dateJ, commentaires)
                            VALUES
                            (@p, @m, @d, @c)";

                SQLiteCommand cmd = new SQLiteCommand(req, maConnexion);

                //l'heure est gardée pour pouvoir noter plusieurs événements le même jour
                DateTime dateEvenement = dtpDateEvenement.Value.Date + DateTime.Now.TimeOfDay;

                cmd.Parameters.AddWithValue("@p", planeteEnCours);
                cmd.Parameters.AddWithValue("@m", numeroEnCours);
                cmd.Parameters.AddWithValue("@d", dateEvenement.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@c", rtxtCommentaireEvenement.Text);

                cmd.ExecuteNonQuery();

                MesDatas.RechargerTables("JournalDeBord");

                //barre chargement
                FormEcranChargement ecranSombre = new FormEcranChargement();
                ecranSombre.ShowDialog(this);

                ViderChampsEven();

                FormSucces.Afficher("Événement enregistré avec succès !");
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
                //verifie que l'utilisateur a mis plus que 0
                if (cmbEspece.SelectedValue == null || nudNombreCapture.Value <= 0)
                {
                    FormSucces.Afficher("Veuillez sélectionner une espèce et un nombre supérieur à 0.", true);
                    return; 
                }

                SQLiteConnection maConnexion = Connexion.Connec;
                string req = @" INSERT INTO Capturer
                            (numeroMission, nomPlanete, idEspeceEnnemi, nombre)
                            VALUES
                            (@m, @p, @e, @n)
                            ON CONFLICT(nomPlanete, numeroMission, idEspeceEnnemi)
                            DO UPDATE SET nombre = nombre + excluded.nombre";

                SQLiteCommand cmd = new SQLiteCommand(req, maConnexion);

                cmd.Parameters.AddWithValue("@m", numeroEnCours);
                cmd.Parameters.AddWithValue("@p", planeteEnCours);
                cmd.Parameters.AddWithValue("@e", cmbEspece.SelectedValue);
                cmd.Parameters.AddWithValue("@n", (int)nudNombreCapture.Value);

                cmd.ExecuteNonQuery();

                MesDatas.RechargerTables("Capturer");

                //barre chargement
                FormEcranChargement ecranSombre = new FormEcranChargement();
                ecranSombre.ShowDialog(this);

                ViderChampsCapture();

                FormSucces.Afficher("Capture enregistrée avec succès !");
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlTrombinoPlanete;
using System.Data.SQLite;

namespace Form_Sae24_Stargate
{
    public partial class FormSaisieNouvelleMission : Form
    {
        private int nbMembre = 0;
        private UserControlCarteMembre chefSelectionne = null;
        private UCTrombPlanete planeteSelectionnee = null;
        private List<UserControlCarteMembre> membresSelectionnes = new List<UserControlCarteMembre>();
        
        private Dictionary<UserControlExtraterrestres.UCTrombinoExtraterrestre, int> capturesSelectionnees = new Dictionary<UserControlExtraterrestres.UCTrombinoExtraterrestre, int>();

        
        private UserControlExtraterrestres.UCTrombinoExtraterrestre alienEnCoursDeSaisie = null;

        
        private Panel pnlSaisieQuantite;
        private Label lblSaisieQuantite;
        private TextBox txtSaisieQuantite; private UserControlExtraterrestres.UCTrombinoExtraterrestre alienSelectionne = null;
        public FormSaisieNouvelleMission()
        {
            InitializeComponent();

            gpbChoixPlanete.Visible = true;

            dtpDebut.MinDate = System.DateTime.Today;
            dtpFin.MinDate = System.DateTime.Today;

            numNbMembre.Minimum = 1;

            ChargerPlanetes();
            InitialiserPopupCapture();

        }
    
        private void passserEtape1a2(UCTrombPlanete planetChoisie)
        {
            
            lblPlanete.Text = "Planète : " + planetChoisie.getNomPlanete();
            lblPlanete.Visible = true;

            gpbChoixPlanete.Visible = false;
            gpbChoixChef.Visible = true;
            gpbChoixParametresMission.Visible = false;
            gpbChoixMembreMission.Visible = false;
            grbChoixCaptures.Visible = false;

            flpChef.Visible = false;
        }

        private void passserEtape2a1(object sender, EventArgs e)
        {
            gpbChoixPlanete.Visible = true;
            gpbChoixChef.Visible = false;
            gpbChoixParametresMission.Visible = false;
            gpbChoixMembreMission.Visible = false;
            grbChoixCaptures.Visible = false;

            lblPlanete.Text = "Planète : ";
            
        }

        private void passserEtape2a3(UserControlCarteMembre membreChoisis)
        {

            //numNbMembre.Maximum = 10;

            gpbChoixPlanete.Visible = false;
            gpbChoixChef.Visible = false;
            gpbChoixParametresMission.Visible = true;
            gpbChoixMembreMission.Visible = false;
            grbChoixCaptures.Visible = false;


            lblChef.Text = "Chef de mission : " + membreChoisis.getnom();
            lblDateDebut.Text = "Départ : " + dtpDebut.Value.ToShortDateString();
            lblDateFin.Text = "Retour : " + dtpFin.Value.ToShortDateString();

            lblChef.Visible = true;
            lblDateDebut.Visible = true;
            lblDateFin.Visible = true;

        }

        private void passserEtape3a2(object sender, EventArgs e)
        {

            gpbChoixPlanete.Visible = false;
            gpbChoixChef.Visible = true;
            gpbChoixParametresMission.Visible = false;
            gpbChoixMembreMission.Visible = false;
            grbChoixCaptures.Visible = false;


            lblChef.Text = "Chef de mission : ";
            lblDateDebut.Text = "Date de début : ";
            lblDateFin.Text = "Date de fin : ";
            
        }
        private void passserEtape3a4(object sender, EventArgs e)
        {

            gpbChoixPlanete.Visible = false;
            gpbChoixChef.Visible = false;
            gpbChoixParametresMission.Visible = false;
            gpbChoixMembreMission.Visible = true;
            grbChoixCaptures.Visible = false;


            lblBudget.Text = "Budget : " + numBudget.Value.ToString() + " €";
            txtFeuilleRoute.Text = txtSaisieFeuilleRoute.Text;
            lblObjectifDataBaz.Text = "Objectif DataBaz : " + numObjDataBaz.Value.ToString() + " tonnes";
            nbMembre = ((int)numNbMembre.Value);

            lblBudget.Visible = true;
            lblFeuilleRoute.Visible = true;
            txtFeuilleRoute.Visible = true;
            lblObjectifDataBaz.Visible = true;

            ChargerCivilsDisponibles(dtpDebut.Value, dtpFin.Value);
        }

        private void passserEtape4a3(object sender, EventArgs e)
        {

            gpbChoixPlanete.Visible = false;
            gpbChoixChef.Visible = false;
            gpbChoixParametresMission.Visible = true;
            gpbChoixMembreMission.Visible = false;
            grbChoixCaptures.Visible = false;


            lblBudget.Text = "Budget : ";
            txtFeuilleRoute.Clear();
            lblObjectifDataBaz.Text = "Objectif DataBaz : ";
            nbMembre = 0;
        }

        private void passserEtape4a5(object sender, EventArgs e)
        {

            gpbChoixPlanete.Visible = false;
            gpbChoixChef.Visible = false;
            gpbChoixParametresMission.Visible = false;
            gpbChoixMembreMission.Visible = false;
            grbChoixCaptures.Visible = true;

            lbbMembreMission.Visible = true;
            listViewMembre.Visible = true;
            listViewMembre.Items.Clear();

            if (chefSelectionne != null)
            {
                listViewMembre.Items.Add(chefSelectionne.getnom() + " (Chef)");
            }
            foreach (Form_Sae24_Stargate.UserControlCarteMembre civil in membresSelectionnes)
            {
                listViewMembre.Items.Add(civil.getnom());
            }

            
            ChargerAliensPlanete(planeteSelectionnee.getNomPlanete());
        }
        private void passserEtape5a4(object sender, EventArgs e)
        {

            gpbChoixPlanete.Visible = false;
            gpbChoixChef.Visible = false;
            gpbChoixParametresMission.Visible = false;
            gpbChoixMembreMission.Visible = true;
            grbChoixCaptures.Visible = false;


            listViewMembre.Items.Clear();
        }


        private void ChargerPlanetes()
        {
            flpChoixPlanete.Controls.Clear();

            try
            {
                string requeteSQL = "SELECT * FROM Planete";

                SQLiteCommand commande = new SQLiteCommand(requeteSQL, Connexion.Connec);

                SQLiteDataReader lecteur = commande.ExecuteReader();

                while (lecteur.Read())
                {
                    string nomPlanete = lecteur["nom"].ToString();

                    string temperature;
                    if (lecteur["temperature"] != DBNull.Value)
                    {
                        temperature = lecteur["temperature"].ToString();
                    }
                    else
                    {
                        temperature = "?";
                    }

                    string gravite;
                    if (lecteur["gravite"] != DBNull.Value)
                    {
                        gravite = lecteur["gravite"].ToString();
                    }
                    else
                    {
                        gravite = "?";
                    }

                    string dataBaz;
                    if (lecteur["dataBazON"] != DBNull.Value)
                    {
                        dataBaz = lecteur["dataBazON"].ToString();
                    }
                    else
                    {
                        dataBaz = "?";
                    }

                    UCTrombPlanete planete = new UCTrombPlanete(nomPlanete, temperature, gravite, dataBaz);

                    planete.afficheur = ClicSurUnePlanete;

                    flpChoixPlanete.Controls.Add(planete);
                }
                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SQL : " + ex);
            }
        }
        private void ClicSurUnePlanete(object sender, EventArgs e)
        {

            Control btn = (Control)sender;

            UCTrombPlanete planeteChoisie = btn as UCTrombPlanete;
            if (planeteChoisie == null)
            {
                planeteChoisie = (UCTrombPlanete)btn.Parent;
            }

            if (planeteSelectionnee == planeteChoisie)
            {
                planeteChoisie.BackColor = Color.Transparent;
                planeteSelectionnee = null;
                return;
            }

            foreach (Control ctrl in flpChoixPlanete.Controls)
            {
                if (ctrl is UCTrombPlanete)
                {
                    ctrl.BackColor = SystemColors.Control;
                }
            }
            planeteChoisie.BackColor = Color.Pink;

            planeteSelectionnee = planeteChoisie;
        }

        private void ChargerMilitairesDisponibles(DateTime dateDebut, DateTime dateFin)
        {
            flpChef.Controls.Clear();

            try
            {
                string requeteSQL = @" SELECT Membre.matricule, Membre.nom
                                    FROM Membre
                                    INNER JOIN Militaire
                                    ON Membre.matricule = Militaire.matriculeMembre
                                    WHERE Membre.matricule NOT IN
                                    (
                                        SELECT matriculeChef
                                        FROM Mission
                                        WHERE dateDepart <= @dateFin
                                        AND dateRetour >= @dateDebut
                                        AND matriculeChef IS NOT NULL
                                    )";

                SQLiteCommand commande = new SQLiteCommand(requeteSQL, Connexion.Connec);

                commande.Parameters.AddWithValue("@dateDebut", dateDebut.ToString("yyyy-MM-dd"));

                commande.Parameters.AddWithValue("@dateFin", dateFin.ToString("yyyy-MM-dd"));

                SQLiteDataReader lecteur = commande.ExecuteReader();

                while (lecteur.Read())
                {
                    string matricule = lecteur["matricule"].ToString();
                    string nom = lecteur["nom"].ToString();

                    UserControlCarteMembre carte = new UserControlCarteMembre();

                    carte.RemplirInfos(matricule, nom);

                    carte.afficheur = ClicSurUneMilitaire;

                    flpChef.Controls.Add(carte);
                }

                lecteur.Close();

                string reqTotalDispo = @"SELECT COUNT(*) FROM Membre 
                                         WHERE matricule NOT IN (
                                            SELECT matriculeMembre FROM Composer 
                                            INNER JOIN Mission ON Composer.numeroMission = Mission.numero
                                            WHERE Mission.dateDepart <= @dateFin 
                                            AND Mission.dateRetour >= @dateDebut
                                         )";

                SQLiteCommand cmdTotal = new SQLiteCommand(reqTotalDispo, Connexion.Connec);
                cmdTotal.Parameters.AddWithValue("@dateDebut", dateDebut.ToString("yyyy-MM-dd"));
                cmdTotal.Parameters.AddWithValue("@dateFin", dateFin.ToString("yyyy-MM-dd"));

                int vraiTotalDispo = Convert.ToInt32(cmdTotal.ExecuteScalar());

                if (vraiTotalDispo >= 2) 
                {
                    numNbMembre.Maximum = vraiTotalDispo;
                }
                else
                {
                    numNbMembre.Maximum = 1;
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SQL lors du chargement des militaires disponibles : " + ex);
            }
        }

        private void ClicSurUneMilitaire(object sender, EventArgs e)
        {
            Control declencheur = (Control)sender;
            UserControlCarteMembre membreChoisi = declencheur as UserControlCarteMembre;
            if (membreChoisi == null)
            {
                membreChoisi = (UserControlCarteMembre)declencheur.Parent;
            }

            if (chefSelectionne == membreChoisi)
            {
                membreChoisi.BackColor = Color.Transparent;
                chefSelectionne = null;
                return;
            }


            foreach (Control ctrl in flpChef.Controls)
            {
                if (ctrl is UserControlCarteMembre)
                {
                    ctrl.BackColor = SystemColors.Control; 
                }
            }
            
            membreChoisi.BackColor = Color.Pink;


            chefSelectionne = membreChoisi;
        }

        private void ChargerCivilsDisponibles(DateTime dateDebut, DateTime dateFin)
        {
            flpMembreMission.Controls.Clear();
            membresSelectionnes.Clear();

            try
            {
                string requeteSQL = @" SELECT Membre.matricule, Membre.nom
                                    FROM Membre
                                    WHERE Membre.matricule NOT IN
                                    (   SELECT Composer.matriculeMembre
                                        FROM Composer
                                        INNER JOIN Mission
                                            ON Composer.numeroMission = Mission.numero
                                        WHERE Mission.dateDepart <= @dateFin
                                        AND Mission.dateRetour >= @dateDebut
                                    )";

                if (chefSelectionne != null)
                {
                    requeteSQL += " AND Membre.matricule != @matriculeChef";
                }
                    
                SQLiteCommand commande = new SQLiteCommand(requeteSQL, Connexion.Connec);

                if (chefSelectionne != null)
                {
                    commande.Parameters.AddWithValue("@matriculeChef", chefSelectionne.getMatricule());
                }

                commande.Parameters.AddWithValue("@dateDebut",dateDebut.ToString("yyyy-MM-dd"));

                commande.Parameters.AddWithValue("@dateFin",dateFin.ToString("yyyy-MM-dd"));

                SQLiteDataReader lecteur = commande.ExecuteReader();

                while (lecteur.Read())
                {
                    string matricule = lecteur["matricule"].ToString();
                    string nom = lecteur["nom"].ToString();

                    UserControlCarteMembre carte = new UserControlCarteMembre();

                    carte.RemplirInfos(matricule, nom);

                    carte.afficheur = ClicSurUnCivil;

                    flpMembreMission.Controls.Add(carte);
                }

                lecteur.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur SQL lors du chargement des civils disponibles : "+ ex);
            }
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (gpbChoixPlanete.Visible)
            {
                if (planeteSelectionnee != null)
                {
                    passserEtape1a2(planeteSelectionnee);
                }
                else
                {
                    FormSucces.Afficher("Veuillez d'abord sélectionner une planète en cliquant sur son image.", true);
                }
            }
            else if (gpbChoixChef.Visible)
            {
                if (chefSelectionne != null)
                {
                    passserEtape2a3(chefSelectionne);
                }
                else
                {
                    FormSucces.Afficher("Veuillez d'abord sélectionner un chef de mission en cliquant sur sa photo.", true);
                }
            }
            else if (gpbChoixParametresMission.Visible)
            {
                passserEtape3a4(sender, e);
            }
            else if (gpbChoixMembreMission.Visible)
            {
                int nbPlacesDispo = Math.Max(0, nbMembre - 1);
                if (membresSelectionnes.Count == nbPlacesDispo)
                {
                    passserEtape4a5(sender, e);
                }
                else
                {
                    FormSucces.Afficher("Veuillez sélectionner exactement " + nbPlacesDispo + " civils avant de continuer.", true);
                }
            }
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (gpbChoixChef.Visible)
            {
                gpbChoixPlanete.Visible = true;
                gpbChoixChef.Visible = false;
            }
            else if (gpbChoixParametresMission.Visible)
            {
                passserEtape3a2(sender, e);
            }
            else if (gpbChoixMembreMission.Visible)
            {
                passserEtape4a3(sender, e);
            }
            else if (grbChoixCaptures.Visible)
            {
                passserEtape5a4(sender, e);
            }
        }

        private void dtpDates_ValueChanged(object sender, EventArgs e)
        {
            dtpFin.MinDate = dtpDebut.Value;

            if (dtpFin.Value >= dtpDebut.Value)
            {
                flpChef.Visible = true;
                ChargerMilitairesDisponibles(dtpDebut.Value, dtpFin.Value);
            }
            else
            {
                flpChef.Visible = false;
            }
        }
        private void ClicSurUnCivil(object sender, EventArgs e)
        {
            Control declencheur = (Control)sender;
            UserControlCarteMembre membreChoisi = declencheur as UserControlCarteMembre;

            if (membreChoisi == null)
            {
                membreChoisi = (UserControlCarteMembre)declencheur.Parent;
            }
            int nbPlacesDispo = Math.Max(0, nbMembre - 1);


            if (membresSelectionnes.Contains(membreChoisi))
            {
                membresSelectionnes.Remove(membreChoisi);
                membreChoisi.BackColor = Color.Transparent;
            }
            else 
            {
                if (membresSelectionnes.Count < nbPlacesDispo)
                {
                    membresSelectionnes.Add(membreChoisi);
                    membreChoisi.BackColor = Color.Pink; 
                }
                else
                {
                    FormSucces.Afficher("Votre équipage est complet ! Vous ne pouvez pas sélectionner plus de " + nbPlacesDispo + " civils.", true);
                }
            }
        }

        private void ChargerAliensPlanete(string nomPlaneteChoisie)
        {
            flpCaptures.Controls.Clear();

            try
            {
                string requeteSQL = @" SELECT Espece.nom, Espece.couleur
                                    FROM Espece
                                    INNER JOIN Habiter
                                        ON Espece.id = Habiter.idEspece
                                    WHERE Habiter.nomPlanete = @planete";

                SQLiteCommand commande = new SQLiteCommand(requeteSQL, Connexion.Connec);

                commande.Parameters.AddWithValue("@planete",nomPlaneteChoisie);

                SQLiteDataReader lecteur = commande.ExecuteReader();

                while (lecteur.Read())
                {
                    string nomAlien = lecteur["nom"].ToString();
                    string couleur = lecteur["couleur"].ToString();

                    UserControlExtraterrestres.UCTrombinoExtraterrestre carteAlien = new UserControlExtraterrestres.UCTrombinoExtraterrestre(nomAlien,couleur, "Cible",nomPlaneteChoisie);

                    carteAlien.afficheur = ClicSurUnAlien;

                    flpCaptures.Controls.Add(carteAlien);
                }

                lecteur.Close();

                if (flpCaptures.Controls.Count == 0)
                {
                    Label lblAucun = new Label();
                    lblAucun.Text = "Aucun extraterrestre connu n'habite sur cette planète.";
                    lblAucun.AutoSize = true;
                    lblAucun.ForeColor = Color.White;
                    lblAucun.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                    lblAucun.Margin = new Padding(20);
                    
                    flpCaptures.Controls.Add(lblAucun);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SQL lors du chargement des extraterrestres : "+ ex);
            }
        }

        private void InitialiserPopupCapture()
        {
            pnlSaisieQuantite = new Panel();
            pnlSaisieQuantite.Size = new Size(300, 100);
            pnlSaisieQuantite.BackColor = Color.MidnightBlue;
            pnlSaisieQuantite.BorderStyle = BorderStyle.FixedSingle;
            pnlSaisieQuantite.Visible = false; 

            lblSaisieQuantite = new Label();
            lblSaisieQuantite.Text = "Combien voulez-vous en capturer ?";
            lblSaisieQuantite.ForeColor = Color.White;
            lblSaisieQuantite.AutoSize = true;
            lblSaisieQuantite.Location = new Point(20, 20);

            txtSaisieQuantite = new TextBox();
            txtSaisieQuantite.Location = new Point(20, 50);
            txtSaisieQuantite.Size = new Size(260, 26);

            txtSaisieQuantite.KeyDown += new KeyEventHandler(this.txtSaisieQuantite_KeyDown);

            pnlSaisieQuantite.Controls.Add(lblSaisieQuantite);
            pnlSaisieQuantite.Controls.Add(txtSaisieQuantite);
            this.Controls.Add(pnlSaisieQuantite);
        }

        private void ClicSurUnAlien(object sender, EventArgs e)
        {
            Control declencheur = (Control)sender;
            UserControlExtraterrestres.UCTrombinoExtraterrestre alienChoisi = declencheur as UserControlExtraterrestres.UCTrombinoExtraterrestre;
            if (alienChoisi == null)
            {
                alienChoisi = (UserControlExtraterrestres.UCTrombinoExtraterrestre)declencheur.Parent;
            }
            alienEnCoursDeSaisie = alienChoisi;

            pnlSaisieQuantite.Location = new Point((this.Width - pnlSaisieQuantite.Width) / 2,(this.Height - pnlSaisieQuantite.Height) / 2);

            pnlSaisieQuantite.BringToFront();
            pnlSaisieQuantite.Visible = true;

            txtSaisieQuantite.Clear();
            txtSaisieQuantite.Focus();
        }

        private void txtSaisieQuantite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 

                int quantite = 0;

                if (int.TryParse(txtSaisieQuantite.Text, out quantite) && quantite > 0)
                {
                    capturesSelectionnees[alienEnCoursDeSaisie] = quantite;

                    alienEnCoursDeSaisie.BackColor = Color.LightCoral;

                    pnlSaisieQuantite.Visible = false;

                    listViewCapture.Items.Clear();
                    foreach (KeyValuePair<UserControlExtraterrestres.UCTrombinoExtraterrestre, int> capture in capturesSelectionnees)
                    {
                        listViewCapture.Items.Add(capture.Value.ToString() + " - " + capture.Key.getNomAlien());
                    }

                    listViewCapture.Visible = true;
                    lblObjectifCapture.Visible = true;
                }
                else
                {
                    FormSucces.Afficher("Veuillez entrer un nombre valide supérieur à 0.", true);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                pnlSaisieQuantite.Visible = false;
            }
        }

        private void btnValiderMission_Click(object sender, EventArgs e)
        {
            if (planeteSelectionnee == null || chefSelectionne == null || membresSelectionnes == null)
            {
                FormSucces.Afficher("Erreur : Informations manquantes pour créer la mission.", true);
                return;
            }

            try
            {
                SQLiteTransaction maTransaction = Connexion.Connec.BeginTransaction();

                try
                {
                    //numero mission
                    int nouveauNumero = 1;

                    string reqMax = "SELECT MAX(numero) FROM Mission WHERE nomPlanete = @planete";

                    SQLiteCommand cmdMax = new SQLiteCommand(reqMax, Connexion.Connec, maTransaction);

                    cmdMax.Parameters.AddWithValue("@planete", planeteSelectionnee.getNomPlanete());

                    object resultat = cmdMax.ExecuteScalar();

                    if (resultat != null && resultat != DBNull.Value)
                    {
                        nouveauNumero = Convert.ToInt32(resultat) + 1;
                    }

                    //creation mission
                    string reqInsertMission =
                        @"INSERT INTO Mission
                                (nomPlanete,numero,nbMembreRequis,
                                dateDepart,dateRetour,matriculeChef,
                                feuilleDeRoute,objectifDatabaz,budget)
                                VALUES
                                (@planete,@numero,@nbMembreRequis,
                                @dateDepart,@dateRetour,@matriculeChef,
                                @feuilleDeRoute,@objectifDatabaz,@budget)";

                    SQLiteCommand cmdMission =  new SQLiteCommand(reqInsertMission, Connexion.Connec, maTransaction);

                    cmdMission.Parameters.AddWithValue("@planete", planeteSelectionnee.getNomPlanete());
                    cmdMission.Parameters.AddWithValue("@numero", nouveauNumero);
                    cmdMission.Parameters.AddWithValue("@nbMembreRequis", nbMembre);
                    cmdMission.Parameters.AddWithValue("@dateDepart", dtpDebut.Value.ToString("yyyy-MM-dd"));
                    cmdMission.Parameters.AddWithValue("@dateRetour", dtpFin.Value.ToString("yyyy-MM-dd"));
                    cmdMission.Parameters.AddWithValue("@matriculeChef", chefSelectionne.getMatricule());
                    cmdMission.Parameters.AddWithValue("@feuilleDeRoute", txtSaisieFeuilleRoute.Text);
                    cmdMission.Parameters.AddWithValue("@objectifDatabaz", (int)numObjDataBaz.Value);
                    cmdMission.Parameters.AddWithValue("@budget", (int)numBudget.Value);

                    cmdMission.ExecuteNonQuery();

                    //ajout membre
                    string reqComposer =
                        @"INSERT INTO Composer
                            (nomPlanete, numeroMission, matriculeMembre)
                            VALUES
                            (@planete, @numero, @matricule)";

                    SQLiteCommand cmdComposer = new SQLiteCommand(reqComposer, Connexion.Connec, maTransaction);

                    cmdComposer.Parameters.AddWithValue("@planete", planeteSelectionnee.getNomPlanete());
                    cmdComposer.Parameters.AddWithValue("@numero", nouveauNumero);
                    cmdComposer.Parameters.AddWithValue("@matricule", chefSelectionne.getMatricule());

                    // Chef
                    cmdComposer.ExecuteNonQuery();

                    // Civils
                    foreach (UserControlCarteMembre civil in membresSelectionnes)
                    {
                        cmdComposer.Parameters["@matricule"].Value = civil.getMatricule();
                        cmdComposer.ExecuteNonQuery();
                    }

                    // objectif de capture
                    if (capturesSelectionnees.Count > 0)
                    {
                        string reqCapture =
                            @"INSERT INTO ObjectifCapture
                                (nomPlanete, numeroMission, idEspeceEnnemi, objectif)
                                VALUES
                                (@planete, @numero,
                                    (SELECT id FROM Espece WHERE nom = @nomAlien),
                                    @objectif )";

                        SQLiteCommand cmdCapture =
                            new SQLiteCommand(reqCapture, Connexion.Connec, maTransaction);

                        cmdCapture.Parameters.AddWithValue("@planete", planeteSelectionnee.getNomPlanete());
                        cmdCapture.Parameters.AddWithValue("@numero", nouveauNumero);
                        cmdCapture.Parameters.AddWithValue("@nomAlien", "");
                        cmdCapture.Parameters.AddWithValue("@objectif", 0);

                        foreach (KeyValuePair<UserControlExtraterrestres.UCTrombinoExtraterrestre, int> capture
                            in capturesSelectionnees)
                        {
                            cmdCapture.Parameters["@nomAlien"].Value = capture.Key.getNomAlien();

                            cmdCapture.Parameters["@objectif"].Value = capture.Value;

                            cmdCapture.ExecuteNonQuery();
                        }
                    }

                    //C'EST VALIDEE
                    maTransaction.Commit();

                    FormSucces.Afficher("Félicitations ! La mission a été créée et enregistrée avec succès.");

                    this.Close();
                }
                catch (Exception exTransaction)
                {
                    maTransaction.Rollback();

                    MessageBox.Show("Une erreur est survenue lors de l'enregistrement.\n\n" + exTransaction.Message,"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message,"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}

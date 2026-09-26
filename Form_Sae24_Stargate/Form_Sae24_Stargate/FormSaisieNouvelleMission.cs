using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Form_Sae24_Stargate
{
    public partial class FormSaisieNouvelleMission : Form
    {
        private int nbMembre = 0;
        private CarteMembre chefSelectionne = null;
        private CartePlanete planeteSelectionnee = null;
        private List<CarteMembre> membresSelectionnes = new List<CarteMembre>();
        
        private Dictionary<CarteAlien, int> capturesSelectionnees = new Dictionary<CarteAlien, int>();

        
        private CarteAlien alienEnCoursDeSaisie = null;

        
        private Panel pnlSaisieQuantite;
        private Label lblSaisieQuantite;
        private TextBox txtSaisieQuantite; private CarteAlien alienSelectionne = null;
        public FormSaisieNouvelleMission()
        {
            InitializeComponent();

            gpbChoixPlanete.Visible = true;

            dtpDebut.MinDate = System.DateTime.Today;
            dtpFin.MinDate = System.DateTime.Today;

            numNbMembre.Minimum = 1;

            ChargerPlanetes();
            InitialiserPopupCapture();

            //tout s'agrandit ou se réduit avec l'écran
            AdaptationEcran.Activer(this);

            //Visible ne vaut true qu'une fois la fenêtre affichée : on grise les boutons à ce moment-là
            this.Shown += delegate { MettreAJourBoutons(); };

        }
    
        private void passserEtape1a2(CartePlanete planetChoisie)
        {
            
            lblPlanete.Text = "Planète : " + planetChoisie.getNomPlanete();
            lblPlanete.Visible = true;

            gpbChoixPlanete.Visible = false;
            gpbChoixChef.Visible = true;
            gpbChoixParametresMission.Visible = false;
            gpbChoixMembreMission.Visible = false;
            grbChoixCaptures.Visible = false;

            flpChef.Visible = false;

            lblChoixChef.Text = "Choisissez d'abord les dates, puis un chef de mission.";
            lblChoixChef.Visible = true;
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

        private void passserEtape2a3(CarteMembre membreChoisis)
        {

            //numNbMembre.Maximum = 10;

            gpbChoixPlanete.Visible = false;
            gpbChoixChef.Visible = false;
            gpbChoixParametresMission.Visible = true;
            gpbChoixMembreMission.Visible = false;
            grbChoixCaptures.Visible = false;


            lblChef.Text = "Chef de mission : " + membreChoisis.Nom;
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
            AfficherMembresRestants();
        }

        /// <summary>
        /// Indique combien de membres il reste à choisir : le nombre de participants moins 1, car le chef en fait partie
        /// </summary>
        private void AfficherMembresRestants()
        {
            int nbPlacesDispo = Math.Max(0, nbMembre - 1);
            int restants = nbPlacesDispo - membresSelectionnes.Count;

            if (nbPlacesDispo == 0)
            {
                lblNbMembreRestant.Text = "Le chef part seul : aucun membre à choisir. Cliquez sur Étape suivante.";
            }
            else if (restants > 0)
            {
                lblNbMembreRestant.Text = "Choisissez encore " + restants + " membre" + (restants > 1 ? "s" : "")
                    + " (" + membresSelectionnes.Count + " sur " + nbPlacesDispo + ", le chef compte déjà comme participant)";
            }
            else
            {
                lblNbMembreRestant.Text = "Équipage complet (" + nbPlacesDispo + " membres + le chef). Cliquez sur Étape suivante.";
            }

            MettreAJourBoutons();
        }

        /// <summary>
        /// Grise les boutons qu'on ne peut pas utiliser à l'étape en cours :
        /// - Étape précédente : grisé à la première étape (choix de la planète)
        /// - Étape suivante : grisé tant que l'étape n'est pas remplie, et à la dernière étape (captures)
        /// - Valider la mission : actif seulement à la dernière étape, quand tout est rempli
        /// </summary>
        private void MettreAJourBoutons()
        {
            bool planeteChoisie = planeteSelectionnee != null;
            bool chefChoisi = chefSelectionne != null;
            bool equipageComplet = membresSelectionnes.Count == Math.Max(0, nbMembre - 1);

            btnPrecedent.Enabled = !gpbChoixPlanete.Visible;

            if (gpbChoixPlanete.Visible)
            {
                btnSuivant.Enabled = planeteChoisie;
            }
            else if (gpbChoixChef.Visible)
            {
                btnSuivant.Enabled = chefChoisi;
            }
            else if (gpbChoixMembreMission.Visible)
            {
                btnSuivant.Enabled = equipageComplet;
            }
            else
            {
                //paramètres : toujours valides ; captures : dernière étape, plus rien après
                btnSuivant.Enabled = gpbChoixParametresMission.Visible;
            }

            btnValiderMission.Enabled = grbChoixCaptures.Visible && planeteChoisie && chefChoisi && equipageComplet;
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
                listViewMembre.Items.Add(chefSelectionne.Nom + " (Chef)");
            }
            foreach (CarteMembre civil in membresSelectionnes)
            {
                listViewMembre.Items.Add(civil.Nom);
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
            flpChoixPlanete.BackColor = CarteMembre.CouleurTrombinoscope;
            CarteMembre.CentrerColonnes(flpChoixPlanete, CartePlanete.Largeur, CartePlanete.Marge);

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

                    CartePlanete planete = new CartePlanete(nomPlanete, temperature, gravite, dataBaz);

                    planete.Clic += ClicSurUnePlanete;

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
            CartePlanete planeteChoisie = (CartePlanete)sender;

            //un deuxième clic sur la planète choisie la désélectionne
            if (planeteSelectionnee == planeteChoisie)
            {
                planeteChoisie.Selectionnee = false;
                planeteSelectionnee = null;
                lblPlanete.Text = "Planète : ";
                MettreAJourBoutons();
                return;
            }

            //une seule planète : on désélectionne l'ancienne
            if (planeteSelectionnee != null)
            {
                planeteSelectionnee.Selectionnee = false;
            }

            planeteChoisie.Selectionnee = true;
            planeteSelectionnee = planeteChoisie;

            lblPlanete.Text = "Planète : " + planeteChoisie.getNomPlanete();
            lblPlanete.Visible = true;
            MettreAJourBoutons();
        }

        private void ChargerMilitairesDisponibles(DateTime dateDebut, DateTime dateFin)
        {
            flpChef.Controls.Clear();
            chefSelectionne = null;
            MettreAJourBoutons();
            CarteMembre.CentrerColonnes(flpChef);

            try
            {
                string requeteSQL = @" SELECT Membre.matricule, Membre.nom, Membre.prenom
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
                    string nom = lecteur["nom"].ToString() + " " + lecteur["prenom"].ToString();

                    CarteMembre carte = new CarteMembre(matricule, nom, false);

                    carte.Clic += ClicSurUneMilitaire;

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
            CarteMembre membreChoisi = (CarteMembre)sender;

            if (chefSelectionne == membreChoisi)
            {
                membreChoisi.Selectionnee = false;
                chefSelectionne = null;
                lblChoixChef.Text = "Choisissez un chef de mission en cliquant sur sa photo :";
                MettreAJourBoutons();
                return;
            }

            //un seul chef : on désélectionne l'ancien
            if (chefSelectionne != null)
            {
                chefSelectionne.Selectionnee = false;
            }

            membreChoisi.Selectionnee = true;

            chefSelectionne = membreChoisi;
            lblChoixChef.Text = "Chef choisi : " + membreChoisi.Nom + " (cliquez sur une autre photo pour changer)";
            MettreAJourBoutons();
        }

        private void ChargerCivilsDisponibles(DateTime dateDebut, DateTime dateFin)
        {
            flpMembreMission.Controls.Clear();
            membresSelectionnes.Clear();
            CarteMembre.CentrerColonnes(flpMembreMission);

            try
            {
                string requeteSQL = @" SELECT Membre.matricule, Membre.nom, Membre.prenom
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
                    commande.Parameters.AddWithValue("@matriculeChef", chefSelectionne.Matricule);
                }

                commande.Parameters.AddWithValue("@dateDebut",dateDebut.ToString("yyyy-MM-dd"));

                commande.Parameters.AddWithValue("@dateFin",dateFin.ToString("yyyy-MM-dd"));

                SQLiteDataReader lecteur = commande.ExecuteReader();

                while (lecteur.Read())
                {
                    string matricule = lecteur["matricule"].ToString();
                    string nom = lecteur["nom"].ToString() + " " + lecteur["prenom"].ToString();

                    CarteMembre carte = new CarteMembre(matricule, nom, false);

                    carte.Clic += ClicSurUnCivil;

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
                    FormSucces.Afficher("Veuillez sélectionner exactement " + nbPlacesDispo + " membres avant de continuer.", true);
                }
            }

            MettreAJourBoutons();
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

            MettreAJourBoutons();
        }

        private void dtpDates_ValueChanged(object sender, EventArgs e)
        {
            dtpFin.MinDate = dtpDebut.Value;

            if (dtpFin.Value >= dtpDebut.Value)
            {
                flpChef.Visible = true;
                lblChoixChef.Text = "Choisissez un chef de mission en cliquant sur sa photo :";
                lblChoixChef.Visible = true;
                ChargerMilitairesDisponibles(dtpDebut.Value, dtpFin.Value);
            }
            else
            {
                flpChef.Visible = false;
            }
        }
        private void ClicSurUnCivil(object sender, EventArgs e)
        {
            CarteMembre membreChoisi = (CarteMembre)sender;

            int nbPlacesDispo = Math.Max(0, nbMembre - 1);


            if (membresSelectionnes.Contains(membreChoisi))
            {
                membresSelectionnes.Remove(membreChoisi);
                membreChoisi.Selectionnee = false;
            }
            else 
            {
                if (membresSelectionnes.Count < nbPlacesDispo)
                {
                    membresSelectionnes.Add(membreChoisi);
                    membreChoisi.Selectionnee = true;
                }
                else
                {
                    FormSucces.Afficher("Votre équipage est complet ! Vous ne pouvez pas sélectionner plus de " + nbPlacesDispo + " membres.", true);
                }
            }

            AfficherMembresRestants();
        }

        private void ChargerAliensPlanete(string nomPlaneteChoisie)
        {
            flpCaptures.Controls.Clear();
            flpCaptures.BackColor = CarteMembre.CouleurTrombinoscope;
            CarteMembre.CentrerColonnes(flpCaptures, CarteAlien.Largeur, CarteAlien.Marge);

            try
            {
                string requeteSQL = @" SELECT Espece.nom, Espece.couleur, Habiter.pourcentage,
                                        Allie.idEspece AS idAllie, Ennemi.idEspece AS idEnnemi
                                    FROM Espece
                                    INNER JOIN Habiter
                                        ON Espece.id = Habiter.idEspece
                                    LEFT JOIN Allie ON Allie.idEspece = Espece.id
                                    LEFT JOIN Ennemi ON Ennemi.idEspece = Espece.id
                                    WHERE Habiter.nomPlanete = @planete
                                    ORDER BY Espece.nom";

                SQLiteCommand commande = new SQLiteCommand(requeteSQL, Connexion.Connec);

                commande.Parameters.AddWithValue("@planete",nomPlaneteChoisie);

                SQLiteDataReader lecteur = commande.ExecuteReader();

                while (lecteur.Read())
                {
                    string nomAlien = lecteur["nom"].ToString();
                    string couleur = lecteur["couleur"].ToString();

                    //même règle que l'accueil : ennemi prioritaire sur allié, sinon neutre
                    string statut = "Neutre";
                    if (lecteur["idAllie"] != DBNull.Value)
                    {
                        statut = "Allié";
                    }
                    if (lecteur["idEnnemi"] != DBNull.Value)
                    {
                        statut = "Ennemi";
                    }

                    CarteAlien carteAlien = new CarteAlien(nomAlien, couleur, statut, "Présence : " + lecteur["pourcentage"].ToString() + "%");

                    carteAlien.Clic += ClicSurUnAlien;

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
            alienEnCoursDeSaisie = (CarteAlien)sender;

            //centrée dans la fenêtre (positions d'origine, AdaptationEcran les met à l'échelle)
            Size zone = AdaptationEcran.TailleDeBase(this);
            Size taillePopup = AdaptationEcran.TailleDeBase(pnlSaisieQuantite);
            pnlSaisieQuantite.Location = new Point((zone.Width - taillePopup.Width) / 2, (zone.Height - taillePopup.Height) / 2);

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

                    alienEnCoursDeSaisie.Selectionnee = true;
                    alienEnCoursDeSaisie.Info = "À capturer : " + quantite;

                    pnlSaisieQuantite.Visible = false;

                    listViewCapture.Items.Clear();
                    foreach (KeyValuePair<CarteAlien, int> capture in capturesSelectionnees)
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
                    //numéro mission
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
                    cmdMission.Parameters.AddWithValue("@matriculeChef", chefSelectionne.Matricule);
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
                    cmdComposer.Parameters.AddWithValue("@matricule", chefSelectionne.Matricule);

                    // Chef
                    cmdComposer.ExecuteNonQuery();

                    // Civils
                    foreach (CarteMembre civil in membresSelectionnes)
                    {
                        cmdComposer.Parameters["@matricule"].Value = civil.Matricule;
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

                        foreach (KeyValuePair<CarteAlien, int> capture
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

using BCrypt.Net;
using iTextSharp.text;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UserControlBoutonAvecImage;
using UserControlExtraterrestres;
using UserControlExtraterrestresDetail;
using UserControlMission;
using UserControlPlanete;
using UserControlTrombinoPlanete;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Form_Sae24_Stargate
{


    public partial class FormAccueil : Form
    {
        //flpAffichage partagé par trombinoAlien et trombinoPlanete
        private FlowLayoutPanel flpAffichage;

        //UCBtn permettant de savoir quel bouton est séléctionné et le colorer
        private UCBoutonImage btnActif = null;

        public FormAccueil()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FormAccueil prend tout l'écran
            WindowState = FormWindowState.Maximized;

            //Ajouter un login/mdp dans la base de données

            /*string password = "Alexia"; // Password entered by the user
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            string addLogin = @"insert into Admin (login, mdp) values ('Alexia','" + hashedPassword + "')";
            SQLiteCommand cd1 = new SQLiteCommand(addLogin, Connexion.Connec);
            cd1.ExecuteNonQuery();*/

            //Chargement des tables
            DataTable dtSchema = Connexion.Connec.GetSchema("Tables");

            //Chargement des tables
            for (int i = 0; i < dtSchema.Rows.Count; i++)
            {
                string nomTable = dtSchema.Rows[i]["TABLE_NAME"].ToString();
                string req = @"select * from " + nomTable;
                SQLiteCommand cd = new SQLiteCommand(req, Connexion.Connec);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cd);
                da.Fill(MesDatas.DsGlobal, nomTable);
            }


            //Instanciation objets flpAffichage et dtAlien
            flpAffichage = new FlowLayoutPanel();

            //Instanciation et remplissage dtAlien
            DataTable dtAlien = new DataTable();
            remplirTableAlien(dtAlien);
            dtAlien.TableName = "dtAlien";
            MesDatas.DsGlobal.Tables.Add(dtAlien);

            //Créer une table planète sort by nom
            MesDatas.DsGlobal.Tables["Planete"].DefaultView.Sort = "nom ASC";
            DataTable dtPlanetes = MesDatas.DsGlobal.Tables["Planete"].DefaultView.ToTable(true);
            dtPlanetes.TableName = "dtPlanetes";
            MesDatas.DsGlobal.Tables.Add(dtPlanetes);

            //Association des delegate aux méthodes des boutons 
            btnUCTableauDeBord.afficheur = clickTableauDeBord;
            btnUCNouvelleMission.afficheur = clickAjouterNouvelleMission;
            btnUCAliens.afficheur = clickDecouverteAliens;
            btnUCInfoPlanete.afficheur = clickDecouvertePlanetes;
            btnUCStatistiques.afficheur = clickStatistiques;

        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Colore le bouton sélectionné sur le tableau de bord
        /// </summary>
        /// <param name="btnSelect"></param>
        private void selectionnerBouton(UCBoutonImage btnSelect)
        {
            //Si il y a un bouton sélectionné, on remets sa couleur
            if (btnActif != null)
            {
                btnActif.retablirCouleur();
            }

            //Changer la couleur du bouton séléctionné
            btnSelect.changerCouleur();

            //Garder en mémoire le bouton sélectionné (btnActif : variable globale)
            btnActif = btnSelect;
        }

        //===============================================================================================================================================================================
        //      VOLET TABLEAU DE BORD
        //===============================================================================================================================================================================
        //Méthode appelée par le delegate afficheur
        /// <summary>
        /// Affiche un TabControl avec plusieurs Tab : missions en cours, à venir, terminées. Les tab contiennent des UserControl UCMission permettant un aperçu des missions
        /// (chef, budget, dates, statut, planète...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickTableauDeBord(object sender, EventArgs e)
        {
            //Cast de l'object sender en "Control"
            //On doit caster en "Control" et pas en UCBoutonImage parce que sender est l’objet EXACT qui a déclenché l’événement
            //Ici, l'évenement est le click sur boutonImage ou lblImage ou pictureBox
            Control btn = (Control)sender;
            //Récupération du UserControl parent
            UCBoutonImage btnImage = (UCBoutonImage)btn.Parent;
            selectionnerBouton(btnImage);

            AfficherTableauDeBord();
        }

        /// <summary>
        /// Remplit le tableau de bord avec les missions du DataSet (en cours, à venir, terminées)
        /// </summary>
        private void AfficherTableauDeBord()
        {
            //Gestion affichage
            tabAffichage.Visible = false;
            tabControlMission.Visible = true;
            grpFiltre.Visible = false;
            grpFiltrePlanete.Visible = false;
            if (flpAffichage != null)
            {
                flpAffichage.Visible = false;
            }

            //Pour ne pas avoir de doublons de missions
            flpMissionEnCours.Controls.Clear();
            flpMissionTerminee.Controls.Clear();
            flpMissionsAVenir.Controls.Clear();

            //Compteur de nombre de missions
            int nbMissionEnCours = 0;
            int nbMissionTerminees = 0;
            int nbMissionAVenir = 0;


            for (int i = 0; i < MesDatas.DsGlobal.Tables["Mission"].Rows.Count; i++)
            {
                DataRow ligne = MesDatas.DsGlobal.Tables["Mission"].Rows[i];
                string filtreChefMission = "matricule = '" + ligne[5].ToString() + "'";

                //Récuperer le nom du chef à partir du matricule
                DataRow[] tabMembre = MesDatas.DsGlobal.Tables["Membre"].Select(filtreChefMission);
                string nomChef = tabMembre[0][1].ToString() + " " + tabMembre[0][2].ToString();

                //Nouvel objet mission
                UCMission mission = new UCMission(ligne[0].ToString(), ligne[1].ToString(), ligne[3].ToString(), ligne[4].ToString(), nomChef, ligne[8].ToString() + "€");

                //Associer le délegate au nouvel objet mission pour que le bouton 'détail' soit fonctionnel
                mission.afficher = clickDetailMission;

                //Ajout des usercontrol mission dans le flp correspondant à leur statut (en cours, terminee, a venir)
                if (mission.statutMission == "En cours")
                {
                    flpMissionEnCours.Controls.Add(mission);
                    nbMissionEnCours++;
                }
                else if (mission.statutMission == "Terminée")
                {
                    flpMissionTerminee.Controls.Add(mission);
                    nbMissionTerminees++;
                }
                else
                {
                    flpMissionsAVenir.Controls.Add(mission);
                    nbMissionAVenir++;
                }
            }


            //Ajout de label "aucune mission" si absence de mission
            if (nbMissionEnCours == 0)
            {
                Label lblAucuneMissionEnCours = new Label();
                lblAucuneMissionEnCours.AutoSize = true;
                lblAucuneMissionEnCours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                lblAucuneMissionEnCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblAucuneMissionEnCours.ForeColor = System.Drawing.Color.White;
                lblAucuneMissionEnCours.Size = new System.Drawing.Size(580, 36);
                lblAucuneMissionEnCours.Text = "Aucune mission en cours";
                flpMissionEnCours.Controls.Add(lblAucuneMissionEnCours);
            }
            if (nbMissionTerminees == 0)
            {
                Label lblAucuneMissionTerminee = new Label();
                lblAucuneMissionTerminee.AutoSize = true;
                lblAucuneMissionTerminee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                lblAucuneMissionTerminee.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblAucuneMissionTerminee.ForeColor = System.Drawing.Color.White;
                lblAucuneMissionTerminee.Size = new System.Drawing.Size(580, 36);
                lblAucuneMissionTerminee.Text = "Aucune mission terminée";
                flpMissionTerminee.Controls.Add(lblAucuneMissionTerminee);
            }
            if (nbMissionAVenir == 0)
            {
                Label lblAucuneMissionAVenir = new Label();
                lblAucuneMissionAVenir.AutoSize = true;
                lblAucuneMissionAVenir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                lblAucuneMissionAVenir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblAucuneMissionAVenir.ForeColor = System.Drawing.Color.White;
                lblAucuneMissionAVenir.Size = new System.Drawing.Size(580, 36);
                lblAucuneMissionAVenir.Text = "Aucune mission à venir";
                flpMissionsAVenir.Controls.Add(lblAucuneMissionAVenir);
            }
        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Ouvre un nouveau formulaire comprenant le détail de la mission sélectionné (objectifs, équipage ...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickDetailMission(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            //1*Parent car le sender btn est dans une grpbox, 2*parent car grpbox dans UCMission
            UCMission missionCliquee = (UCMission)btn.Parent.Parent;



            //Ouverture du form contenant le détail de la mission sélectionnée
            UserControlMissionDetail detailMission = new UserControlMissionDetail();

            detailMission.ChargerMission(Convert.ToInt32(missionCliquee.getNumero()), missionCliquee.getPlanete());
            //couleur / design 

            if (missionCliquee.statutMission != "Terminée")
            {

                detailMission.ActiverModeEdition(true);
            }
            else
            {
                detailMission.ActiverModeEdition(false);
            }

            // Ouverture du form contenant le détail
            FormClickDetail frmMissionDetail = new FormClickDetail(detailMission);
            frmMissionDetail.Text = "Détail de la mission n°" + missionCliquee.getNumero() + " - " + missionCliquee.getPlanete();
            frmMissionDetail.ShowDialog();
        
        }

        //===============================================================================================================================================================================
        //      VOLET AJOUT MISSION
        //===============================================================================================================================================================================

        //Méthode appelée par le delegate afficheur de btnUCNouvelleMission
        /// <summary>
        /// Ouvre le formulaire d'authentification permettant d'ajouter une mission en cas d'authentification réussie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickAjouterNouvelleMission(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            UCBoutonImage btnImage = (UCBoutonImage)btn.Parent;

            //Ouverture du form Authentification
            FormAuthentification frmLogin = new FormAuthentification();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                //Si authentification ok, ouverture nouvelle mission
                FormSaisieNouvelleMission frmSaisieMission = new FormSaisieNouvelleMission();
                frmSaisieMission.ShowDialog();

                //Mettre une fonction pour recharger le data set et la table
                ActualiserMissionsDansDataSet();

                //Si le tableau de bord est affiché, il montre tout de suite la nouvelle mission
                if (tabControlMission.Visible)
                {
                    AfficherTableauDeBord();
                }
            }
            //Sinon l'utilisateur a cliqué sur Annuler : les échecs sont déjà signalés par FormAuthentification
        }

        /// <summary>
        /// Rafraîchit uniquement les tables liées aux missions dans le DataSet global
        /// pour éviter de recharger toute la base de données.
        /// </summary>
        private void ActualiserMissionsDansDataSet()
        {
            //list des tables potentiellement modifiées par ta transaction d'ajout
            string[] tablesModifiees = { "Mission", "Composer", "ObjectifCapture" };

            foreach (string nomTable in tablesModifiees)
            {
                if (MesDatas.DsGlobal.Tables.Contains(nomTable))
                {
                    MesDatas.DsGlobal.Tables[nomTable].Clear();

                    string requete = "SELECT * FROM " + nomTable;
                    using (SQLiteCommand cd = new SQLiteCommand(requete, Connexion.Connec))
                    {
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cd))
                        {
                            //remplit le DataSet
                            da.Fill(MesDatas.DsGlobal, nomTable);
                        }
                    }
                }
            }
        }
        //===============================================================================================================================================================================
        //      VOLET ALIENS
        //===============================================================================================================================================================================
        /// <summary>
        /// Remplit la variable globale dtAlien avec toutes les infos sur les aliens
        /// </summary>
        private void remplirTableAlien(DataTable dtAlien)
        {
            //Créer une table avec toutes les infos des aliens
            dtAlien.Columns.Add("idEspece", typeof(int));
            dtAlien.Columns.Add("nom", typeof(String));
            dtAlien.Columns.Add("couleur", typeof(String));
            dtAlien.Columns.Add("statut", typeof(String));
            dtAlien.Columns.Add("datePremierContact", typeof(String));
            dtAlien.Columns.Add("degreBienveillance", typeof(String));
            dtAlien.Columns.Add("instrumentMusique", typeof(String));
            dtAlien.Columns.Add("typeArme", typeof(String));
            dtAlien.Columns.Add("degreAgressivite", typeof(String));
            dtAlien.Columns.Add("planete", typeof(String));

            for (int i = 0; i < MesDatas.DsGlobal.Tables["Espece"].Rows.Count; i++)
            {
                //Pour chaque espece dans table Espece, on récupère la ligne
                DataRow ligneEspece = MesDatas.DsGlobal.Tables["Espece"].Rows[i];
                string idEspece = ligneEspece[0].ToString();
                string nom = ligneEspece[1].ToString();
                string couleur = ligneEspece[2].ToString();
                string datePremierContact = string.Empty;
                string degreBienveillance = string.Empty;
                string instrumentMusique = string.Empty;
                string degreAgressivite = string.Empty;
                string typeArme = string.Empty;

                string filtre = "idEspece = " + ligneEspece[0].ToString() + "";

                //Filtre si idEspece est dans Allie
                DataRow[] tabAllie = MesDatas.DsGlobal.Tables["Allie"].Select(filtre);

                //Filtre si idEspece est dans Ennemi
                DataRow[] tabEnnemi = MesDatas.DsGlobal.Tables["Ennemi"].Select(filtre);

                //Check le statut de l'alien
                string statut = "Neutre";
                if (tabAllie.Length > 0)
                {
                    statut = "Allié";
                    datePremierContact = tabAllie[0][1].ToString();
                    degreBienveillance = tabAllie[0][2].ToString();
                    instrumentMusique = tabAllie[0][3].ToString();

                }
                if (tabEnnemi.Length > 0)
                {
                    statut = "Ennemi";
                    degreAgressivite = tabEnnemi[0][2].ToString();
                    typeArme = tabEnnemi[0][1].ToString();
                }

                //Filtre sur quelles planetes sont idEspece
                DataRow[] tabPlanete = MesDatas.DsGlobal.Tables["Habiter"].Select(filtre);
                string planete = "";

                //Construction de la liste de planètes
                for (int j = 0; j < tabPlanete.Length; j++)
                {
                    planete += tabPlanete[j][0].ToString() + "/";
                }
                if (planete.Length > 0)
                {
                    planete = planete.Substring(0, planete.Length - 1);
                }
                else
                {
                    planete = "Inconnu";
                }

                //Création de la ligne à ajouter
                DataRow ligne = dtAlien.NewRow();
                ligne[0] = idEspece;
                ligne[1] = nom;
                ligne[2] = couleur;
                ligne[3] = statut;
                ligne[4] = datePremierContact;
                ligne[5] = degreBienveillance;
                ligne[6] = instrumentMusique;
                ligne[7] = typeArme;
                ligne[8] = degreAgressivite;
                ligne[9] = planete;

                //Ajout à dtAlien
                dtAlien.Rows.Add(ligne);

            }
        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Remplit de UCTrombinoAlien un flowLayoutPanel donné avec une table donnée
        /// Permet de selectionner une table filtré, ainsi que soit le flp du bouton découverte alien, soit celui de détail planètes
        /// </summary>
        /// <param name="table"></param>
        /// <param name="flp"></param>
        private void flpAffichageTrombinoAlien(DataTable table, FlowLayoutPanel flp)
        {
            //Vide le flp
            flp.Controls.Clear();

            //Trie la dataTable par ordre alphabétique
            table.DefaultView.Sort = "nom ASC";
            table = table.DefaultView.ToTable(true);

            foreach (DataRow dr in table.Rows)
            {
                //Crée un objet UCTrombinoExtraterrestre avec les donnees de la dataTable
                UCTrombinoExtraterrestre alien = new UCTrombinoExtraterrestre(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[9].ToString());
                //Associer le délegate au nouvel objet UCTrombinoExtraterrestre pour que le click soit fonctionnel
                alien.afficheur = clickDetailAlien;
                //Ajout au flp
                flp.Controls.Add(alien);
            }
        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Méthode appelée par le delegate afficheur lors de l'appui sur le bouton "découverte des aliens
        /// Affiche le trombinoscope des aliens sans filtre appliqués, ainsi que le groupBox filtres 
        /// Les UserControl UCTrombinoExtraterrestres sont ajoutés dans le flpAffichage via la méthode flpAffichageTrombinoAlien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickDecouverteAliens(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            UCBoutonImage btnImage = (UCBoutonImage)btn.Parent;
            //Selectionne ce bouton comme bouton actif
            selectionnerBouton(btnImage);

            //Gestion de l'affichage
            tabAffichage.Visible = false;
            tabControlMission.Visible = false;
            //Afficher les filtres
            grpFiltre.Visible = true;
            grpFiltrePlanete.Visible = false;


            foreach (DataRow dr in MesDatas.DsGlobal.Tables["dtAlien"].Rows)
            {
                //Compléter la comboBox de filtre couleur par ordre alphabétique
                if (!cboFiltreCouleur.Items.Contains(dr["couleur"].ToString()))
                {
                    cboFiltreCouleur.Items.Add(dr["couleur"].ToString());
                    cboFiltreCouleur.Sorted = true;
                }
            }

            foreach (DataRow dr in MesDatas.DsGlobal.Tables["Planete"].Rows)
            {
                //Compléter la comboBox de filtre planete par ordre alphabétique
                if (!cboFiltrePlanete.Items.Contains(dr["nom"].ToString()))
                {
                    cboFiltrePlanete.Items.Add(dr["nom"].ToString());
                    cboFiltrePlanete.Sorted = true;
                }
            }

            //Pamamètres du flpAffichage comprenant les usercontrol
            this.grpFiltre.Location = new System.Drawing.Point(360, 29);
            flpAffichage.Visible = true;
            flpAffichage.AutoScroll = true;
            flpAffichage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            flpAffichage.Location = new System.Drawing.Point(360, 210);
            flpAffichage.Name = "flpAffichage";
            flpAffichage.Size = new System.Drawing.Size(1120, 590);
            flpAffichage.TabIndex = 11;

            //Ajout du flpAffichage
            this.Controls.Add(flpAffichage);

            //Remplir flpAffichage avec les usercontrols
            flpAffichageTrombinoAlien(MesDatas.DsGlobal.Tables["dtAlien"], flpAffichage);

        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Affiche les filtres des alliés (degré de bienveillance, instrument...) dans la grpbox filtres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbFiltreAllie_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiltreAllie.Checked)
            {
                //Affiche les filtres alliés
                gpbFiltreAllie.Visible = true;
                foreach (DataRow dr in MesDatas.DsGlobal.Tables["Allie"].Rows)
                {
                    //Compléter la comboBox de filtre instrument par ordre alphabétique
                    if (!cboFiltreInstrument.Items.Contains(dr[3].ToString()))
                    {
                        cboFiltreInstrument.Items.Add(dr[3].ToString());
                        cboFiltreInstrument.Sorted = true;
                    }
                    //Compléter la comboBox de filtre degreBienveillance par ordre alphabétique
                    if (!cboDegBien.Items.Contains(dr[2].ToString()))
                    {
                        cboDegBien.Items.Add(dr[2].ToString());
                        cboDegBien.Sorted = true;
                    }
                }
            }
            if (!ckbFiltreAllie.Checked)
            {
                //Massqe les filtres si Alliés non checked
                gpbFiltreAllie.Visible = false;
            }
        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Affiche les filtres des ennemis (degré d'agressivité, arme...) dans la grpbox filtres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ckbFiltreEnnemi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiltreEnnemi.Checked)
            {
                //Affiche les filtres ennemis
                gpbFiltreEnnemi.Visible = true;
                foreach (DataRow dr in MesDatas.DsGlobal.Tables["Ennemi"].Rows)
                {
                    //Compléter la comboBox de filtre degreAgressivite par ordre alphabétique
                    if (!cboDegMal.Items.Contains(dr[2].ToString()))
                    {
                        cboDegMal.Items.Add(dr[2].ToString());
                        cboDegMal.Sorted = true;
                    }
                    //Compléter la comboBox de filtre arme par ordre alphabétique
                    if (!cboFiltreArme.Items.Contains(dr[1].ToString()))
                    {
                        cboFiltreArme.Items.Add(dr[1].ToString());
                        cboFiltreArme.Sorted = true;
                    }
                }
            }
            if (!ckbFiltreEnnemi.Checked)
            {
                //Massqe les filtres si Ennemis non checked
                gpbFiltreEnnemi.Visible = false;
            }
        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Applique les filtres sélectionnés et remplit le flpAffichage avec les UCTrombinoExtraterrestres filtrés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppliquerFiltre_Click(object sender, EventArgs e)
        {
            //Création d'un dictionnaire pour stocker le type de filtre et sa valeur
            Dictionary<string, string> filtres = new Dictionary<string, string>();
            string nom = string.Empty;
            string couleur = string.Empty;
            string statut = string.Empty;
            string degreBienveillance = string.Empty;
            string instrumentMusique = string.Empty;
            string degreAgressivite = string.Empty;
            string typeArme = string.Empty;
            string planete = string.Empty;

            //Remplissage des valeurs de filtres
            if (txtFiltreNom.Text != string.Empty)
            {
                nom = txtFiltreNom.Text;
            }
            couleur = cboFiltreCouleur.Text.ToString();
            planete = cboFiltrePlanete.Text.ToString();
            if (ckbFiltreAllie.Checked)
            {
                statut = "Allié";
                degreBienveillance = cboDegBien.Text.ToString();
                instrumentMusique = cboFiltreInstrument.Text.ToString();
            }
            if (ckbFiltreEnnemi.Checked)
            {
                statut = "Ennemi";
                degreAgressivite = cboDegMal.Text.ToString();
                typeArme = cboFiltreArme.Text.ToString();
            }
            if (ckbFiltreNeutre.Checked)
            {
                statut = "Neutre";
            }

            //Ajout des couples clé-valeur au dictionnaire
            filtres.Add("couleur", couleur);
            filtres.Add("nom", nom);
            filtres.Add("planete", planete);
            filtres.Add("statut", statut);
            filtres.Add("degreBienveillance", degreBienveillance);
            filtres.Add("instrumentMusique", instrumentMusique);
            filtres.Add("typeArme", typeArme);
            filtres.Add("degreAgressivite", degreAgressivite);

            bool filtrePresent = false;
            string filtreFinal = string.Empty;

            foreach (String key in filtres.Keys)
            {
                if (key == "statut")
                {
                    //Si pas de statut sélectionné, tous les statuts sont pris en compte
                    if (statut == string.Empty)
                    {
                        filtreFinal += "(statut = 'Allié' OR statut='Ennemi' OR statut = 'Neutre')";
                    }
                    else
                    {
                        //Choix des statuts
                        filtreFinal += "(";
                        if (ckbFiltreAllie.Checked)
                        {
                            filtreFinal += "(" + key + " = '" + "Allié'";
                            //Vérif filtre degreBienveillance
                            if (filtres["degreBienveillance"] != "")
                            {
                                filtreFinal += " AND degreBienveillance = '" + filtres["degreBienveillance"] + "'";
                            }
                            //Vérif filtre instrumentMusique
                            if (filtres["instrumentMusique"] != "")
                            {
                                filtreFinal += " AND instrumentMusique = '" + filtres["instrumentMusique"] + "'";
                            }
                            filtreFinal += ") OR ";
                        }
                        if (ckbFiltreEnnemi.Checked)
                        {
                            filtreFinal += "(" + key + " = '" + "Ennemi'";
                            //Vérif filtre degreAgressivite
                            if (filtres["degreAgressivite"] != "")
                            {
                                filtreFinal += " AND degreAgressivite = '" + filtres["degreAgressivite"] + "'";
                            }
                            //Vérif filtre typeArme
                            if (filtres["typeArme"] != "")
                            {
                                filtreFinal += " AND typeArme = '" + filtres["typeArme"] + "'";
                            }
                            filtreFinal += ") OR ";
                        }
                        if (ckbFiltreNeutre.Checked)
                        {
                            filtreFinal += key + " = 'Neutre' OR";
                        }
                        filtreFinal = filtreFinal.Substring(0, filtreFinal.Length - 3);
                        filtreFinal += ")";
                    }
                }
                if (filtres[key] != string.Empty)
                {
                    //Recherche avec un like pour nom et planète
                    filtrePresent = true;
                    if (key == "nom" || key == "planete")
                    {
                        filtreFinal += key + " like '%" + filtres[key].ToLower() + "%' AND ";
                    }
                    //Recherche classique pour la couleur
                    else if (key == "couleur")
                    {
                        filtreFinal += key + " = '" + filtres[key] + "' AND ";
                    }
                }
            }

            //Si au moins un filtre a été sélectionné
            if (filtrePresent)
            {
                //Recherche filtrée dans la table dtAlien
                DataRow[] rowResultat = MesDatas.DsGlobal.Tables["dtAlien"].Select(filtreFinal);

                //Si il y a des aliens qui correspondent au filtre
                if (rowResultat.Length > 0)
                {
                    DataTable dtFiltre = rowResultat.CopyToDataTable();
                    //Affichage des aliens
                    flpAffichageTrombinoAlien(dtFiltre, flpAffichage);
                }
                //Si aucun alien ne correspond au filtre
                else
                {
                    //Ajout dun label "aucun alien correspondant"
                    MessageBox.Show("pas d'alien avec ces filtres");
                    Label lblAucunResultatFiltre = new System.Windows.Forms.Label();
                    lblAucunResultatFiltre.AutoSize = true;
                    lblAucunResultatFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                    lblAucunResultatFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblAucunResultatFiltre.ForeColor = System.Drawing.Color.White;
                    lblAucunResultatFiltre.Name = "lblAucunResultatFiltre";
                    lblAucunResultatFiltre.Size = new System.Drawing.Size(580, 36);
                    lblAucunResultatFiltre.Text = "Aucun alien correspondant à ces filtres";

                    //Aucun alien dans flpAffichage
                    flpAffichage.Controls.Clear();
                    //Ajout du label
                    flpAffichage.Controls.Add(lblAucunResultatFiltre);
                }

            }
            //Si clic 'Appliquer' sans bouton sélectionné
            else
            {
                //Affichage de la totalité des aliens
                flpAffichageTrombinoAlien(MesDatas.DsGlobal.Tables["dtAlien"], flpAffichage);
            }

        }


        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Vide les filtres du grpBox filtres Aliens et affiche la totalité des aliens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimerFiltre_Click(object sender, EventArgs e)
        {
            txtFiltreNom.Clear();
            cboFiltreCouleur.SelectedItem = null;
            ckbFiltreAllie.Checked = false;
            ckbFiltreEnnemi.Checked = false;
            ckbFiltreNeutre.Checked = false;
            cboDegBien.SelectedItem = null;
            cboFiltrePlanete.SelectedItem = null;
            cboFiltreInstrument.SelectedItem = null;
            cboDegMal.SelectedItem = null;
            cboFiltreArme.SelectedItem = null;

            //Réafficher la totalité des aliens
            flpAffichageTrombinoAlien(MesDatas.DsGlobal.Tables["dtAlien"], flpAffichage);
        }


        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Affiche les détails de l'alien (bienveillance, arme, instrument...) dans un nouveau form après un click sur un UCTrombinoAlien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Clic sur un UCTrombino alien donne le détail dans un nouveau form
        private void clickDetailAlien(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            UCTrombinoExtraterrestre alien = (UCTrombinoExtraterrestre)btn.Parent;

            //Créer le filtre avec le nom de l'alien du UCTrombinoExtraterrestres
            String filtre = "nom = '" + alien.getNomAlien() + "'";

            //Récupérer la ligne de l'alien dans dtAlien
            DataRow[] r = MesDatas.DsGlobal.Tables["dtAlien"].Select(filtre);

            //Création UCExtraterrestresDétail avec des infos complémentaires
            UCExtraterrestresDetail alienDetail = new UCExtraterrestresDetail();

            //Instanciation de alienDetail selon le statut de l'alien
            if (r[0][3].ToString() == "Neutre")
            {
                alienDetail = new UCExtraterrestresDetail(r[0][1].ToString(), r[0][2].ToString(), r[0][3].ToString(), r[0][9].ToString(), r[0][4].ToString(), r[0][6].ToString(), r[0][5].ToString());
            }
            if (r[0][3].ToString() == "Allié")
            {
                alienDetail = new UCExtraterrestresDetail(r[0][1].ToString(), r[0][2].ToString(), r[0][3].ToString(), r[0][9].ToString(), r[0][4].ToString(), r[0][6].ToString(), r[0][5].ToString());
            }
            if (r[0][3].ToString() == "Ennemi")
            {
                alienDetail = new UCExtraterrestresDetail(r[0][1].ToString(), r[0][2].ToString(), r[0][3].ToString(), r[0][9].ToString(), r[0][4].ToString(), r[0][7].ToString(), r[0][8].ToString());
            }

            //Ajout du UC dans un form et affichage
            FormClickDetail frmDetailAlien = new FormClickDetail(alienDetail);
            frmDetailAlien.ShowDialog();
        }

        //===============================================================================================================================================================================
        //      VOLET PLANETES
        //===============================================================================================================================================================================
        /// <summary>
        /// Remplit de UCTrombPlanete flpAffichage avec une table donnée
        /// </summary>
        /// <param name="dt"></param>
        private void flpAffichageTrombinoPlanetes(DataTable dt)
        {
            //Vide le flpAffichage
            flpAffichage.Controls.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Pour chaque planete dans table Planete, on récupère la ligne
                DataRow lignePlanete = dt.Rows[i];
                string nomPlanete = lignePlanete[0].ToString();
                string temperature;
                //Gestion des cases vides : null -> ?
                if (lignePlanete[1] != DBNull.Value)
                {
                    temperature = lignePlanete[1].ToString();
                }
                else
                {
                    temperature = "?";
                }
                string gravite = lignePlanete[2].ToString();
                if (lignePlanete[2] == DBNull.Value)
                {
                    gravite = "?";
                }

                string dataBaz;
                if (lignePlanete[3] != DBNull.Value)
                {
                    dataBaz = lignePlanete[3].ToString();
                }
                else
                {
                    dataBaz = "?";
                }
                //Crée un objet UCTrombPlanete avec les donnees de la dataTable
                UCTrombPlanete planete = new UCTrombPlanete(nomPlanete, temperature, gravite, dataBaz);
                //Associer le délegate au nouvel objet UCTrombPlanete pour que le click soit fonctionnel
                planete.afficheur = clickDetailPlanete;
                //Ajout au flpAffichage
                flpAffichage.Controls.Add(planete);
            }
        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Méthode appelée par le delegate afficheur lors de l'appui sur le bouton "découverte des planetes
        /// Affiche le trombinoscope des planetes sans filtre appliqués, ainsi que le groupBox filtres 
        /// Les UserControl UCTrombPlanete sont ajoutés dans le flpAffichage via la méthode flpAffichageTrombinoPlanetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickDecouvertePlanetes(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            UCBoutonImage btnImage = (UCBoutonImage)btn.Parent;
            //Selectionne ce bouton comme bouton actif
            selectionnerBouton(btnImage);

            //Gestion de l'affichage
            tabAffichage.Visible = false;
            tabControlMission.Visible = false;
            //Afficher les filtres
            grpFiltre.Visible = false;
            grpFiltrePlanete.Visible = true;

            //Bloque les raccourcis claavier dans les txtBox de filtres
            txtTempMin.ShortcutsEnabled = false;
            txtTempMax.ShortcutsEnabled = false;
            txtGraviteMin.ShortcutsEnabled = false;
            txtGraviteMax.ShortcutsEnabled = false;

            //Pamamètres du flpAffichage comprenant les usercontrol
            this.grpFiltrePlanete.Location = new System.Drawing.Point(360, 29);
            flpAffichage.Visible = true;
            flpAffichage.AutoScroll = true;
            flpAffichage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            flpAffichage.Location = new System.Drawing.Point(360, 200);
            flpAffichage.Name = "flpAffichage";
            flpAffichage.Size = new System.Drawing.Size(1053, 610);
            flpAffichage.TabIndex = 11;

            //Ajout du flpAffichage
            this.Controls.Add(flpAffichage);

            //Remplir flpAffichage avec les usercontrols
            flpAffichageTrombinoPlanetes(MesDatas.DsGlobal.Tables["dtPlanetes"]);
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Affiche les détails de la planete (missions effectuées, races présentes...) dans un nouveau form après un click sur un UCTrombPlanetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickDetailPlanete(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            UCTrombPlanete planete = (UCTrombPlanete)btn.Parent;

            //Créer le filtre avec le nom de la planete du UCTrombPlanete
            String filtre = "nom = '" + planete.getNomPlanete() + "'";

            //Récupérer la ligne de la planete dans dtPlanete
            DataRow[] r = MesDatas.DsGlobal.Tables["dtPlanetes"].Select(filtre);

            //Gestion des valeurs "null"
            string temp = "?";
            if (r[0][1].ToString() != string.Empty)
            {
                temp = r[0][1].ToString();
            }
            string gravite = "?";
            if (r[0][2].ToString() != string.Empty)
            {
                gravite = r[0][2].ToString();
            }
            string dataBaz = "?";
            if (r[0][3].ToString() != string.Empty)
            {
                dataBaz = r[0][3].ToString();
            }

            //Création UCPlaneteDetail avec des infos complémentaires
            UCPlaneteDetail planeteDetail = new UCPlaneteDetail(r[0][0].ToString(), temp, gravite, dataBaz);
            FormClickDetail FormClickDetail = new FormClickDetail(planeteDetail);

            //Création d'un label si absence de missions
            Label lblAucunResultatFiltre = new System.Windows.Forms.Label();
            lblAucunResultatFiltre.AutoSize = true;
            lblAucunResultatFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblAucunResultatFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAucunResultatFiltre.ForeColor = System.Drawing.Color.White;
            lblAucunResultatFiltre.Name = "lblAucunResultatFiltre";
            lblAucunResultatFiltre.Size = new System.Drawing.Size(580, 36);

            //Création d'un label si absence d'alien
            Label lblAucunResultatAlien = new System.Windows.Forms.Label();
            lblAucunResultatAlien.AutoSize = true;
            lblAucunResultatAlien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblAucunResultatAlien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAucunResultatAlien.ForeColor = System.Drawing.Color.White;
            lblAucunResultatAlien.Name = "lblAucunResultatFiltre";
            lblAucunResultatAlien.Size = new System.Drawing.Size(580, 36);

            //Remplir le flp des especes présentes sur la planète
            string filtreEspece = "planete like '%" + planeteDetail.nomPlanete + "%'";
            //Récupere les especes présentes sur la planète
            DataRow[] rowResultat = MesDatas.DsGlobal.Tables["dtAlien"].Select(filtreEspece);
            //Si il y a des especes
            if (rowResultat.Length > 0)
            {
                DataTable dtFiltre = rowResultat.CopyToDataTable();
                foreach (DataRow dr in dtFiltre.Rows)
                {
                    string filtrePourcentage = "idEspece = '" + dr[0].ToString() + "' AND nomPlanete = '" + planeteDetail.nomPlanete + "'";
                    //Récuperer les pourcentages des espèces
                    DataRow[] rowPourcentage = MesDatas.DsGlobal.Tables["Habiter"].Select(filtrePourcentage);
                    string pourcentage = "Présence : " + rowPourcentage[0][2].ToString() + "%";

                    //Instancier nouvel objet UCTrombinoExtraterrestre avec le pourcentage
                    UCTrombinoExtraterrestre alien = new UCTrombinoExtraterrestre(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), pourcentage);
                    //Associer le délegate au nouvel objet UCTrombinoExtraterrestre pour que le click soit fonctionnel
                    alien.afficheur = clickDetailAlien;
                    //Ajout au flpRaces du UCPlaneteDétail
                    planeteDetail.getFLPRaces.Controls.Add(alien);
                }
            }
            //Pas d'espece sur cette planete
            else
            {
                //Affichage du label dans le flpRaces du UCPlaneteDétail
                lblAucunResultatAlien.Text = "Aucun alien connu sur cette planète";
                planeteDetail.getFLPRaces.Controls.Add(lblAucunResultatAlien);
            }

            //Remplir le flp des missions sur la planète
            string filtreMission = "nomPlanete like '%" + planeteDetail.nomPlanete + "%'";
            DataRow[] rowResultatMission = MesDatas.DsGlobal.Tables["Mission"].Select(filtreMission);
            //Si il y a ue des missions
            if (rowResultatMission.Length > 0)
            {
                DataTable dtFiltreMission = rowResultatMission.CopyToDataTable();
                for (int i = 0; i < dtFiltreMission.Rows.Count; i++)
                {
                    //Récuperer le nom du chef de mission
                    DataRow ligne = dtFiltreMission.Rows[i];
                    string filtreChefMission = "matricule = '" + ligne[5].ToString() + "'";

                    DataRow[] tabMembre = MesDatas.DsGlobal.Tables["Membre"].Select(filtreChefMission);
                    string nomChef = tabMembre[0][1].ToString() + " " + tabMembre[0][2].ToString();

                    //Instancier nouvel objet UCTrombinoExtraterrestre
                    UCMission mission = new UCMission(ligne[0].ToString(), ligne[1].ToString(), ligne[3].ToString(), ligne[4].ToString(), nomChef, ligne[8].ToString() + "€");
                    //Associer le délegate au nouvel objet mission pour que le bouton 'détail' soit fonctionnel
                    mission.afficher = clickDetailMission;
                    //Ajout au flpMission du UCPlaneteDétail
                    planeteDetail.getFLPMission.Controls.Add(mission);

                }
            }
            //Pas de missions sur cette planète
            else
            {
                //Affichage du label dans le flpMission du UCPlaneteDétail
                lblAucunResultatFiltre.Text = "Aucune mission effectuée sur cette planète";
                planeteDetail.getFLPMission.Controls.Add(lblAucunResultatFiltre);
            }
            //afficher le form
            FormClickDetail.ShowDialog();
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Applique les filtres sélectionnés et remplit le flpAffichage avec les UCTrombPlanete filtrés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppliquerFiltrePlanete_Click(object sender, EventArgs e)
        {
            //Création d'un dictionnaire pour stocker le type de filtre et sa valeur
            Dictionary<string, string> filtres = new Dictionary<string, string>();
            string nom = string.Empty;
            string tempMin = string.Empty;
            string tempMax = string.Empty;
            string graviteMin = string.Empty;
            string graviteMax = string.Empty;
            string dataBaz = string.Empty;

            //Remplissage des valeurs de filtres
            if (txtFiltreNomPlanete.Text != string.Empty)
            {
                nom = txtFiltreNomPlanete.Text;
            }
            if (txtTempMin.Text != string.Empty)
            {
                tempMin = txtTempMin.Text;
            }
            if (txtTempMax.Text != string.Empty)
            {
                tempMax = txtTempMax.Text;
            }
            if (txtGraviteMin.Text != string.Empty)
            {
                graviteMin = txtGraviteMin.Text;
            }
            if (txtGraviteMax.Text != string.Empty)
            {
                graviteMax = txtGraviteMax.Text;
            }
            if (ckbPDataBaz.Checked || ckbADataBaz.Checked || ckbDataBazInconnu.Checked)
            {
                dataBaz = "oui";
            }

            //Ajout des couples clé-valeur au dictionnaire
            filtres.Add("nom", nom);
            filtres.Add("temperature", tempMin);
            filtres.Add("gravite", graviteMin);
            filtres.Add("dataBazON", dataBaz);

            bool filtrePresent = false;
            string filtreFinal = string.Empty;

            foreach (String key in filtres.Keys)
            {
                if (key == "dataBazON")
                {
                    //Si pas de dataBaz sélectionné, tous les dataBaz sont pris en compte
                    if (dataBaz == string.Empty)
                    {
                        filtrePresent = true;
                        filtreFinal += "(dataBazON = '1' OR dataBazON = '0' OR dataBazON IS NULL)";
                    }
                    else
                    {
                        //Choix des dataBaz
                        filtreFinal += "(";
                        filtrePresent = true;
                        if (ckbPDataBaz.Checked)
                        {
                            filtreFinal += "dataBazON = '1' OR ";
                        }
                        if (ckbADataBaz.Checked)
                        {
                            filtreFinal += "dataBazON = '0' OR ";
                        }
                        if (ckbDataBazInconnu.Checked)
                        {
                            filtreFinal += "dataBazON IS NULL OR ";
                        }

                        filtreFinal = filtreFinal.Substring(0, filtreFinal.Length - 3);
                        filtreFinal += ")";
                    }
                }
                if (filtres[key] != string.Empty)
                {
                    //Recherche avec un like pour nom
                    filtrePresent = true;
                    if (key == "nom")
                    {
                        filtreFinal += key + " like '%" + filtres[key].ToLower() + "%' AND ";
                    }
                    //Recherche avec < et > pour la gravité
                    if (key == "gravite")
                    {
                        if (graviteMin != string.Empty)
                        {
                            filtreFinal += key + " >= " + graviteMin + " AND ";
                        }
                        if (graviteMax != string.Empty)
                        {
                            filtreFinal += key + " <= " + graviteMax + " AND ";
                        }
                    }
                    //Recherche avec < et > pour la température
                    if (key == "temperature")
                    {
                        if (tempMin != string.Empty)
                        {
                            filtreFinal += key + " >= " + tempMin + " AND ";
                        }
                        if (tempMax != string.Empty)
                        {
                            filtreFinal += key + " <= " + tempMax + " AND ";
                        }
                    }
                }
            }
            //Si au moins un filtre a été sélectionné
            if (filtrePresent)
            {
                //Recherche filtrée dans la table dtPlanetes
                DataRow[] rowResultat = MesDatas.DsGlobal.Tables["dtPlanetes"].Select(filtreFinal);

                //Si il y a des planetes qui correspondent au filtre
                if (rowResultat.Length > 0)
                {
                    DataTable dtFiltre = rowResultat.CopyToDataTable();
                    //Affichage des planetes
                    flpAffichageTrombinoPlanetes(dtFiltre);
                }
                //Si aucune planète ne correspond au filtre
                else
                {
                    //Ajout dun label "aucune planete correspondant"
                    Label lblAucunResultatFiltre = new System.Windows.Forms.Label();
                    lblAucunResultatFiltre.AutoSize = true;
                    lblAucunResultatFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                    lblAucunResultatFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblAucunResultatFiltre.ForeColor = System.Drawing.Color.White;
                    lblAucunResultatFiltre.Name = "lblAucunResultatFiltre";
                    lblAucunResultatFiltre.Size = new System.Drawing.Size(580, 36);
                    lblAucunResultatFiltre.Text = "Aucune planète correspondant à ces filtres";

                    //Aucune planete dans flpAffichage
                    flpAffichage.Controls.Clear();

                    //Ajout du label
                    flpAffichage.Controls.Add(lblAucunResultatFiltre);
                }

            }
            //Si clic 'Appliquer' sans bouton sélectionné
            else
            {
                //Affichage de la totalité des planetes
                flpAffichageTrombinoPlanetes(MesDatas.DsGlobal.Tables["dtPlanetes"]);
            }
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Vide les filtres du grpBox filtres Planètes et affiche la totalité des planetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimerFiltrePlanete_Click(object sender, EventArgs e)
        {
            txtFiltreNomPlanete.Text = string.Empty;
            txtGraviteMin.Text = string.Empty;
            txtGraviteMax.Text = string.Empty;
            txtTempMax.Text = string.Empty;
            txtTempMin.Text = string.Empty;
            ckbADataBaz.Checked = false;
            ckbDataBazInconnu.Checked = false;
            ckbPDataBaz.Checked = false;

            //Affichage de la totalité des planetes
            flpAffichageTrombinoPlanetes(MesDatas.DsGlobal.Tables["dtPlanetes"]);
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Autorise uniquement la saisie de chiffres et de '-' dans la textBox txtTempMin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempMin_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (txtTempMin.SelectionStart != 0 && e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Autorise uniquement la saisie de chiffres et de '-' dans la textBox txtTempMax
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtTempMax_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            if (txtTempMax.SelectionStart != 0 && e.KeyChar == '-')
            {
                e.Handled = true;
            }
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Autorise uniquement la saisie de chiffres et de points dans la textBox txtGraviteMin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGraviteMin_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool contientVirgule = false;

            //Si le caractère entré n'est chiffre ou caractère autorisé, interdit d'écrire
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            //Si y'a une virgule bool a true
            contientVirgule = txtGraviteMin.Text.Contains('.');

            //Si le caractère est une virgule
            if (e.KeyChar == '.')
            {
                //déja une virgule
                if (contientVirgule)
                {
                    //Pas le droit d'écrire
                    e.Handled = true;
                }
                if (txtGraviteMin.SelectionStart == 0)
                {
                    txtGraviteMin.Text = "0";
                    contientVirgule = true;
                    txtGraviteMin.SelectionStart += 2;
                }

            }

            //Si le caractère est un point
            if (e.KeyChar == ',')
            {
                //Remplacer point par virgule
                e.KeyChar = '.';

                //déja une virgule
                if (contientVirgule)
                {
                    //Pas le droit d'écrire
                    e.Handled = true;
                }
                else
                {
                    if (txtGraviteMin.SelectionStart == 0)
                    {
                        txtGraviteMin.Text = "0";
                        contientVirgule = true;
                        txtGraviteMin.SelectionStart += 2;
                    }
                }

            }
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Autorise uniquement la saisie de chiffres et de points dans la textBox txtGraviteMax
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGraviteMax_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool contientVirgule = false;

            //Si le caractère entré n'est chiffre ou caractère autorisé, interdit d'écrire
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            //Si y'a une virgule bool a true
            contientVirgule = txtGraviteMax.Text.Contains('.');

            //Si le caractère est une virgule
            if (e.KeyChar == '.')
            {
                //déja une virgule
                if (contientVirgule)
                {
                    //Pas le droit d'écrire
                    e.Handled = true;
                }
                if (txtGraviteMax.SelectionStart == 0)
                {
                    txtGraviteMax.Text = "0";
                    contientVirgule = true;
                    txtGraviteMax.SelectionStart += 2;
                }

            }

            //Si le caractère est un point
            if (e.KeyChar == ',')
            {
                //Remplacer point par virgule
                e.KeyChar = '.';

                //déja une virgule
                if (contientVirgule)
                {
                    //Pas le droit d'écrire
                    e.Handled = true;
                }
                else
                {
                    if (txtGraviteMax.SelectionStart == 0)
                    {
                        txtGraviteMax.Text = "0";
                        contientVirgule = true;
                        txtGraviteMax.SelectionStart += 2;
                    }
                }

            }
        }
        //===============================================================================================================================================================================
        //      VOLET STATISTIQUES
        //===============================================================================================================================================================================
        /// <summary>
        /// Affiche un TabControl avec plusieurs Tab correspondant a des requêtes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickStatistiques(object sender, EventArgs e)
        {
            //Cast de l'object sender en "Control"
            //On doit caster en "Control" et pas en UCBoutonImage parce que sender est l’objet EXACT qui a déclenché l’événement
            //Ici, l'évenement est le click sur boutonImage ou lblImage ou pictureBox
            Control btn = (Control)sender;
            //Récupération du UserControl parent
            UCBoutonImage btnImage = (UCBoutonImage)btn.Parent;
            selectionnerBouton(btnImage);

            //Gestion affichage
            tabAffichage.Visible = true;
            tabControlMission.Visible = false;
            grpFiltre.Visible = false;
            grpFiltrePlanete.Visible = false;
            if (flpAffichage != null)
            {
                flpAffichage.Visible = false;
            }

            //Tab1 : Liste de toutes les personnes (nom, prénom, type (militaire ou civil)) avec laquelle un membre est déjà parti en mission.

            cboTab1MembreMission.DataSource = Statistiques.ObtenirMembreNomPrenom();
            cboTab1MembreMission.DisplayMember = "NomPrenom";
            cboTab1MembreMission.ValueMember = "matricule";

            //Tab 2 : Pour les missions comportant un équipage de plus de 10 personnes, indiquer la liste des dépenses effectuées, ainsi que les budgets initiaux et actuels.
            dgvTab2.DataSource = Statistiques.MissionPlusDixMembre();
            dgvTab2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Tab 3 : Pour chaque planète, indiquer le nombre de missions qui y ont déjà eu lieu.

            //Eviter les doublons de jeu de données
            graphMissionPlanetes.Series.Clear();

            //Remplir les données du graphique
            Series donnees = new Series();

            //Type de graph : histogramme
            donnees.ChartType = SeriesChartType.Column;

            //Caacher la légende du graphique
            donnees.IsVisibleInLegend = false;

            //Afficher les valeurs au dessus des colonnes et en blanc
            donnees.IsValueShownAsLabel = true;
            donnees.LabelForeColor = Color.White;

            //Ajouter les valeurs nom-nombre mission dans les données
            foreach (DataRow row in Statistiques.NbMissionSurPlanet().Rows)
            {
                donnees.Points.AddXY(row["nom"], row["NombreMission"]);
            }

            //Modification de la zone graphique pour pouvoir avoir toutes les planètes affichées
            //ChartAeras est une liste de zones graphiques
            graphMissionPlanetes.ChartAreas[0].AxisX.Interval = 1;
            graphMissionPlanetes.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            //Que des entiers sur y
            graphMissionPlanetes.ChartAreas[0].AxisY.Interval = 1;

            //Supprimer les lignes de fond
            graphMissionPlanetes.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            graphMissionPlanetes.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;

            //Ajouter les données dans le graphique
            graphMissionPlanetes.Series.Add(donnees);


            //Tab 4 : Liste des dépenses (date, motif et montant concaténés dans une seule colonne intitulée « Dépenses les plus importantes »),
            //nom de la mission et nom et prénom du chef de la mission, pour les dépenses les plus élevées de chaque mission.
            dgvTab4Depenses.DataSource = Statistiques.DepensePlusElever();
            //Prendre toute la largeur du dgv
            dgvTab4Depenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //La première colonne doit afficher tout son contenu
            dgvTab4Depenses.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //Tab 5 :  Quels sont les informateurs (nom de code, espèce d’origine, somme totale reçue) qui ont perçu le moins d’argent pendant une mission donnée?

            //Remplissage de la comboBox avec les noms des missions
            
            cboTab5Missions.DataSource = Statistiques.ObtenirNomMission();
            
            cboTab5Missions.DisplayMember = "mission";
            
            cboTab5Missions.ValueMember = "mission";


        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Lorsque la sélection du membre est changée, le dataGridView est mis à jour avec les informations du nouveau membre sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTab1MembreMission_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTab1MembreMission.SelectedValue is DataRowView) { return; }
            
                //récupération du matricule du membre sélectionné
                string matricule = cboTab1MembreMission.SelectedValue.ToString();
                //Si le membre a des copains de mission
                if (Statistiques.ObtenirMembreMemeMissionStatut(matricule).Rows.Count == 0)
                {
                    //Vide le dgv
                    dgvTab1CopainMission.DataSource = "";
                    //Affichage "aucun résultat"
                    lblAucunResultat.Visible = true;
                }
                else
                {
                    lblAucunResultat.Visible = false;
                    //Remplit le dgv avec le résultat de la requête
                    dgvTab1CopainMission.DataSource = Statistiques.ObtenirMembreMemeMissionStatut(matricule);
                    //les données prennent toute la largeur du dgv
                    dgvTab1CopainMission.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            
            
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Lorsque la sélection de la mission est changée, le dataGridView est mis à jour avec les informations de la nouvelle mission sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTab5Missions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTab5Missions.SelectedValue is DataRowView) {  return; }
            string nomMission = cboTab5Missions.SelectedValue.ToString();

                string nomPlanete = "";
                string numeroMission = "";

                //Séparer nom planète et numéro mission
                for (int i = 0; i < nomMission.Length; i++)
                {
                    if (char.IsDigit(nomMission[i]))
                    {
                        numeroMission += nomMission[i];
                    }
                    else
                    {
                        nomPlanete += nomMission[i];
                    }
                }
                //Remplit le dgv avec le résultat de la requête
                dgvTab5Informateur.DataSource = Statistiques.InformateurMoinsCher(numeroMission, nomPlanete);
                //les données prennent toute la largeur du dgv
                dgvTab5Informateur.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            

        }

    }
}

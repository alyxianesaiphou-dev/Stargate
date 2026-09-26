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
using UserControlExtraterrestresDetail;
using UserControlMission;
using UserControlPlanete;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Form_Sae24_Stargate
{


    public partial class FormAccueil : Form
    {
        //flpAffichage partagé par trombinoAlien et trombinoPlanete
        private FlowLayoutPanel flpAffichage;

        //UCBtn permettant de savoir quel bouton est sélectionné et le colorer
        private UCBoutonImage btnActif = null;

        //Vrai pendant qu'on vide tous les filtres d'un coup, pour ne réafficher qu'une fois à la fin
        private bool majFiltresSuspendue = false;

        public FormAccueil()
        {
            InitializeComponent();

            //Les filtres aliens et planètes s'appliquent dès qu'on les change
            BrancherFiltresAutomatiques();

            //tout s'agrandit ou se réduit avec l'écran
            AdaptationEcran.Activer(this);
            //la zone des cartes suit le cadre des filtres (après la mise à l'échelle)
            this.Resize += delegate { PlacerCartes(); };
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
            //placée en pixels réels sous le cadre des filtres (voir PlacerCartes)
            AdaptationEcran.PlacementLibre(flpAffichage);

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
        private void PlacerTrombino(GroupBox filtres)
        {
            //Le trombinoscope (aliens ou planètes) va du bord gauche habituel (360) jusqu'au bord droit
            //des statistiques, sans jamais dépasser de la fenêtre : les filtres en haut, les cartes en
            //dessous (on fait défiler à la molette)
            System.Drawing.Rectangle zone = AdaptationEcran.BornesDeBase(tabAffichage);
            System.Drawing.Rectangle zoneFiltres = AdaptationEcran.BornesDeBase(filtres);
            System.Drawing.Size fenetre = AdaptationEcran.TailleDeBase(this);

            int gauche = 360;
            int droite = Math.Min(zone.Right, fenetre.Width - 20);

            filtres.Location = new System.Drawing.Point(gauche, zone.Top);
            filtres.Size = new System.Drawing.Size(droite - gauche, zoneFiltres.Height);

            //les filtres des alliés et des ennemis (affichés en cochant Allié / Ennemi) collés à droite,
            //sans recouvrir les autres filtres
            int largeurFiltres = droite - gauche;
            int finAutresFiltres = 0;
            foreach (Control controle in filtres.Controls)
            {
                if (!(controle is GroupBox))
                {
                    finAutresFiltres = Math.Max(finAutresFiltres, AdaptationEcran.BornesDeBase(controle).Right);
                }
            }
            foreach (Control sousFiltre in filtres.Controls)
            {
                if (sousFiltre is GroupBox)
                {
                    System.Drawing.Rectangle bornes = AdaptationEcran.BornesDeBase(sousFiltre);
                    int x = Math.Max(finAutresFiltres + 6, largeurFiltres - 8 - bornes.Width);
                    sousFiltre.Location = new System.Drawing.Point(x, bornes.Top);
                    sousFiltre.Size = new System.Drawing.Size(Math.Min(bornes.Width, largeurFiltres - 8 - x), bornes.Height);
                }
            }

            filtresActifs = filtres;
            PlacerCartes();
        }

        //cadre des filtres affiché au-dessus des cartes (aliens ou planètes)
        private GroupBox filtresActifs = null;

        /// <summary>
        /// Place la zone des cartes juste sous le cadre des filtres, exactement aussi large que lui,
        /// et jusqu'en bas des statistiques sans sortir de la fenêtre. On part de la position réelle
        /// du cadre à l'écran, pour que les cartes ne dépassent jamais, quel que soit l'écran.
        /// </summary>
        private void PlacerCartes()
        {
            if (flpAffichage == null || filtresActifs == null)
            {
                return;
            }
            float facteur = AdaptationEcran.Facteur(this);
            int haut = filtresActifs.Bottom + (int)Math.Round(8 * facteur);
            int bas = Math.Min(tabAffichage.Bottom, this.ClientSize.Height - (int)Math.Round(20 * facteur));
            flpAffichage.Bounds = new System.Drawing.Rectangle(filtresActifs.Left, haut, filtresActifs.Width, Math.Max(0, bas - haut));
        }

        private void selectionnerBouton(UCBoutonImage btnSelect)
        {
            //S'il y a un bouton sélectionné, on remet sa couleur
            if (btnActif != null)
            {
                btnActif.retablirCouleur();
            }

            //Changer la couleur du bouton sélectionné
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
            //Cast de l'objet sender en "Control"
            //On doit caster en "Control" et pas en UCBoutonImage parce que sender est l’objet EXACT qui a déclenché l’événement
            //Ici, l'événement est le click sur boutonImage ou lblImage ou pictureBox
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

                //Récupérer le nom du chef à partir du matricule
                DataRow[] tabMembre = MesDatas.DsGlobal.Tables["Membre"].Select(filtreChefMission);
                string nomChef = tabMembre[0][1].ToString() + " " + tabMembre[0][2].ToString();

                //Nouvel objet mission
                UCMission mission = new UCMission(ligne[0].ToString(), ligne[1].ToString(), ligne[3].ToString(), ligne[4].ToString(), nomChef, ligne[8].ToString() + "€");

                //Associer le délégué au nouvel objet mission pour que le bouton 'détail' soit fonctionnel
                mission.afficher = clickDetailMission;

                //Ajout des usercontrol mission dans le flp correspondant à leur statut (en cours, terminée, à venir)
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
                //Pour chaque espèce dans table Espece, on récupère la ligne
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

                //Filtre sur quelles planètes sont idEspece
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
        /// Remplit de cartes CarteAlien un flowLayoutPanel donné avec une table donnée
        /// Permet de sélectionner une table filtrée, ainsi que soit le flp du bouton découverte alien, soit celui de détail planètes
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

            CarteMembre.CentrerColonnes(flp, CarteAlien.Largeur, CarteAlien.Marge);

            foreach (DataRow dr in table.Rows)
            {
                //Crée une carte avec les données de la dataTable, et les planètes habitées en bas
                string planetes = dr["planete"].ToString() == "Inconnu" ? "Planète inconnue" : dr["planete"].ToString().Replace("/", ", ");
                CarteAlien alien = CarteAlien.DepuisLigne(dr, planetes);
                //Un clic sur la carte ouvre le détail de l'alien
                alien.Clic += clickDetailAlien;
                //Ajout au flp
                flp.Controls.Add(alien);
            }
        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Méthode appelée par le delegate afficheur lors de l'appui sur le bouton "découverte des aliens
        /// Affiche le trombinoscope des aliens sans filtre appliqué, ainsi que le groupBox filtres 
        /// Les cartes CarteAlien sont ajoutées dans le flpAffichage via la méthode flpAffichageTrombinoAlien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickDecouverteAliens(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            UCBoutonImage btnImage = (UCBoutonImage)btn.Parent;
            //Sélectionne ce bouton comme bouton actif
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
                //Compléter la comboBox de filtre planète par ordre alphabétique
                if (!cboFiltrePlanete.Items.Contains(dr["nom"].ToString()))
                {
                    cboFiltrePlanete.Items.Add(dr["nom"].ToString());
                    cboFiltrePlanete.Sorted = true;
                }
            }

            //Choix vide en tête des listes pour ne rien filtrer
            ComboVide.AjouterChoixVide(cboFiltreCouleur);
            ComboVide.AjouterChoixVide(cboFiltrePlanete);

            //Paramètres du flpAffichage comprenant les usercontrol
            flpAffichage.Visible = true;
            flpAffichage.AutoScroll = true;
            flpAffichage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            flpAffichage.Name = "flpAffichage";
            flpAffichage.TabIndex = 11;
            PlacerTrombino(grpFiltre);

            //Ajout du flpAffichage
            this.Controls.Add(flpAffichage);

            //Remplir flpAffichage avec les aliens qui respectent les filtres déjà choisis
            AppliquerFiltresAliens();

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
                ComboVide.AjouterChoixVide(cboFiltreInstrument);
                ComboVide.AjouterChoixVide(cboDegBien);
            }
            if (!ckbFiltreAllie.Checked)
            {
                //Masque les filtres si Alliés non checked
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
                ComboVide.AjouterChoixVide(cboDegMal);
                ComboVide.AjouterChoixVide(cboFiltreArme);
            }
            if (!ckbFiltreEnnemi.Checked)
            {
                //Masque les filtres si Ennemis non checked
                gpbFiltreEnnemi.Visible = false;
            }
        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Applique les filtres sélectionnés et remplit le flpAffichage avec les cartes des aliens filtrés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppliquerFiltre_Click(object sender, EventArgs e)
        {
            AppliquerFiltresAliens();
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Affiche dans flpAffichage les cartes des aliens qui respectent tous les filtres choisis.
        /// Un filtre laissé vide ne filtre rien. Si aucun statut n'est coché, tous les statuts sont gardés ;
        /// sinon on garde les aliens d'un des statuts cochés, avec les filtres propres à ce statut
        /// (bienveillance et instrument pour les alliés, agressivité et arme pour les ennemis).
        /// </summary>
        private void AppliquerFiltresAliens()
        {
            if (majFiltresSuspendue || flpAffichage == null)
            {
                return;
            }

            string nom = txtFiltreNom.Text.Trim();
            string couleur = cboFiltreCouleur.Text;
            string planete = cboFiltrePlanete.Text;
            bool allie = ckbFiltreAllie.Checked;
            bool ennemi = ckbFiltreEnnemi.Checked;
            bool neutre = ckbFiltreNeutre.Checked;
            bool statutChoisi = allie || ennemi || neutre;

            List<DataRow> resultat = new List<DataRow>();
            foreach (DataRow dr in MesDatas.DsGlobal.Tables["dtAlien"].Rows)
            {
                //Nom : contient le texte tapé, sans tenir compte des majuscules
                if (nom != string.Empty && dr["nom"].ToString().IndexOf(nom, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }
                //Couleur : exactement celle choisie
                if (couleur != string.Empty && dr["couleur"].ToString() != couleur)
                {
                    continue;
                }
                //Planète : l'alien habite exactement cette planète (pas juste un nom qui la contient)
                if (planete != string.Empty && !dr["planete"].ToString().Split('/').Contains(planete))
                {
                    continue;
                }
                //Statut
                if (statutChoisi)
                {
                    string statut = dr["statut"].ToString();
                    bool garde = false;
                    if (allie && statut == "Allié"
                        && (cboDegBien.Text == string.Empty || dr["degreBienveillance"].ToString() == cboDegBien.Text)
                        && (cboFiltreInstrument.Text == string.Empty || dr["instrumentMusique"].ToString() == cboFiltreInstrument.Text))
                    {
                        garde = true;
                    }
                    if (ennemi && statut == "Ennemi"
                        && (cboDegMal.Text == string.Empty || dr["degreAgressivite"].ToString() == cboDegMal.Text)
                        && (cboFiltreArme.Text == string.Empty || dr["typeArme"].ToString() == cboFiltreArme.Text))
                    {
                        garde = true;
                    }
                    if (neutre && statut == "Neutre")
                    {
                        garde = true;
                    }
                    if (!garde)
                    {
                        continue;
                    }
                }
                resultat.Add(dr);
            }

            if (resultat.Count > 0)
            {
                flpAffichageTrombinoAlien(resultat.CopyToDataTable(), flpAffichage);
            }
            else
            {
                AfficherAucunResultat("Aucun alien correspondant à ces filtres");
            }
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Vide flpAffichage et y affiche un message quand aucun résultat ne correspond aux filtres
        /// </summary>
        private void AfficherAucunResultat(string message)
        {
            System.Windows.Forms.Label lblAucunResultatFiltre = new System.Windows.Forms.Label();
            lblAucunResultatFiltre.AutoSize = true;
            lblAucunResultatFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblAucunResultatFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAucunResultatFiltre.ForeColor = System.Drawing.Color.White;
            lblAucunResultatFiltre.Name = "lblAucunResultatFiltre";
            lblAucunResultatFiltre.Size = new System.Drawing.Size(580, 36);
            lblAucunResultatFiltre.Text = message;

            flpAffichage.Controls.Clear();
            flpAffichage.Controls.Add(lblAucunResultatFiltre);
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Les filtres s'appliquent tout seuls dès qu'on tape ou coche quelque chose
        /// (le bouton Appliquer marche toujours). Les listes des filtres ne se tapent plus à la main :
        /// on choisit forcément une valeur qui existe.
        /// </summary>
        private void BrancherFiltresAutomatiques()
        {
            System.Windows.Forms.ComboBox[] listesAliens = { cboFiltreCouleur, cboFiltrePlanete, cboDegBien, cboFiltreInstrument, cboDegMal, cboFiltreArme };
            foreach (System.Windows.Forms.ComboBox cbo in listesAliens)
            {
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo.SelectedIndexChanged += delegate { if (grpFiltre.Visible) AppliquerFiltresAliens(); };
            }
            txtFiltreNom.TextChanged += delegate { if (grpFiltre.Visible) AppliquerFiltresAliens(); };
            foreach (System.Windows.Forms.CheckBox ckb in new[] { ckbFiltreAllie, ckbFiltreEnnemi, ckbFiltreNeutre })
            {
                ckb.CheckedChanged += delegate { if (grpFiltre.Visible) AppliquerFiltresAliens(); };
            }

            foreach (System.Windows.Forms.TextBox txt in new[] { txtFiltreNomPlanete, txtTempMin, txtTempMax, txtGraviteMin, txtGraviteMax })
            {
                txt.TextChanged += delegate { if (grpFiltrePlanete.Visible) AppliquerFiltresPlanetes(); };
            }
            foreach (System.Windows.Forms.CheckBox ckb in new[] { ckbPDataBaz, ckbADataBaz, ckbDataBazInconnu })
            {
                ckb.CheckedChanged += delegate { if (grpFiltrePlanete.Visible) AppliquerFiltresPlanetes(); };
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
            //On vide tout d'abord, puis on réaffiche une seule fois
            majFiltresSuspendue = true;
            txtFiltreNom.Clear();
            ComboVide.Vider(cboFiltreCouleur);
            ckbFiltreAllie.Checked = false;
            ckbFiltreEnnemi.Checked = false;
            ckbFiltreNeutre.Checked = false;
            ComboVide.Vider(cboDegBien);
            ComboVide.Vider(cboFiltrePlanete);
            ComboVide.Vider(cboFiltreInstrument);
            ComboVide.Vider(cboDegMal);
            ComboVide.Vider(cboFiltreArme);
            majFiltresSuspendue = false;

            //Réafficher la totalité des aliens
            AppliquerFiltresAliens();
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Affiche les détails de l'alien (bienveillance, arme, instrument...) dans un nouveau form après un clic sur une carte alien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Clic sur une carte alien donne le détail dans un nouveau form
        private void clickDetailAlien(object sender, EventArgs e)
        {
            CarteAlien alien = (CarteAlien)sender;

            //Créer le filtre avec le nom de l'alien de la carte
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
        /// Remplit de cartes CartePlanete flpAffichage avec une table donnée
        /// </summary>
        /// <param name="dt"></param>
        private void flpAffichageTrombinoPlanetes(DataTable dt)
        {
            //Vide le flpAffichage
            flpAffichage.Controls.Clear();
            CarteMembre.CentrerColonnes(flpAffichage, CartePlanete.Largeur, CartePlanete.Marge);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Pour chaque planète dans table Planete, on récupère la ligne
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
                //Crée une carte planète avec les données de la dataTable
                CartePlanete planete = new CartePlanete(nomPlanete, temperature, gravite, dataBaz);
                //Un clic sur la carte ouvre le détail de la planète
                planete.Clic += clickDetailPlanete;
                //Ajout au flpAffichage
                flpAffichage.Controls.Add(planete);
            }
        }

        /****************************************************************************************************************************************************************************/

        /// <summary>
        /// Méthode appelée par le delegate afficheur lors de l'appui sur le bouton "découverte des planètes
        /// Affiche le trombinoscope des planètes sans filtre appliqué, ainsi que le groupBox filtres 
        /// Les cartes CartePlanete sont ajoutées dans le flpAffichage via la méthode flpAffichageTrombinoPlanetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickDecouvertePlanetes(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            UCBoutonImage btnImage = (UCBoutonImage)btn.Parent;
            //Sélectionne ce bouton comme bouton actif
            selectionnerBouton(btnImage);

            //Gestion de l'affichage
            tabAffichage.Visible = false;
            tabControlMission.Visible = false;
            //Afficher les filtres
            grpFiltre.Visible = false;
            grpFiltrePlanete.Visible = true;

            //Bloque les raccourcis clavier dans les txtBox de filtres
            txtTempMin.ShortcutsEnabled = false;
            txtTempMax.ShortcutsEnabled = false;
            txtGraviteMin.ShortcutsEnabled = false;
            txtGraviteMax.ShortcutsEnabled = false;

            //Paramètres du flpAffichage comprenant les usercontrol
            flpAffichage.Visible = true;
            flpAffichage.AutoScroll = true;
            flpAffichage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            flpAffichage.Name = "flpAffichage";
            flpAffichage.TabIndex = 11;
            PlacerTrombino(grpFiltrePlanete);

            //Ajout du flpAffichage
            this.Controls.Add(flpAffichage);

            //Remplir flpAffichage avec les planètes qui respectent les filtres déjà choisis
            AppliquerFiltresPlanetes();
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Affiche les détails de la planète (missions effectuées, races présentes...) dans un nouveau form après un clic sur une carte planète
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clickDetailPlanete(object sender, EventArgs e)
        {
            CartePlanete planete = (CartePlanete)sender;

            //Créer le filtre avec le nom de la planète de la carte
            String filtre = "nom = '" + planete.getNomPlanete() + "'";

            //Récupérer la ligne de la planète dans dtPlanete
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

            //Remplir le flp des espèces présentes sur la planète
            //Récupère les espèces présentes sur cette planète exactement (pas celles d'une planète au nom proche)
            DataRow[] rowResultat = MesDatas.DsGlobal.Tables["dtAlien"].AsEnumerable()
                .Where(ligneAlien => ligneAlien["planete"].ToString().Split('/').Contains(planeteDetail.nomPlanete)).ToArray();
            //S'il y a des espèces
            if (rowResultat.Length > 0)
            {
                DataTable dtFiltre = rowResultat.CopyToDataTable();
                FlowLayoutPanel flpRaces = planeteDetail.getFLPRaces;
                CarteMembre.CentrerColonnes(flpRaces, CarteAlien.Largeur, CarteAlien.Marge);
                //recentre si la fenêtre agrandit le panneau à l'affichage
                flpRaces.Resize += delegate { CarteMembre.CentrerColonnes(flpRaces, CarteAlien.Largeur, CarteAlien.Marge); };
                foreach (DataRow dr in dtFiltre.Rows)
                {
                    string filtrePourcentage = "idEspece = '" + dr[0].ToString() + "' AND nomPlanete = '" + planeteDetail.nomPlanete + "'";
                    //Récupérer les pourcentages des espèces
                    DataRow[] rowPourcentage = MesDatas.DsGlobal.Tables["Habiter"].Select(filtrePourcentage);
                    string pourcentage = "Présence : " + rowPourcentage[0][2].ToString() + "%";

                    //Carte de l'espèce avec son pourcentage de présence en bas
                    CarteAlien alien = CarteAlien.DepuisLigne(dr, pourcentage);
                    //Un clic sur la carte ouvre le détail de l'alien
                    alien.Clic += clickDetailAlien;
                    //Ajout au flpRaces du UCPlaneteDétail
                    planeteDetail.getFLPRaces.Controls.Add(alien);
                }
            }
            //Pas d'espèce sur cette planète
            else
            {
                //Affichage du label dans le flpRaces du UCPlaneteDétail
                lblAucunResultatAlien.Text = "Aucun alien connu sur cette planète";
                planeteDetail.getFLPRaces.Controls.Add(lblAucunResultatAlien);
            }

            //Remplir le flp des missions sur la planète
            string filtreMission = "nomPlanete = '" + planeteDetail.nomPlanete.Replace("'", "''") + "'";
            DataRow[] rowResultatMission = MesDatas.DsGlobal.Tables["Mission"].Select(filtreMission);
            //S'il y a eu des missions
            if (rowResultatMission.Length > 0)
            {
                DataTable dtFiltreMission = rowResultatMission.CopyToDataTable();
                for (int i = 0; i < dtFiltreMission.Rows.Count; i++)
                {
                    //Récupérer le nom du chef de mission
                    DataRow ligne = dtFiltreMission.Rows[i];
                    string filtreChefMission = "matricule = '" + ligne[5].ToString() + "'";

                    DataRow[] tabMembre = MesDatas.DsGlobal.Tables["Membre"].Select(filtreChefMission);
                    string nomChef = tabMembre[0][1].ToString() + " " + tabMembre[0][2].ToString();

                    //Instancier nouvel objet UCMission
                    UCMission mission = new UCMission(ligne[0].ToString(), ligne[1].ToString(), ligne[3].ToString(), ligne[4].ToString(), nomChef, ligne[8].ToString() + "€");
                    //Associer le délégué au nouvel objet mission pour que le bouton 'détail' soit fonctionnel
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
        /// Applique les filtres sélectionnés et remplit le flpAffichage avec les cartes des planètes filtrées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppliquerFiltrePlanete_Click(object sender, EventArgs e)
        {
            AppliquerFiltresPlanetes();
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Affiche dans flpAffichage les cartes des planètes qui respectent tous les filtres choisis.
        /// Un champ vide ne filtre rien. Dès qu'une borne de température ou de gravité est remplie,
        /// seules les planètes dont la valeur est connue et respecte cette borne restent
        /// (une planète à température inconnue n'apparaît pas avec « température minimum : 10 »).
        /// Les cases DataBaz gardent les planètes d'une des catégories cochées (aucune cochée = toutes).
        /// </summary>
        private void AppliquerFiltresPlanetes()
        {
            if (majFiltresSuspendue || flpAffichage == null)
            {
                return;
            }

            string nom = txtFiltreNomPlanete.Text.Trim();
            decimal? tempMin = LireNombre(txtTempMin.Text);
            decimal? tempMax = LireNombre(txtTempMax.Text);
            decimal? graviteMin = LireNombre(txtGraviteMin.Text);
            decimal? graviteMax = LireNombre(txtGraviteMax.Text);
            bool dataBazChoisi = ckbPDataBaz.Checked || ckbADataBaz.Checked || ckbDataBazInconnu.Checked;

            DataTable dtPlanetes = MesDatas.DsGlobal.Tables["dtPlanetes"];
            DataTable dtFiltre = dtPlanetes.Clone();
            foreach (DataRow dr in dtPlanetes.Rows)
            {
                //Nom : contient le texte tapé, sans tenir compte des majuscules
                if (nom != string.Empty && dr["nom"].ToString().IndexOf(nom, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }
                if (!DansLesBornes(dr["temperature"], tempMin, tempMax) || !DansLesBornes(dr["gravite"], graviteMin, graviteMax))
                {
                    continue;
                }
                if (dataBazChoisi)
                {
                    string dataBaz = dr["dataBazON"] == DBNull.Value ? string.Empty : Convert.ToInt32(dr["dataBazON"]).ToString();
                    bool garde = (ckbPDataBaz.Checked && dataBaz == "1")
                        || (ckbADataBaz.Checked && dataBaz == "0")
                        || (ckbDataBazInconnu.Checked && dataBaz == string.Empty);
                    if (!garde)
                    {
                        continue;
                    }
                }
                dtFiltre.ImportRow(dr);
            }

            if (dtFiltre.Rows.Count > 0)
            {
                flpAffichageTrombinoPlanetes(dtFiltre);
            }
            else
            {
                AfficherAucunResultat("Aucune planète correspondant à ces filtres");
            }
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Lit un nombre tapé dans un filtre (virgule ou point acceptés). Renvoie null si le champ est vide
        /// ou pas encore un nombre complet (par exemple juste « - »), pour ne pas filtrer pendant la frappe.
        /// </summary>
        private static decimal? LireNombre(string texte)
        {
            decimal valeur;
            string nombre = texte.Trim().Replace(',', '.');
            if (decimal.TryParse(nombre, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out valeur))
            {
                return valeur;
            }
            return null;
        }

        /// <summary>
        /// Vrai si la valeur respecte le minimum et le maximum demandés (bornes comprises).
        /// Une valeur inconnue ne respecte aucune borne.
        /// </summary>
        private static bool DansLesBornes(object valeur, decimal? min, decimal? max)
        {
            if (min == null && max == null)
            {
                return true;
            }
            if (valeur == null || valeur == DBNull.Value)
            {
                return false;
            }
            decimal nombre;
            if (!decimal.TryParse(Convert.ToString(valeur, System.Globalization.CultureInfo.InvariantCulture), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out nombre))
            {
                return false;
            }
            return (min == null || nombre >= min) && (max == null || nombre <= max);
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Vide les filtres du grpBox filtres Planètes et affiche la totalité des planètes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimerFiltrePlanete_Click(object sender, EventArgs e)
        {
            //On vide tout d'abord, puis on réaffiche une seule fois
            majFiltresSuspendue = true;
            txtFiltreNomPlanete.Text = string.Empty;
            txtGraviteMin.Text = string.Empty;
            txtGraviteMax.Text = string.Empty;
            txtTempMax.Text = string.Empty;
            txtTempMin.Text = string.Empty;
            ckbADataBaz.Checked = false;
            ckbDataBazInconnu.Checked = false;
            ckbPDataBaz.Checked = false;
            majFiltresSuspendue = false;

            //Affichage de la totalité des planètes
            AppliquerFiltresPlanetes();
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Autorise uniquement la saisie d'un nombre entier, avec un seul '-' au début, dans la textBox txtTempMin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !ToucheEntierAutorisee(txtTempMin, e.KeyChar);
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Autorise uniquement la saisie d'un nombre entier, avec un seul '-' au début, dans la textBox txtTempMax
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTempMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !ToucheEntierAutorisee(txtTempMax, e.KeyChar);
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Autorise uniquement la saisie d'un nombre à virgule dans la textBox txtGraviteMin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGraviteMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ToucheDecimalAutorisee(txtGraviteMin, e);
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Autorise uniquement la saisie d'un nombre à virgule dans la textBox txtGraviteMax
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGraviteMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            ToucheDecimalAutorisee(txtGraviteMax, e);
        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Texte qu'aurait la textBox si la touche tapée remplaçait la sélection actuelle
        /// </summary>
        private static string TexteSansSelection(System.Windows.Forms.TextBox txt)
        {
            return txt.Text.Remove(txt.SelectionStart, txt.SelectionLength);
        }

        /// <summary>
        /// Chiffres, effacement, et un seul '-' placé au tout début
        /// </summary>
        private static bool ToucheEntierAutorisee(System.Windows.Forms.TextBox txt, char touche)
        {
            if (char.IsDigit(touche) || char.IsControl(touche))
            {
                return true;
            }
            if (touche == '-')
            {
                return txt.SelectionStart == 0 && !TexteSansSelection(txt).Contains('-');
            }
            return false;
        }

        /// <summary>
        /// Chiffres, effacement, et un seul séparateur décimal (la virgule est changée en point)
        /// </summary>
        private static void ToucheDecimalAutorisee(System.Windows.Forms.TextBox txt, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = '.';
                e.Handled = TexteSansSelection(txt).Contains('.');
                return;
            }
            e.Handled = true;
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
            //Cast de l'objet sender en "Control"
            //On doit caster en "Control" et pas en UCBoutonImage parce que sender est l’objet EXACT qui a déclenché l’événement
            //Ici, l'événement est le click sur boutonImage ou lblImage ou pictureBox
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

            ComboVide.Remplir(cboTab1MembreMission, Statistiques.ObtenirMembreNomPrenom(), "NomPrenom", "matricule");

            //Tab 2 : Pour les missions comportant un équipage de plus de 10 personnes, indiquer la liste des dépenses effectuées, ainsi que les budgets initiaux et actuels.
            dgvTab2.DataSource = Statistiques.MissionPlusDixMembre();
            dgvTab2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Tab 3 : Pour chaque planète, indiquer le nombre de missions qui y ont déjà eu lieu.

            //Éviter les doublons de jeu de données
            graphMissionPlanetes.Series.Clear();

            //Remplir les données du graphique
            Series donnees = new Series();

            //Type de graph : histogramme
            donnees.ChartType = SeriesChartType.Column;

            //Cacher la légende du graphique
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
            
            ComboVide.Remplir(cboTab5Missions, Statistiques.ObtenirNomMission(), "mission", "mission");


        }

        /****************************************************************************************************************************************************************************/
        /// <summary>
        /// Lorsque la sélection du membre est changée, le dataGridView est mis à jour avec les informations du nouveau membre sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTab1MembreMission_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Choix vide : on n'affiche rien
            if (ComboVide.EstVide(cboTab1MembreMission))
            {
                dgvTab1CopainMission.DataSource = null;
                lblAucunResultat.Visible = false;
                return;
            }
            
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
            //Choix vide : on n'affiche rien
            if (ComboVide.EstVide(cboTab5Missions))
            {
                dgvTab5Informateur.DataSource = null;
                return;
            }
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

namespace Form_Sae24_Stargate
{
    partial class FormAccueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccueil));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.grpFiltre = new System.Windows.Forms.GroupBox();
            this.cboFiltrePlanete = new System.Windows.Forms.ComboBox();
            this.lblFiltrePlanete = new System.Windows.Forms.Label();
            this.btnSupprimerFiltre = new System.Windows.Forms.Button();
            this.btnAppliquerFiltre = new System.Windows.Forms.Button();
            this.gpbFiltreEnnemi = new System.Windows.Forms.GroupBox();
            this.cboDegMal = new System.Windows.Forms.ComboBox();
            this.cboFiltreArme = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFiltreArme = new System.Windows.Forms.Label();
            this.gpbFiltreAllie = new System.Windows.Forms.GroupBox();
            this.cboDegBien = new System.Windows.Forms.ComboBox();
            this.cboFiltreInstrument = new System.Windows.Forms.ComboBox();
            this.lblFiltreDegBien = new System.Windows.Forms.Label();
            this.lblFiltreInstrument = new System.Windows.Forms.Label();
            this.ckbFiltreNeutre = new System.Windows.Forms.CheckBox();
            this.ckbFiltreEnnemi = new System.Windows.Forms.CheckBox();
            this.ckbFiltreAllie = new System.Windows.Forms.CheckBox();
            this.lblFiltreStatut = new System.Windows.Forms.Label();
            this.cboFiltreCouleur = new System.Windows.Forms.ComboBox();
            this.lblFiltreCouleur = new System.Windows.Forms.Label();
            this.txtFiltreNom = new System.Windows.Forms.TextBox();
            this.lblFiltreNom = new System.Windows.Forms.Label();
            this.grpFiltrePlanete = new System.Windows.Forms.GroupBox();
            this.txtGraviteMax = new System.Windows.Forms.TextBox();
            this.lblGraviteMax = new System.Windows.Forms.Label();
            this.txtGraviteMin = new System.Windows.Forms.TextBox();
            this.lblGraviteMin = new System.Windows.Forms.Label();
            this.txtTempMax = new System.Windows.Forms.TextBox();
            this.lblTempMax = new System.Windows.Forms.Label();
            this.txtTempMin = new System.Windows.Forms.TextBox();
            this.btnSupprimerFiltrePlanete = new System.Windows.Forms.Button();
            this.btnAppliquerFiltrePlanete = new System.Windows.Forms.Button();
            this.ckbDataBazInconnu = new System.Windows.Forms.CheckBox();
            this.ckbADataBaz = new System.Windows.Forms.CheckBox();
            this.ckbPDataBaz = new System.Windows.Forms.CheckBox();
            this.lblFiltreDataBaz = new System.Windows.Forms.Label();
            this.lblTempMin = new System.Windows.Forms.Label();
            this.txtFiltreNomPlanete = new System.Windows.Forms.TextBox();
            this.lblFiltreNomPlanete = new System.Windows.Forms.Label();
            this.tab5 = new System.Windows.Forms.TabPage();
            this.cboTab5Missions = new System.Windows.Forms.ComboBox();
            this.lblInformateursMalRemuneres = new System.Windows.Forms.Label();
            this.lblTab5Mission = new System.Windows.Forms.Label();
            this.dgvTab5Informateur = new System.Windows.Forms.DataGridView();
            this.tab4 = new System.Windows.Forms.TabPage();
            this.lblTab4Depenses = new System.Windows.Forms.Label();
            this.dgvTab4Depenses = new System.Windows.Forms.DataGridView();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.lblTab3nbMission = new System.Windows.Forms.Label();
            this.graphMissionPlanetes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.dgvTab2 = new System.Windows.Forms.DataGridView();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.lblAucunResultat = new System.Windows.Forms.Label();
            this.cboTab1MembreMission = new System.Windows.Forms.ComboBox();
            this.lblTab1CopainMission = new System.Windows.Forms.Label();
            this.dgvTab1CopainMission = new System.Windows.Forms.DataGridView();
            this.lblTab1MembreMission = new System.Windows.Forms.Label();
            this.tabAffichage = new System.Windows.Forms.TabControl();
            this.tabControlMission = new System.Windows.Forms.TabControl();
            this.tabMissionsEnCours = new System.Windows.Forms.TabPage();
            this.flpMissionEnCours = new System.Windows.Forms.FlowLayoutPanel();
            this.tabMissionsAVenir = new System.Windows.Forms.TabPage();
            this.flpMissionsAVenir = new System.Windows.Forms.FlowLayoutPanel();
            this.tabMissionsTerminees = new System.Windows.Forms.TabPage();
            this.flpMissionTerminee = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUCStatistiques = new UserControlBoutonAvecImage.UCBoutonImage();
            this.btnUCInfoPlanete = new UserControlBoutonAvecImage.UCBoutonImage();
            this.btnUCAliens = new UserControlBoutonAvecImage.UCBoutonImage();
            this.btnUCNouvelleMission = new UserControlBoutonAvecImage.UCBoutonImage();
            this.btnUCTableauDeBord = new UserControlBoutonAvecImage.UCBoutonImage();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.grpFiltre.SuspendLayout();
            this.gpbFiltreEnnemi.SuspendLayout();
            this.gpbFiltreAllie.SuspendLayout();
            this.grpFiltrePlanete.SuspendLayout();
            this.tab5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab5Informateur)).BeginInit();
            this.tab4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab4Depenses)).BeginInit();
            this.tab3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphMissionPlanetes)).BeginInit();
            this.tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab2)).BeginInit();
            this.tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab1CopainMission)).BeginInit();
            this.tabAffichage.SuspendLayout();
            this.tabControlMission.SuspendLayout();
            this.tabMissionsEnCours.SuspendLayout();
            this.tabMissionsAVenir.SuspendLayout();
            this.tabMissionsTerminees.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(60, 47);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(399, 248);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 10;
            this.picLogo.TabStop = false;
            // 
            // grpFiltre
            // 
            this.grpFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.grpFiltre.Controls.Add(this.cboFiltrePlanete);
            this.grpFiltre.Controls.Add(this.lblFiltrePlanete);
            this.grpFiltre.Controls.Add(this.btnSupprimerFiltre);
            this.grpFiltre.Controls.Add(this.btnAppliquerFiltre);
            this.grpFiltre.Controls.Add(this.gpbFiltreEnnemi);
            this.grpFiltre.Controls.Add(this.gpbFiltreAllie);
            this.grpFiltre.Controls.Add(this.ckbFiltreNeutre);
            this.grpFiltre.Controls.Add(this.ckbFiltreEnnemi);
            this.grpFiltre.Controls.Add(this.ckbFiltreAllie);
            this.grpFiltre.Controls.Add(this.lblFiltreStatut);
            this.grpFiltre.Controls.Add(this.cboFiltreCouleur);
            this.grpFiltre.Controls.Add(this.lblFiltreCouleur);
            this.grpFiltre.Controls.Add(this.txtFiltreNom);
            this.grpFiltre.Controls.Add(this.lblFiltreNom);
            this.grpFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltre.ForeColor = System.Drawing.Color.White;
            this.grpFiltre.Location = new System.Drawing.Point(13, 827);
            this.grpFiltre.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grpFiltre.Name = "grpFiltre";
            this.grpFiltre.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grpFiltre.Size = new System.Drawing.Size(1555, 207);
            this.grpFiltre.TabIndex = 11;
            this.grpFiltre.TabStop = false;
            this.grpFiltre.Text = "Filtres";
            this.grpFiltre.Visible = false;
            // 
            // cboFiltrePlanete
            // 
            this.cboFiltrePlanete.FormattingEnabled = true;
            this.cboFiltrePlanete.Location = new System.Drawing.Point(492, 86);
            this.cboFiltrePlanete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboFiltrePlanete.Name = "cboFiltrePlanete";
            this.cboFiltrePlanete.Size = new System.Drawing.Size(263, 28);
            this.cboFiltrePlanete.TabIndex = 21;
            // 
            // lblFiltrePlanete
            // 
            this.lblFiltrePlanete.AutoSize = true;
            this.lblFiltrePlanete.Location = new System.Drawing.Point(384, 90);
            this.lblFiltrePlanete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltrePlanete.Name = "lblFiltrePlanete";
            this.lblFiltrePlanete.Size = new System.Drawing.Size(75, 20);
            this.lblFiltrePlanete.TabIndex = 20;
            this.lblFiltrePlanete.Text = "Planète :";
            // 
            // btnSupprimerFiltre
            // 
            this.btnSupprimerFiltre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSupprimerFiltre.Location = new System.Drawing.Point(17, 144);
            this.btnSupprimerFiltre.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSupprimerFiltre.Name = "btnSupprimerFiltre";
            this.btnSupprimerFiltre.Size = new System.Drawing.Size(155, 43);
            this.btnSupprimerFiltre.TabIndex = 19;
            this.btnSupprimerFiltre.Text = "Réinitialiser";
            this.btnSupprimerFiltre.UseVisualStyleBackColor = true;
            this.btnSupprimerFiltre.Click += new System.EventHandler(this.btnSupprimerFiltre_Click);
            // 
            // btnAppliquerFiltre
            // 
            this.btnAppliquerFiltre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAppliquerFiltre.Location = new System.Drawing.Point(192, 144);
            this.btnAppliquerFiltre.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAppliquerFiltre.Name = "btnAppliquerFiltre";
            this.btnAppliquerFiltre.Size = new System.Drawing.Size(155, 43);
            this.btnAppliquerFiltre.TabIndex = 18;
            this.btnAppliquerFiltre.Text = "Appliquer";
            this.btnAppliquerFiltre.UseVisualStyleBackColor = true;
            this.btnAppliquerFiltre.Click += new System.EventHandler(this.btnAppliquerFiltre_Click);
            // 
            // gpbFiltreEnnemi
            // 
            this.gpbFiltreEnnemi.Controls.Add(this.cboDegMal);
            this.gpbFiltreEnnemi.Controls.Add(this.cboFiltreArme);
            this.gpbFiltreEnnemi.Controls.Add(this.label1);
            this.gpbFiltreEnnemi.Controls.Add(this.lblFiltreArme);
            this.gpbFiltreEnnemi.Location = new System.Drawing.Point(781, 114);
            this.gpbFiltreEnnemi.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gpbFiltreEnnemi.Name = "gpbFiltreEnnemi";
            this.gpbFiltreEnnemi.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gpbFiltreEnnemi.Size = new System.Drawing.Size(752, 82);
            this.gpbFiltreEnnemi.TabIndex = 17;
            this.gpbFiltreEnnemi.TabStop = false;
            this.gpbFiltreEnnemi.Visible = false;
            // 
            // cboDegMal
            // 
            this.cboDegMal.FormattingEnabled = true;
            this.cboDegMal.Location = new System.Drawing.Point(239, 30);
            this.cboDegMal.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboDegMal.Name = "cboDegMal";
            this.cboDegMal.Size = new System.Drawing.Size(85, 28);
            this.cboDegMal.TabIndex = 11;
            // 
            // cboFiltreArme
            // 
            this.cboFiltreArme.FormattingEnabled = true;
            this.cboFiltreArme.Location = new System.Drawing.Point(518, 30);
            this.cboFiltreArme.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboFiltreArme.Name = "cboFiltreArme";
            this.cboFiltreArme.Size = new System.Drawing.Size(211, 28);
            this.cboFiltreArme.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Degré de malveillance :";
            // 
            // lblFiltreArme
            // 
            this.lblFiltreArme.AutoSize = true;
            this.lblFiltreArme.Location = new System.Drawing.Point(366, 33);
            this.lblFiltreArme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltreArme.Name = "lblFiltreArme";
            this.lblFiltreArme.Size = new System.Drawing.Size(64, 20);
            this.lblFiltreArme.TabIndex = 14;
            this.lblFiltreArme.Text = "Arme  :";
            // 
            // gpbFiltreAllie
            // 
            this.gpbFiltreAllie.Controls.Add(this.cboDegBien);
            this.gpbFiltreAllie.Controls.Add(this.cboFiltreInstrument);
            this.gpbFiltreAllie.Controls.Add(this.lblFiltreDegBien);
            this.gpbFiltreAllie.Controls.Add(this.lblFiltreInstrument);
            this.gpbFiltreAllie.Location = new System.Drawing.Point(781, 24);
            this.gpbFiltreAllie.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gpbFiltreAllie.Name = "gpbFiltreAllie";
            this.gpbFiltreAllie.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gpbFiltreAllie.Size = new System.Drawing.Size(752, 85);
            this.gpbFiltreAllie.TabIndex = 16;
            this.gpbFiltreAllie.TabStop = false;
            this.gpbFiltreAllie.Visible = false;
            // 
            // cboDegBien
            // 
            this.cboDegBien.FormattingEnabled = true;
            this.cboDegBien.Location = new System.Drawing.Point(239, 33);
            this.cboDegBien.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboDegBien.Name = "cboDegBien";
            this.cboDegBien.Size = new System.Drawing.Size(85, 28);
            this.cboDegBien.TabIndex = 9;
            // 
            // cboFiltreInstrument
            // 
            this.cboFiltreInstrument.FormattingEnabled = true;
            this.cboFiltreInstrument.Location = new System.Drawing.Point(518, 34);
            this.cboFiltreInstrument.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboFiltreInstrument.Name = "cboFiltreInstrument";
            this.cboFiltreInstrument.Size = new System.Drawing.Size(211, 28);
            this.cboFiltreInstrument.TabIndex = 13;
            // 
            // lblFiltreDegBien
            // 
            this.lblFiltreDegBien.AutoSize = true;
            this.lblFiltreDegBien.Location = new System.Drawing.Point(16, 37);
            this.lblFiltreDegBien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltreDegBien.Name = "lblFiltreDegBien";
            this.lblFiltreDegBien.Size = new System.Drawing.Size(189, 20);
            this.lblFiltreDegBien.TabIndex = 8;
            this.lblFiltreDegBien.Text = "Degré de bienveillance :";
            // 
            // lblFiltreInstrument
            // 
            this.lblFiltreInstrument.AutoSize = true;
            this.lblFiltreInstrument.Location = new System.Drawing.Point(366, 38);
            this.lblFiltreInstrument.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltreInstrument.Name = "lblFiltreInstrument";
            this.lblFiltreInstrument.Size = new System.Drawing.Size(98, 20);
            this.lblFiltreInstrument.TabIndex = 12;
            this.lblFiltreInstrument.Text = "Instrument :";
            // 
            // ckbFiltreNeutre
            // 
            this.ckbFiltreNeutre.AutoSize = true;
            this.ckbFiltreNeutre.Location = new System.Drawing.Point(674, 32);
            this.ckbFiltreNeutre.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ckbFiltreNeutre.Name = "ckbFiltreNeutre";
            this.ckbFiltreNeutre.Size = new System.Drawing.Size(81, 24);
            this.ckbFiltreNeutre.TabIndex = 7;
            this.ckbFiltreNeutre.Text = "Neutre";
            this.ckbFiltreNeutre.UseVisualStyleBackColor = true;
            // 
            // ckbFiltreEnnemi
            // 
            this.ckbFiltreEnnemi.AutoSize = true;
            this.ckbFiltreEnnemi.Location = new System.Drawing.Point(569, 32);
            this.ckbFiltreEnnemi.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ckbFiltreEnnemi.Name = "ckbFiltreEnnemi";
            this.ckbFiltreEnnemi.Size = new System.Drawing.Size(87, 24);
            this.ckbFiltreEnnemi.TabIndex = 6;
            this.ckbFiltreEnnemi.Text = "Ennemi";
            this.ckbFiltreEnnemi.UseVisualStyleBackColor = true;
            this.ckbFiltreEnnemi.CheckedChanged += new System.EventHandler(this.ckbFiltreEnnemi_CheckedChanged);
            // 
            // ckbFiltreAllie
            // 
            this.ckbFiltreAllie.AutoSize = true;
            this.ckbFiltreAllie.Location = new System.Drawing.Point(492, 32);
            this.ckbFiltreAllie.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ckbFiltreAllie.Name = "ckbFiltreAllie";
            this.ckbFiltreAllie.Size = new System.Drawing.Size(63, 24);
            this.ckbFiltreAllie.TabIndex = 5;
            this.ckbFiltreAllie.Text = "Allié";
            this.ckbFiltreAllie.UseVisualStyleBackColor = true;
            this.ckbFiltreAllie.CheckedChanged += new System.EventHandler(this.ckbFiltreAllie_CheckedChanged);
            // 
            // lblFiltreStatut
            // 
            this.lblFiltreStatut.AutoSize = true;
            this.lblFiltreStatut.Location = new System.Drawing.Point(383, 32);
            this.lblFiltreStatut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltreStatut.Name = "lblFiltreStatut";
            this.lblFiltreStatut.Size = new System.Drawing.Size(63, 20);
            this.lblFiltreStatut.TabIndex = 4;
            this.lblFiltreStatut.Text = "Statut :";
            // 
            // cboFiltreCouleur
            // 
            this.cboFiltreCouleur.FormattingEnabled = true;
            this.cboFiltreCouleur.Location = new System.Drawing.Point(120, 86);
            this.cboFiltreCouleur.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboFiltreCouleur.Name = "cboFiltreCouleur";
            this.cboFiltreCouleur.Size = new System.Drawing.Size(236, 28);
            this.cboFiltreCouleur.TabIndex = 3;
            // 
            // lblFiltreCouleur
            // 
            this.lblFiltreCouleur.AutoSize = true;
            this.lblFiltreCouleur.Location = new System.Drawing.Point(20, 89);
            this.lblFiltreCouleur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltreCouleur.Name = "lblFiltreCouleur";
            this.lblFiltreCouleur.Size = new System.Drawing.Size(77, 20);
            this.lblFiltreCouleur.TabIndex = 2;
            this.lblFiltreCouleur.Text = "Couleur :";
            // 
            // txtFiltreNom
            // 
            this.txtFiltreNom.Location = new System.Drawing.Point(120, 29);
            this.txtFiltreNom.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtFiltreNom.Name = "txtFiltreNom";
            this.txtFiltreNom.Size = new System.Drawing.Size(236, 27);
            this.txtFiltreNom.TabIndex = 1;
            // 
            // lblFiltreNom
            // 
            this.lblFiltreNom.AutoSize = true;
            this.lblFiltreNom.Location = new System.Drawing.Point(20, 32);
            this.lblFiltreNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltreNom.Name = "lblFiltreNom";
            this.lblFiltreNom.Size = new System.Drawing.Size(54, 20);
            this.lblFiltreNom.TabIndex = 0;
            this.lblFiltreNom.Text = "Nom :";
            // 
            // grpFiltrePlanete
            // 
            this.grpFiltrePlanete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.grpFiltrePlanete.Controls.Add(this.txtGraviteMax);
            this.grpFiltrePlanete.Controls.Add(this.lblGraviteMax);
            this.grpFiltrePlanete.Controls.Add(this.txtGraviteMin);
            this.grpFiltrePlanete.Controls.Add(this.lblGraviteMin);
            this.grpFiltrePlanete.Controls.Add(this.txtTempMax);
            this.grpFiltrePlanete.Controls.Add(this.lblTempMax);
            this.grpFiltrePlanete.Controls.Add(this.txtTempMin);
            this.grpFiltrePlanete.Controls.Add(this.btnSupprimerFiltrePlanete);
            this.grpFiltrePlanete.Controls.Add(this.btnAppliquerFiltrePlanete);
            this.grpFiltrePlanete.Controls.Add(this.ckbDataBazInconnu);
            this.grpFiltrePlanete.Controls.Add(this.ckbADataBaz);
            this.grpFiltrePlanete.Controls.Add(this.ckbPDataBaz);
            this.grpFiltrePlanete.Controls.Add(this.lblFiltreDataBaz);
            this.grpFiltrePlanete.Controls.Add(this.lblTempMin);
            this.grpFiltrePlanete.Controls.Add(this.txtFiltreNomPlanete);
            this.grpFiltrePlanete.Controls.Add(this.lblFiltreNomPlanete);
            this.grpFiltrePlanete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltrePlanete.ForeColor = System.Drawing.Color.White;
            this.grpFiltrePlanete.Location = new System.Drawing.Point(21, 795);
            this.grpFiltrePlanete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grpFiltrePlanete.Name = "grpFiltrePlanete";
            this.grpFiltrePlanete.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.grpFiltrePlanete.Size = new System.Drawing.Size(1428, 195);
            this.grpFiltrePlanete.TabIndex = 15;
            this.grpFiltrePlanete.TabStop = false;
            this.grpFiltrePlanete.Text = "Filtres";
            this.grpFiltrePlanete.Visible = false;
            // 
            // txtGraviteMax
            // 
            this.txtGraviteMax.Location = new System.Drawing.Point(1294, 82);
            this.txtGraviteMax.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtGraviteMax.Name = "txtGraviteMax";
            this.txtGraviteMax.Size = new System.Drawing.Size(112, 27);
            this.txtGraviteMax.TabIndex = 28;
            this.txtGraviteMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGraviteMax_KeyPress);
            // 
            // lblGraviteMax
            // 
            this.lblGraviteMax.AutoSize = true;
            this.lblGraviteMax.Location = new System.Drawing.Point(1125, 85);
            this.lblGraviteMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGraviteMax.Name = "lblGraviteMax";
            this.lblGraviteMax.Size = new System.Drawing.Size(150, 20);
            this.lblGraviteMax.TabIndex = 27;
            this.lblGraviteMax.Text = "Gravité maximum :";
            // 
            // txtGraviteMin
            // 
            this.txtGraviteMin.Location = new System.Drawing.Point(971, 82);
            this.txtGraviteMin.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtGraviteMin.Name = "txtGraviteMin";
            this.txtGraviteMin.Size = new System.Drawing.Size(112, 27);
            this.txtGraviteMin.TabIndex = 26;
            this.txtGraviteMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGraviteMin_KeyPress);
            // 
            // lblGraviteMin
            // 
            this.lblGraviteMin.AutoSize = true;
            this.lblGraviteMin.Location = new System.Drawing.Point(800, 85);
            this.lblGraviteMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGraviteMin.Name = "lblGraviteMin";
            this.lblGraviteMin.Size = new System.Drawing.Size(146, 20);
            this.lblGraviteMin.TabIndex = 25;
            this.lblGraviteMin.Text = "Gravité minimum :";
            // 
            // txtTempMax
            // 
            this.txtTempMax.Location = new System.Drawing.Point(602, 82);
            this.txtTempMax.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTempMax.Name = "txtTempMax";
            this.txtTempMax.Size = new System.Drawing.Size(112, 27);
            this.txtTempMax.TabIndex = 24;
            this.txtTempMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempMax_KeyPress);
            // 
            // lblTempMax
            // 
            this.lblTempMax.AutoSize = true;
            this.lblTempMax.Location = new System.Drawing.Point(386, 89);
            this.lblTempMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempMax.Name = "lblTempMax";
            this.lblTempMax.Size = new System.Drawing.Size(191, 20);
            this.lblTempMax.TabIndex = 23;
            this.lblTempMax.Text = "Température maximum :";
            // 
            // txtTempMin
            // 
            this.txtTempMin.Location = new System.Drawing.Point(244, 82);
            this.txtTempMin.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTempMin.Name = "txtTempMin";
            this.txtTempMin.Size = new System.Drawing.Size(112, 27);
            this.txtTempMin.TabIndex = 22;
            this.txtTempMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempMin_KeyPress);
            // 
            // btnSupprimerFiltrePlanete
            // 
            this.btnSupprimerFiltrePlanete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSupprimerFiltrePlanete.Location = new System.Drawing.Point(1077, 132);
            this.btnSupprimerFiltrePlanete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSupprimerFiltrePlanete.Name = "btnSupprimerFiltrePlanete";
            this.btnSupprimerFiltrePlanete.Size = new System.Drawing.Size(155, 43);
            this.btnSupprimerFiltrePlanete.TabIndex = 19;
            this.btnSupprimerFiltrePlanete.Text = "Réinitialiser";
            this.btnSupprimerFiltrePlanete.UseVisualStyleBackColor = true;
            this.btnSupprimerFiltrePlanete.Click += new System.EventHandler(this.btnSupprimerFiltrePlanete_Click);
            // 
            // btnAppliquerFiltrePlanete
            // 
            this.btnAppliquerFiltrePlanete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAppliquerFiltrePlanete.Location = new System.Drawing.Point(1252, 132);
            this.btnAppliquerFiltrePlanete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAppliquerFiltrePlanete.Name = "btnAppliquerFiltrePlanete";
            this.btnAppliquerFiltrePlanete.Size = new System.Drawing.Size(155, 43);
            this.btnAppliquerFiltrePlanete.TabIndex = 18;
            this.btnAppliquerFiltrePlanete.Text = "Appliquer";
            this.btnAppliquerFiltrePlanete.UseVisualStyleBackColor = true;
            this.btnAppliquerFiltrePlanete.Click += new System.EventHandler(this.btnAppliquerFiltrePlanete_Click);
            // 
            // ckbDataBazInconnu
            // 
            this.ckbDataBazInconnu.AutoSize = true;
            this.ckbDataBazInconnu.Location = new System.Drawing.Point(674, 32);
            this.ckbDataBazInconnu.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ckbDataBazInconnu.Name = "ckbDataBazInconnu";
            this.ckbDataBazInconnu.Size = new System.Drawing.Size(40, 24);
            this.ckbDataBazInconnu.TabIndex = 7;
            this.ckbDataBazInconnu.Text = "?";
            this.ckbDataBazInconnu.UseVisualStyleBackColor = true;
            // 
            // ckbADataBaz
            // 
            this.ckbADataBaz.AutoSize = true;
            this.ckbADataBaz.Location = new System.Drawing.Point(582, 32);
            this.ckbADataBaz.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ckbADataBaz.Name = "ckbADataBaz";
            this.ckbADataBaz.Size = new System.Drawing.Size(61, 24);
            this.ckbADataBaz.TabIndex = 6;
            this.ckbADataBaz.Text = "Non";
            this.ckbADataBaz.UseVisualStyleBackColor = true;
            // 
            // ckbPDataBaz
            // 
            this.ckbPDataBaz.AutoSize = true;
            this.ckbPDataBaz.Location = new System.Drawing.Point(492, 32);
            this.ckbPDataBaz.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ckbPDataBaz.Name = "ckbPDataBaz";
            this.ckbPDataBaz.Size = new System.Drawing.Size(57, 24);
            this.ckbPDataBaz.TabIndex = 5;
            this.ckbPDataBaz.Text = "Oui";
            this.ckbPDataBaz.UseVisualStyleBackColor = true;
            // 
            // lblFiltreDataBaz
            // 
            this.lblFiltreDataBaz.AutoSize = true;
            this.lblFiltreDataBaz.Location = new System.Drawing.Point(383, 32);
            this.lblFiltreDataBaz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltreDataBaz.Name = "lblFiltreDataBaz";
            this.lblFiltreDataBaz.Size = new System.Drawing.Size(85, 20);
            this.lblFiltreDataBaz.TabIndex = 4;
            this.lblFiltreDataBaz.Text = "DataBaz :";
            // 
            // lblTempMin
            // 
            this.lblTempMin.AutoSize = true;
            this.lblTempMin.Location = new System.Drawing.Point(20, 89);
            this.lblTempMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempMin.Name = "lblTempMin";
            this.lblTempMin.Size = new System.Drawing.Size(187, 20);
            this.lblTempMin.TabIndex = 2;
            this.lblTempMin.Text = "Température minimum :";
            // 
            // txtFiltreNomPlanete
            // 
            this.txtFiltreNomPlanete.Location = new System.Drawing.Point(120, 29);
            this.txtFiltreNomPlanete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtFiltreNomPlanete.Name = "txtFiltreNomPlanete";
            this.txtFiltreNomPlanete.Size = new System.Drawing.Size(236, 27);
            this.txtFiltreNomPlanete.TabIndex = 1;
            // 
            // lblFiltreNomPlanete
            // 
            this.lblFiltreNomPlanete.AutoSize = true;
            this.lblFiltreNomPlanete.Location = new System.Drawing.Point(20, 32);
            this.lblFiltreNomPlanete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltreNomPlanete.Name = "lblFiltreNomPlanete";
            this.lblFiltreNomPlanete.Size = new System.Drawing.Size(54, 20);
            this.lblFiltreNomPlanete.TabIndex = 0;
            this.lblFiltreNomPlanete.Text = "Nom :";
            // 
            // tab5
            // 
            this.tab5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tab5.Controls.Add(this.cboTab5Missions);
            this.tab5.Controls.Add(this.lblInformateursMalRemuneres);
            this.tab5.Controls.Add(this.lblTab5Mission);
            this.tab5.Controls.Add(this.dgvTab5Informateur);
            this.tab5.Location = new System.Drawing.Point(4, 29);
            this.tab5.Name = "tab5";
            this.tab5.Padding = new System.Windows.Forms.Padding(3);
            this.tab5.Size = new System.Drawing.Size(1455, 859);
            this.tab5.TabIndex = 4;
            this.tab5.Text = "Informateurs arnaqués";
            // 
            // cboTab5Missions
            // 
            this.cboTab5Missions.FormattingEnabled = true;
            this.cboTab5Missions.Location = new System.Drawing.Point(186, 36);
            this.cboTab5Missions.Name = "cboTab5Missions";
            this.cboTab5Missions.Size = new System.Drawing.Size(253, 28);
            this.cboTab5Missions.TabIndex = 4;
            this.cboTab5Missions.SelectedIndexChanged += new System.EventHandler(this.cboTab5Missions_SelectedIndexChanged);
            // 
            // lblInformateursMalRemuneres
            // 
            this.lblInformateursMalRemuneres.AutoSize = true;
            this.lblInformateursMalRemuneres.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformateursMalRemuneres.ForeColor = System.Drawing.Color.White;
            this.lblInformateursMalRemuneres.Location = new System.Drawing.Point(36, 86);
            this.lblInformateursMalRemuneres.Name = "lblInformateursMalRemuneres";
            this.lblInformateursMalRemuneres.Size = new System.Drawing.Size(287, 29);
            this.lblInformateursMalRemuneres.TabIndex = 6;
            this.lblInformateursMalRemuneres.Text = "Informateurs arnaqués :";
            // 
            // lblTab5Mission
            // 
            this.lblTab5Mission.AutoSize = true;
            this.lblTab5Mission.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTab5Mission.ForeColor = System.Drawing.Color.White;
            this.lblTab5Mission.Location = new System.Drawing.Point(36, 36);
            this.lblTab5Mission.Name = "lblTab5Mission";
            this.lblTab5Mission.Size = new System.Drawing.Size(117, 29);
            this.lblTab5Mission.TabIndex = 5;
            this.lblTab5Mission.Text = "Mission :";
            // 
            // dgvTab5Informateur
            // 
            this.dgvTab5Informateur.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTab5Informateur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTab5Informateur.Location = new System.Drawing.Point(39, 134);
            this.dgvTab5Informateur.Name = "dgvTab5Informateur";
            this.dgvTab5Informateur.RowHeadersWidth = 51;
            this.dgvTab5Informateur.RowTemplate.Height = 24;
            this.dgvTab5Informateur.Size = new System.Drawing.Size(1367, 337);
            this.dgvTab5Informateur.TabIndex = 1;
            // 
            // tab4
            // 
            this.tab4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tab4.Controls.Add(this.lblTab4Depenses);
            this.tab4.Controls.Add(this.dgvTab4Depenses);
            this.tab4.Location = new System.Drawing.Point(4, 29);
            this.tab4.Name = "tab4";
            this.tab4.Padding = new System.Windows.Forms.Padding(3);
            this.tab4.Size = new System.Drawing.Size(1455, 859);
            this.tab4.TabIndex = 3;
            this.tab4.Text = "Dépenses importantes par mission";
            // 
            // lblTab4Depenses
            // 
            this.lblTab4Depenses.AutoSize = true;
            this.lblTab4Depenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTab4Depenses.ForeColor = System.Drawing.Color.White;
            this.lblTab4Depenses.Location = new System.Drawing.Point(31, 32);
            this.lblTab4Depenses.Name = "lblTab4Depenses";
            this.lblTab4Depenses.Size = new System.Drawing.Size(529, 29);
            this.lblTab4Depenses.TabIndex = 2;
            this.lblTab4Depenses.Text = "Dépenses les plus importantes par mission :";
            // 
            // dgvTab4Depenses
            // 
            this.dgvTab4Depenses.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTab4Depenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTab4Depenses.Location = new System.Drawing.Point(41, 93);
            this.dgvTab4Depenses.Name = "dgvTab4Depenses";
            this.dgvTab4Depenses.RowHeadersWidth = 51;
            this.dgvTab4Depenses.RowTemplate.Height = 24;
            this.dgvTab4Depenses.Size = new System.Drawing.Size(1367, 337);
            this.dgvTab4Depenses.TabIndex = 0;
            // 
            // tab3
            // 
            this.tab3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tab3.Controls.Add(this.lblTab3nbMission);
            this.tab3.Controls.Add(this.graphMissionPlanetes);
            this.tab3.Location = new System.Drawing.Point(4, 29);
            this.tab3.Name = "tab3";
            this.tab3.Padding = new System.Windows.Forms.Padding(3);
            this.tab3.Size = new System.Drawing.Size(1455, 859);
            this.tab3.TabIndex = 2;
            this.tab3.Text = "Nombre de missions par planète";
            // 
            // lblTab3nbMission
            // 
            this.lblTab3nbMission.AutoSize = true;
            this.lblTab3nbMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTab3nbMission.ForeColor = System.Drawing.Color.White;
            this.lblTab3nbMission.Location = new System.Drawing.Point(54, 50);
            this.lblTab3nbMission.Name = "lblTab3nbMission";
            this.lblTab3nbMission.Size = new System.Drawing.Size(420, 29);
            this.lblTab3nbMission.TabIndex = 1;
            this.lblTab3nbMission.Text = "Nombre de missions par planète :";
            // 
            // graphMissionPlanetes
            // 
            this.graphMissionPlanetes.BackColor = System.Drawing.Color.Transparent;
            this.graphMissionPlanetes.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.graphMissionPlanetes.BorderlineColor = System.Drawing.Color.Transparent;
            this.graphMissionPlanetes.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.graphMissionPlanetes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graphMissionPlanetes.Legends.Add(legend1);
            this.graphMissionPlanetes.Location = new System.Drawing.Point(39, 107);
            this.graphMissionPlanetes.Name = "graphMissionPlanetes";
            this.graphMissionPlanetes.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.graphMissionPlanetes.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))))};
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graphMissionPlanetes.Series.Add(series1);
            this.graphMissionPlanetes.Size = new System.Drawing.Size(1372, 469);
            this.graphMissionPlanetes.TabIndex = 0;
            this.graphMissionPlanetes.Text = "Nombre de missions par planète";
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tab2.Controls.Add(this.dgvTab2);
            this.tab2.Location = new System.Drawing.Point(4, 29);
            this.tab2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tab2.Size = new System.Drawing.Size(1455, 859);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Missions avec équipage + 10";
            // 
            // dgvTab2
            // 
            this.dgvTab2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTab2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTab2.Location = new System.Drawing.Point(39, 74);
            this.dgvTab2.Name = "dgvTab2";
            this.dgvTab2.RowHeadersWidth = 51;
            this.dgvTab2.RowTemplate.Height = 24;
            this.dgvTab2.Size = new System.Drawing.Size(1385, 289);
            this.dgvTab2.TabIndex = 0;
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tab1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tab1.Controls.Add(this.lblAucunResultat);
            this.tab1.Controls.Add(this.cboTab1MembreMission);
            this.tab1.Controls.Add(this.lblTab1CopainMission);
            this.tab1.Controls.Add(this.dgvTab1CopainMission);
            this.tab1.Controls.Add(this.lblTab1MembreMission);
            this.tab1.Location = new System.Drawing.Point(4, 29);
            this.tab1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tab1.Size = new System.Drawing.Size(1455, 859);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Copains de mission";
            // 
            // lblAucunResultat
            // 
            this.lblAucunResultat.AutoSize = true;
            this.lblAucunResultat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAucunResultat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAucunResultat.Location = new System.Drawing.Point(626, 145);
            this.lblAucunResultat.Name = "lblAucunResultat";
            this.lblAucunResultat.Size = new System.Drawing.Size(163, 29);
            this.lblAucunResultat.TabIndex = 4;
            this.lblAucunResultat.Text = "Aucun résultat";
            this.lblAucunResultat.Visible = false;
            // 
            // cboTab1MembreMission
            // 
            this.cboTab1MembreMission.FormattingEnabled = true;
            this.cboTab1MembreMission.Location = new System.Drawing.Point(175, 22);
            this.cboTab1MembreMission.Name = "cboTab1MembreMission";
            this.cboTab1MembreMission.Size = new System.Drawing.Size(253, 28);
            this.cboTab1MembreMission.TabIndex = 0;
            this.cboTab1MembreMission.SelectedIndexChanged += new System.EventHandler(this.cboTab1MembreMission_SelectedIndexChanged);
            // 
            // lblTab1CopainMission
            // 
            this.lblTab1CopainMission.AutoSize = true;
            this.lblTab1CopainMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTab1CopainMission.ForeColor = System.Drawing.Color.White;
            this.lblTab1CopainMission.Location = new System.Drawing.Point(25, 72);
            this.lblTab1CopainMission.Name = "lblTab1CopainMission";
            this.lblTab1CopainMission.Size = new System.Drawing.Size(257, 29);
            this.lblTab1CopainMission.TabIndex = 3;
            this.lblTab1CopainMission.Text = "Copains de mission :";
            // 
            // dgvTab1CopainMission
            // 
            this.dgvTab1CopainMission.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTab1CopainMission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTab1CopainMission.Location = new System.Drawing.Point(30, 116);
            this.dgvTab1CopainMission.Name = "dgvTab1CopainMission";
            this.dgvTab1CopainMission.RowHeadersWidth = 51;
            this.dgvTab1CopainMission.RowTemplate.Height = 24;
            this.dgvTab1CopainMission.Size = new System.Drawing.Size(1374, 358);
            this.dgvTab1CopainMission.TabIndex = 2;
            // 
            // lblTab1MembreMission
            // 
            this.lblTab1MembreMission.AutoSize = true;
            this.lblTab1MembreMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTab1MembreMission.ForeColor = System.Drawing.Color.White;
            this.lblTab1MembreMission.Location = new System.Drawing.Point(25, 22);
            this.lblTab1MembreMission.Name = "lblTab1MembreMission";
            this.lblTab1MembreMission.Size = new System.Drawing.Size(123, 29);
            this.lblTab1MembreMission.TabIndex = 1;
            this.lblTab1MembreMission.Text = "Membre :";
            // 
            // tabAffichage
            // 
            this.tabAffichage.Controls.Add(this.tab1);
            this.tabAffichage.Controls.Add(this.tab2);
            this.tabAffichage.Controls.Add(this.tab3);
            this.tabAffichage.Controls.Add(this.tab4);
            this.tabAffichage.Controls.Add(this.tab5);
            this.tabAffichage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAffichage.Location = new System.Drawing.Point(552, 102);
            this.tabAffichage.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabAffichage.Name = "tabAffichage";
            this.tabAffichage.SelectedIndex = 0;
            this.tabAffichage.Size = new System.Drawing.Size(1463, 892);
            this.tabAffichage.TabIndex = 2;
            this.tabAffichage.Visible = false;
            // 
            // tabControlMission
            // 
            this.tabControlMission.Controls.Add(this.tabMissionsEnCours);
            this.tabControlMission.Controls.Add(this.tabMissionsAVenir);
            this.tabControlMission.Controls.Add(this.tabMissionsTerminees);
            this.tabControlMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMission.Location = new System.Drawing.Point(552, 80);
            this.tabControlMission.Name = "tabControlMission";
            this.tabControlMission.SelectedIndex = 0;
            this.tabControlMission.Size = new System.Drawing.Size(1400, 800);
            this.tabControlMission.TabIndex = 17;
            this.tabControlMission.Visible = false;
            // 
            // tabMissionsEnCours
            // 
            this.tabMissionsEnCours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tabMissionsEnCours.Controls.Add(this.flpMissionEnCours);
            this.tabMissionsEnCours.Location = new System.Drawing.Point(4, 29);
            this.tabMissionsEnCours.Name = "tabMissionsEnCours";
            this.tabMissionsEnCours.Padding = new System.Windows.Forms.Padding(3);
            this.tabMissionsEnCours.Size = new System.Drawing.Size(1392, 767);
            this.tabMissionsEnCours.TabIndex = 0;
            this.tabMissionsEnCours.Text = "Missions en cours";
            // 
            // flpMissionEnCours
            // 
            this.flpMissionEnCours.Location = new System.Drawing.Point(0, 3);
            this.flpMissionEnCours.Name = "flpMissionEnCours";
            this.flpMissionEnCours.Size = new System.Drawing.Size(1400, 800);
            this.flpMissionEnCours.TabIndex = 2;
            // 
            // tabMissionsAVenir
            // 
            this.tabMissionsAVenir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tabMissionsAVenir.Controls.Add(this.flpMissionsAVenir);
            this.tabMissionsAVenir.Location = new System.Drawing.Point(4, 29);
            this.tabMissionsAVenir.Name = "tabMissionsAVenir";
            this.tabMissionsAVenir.Padding = new System.Windows.Forms.Padding(3);
            this.tabMissionsAVenir.Size = new System.Drawing.Size(1392, 767);
            this.tabMissionsAVenir.TabIndex = 1;
            this.tabMissionsAVenir.Text = "Missions à venir";
            // 
            // flpMissionsAVenir
            // 
            this.flpMissionsAVenir.Location = new System.Drawing.Point(0, 3);
            this.flpMissionsAVenir.Name = "flpMissionsAVenir";
            this.flpMissionsAVenir.Size = new System.Drawing.Size(1400, 800);
            this.flpMissionsAVenir.TabIndex = 1;
            // 
            // tabMissionsTerminees
            // 
            this.tabMissionsTerminees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tabMissionsTerminees.Controls.Add(this.flpMissionTerminee);
            this.tabMissionsTerminees.Location = new System.Drawing.Point(4, 29);
            this.tabMissionsTerminees.Name = "tabMissionsTerminees";
            this.tabMissionsTerminees.Padding = new System.Windows.Forms.Padding(3);
            this.tabMissionsTerminees.Size = new System.Drawing.Size(1392, 767);
            this.tabMissionsTerminees.TabIndex = 2;
            this.tabMissionsTerminees.Text = "Missions terminées";
            // 
            // flpMissionTerminee
            // 
            this.flpMissionTerminee.Location = new System.Drawing.Point(0, 3);
            this.flpMissionTerminee.Name = "flpMissionTerminee";
            this.flpMissionTerminee.Size = new System.Drawing.Size(1400, 800);
            this.flpMissionTerminee.TabIndex = 0;
            // 
            // btnUCStatistiques
            // 
            this.btnUCStatistiques.BackColor = System.Drawing.Color.Transparent;
            this.btnUCStatistiques.imageBouton = ((System.Drawing.Image)(resources.GetObject("btnUCStatistiques.imageBouton")));
            this.btnUCStatistiques.Location = new System.Drawing.Point(105, 640);
            this.btnUCStatistiques.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnUCStatistiques.Name = "btnUCStatistiques";
            this.btnUCStatistiques.Size = new System.Drawing.Size(305, 78);
            this.btnUCStatistiques.TabIndex = 16;
            this.btnUCStatistiques.texteBouton = "Statistiques";
            // 
            // btnUCInfoPlanete
            // 
            this.btnUCInfoPlanete.BackColor = System.Drawing.Color.Transparent;
            this.btnUCInfoPlanete.imageBouton = ((System.Drawing.Image)(resources.GetObject("btnUCInfoPlanete.imageBouton")));
            this.btnUCInfoPlanete.Location = new System.Drawing.Point(105, 542);
            this.btnUCInfoPlanete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnUCInfoPlanete.Name = "btnUCInfoPlanete";
            this.btnUCInfoPlanete.Size = new System.Drawing.Size(305, 78);
            this.btnUCInfoPlanete.TabIndex = 9;
            this.btnUCInfoPlanete.texteBouton = "Information planètes";
            // 
            // btnUCAliens
            // 
            this.btnUCAliens.BackColor = System.Drawing.Color.Transparent;
            this.btnUCAliens.imageBouton = ((System.Drawing.Image)(resources.GetObject("btnUCAliens.imageBouton")));
            this.btnUCAliens.Location = new System.Drawing.Point(105, 447);
            this.btnUCAliens.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnUCAliens.Name = "btnUCAliens";
            this.btnUCAliens.Size = new System.Drawing.Size(305, 73);
            this.btnUCAliens.TabIndex = 8;
            this.btnUCAliens.texteBouton = "Découverte des aliens";
            // 
            // btnUCNouvelleMission
            // 
            this.btnUCNouvelleMission.BackColor = System.Drawing.Color.Transparent;
            this.btnUCNouvelleMission.imageBouton = ((System.Drawing.Image)(resources.GetObject("btnUCNouvelleMission.imageBouton")));
            this.btnUCNouvelleMission.Location = new System.Drawing.Point(105, 776);
            this.btnUCNouvelleMission.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnUCNouvelleMission.Name = "btnUCNouvelleMission";
            this.btnUCNouvelleMission.Size = new System.Drawing.Size(305, 75);
            this.btnUCNouvelleMission.TabIndex = 7;
            this.btnUCNouvelleMission.texteBouton = "Nouvelle mission";
            // 
            // btnUCTableauDeBord
            // 
            this.btnUCTableauDeBord.BackColor = System.Drawing.Color.Transparent;
            this.btnUCTableauDeBord.imageBouton = ((System.Drawing.Image)(resources.GetObject("btnUCTableauDeBord.imageBouton")));
            this.btnUCTableauDeBord.Location = new System.Drawing.Point(105, 350);
            this.btnUCTableauDeBord.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnUCTableauDeBord.Name = "btnUCTableauDeBord";
            this.btnUCTableauDeBord.Size = new System.Drawing.Size(305, 77);
            this.btnUCTableauDeBord.TabIndex = 6;
            this.btnUCTableauDeBord.texteBouton = "Tableau de bord";
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1744, 1017);
            this.Controls.Add(this.grpFiltrePlanete);
            this.Controls.Add(this.grpFiltre);
            this.Controls.Add(this.btnUCStatistiques);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnUCInfoPlanete);
            this.Controls.Add(this.btnUCAliens);
            this.Controls.Add(this.btnUCNouvelleMission);
            this.Controls.Add(this.btnUCTableauDeBord);
            this.Controls.Add(this.tabAffichage);
            this.Controls.Add(this.tabControlMission);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.Name = "FormAccueil";
            this.Text = "Stargate";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.grpFiltre.ResumeLayout(false);
            this.grpFiltre.PerformLayout();
            this.gpbFiltreEnnemi.ResumeLayout(false);
            this.gpbFiltreEnnemi.PerformLayout();
            this.gpbFiltreAllie.ResumeLayout(false);
            this.gpbFiltreAllie.PerformLayout();
            this.grpFiltrePlanete.ResumeLayout(false);
            this.grpFiltrePlanete.PerformLayout();
            this.tab5.ResumeLayout(false);
            this.tab5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab5Informateur)).EndInit();
            this.tab4.ResumeLayout(false);
            this.tab4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab4Depenses)).EndInit();
            this.tab3.ResumeLayout(false);
            this.tab3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphMissionPlanetes)).EndInit();
            this.tab2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab2)).EndInit();
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTab1CopainMission)).EndInit();
            this.tabAffichage.ResumeLayout(false);
            this.tabControlMission.ResumeLayout(false);
            this.tabMissionsEnCours.ResumeLayout(false);
            this.tabMissionsAVenir.ResumeLayout(false);
            this.tabMissionsTerminees.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UserControlBoutonAvecImage.UCBoutonImage btnUCTableauDeBord;
        private UserControlBoutonAvecImage.UCBoutonImage btnUCNouvelleMission;
        private UserControlBoutonAvecImage.UCBoutonImage btnUCAliens;
        private UserControlBoutonAvecImage.UCBoutonImage btnUCInfoPlanete;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblAucuneMissionTerminee;
        private System.Windows.Forms.GroupBox grpFiltre;
        private System.Windows.Forms.CheckBox ckbFiltreNeutre;
        private System.Windows.Forms.CheckBox ckbFiltreEnnemi;
        private System.Windows.Forms.CheckBox ckbFiltreAllie;
        private System.Windows.Forms.Label lblFiltreStatut;
        private System.Windows.Forms.ComboBox cboFiltreCouleur;
        private System.Windows.Forms.Label lblFiltreCouleur;
        private System.Windows.Forms.TextBox txtFiltreNom;
        private System.Windows.Forms.Label lblFiltreNom;
        private System.Windows.Forms.ComboBox cboDegMal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDegBien;
        private System.Windows.Forms.Label lblFiltreDegBien;
        private System.Windows.Forms.GroupBox gpbFiltreAllie;
        private System.Windows.Forms.ComboBox cboFiltreArme;
        private System.Windows.Forms.Label lblFiltreArme;
        private System.Windows.Forms.ComboBox cboFiltreInstrument;
        private System.Windows.Forms.Label lblFiltreInstrument;
        private System.Windows.Forms.GroupBox gpbFiltreEnnemi;
        private System.Windows.Forms.Button btnSupprimerFiltre;
        private System.Windows.Forms.Button btnAppliquerFiltre;
        private System.Windows.Forms.ComboBox cboFiltrePlanete;
        private System.Windows.Forms.Label lblFiltrePlanete;
        private System.Windows.Forms.GroupBox grpFiltrePlanete;
        private System.Windows.Forms.Button btnSupprimerFiltrePlanete;
        private System.Windows.Forms.Button btnAppliquerFiltrePlanete;
        private System.Windows.Forms.CheckBox ckbDataBazInconnu;
        private System.Windows.Forms.CheckBox ckbADataBaz;
        private System.Windows.Forms.CheckBox ckbPDataBaz;
        private System.Windows.Forms.Label lblFiltreDataBaz;
        private System.Windows.Forms.Label lblTempMin;
        private System.Windows.Forms.TextBox txtFiltreNomPlanete;
        private System.Windows.Forms.Label lblFiltreNomPlanete;
        private System.Windows.Forms.TextBox txtTempMax;
        private System.Windows.Forms.Label lblTempMax;
        private System.Windows.Forms.TextBox txtTempMin;
        private System.Windows.Forms.TextBox txtGraviteMax;
        private System.Windows.Forms.Label lblGraviteMax;
        private System.Windows.Forms.TextBox txtGraviteMin;
        private System.Windows.Forms.Label lblGraviteMin;
        private UserControlBoutonAvecImage.UCBoutonImage btnUCStatistiques;
        private System.Windows.Forms.TabPage tab5;
        private System.Windows.Forms.ComboBox cboTab5Missions;
        private System.Windows.Forms.Label lblInformateursMalRemuneres;
        private System.Windows.Forms.Label lblTab5Mission;
        private System.Windows.Forms.DataGridView dgvTab5Informateur;
        private System.Windows.Forms.TabPage tab4;
        private System.Windows.Forms.Label lblTab4Depenses;
        private System.Windows.Forms.DataGridView dgvTab4Depenses;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.Label lblTab3nbMission;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphMissionPlanetes;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.DataGridView dgvTab2;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.ComboBox cboTab1MembreMission;
        private System.Windows.Forms.Label lblTab1CopainMission;
        private System.Windows.Forms.DataGridView dgvTab1CopainMission;
        private System.Windows.Forms.Label lblTab1MembreMission;
        private System.Windows.Forms.TabControl tabAffichage;
        private System.Windows.Forms.TabControl tabControlMission;
        private System.Windows.Forms.TabPage tabMissionsEnCours;
        private System.Windows.Forms.TabPage tabMissionsAVenir;
        private System.Windows.Forms.TabPage tabMissionsTerminees;
        private System.Windows.Forms.FlowLayoutPanel flpMissionTerminee;
        private System.Windows.Forms.FlowLayoutPanel flpMissionEnCours;
        private System.Windows.Forms.FlowLayoutPanel flpMissionsAVenir;
        private System.Windows.Forms.Label lblAucunResultat;
    }
}


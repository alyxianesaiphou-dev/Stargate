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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnUCInfoPlanete = new UserControlBoutonAvecImage.UCBoutonImage();
            this.btnUCAliens = new UserControlBoutonAvecImage.UCBoutonImage();
            this.btnUCNouvelleMission = new UserControlBoutonAvecImage.UCBoutonImage();
            this.btnUCTableauDeBord = new UserControlBoutonAvecImage.UCBoutonImage();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.lblAucuneMissionTerminee = new System.Windows.Forms.Label();
            this.flpMissionsTerminees = new System.Windows.Forms.FlowLayoutPanel();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.lblAucuneMissionEnCours = new System.Windows.Forms.Label();
            this.flpMissionsEnCours = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControlMissions = new System.Windows.Forms.TabControl();
            this.grpFiltre = new System.Windows.Forms.GroupBox();
            this.btnSupprimerFiltre = new System.Windows.Forms.Button();
            this.btnAppliquerFiltre = new System.Windows.Forms.Button();
            this.gpbFiltreEnnemi = new System.Windows.Forms.GroupBox();
            this.cboFiltreArme = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDegMal = new System.Windows.Forms.ComboBox();
            this.lblFiltreArme = new System.Windows.Forms.Label();
            this.gpbFiltreAllie = new System.Windows.Forms.GroupBox();
            this.cboFiltreInstrument = new System.Windows.Forms.ComboBox();
            this.lblFiltreDegBien = new System.Windows.Forms.Label();
            this.cboDegBien = new System.Windows.Forms.ComboBox();
            this.lblFiltreInstrument = new System.Windows.Forms.Label();
            this.ckbFiltreNeutre = new System.Windows.Forms.CheckBox();
            this.ckbFiltreEnnemi = new System.Windows.Forms.CheckBox();
            this.ckbFiltreAllie = new System.Windows.Forms.CheckBox();
            this.lblFiltreStatut = new System.Windows.Forms.Label();
            this.cboFiltreCouleur = new System.Windows.Forms.ComboBox();
            this.lblFiltreCouleur = new System.Windows.Forms.Label();
            this.txtFiltreNom = new System.Windows.Forms.TextBox();
            this.lblFiltreNom = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.tab2.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tabControlMissions.SuspendLayout();
            this.grpFiltre.SuspendLayout();
            this.gpbFiltreEnnemi.SuspendLayout();
            this.gpbFiltreAllie.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogo.BackgroundImage")));
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(97, 29);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(322, 123);
            this.picLogo.TabIndex = 10;
            this.picLogo.TabStop = false;
            // 
            // btnUCInfoPlanete
            // 
            this.btnUCInfoPlanete.BackColor = System.Drawing.Color.Transparent;
            this.btnUCInfoPlanete.imageBouton = ((System.Drawing.Image)(resources.GetObject("btnUCInfoPlanete.imageBouton")));
            this.btnUCInfoPlanete.Location = new System.Drawing.Point(97, 506);
            this.btnUCInfoPlanete.Name = "btnUCInfoPlanete";
            this.btnUCInfoPlanete.Size = new System.Drawing.Size(331, 89);
            this.btnUCInfoPlanete.TabIndex = 9;
            this.btnUCInfoPlanete.texteBouton = "Information planètes";
            // 
            // btnUCAliens
            // 
            this.btnUCAliens.BackColor = System.Drawing.Color.Transparent;
            this.btnUCAliens.imageBouton = ((System.Drawing.Image)(resources.GetObject("btnUCAliens.imageBouton")));
            this.btnUCAliens.Location = new System.Drawing.Point(97, 396);
            this.btnUCAliens.Name = "btnUCAliens";
            this.btnUCAliens.Size = new System.Drawing.Size(325, 89);
            this.btnUCAliens.TabIndex = 8;
            this.btnUCAliens.texteBouton = "Découverte des aliens";
            // 
            // btnUCNouvelleMission
            // 
            this.btnUCNouvelleMission.BackColor = System.Drawing.Color.Transparent;
            this.btnUCNouvelleMission.imageBouton = ((System.Drawing.Image)(resources.GetObject("btnUCNouvelleMission.imageBouton")));
            this.btnUCNouvelleMission.Location = new System.Drawing.Point(97, 287);
            this.btnUCNouvelleMission.Name = "btnUCNouvelleMission";
            this.btnUCNouvelleMission.Size = new System.Drawing.Size(325, 89);
            this.btnUCNouvelleMission.TabIndex = 7;
            this.btnUCNouvelleMission.texteBouton = "Nouvelle mission";
            // 
            // btnUCTableauDeBord
            // 
            this.btnUCTableauDeBord.BackColor = System.Drawing.Color.Transparent;
            this.btnUCTableauDeBord.imageBouton = ((System.Drawing.Image)(resources.GetObject("btnUCTableauDeBord.imageBouton")));
            this.btnUCTableauDeBord.Location = new System.Drawing.Point(97, 181);
            this.btnUCTableauDeBord.Name = "btnUCTableauDeBord";
            this.btnUCTableauDeBord.Size = new System.Drawing.Size(325, 89);
            this.btnUCTableauDeBord.TabIndex = 6;
            this.btnUCTableauDeBord.texteBouton = "Tableau de bord";
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tab2.Controls.Add(this.lblAucuneMissionTerminee);
            this.tab2.Controls.Add(this.flpMissionsTerminees);
            this.tab2.Location = new System.Drawing.Point(4, 25);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(761, 520);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Missions terminées";
            // 
            // lblAucuneMissionTerminee
            // 
            this.lblAucuneMissionTerminee.AutoSize = true;
            this.lblAucuneMissionTerminee.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAucuneMissionTerminee.ForeColor = System.Drawing.Color.White;
            this.lblAucuneMissionTerminee.Location = new System.Drawing.Point(239, 32);
            this.lblAucuneMissionTerminee.Name = "lblAucuneMissionTerminee";
            this.lblAucuneMissionTerminee.Size = new System.Drawing.Size(283, 29);
            this.lblAucuneMissionTerminee.TabIndex = 1;
            this.lblAucuneMissionTerminee.Text = "Aucune mission terminée";
            this.lblAucuneMissionTerminee.Visible = false;
            // 
            // flpMissionsTerminees
            // 
            this.flpMissionsTerminees.Location = new System.Drawing.Point(0, 0);
            this.flpMissionsTerminees.Name = "flpMissionsTerminees";
            this.flpMissionsTerminees.Size = new System.Drawing.Size(765, 524);
            this.flpMissionsTerminees.TabIndex = 0;
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tab1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tab1.Controls.Add(this.lblAucuneMissionEnCours);
            this.tab1.Controls.Add(this.flpMissionsEnCours);
            this.tab1.Location = new System.Drawing.Point(4, 25);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(761, 520);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Missions en cours";
            // 
            // lblAucuneMissionEnCours
            // 
            this.lblAucuneMissionEnCours.AutoSize = true;
            this.lblAucuneMissionEnCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAucuneMissionEnCours.ForeColor = System.Drawing.Color.White;
            this.lblAucuneMissionEnCours.Location = new System.Drawing.Point(248, 25);
            this.lblAucuneMissionEnCours.Name = "lblAucuneMissionEnCours";
            this.lblAucuneMissionEnCours.Size = new System.Drawing.Size(280, 29);
            this.lblAucuneMissionEnCours.TabIndex = 0;
            this.lblAucuneMissionEnCours.Text = "Aucune mission en cours";
            this.lblAucuneMissionEnCours.Visible = false;
            // 
            // flpMissionsEnCours
            // 
            this.flpMissionsEnCours.AutoScroll = true;
            this.flpMissionsEnCours.BackColor = System.Drawing.Color.Transparent;
            this.flpMissionsEnCours.Location = new System.Drawing.Point(0, 0);
            this.flpMissionsEnCours.Name = "flpMissionsEnCours";
            this.flpMissionsEnCours.Size = new System.Drawing.Size(765, 520);
            this.flpMissionsEnCours.TabIndex = 0;
            // 
            // tabControlMissions
            // 
            this.tabControlMissions.Controls.Add(this.tab1);
            this.tabControlMissions.Controls.Add(this.tab2);
            this.tabControlMissions.Location = new System.Drawing.Point(535, 43);
            this.tabControlMissions.Name = "tabControlMissions";
            this.tabControlMissions.SelectedIndex = 0;
            this.tabControlMissions.Size = new System.Drawing.Size(769, 549);
            this.tabControlMissions.TabIndex = 5;
            this.tabControlMissions.Visible = false;
            // 
            // grpFiltre
            // 
            this.grpFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
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
            this.grpFiltre.ForeColor = System.Drawing.Color.White;
            this.grpFiltre.Location = new System.Drawing.Point(476, 622);
            this.grpFiltre.Name = "grpFiltre";
            this.grpFiltre.Size = new System.Drawing.Size(840, 332);
            this.grpFiltre.TabIndex = 11;
            this.grpFiltre.TabStop = false;
            this.grpFiltre.Text = "Filtres";
            this.grpFiltre.Visible = false;
            this.grpFiltre.Enter += new System.EventHandler(this.grpFiltre_Enter);
            // 
            // btnSupprimerFiltre
            // 
            this.btnSupprimerFiltre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSupprimerFiltre.Location = new System.Drawing.Point(546, 286);
            this.btnSupprimerFiltre.Name = "btnSupprimerFiltre";
            this.btnSupprimerFiltre.Size = new System.Drawing.Size(131, 32);
            this.btnSupprimerFiltre.TabIndex = 19;
            this.btnSupprimerFiltre.Text = "Supprimer";
            this.btnSupprimerFiltre.UseVisualStyleBackColor = true;
            this.btnSupprimerFiltre.Click += new System.EventHandler(this.btnSupprimerFiltre_Click);
            // 
            // btnAppliquerFiltre
            // 
            this.btnAppliquerFiltre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAppliquerFiltre.Location = new System.Drawing.Point(693, 286);
            this.btnAppliquerFiltre.Name = "btnAppliquerFiltre";
            this.btnAppliquerFiltre.Size = new System.Drawing.Size(131, 32);
            this.btnAppliquerFiltre.TabIndex = 18;
            this.btnAppliquerFiltre.Text = "Appliquer";
            this.btnAppliquerFiltre.UseVisualStyleBackColor = true;
            this.btnAppliquerFiltre.Click += new System.EventHandler(this.btnAppliquerFiltre_Click);
            // 
            // gpbFiltreEnnemi
            // 
            this.gpbFiltreEnnemi.Controls.Add(this.cboFiltreArme);
            this.gpbFiltreEnnemi.Controls.Add(this.label1);
            this.gpbFiltreEnnemi.Controls.Add(this.cboDegMal);
            this.gpbFiltreEnnemi.Controls.Add(this.lblFiltreArme);
            this.gpbFiltreEnnemi.Location = new System.Drawing.Point(25, 197);
            this.gpbFiltreEnnemi.Name = "gpbFiltreEnnemi";
            this.gpbFiltreEnnemi.Size = new System.Drawing.Size(799, 74);
            this.gpbFiltreEnnemi.TabIndex = 17;
            this.gpbFiltreEnnemi.TabStop = false;
            this.gpbFiltreEnnemi.Text = "Filtres ennemis";
            this.gpbFiltreEnnemi.Visible = false;
            // 
            // cboFiltreArme
            // 
            this.cboFiltreArme.FormattingEnabled = true;
            this.cboFiltreArme.Location = new System.Drawing.Point(551, 31);
            this.cboFiltreArme.Name = "cboFiltreArme";
            this.cboFiltreArme.Size = new System.Drawing.Size(215, 24);
            this.cboFiltreArme.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Degré de malveillance :";
            // 
            // cboDegMal
            // 
            this.cboDegMal.FormattingEnabled = true;
            this.cboDegMal.Location = new System.Drawing.Point(182, 31);
            this.cboDegMal.Name = "cboDegMal";
            this.cboDegMal.Size = new System.Drawing.Size(141, 24);
            this.cboDegMal.TabIndex = 11;
            // 
            // lblFiltreArme
            // 
            this.lblFiltreArme.AutoSize = true;
            this.lblFiltreArme.Location = new System.Drawing.Point(456, 34);
            this.lblFiltreArme.Name = "lblFiltreArme";
            this.lblFiltreArme.Size = new System.Drawing.Size(48, 16);
            this.lblFiltreArme.TabIndex = 14;
            this.lblFiltreArme.Text = "Arme  :";
            // 
            // gpbFiltreAllie
            // 
            this.gpbFiltreAllie.Controls.Add(this.cboFiltreInstrument);
            this.gpbFiltreAllie.Controls.Add(this.lblFiltreDegBien);
            this.gpbFiltreAllie.Controls.Add(this.cboDegBien);
            this.gpbFiltreAllie.Controls.Add(this.lblFiltreInstrument);
            this.gpbFiltreAllie.Location = new System.Drawing.Point(25, 105);
            this.gpbFiltreAllie.Name = "gpbFiltreAllie";
            this.gpbFiltreAllie.Size = new System.Drawing.Size(799, 76);
            this.gpbFiltreAllie.TabIndex = 16;
            this.gpbFiltreAllie.TabStop = false;
            this.gpbFiltreAllie.Text = "Filtres alliés";
            this.gpbFiltreAllie.Visible = false;
            // 
            // cboFiltreInstrument
            // 
            this.cboFiltreInstrument.FormattingEnabled = true;
            this.cboFiltreInstrument.Location = new System.Drawing.Point(551, 34);
            this.cboFiltreInstrument.Name = "cboFiltreInstrument";
            this.cboFiltreInstrument.Size = new System.Drawing.Size(215, 24);
            this.cboFiltreInstrument.TabIndex = 13;
            // 
            // lblFiltreDegBien
            // 
            this.lblFiltreDegBien.AutoSize = true;
            this.lblFiltreDegBien.Location = new System.Drawing.Point(13, 37);
            this.lblFiltreDegBien.Name = "lblFiltreDegBien";
            this.lblFiltreDegBien.Size = new System.Drawing.Size(153, 16);
            this.lblFiltreDegBien.TabIndex = 8;
            this.lblFiltreDegBien.Text = "Degré de bienveillance :";
            // 
            // cboDegBien
            // 
            this.cboDegBien.FormattingEnabled = true;
            this.cboDegBien.Location = new System.Drawing.Point(182, 34);
            this.cboDegBien.Name = "cboDegBien";
            this.cboDegBien.Size = new System.Drawing.Size(141, 24);
            this.cboDegBien.TabIndex = 9;
            // 
            // lblFiltreInstrument
            // 
            this.lblFiltreInstrument.AutoSize = true;
            this.lblFiltreInstrument.Location = new System.Drawing.Point(456, 37);
            this.lblFiltreInstrument.Name = "lblFiltreInstrument";
            this.lblFiltreInstrument.Size = new System.Drawing.Size(73, 16);
            this.lblFiltreInstrument.TabIndex = 12;
            this.lblFiltreInstrument.Text = "Instrument :";
            // 
            // ckbFiltreNeutre
            // 
            this.ckbFiltreNeutre.AutoSize = true;
            this.ckbFiltreNeutre.Location = new System.Drawing.Point(722, 31);
            this.ckbFiltreNeutre.Name = "ckbFiltreNeutre";
            this.ckbFiltreNeutre.Size = new System.Drawing.Size(69, 20);
            this.ckbFiltreNeutre.TabIndex = 7;
            this.ckbFiltreNeutre.Text = "Neutre";
            this.ckbFiltreNeutre.UseVisualStyleBackColor = true;
            // 
            // ckbFiltreEnnemi
            // 
            this.ckbFiltreEnnemi.AutoSize = true;
            this.ckbFiltreEnnemi.Location = new System.Drawing.Point(632, 31);
            this.ckbFiltreEnnemi.Name = "ckbFiltreEnnemi";
            this.ckbFiltreEnnemi.Size = new System.Drawing.Size(74, 20);
            this.ckbFiltreEnnemi.TabIndex = 6;
            this.ckbFiltreEnnemi.Text = "Ennemi";
            this.ckbFiltreEnnemi.UseVisualStyleBackColor = true;
            this.ckbFiltreEnnemi.CheckedChanged += new System.EventHandler(this.ckbFiltreEnnemi_CheckedChanged);
            // 
            // ckbFiltreAllie
            // 
            this.ckbFiltreAllie.AutoSize = true;
            this.ckbFiltreAllie.Location = new System.Drawing.Point(559, 30);
            this.ckbFiltreAllie.Name = "ckbFiltreAllie";
            this.ckbFiltreAllie.Size = new System.Drawing.Size(55, 20);
            this.ckbFiltreAllie.TabIndex = 5;
            this.ckbFiltreAllie.Text = "Allié";
            this.ckbFiltreAllie.UseVisualStyleBackColor = true;
            this.ckbFiltreAllie.CheckedChanged += new System.EventHandler(this.ckbFiltreAllie_CheckedChanged);
            // 
            // lblFiltreStatut
            // 
            this.lblFiltreStatut.AutoSize = true;
            this.lblFiltreStatut.Location = new System.Drawing.Point(481, 31);
            this.lblFiltreStatut.Name = "lblFiltreStatut";
            this.lblFiltreStatut.Size = new System.Drawing.Size(46, 16);
            this.lblFiltreStatut.TabIndex = 4;
            this.lblFiltreStatut.Text = "Statut :";
            // 
            // cboFiltreCouleur
            // 
            this.cboFiltreCouleur.FormattingEnabled = true;
            this.cboFiltreCouleur.Location = new System.Drawing.Point(115, 64);
            this.cboFiltreCouleur.Name = "cboFiltreCouleur";
            this.cboFiltreCouleur.Size = new System.Drawing.Size(232, 24);
            this.cboFiltreCouleur.TabIndex = 3;
            // 
            // lblFiltreCouleur
            // 
            this.lblFiltreCouleur.AutoSize = true;
            this.lblFiltreCouleur.Location = new System.Drawing.Point(37, 67);
            this.lblFiltreCouleur.Name = "lblFiltreCouleur";
            this.lblFiltreCouleur.Size = new System.Drawing.Size(59, 16);
            this.lblFiltreCouleur.TabIndex = 2;
            this.lblFiltreCouleur.Text = "Couleur :";
            // 
            // txtFiltreNom
            // 
            this.txtFiltreNom.Location = new System.Drawing.Point(115, 25);
            this.txtFiltreNom.Name = "txtFiltreNom";
            this.txtFiltreNom.Size = new System.Drawing.Size(232, 22);
            this.txtFiltreNom.TabIndex = 1;
            // 
            // lblFiltreNom
            // 
            this.lblFiltreNom.AutoSize = true;
            this.lblFiltreNom.Location = new System.Drawing.Point(37, 28);
            this.lblFiltreNom.Name = "lblFiltreNom";
            this.lblFiltreNom.Size = new System.Drawing.Size(42, 16);
            this.lblFiltreNom.TabIndex = 0;
            this.lblFiltreNom.Text = "Nom :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(281, 676);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1343, 1013);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.grpFiltre);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnUCInfoPlanete);
            this.Controls.Add(this.btnUCAliens);
            this.Controls.Add(this.btnUCNouvelleMission);
            this.Controls.Add(this.btnUCTableauDeBord);
            this.Controls.Add(this.tabControlMissions);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormAccueil";
            this.Text = "Stargate";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tabControlMissions.ResumeLayout(false);
            this.grpFiltre.ResumeLayout(false);
            this.grpFiltre.PerformLayout();
            this.gpbFiltreEnnemi.ResumeLayout(false);
            this.gpbFiltreEnnemi.PerformLayout();
            this.gpbFiltreAllie.ResumeLayout(false);
            this.gpbFiltreAllie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private UserControlBoutonAvecImage.UCBoutonImage btnUCTableauDeBord;
        private UserControlBoutonAvecImage.UCBoutonImage btnUCNouvelleMission;
        private UserControlBoutonAvecImage.UCBoutonImage btnUCAliens;
        private UserControlBoutonAvecImage.UCBoutonImage btnUCInfoPlanete;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.Label lblAucuneMissionTerminee;
        private System.Windows.Forms.FlowLayoutPanel flpMissionsTerminees;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.Label lblAucuneMissionEnCours;
        private System.Windows.Forms.FlowLayoutPanel flpMissionsEnCours;
        private System.Windows.Forms.TabControl tabControlMissions;
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
        private System.Windows.Forms.Button button2;
    }
}


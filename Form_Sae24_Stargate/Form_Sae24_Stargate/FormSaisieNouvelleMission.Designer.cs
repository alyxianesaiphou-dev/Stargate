namespace Form_Sae24_Stargate
{
    partial class FormSaisieNouvelleMission
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpbRecapMission = new System.Windows.Forms.GroupBox();
            this.listViewCapture = new System.Windows.Forms.ListView();
            this.lblObjectifCapture = new System.Windows.Forms.Label();
            this.listViewMembre = new System.Windows.Forms.ListView();
            this.lbbMembreMission = new System.Windows.Forms.Label();
            this.lblBudget = new System.Windows.Forms.Label();
            this.lblObjectifDataBaz = new System.Windows.Forms.Label();
            this.txtFeuilleRoute = new System.Windows.Forms.RichTextBox();
            this.lblFeuilleRoute = new System.Windows.Forms.Label();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.lblChef = new System.Windows.Forms.Label();
            this.lblPlanete = new System.Windows.Forms.Label();
            this.gpbChoixPlanete = new System.Windows.Forms.GroupBox();
            this.flpChoixPlanete = new System.Windows.Forms.FlowLayoutPanel();
            this.gpbChoixMembreMission = new System.Windows.Forms.GroupBox();
            this.lblNbMembreRestant = new System.Windows.Forms.Label();
            this.flpMembreMission = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrecedent = new System.Windows.Forms.Button();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.btnValiderMission = new System.Windows.Forms.Button();
            this.gpbChoixChef = new System.Windows.Forms.GroupBox();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.lblChoixChef = new System.Windows.Forms.Label();
            this.dtpDebut = new System.Windows.Forms.DateTimePicker();
            this.flpChef = new System.Windows.Forms.FlowLayoutPanel();
            this.lblChoixFin = new System.Windows.Forms.Label();
            this.lblChoixDebut = new System.Windows.Forms.Label();
            this.gpbChoixParametresMission = new System.Windows.Forms.GroupBox();
            this.numBudget = new System.Windows.Forms.NumericUpDown();
            this.numObjDataBaz = new System.Windows.Forms.NumericUpDown();
            this.numNbMembre = new System.Windows.Forms.NumericUpDown();
            this.lblChoixBudget = new System.Windows.Forms.Label();
            this.txtSaisieFeuilleRoute = new System.Windows.Forms.RichTextBox();
            this.lblChoixObjDataBaz = new System.Windows.Forms.Label();
            this.lblChoixNbMembre = new System.Windows.Forms.Label();
            this.lblSaisieFeuilleRoute = new System.Windows.Forms.Label();
            this.grbChoixCaptures = new System.Windows.Forms.GroupBox();
            this.flpCaptures = new System.Windows.Forms.FlowLayoutPanel();
            this.gpbRecapMission.SuspendLayout();
            this.gpbChoixPlanete.SuspendLayout();
            this.gpbChoixMembreMission.SuspendLayout();
            this.gpbChoixChef.SuspendLayout();
            this.gpbChoixParametresMission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numObjDataBaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNbMembre)).BeginInit();
            this.grbChoixCaptures.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbRecapMission
            // 
            this.gpbRecapMission.Controls.Add(this.listViewCapture);
            this.gpbRecapMission.Controls.Add(this.lblObjectifCapture);
            this.gpbRecapMission.Controls.Add(this.listViewMembre);
            this.gpbRecapMission.Controls.Add(this.lbbMembreMission);
            this.gpbRecapMission.Controls.Add(this.lblBudget);
            this.gpbRecapMission.Controls.Add(this.lblObjectifDataBaz);
            this.gpbRecapMission.Controls.Add(this.txtFeuilleRoute);
            this.gpbRecapMission.Controls.Add(this.lblFeuilleRoute);
            this.gpbRecapMission.Controls.Add(this.lblDateFin);
            this.gpbRecapMission.Controls.Add(this.lblDateDebut);
            this.gpbRecapMission.Controls.Add(this.lblChef);
            this.gpbRecapMission.Controls.Add(this.lblPlanete);
            this.gpbRecapMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbRecapMission.ForeColor = System.Drawing.Color.White;
            this.gpbRecapMission.Location = new System.Drawing.Point(21, 30);
            this.gpbRecapMission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbRecapMission.Name = "gpbRecapMission";
            this.gpbRecapMission.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbRecapMission.Size = new System.Drawing.Size(667, 946);
            this.gpbRecapMission.TabIndex = 0;
            this.gpbRecapMission.TabStop = false;
            this.gpbRecapMission.Text = "Récapitulatif Mission";
            // 
            // listViewCapture
            // 
            this.listViewCapture.HideSelection = false;
            this.listViewCapture.Location = new System.Drawing.Point(29, 789);
            this.listViewCapture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewCapture.Name = "listViewCapture";
            this.listViewCapture.Size = new System.Drawing.Size(617, 115);
            this.listViewCapture.TabIndex = 11;
            this.listViewCapture.UseCompatibleStateImageBehavior = false;
            this.listViewCapture.Visible = false;
            // 
            // lblObjectifCapture
            // 
            this.lblObjectifCapture.AutoSize = true;
            this.lblObjectifCapture.Location = new System.Drawing.Point(21, 751);
            this.lblObjectifCapture.Name = "lblObjectifCapture";
            this.lblObjectifCapture.Size = new System.Drawing.Size(186, 25);
            this.lblObjectifCapture.TabIndex = 10;
            this.lblObjectifCapture.Text = "Objectif de capture :";
            this.lblObjectifCapture.Visible = false;
            // 
            // listViewMembre
            // 
            this.listViewMembre.HideSelection = false;
            this.listViewMembre.Location = new System.Drawing.Point(27, 606);
            this.listViewMembre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewMembre.Name = "listViewMembre";
            this.listViewMembre.Size = new System.Drawing.Size(619, 121);
            this.listViewMembre.TabIndex = 9;
            this.listViewMembre.UseCompatibleStateImageBehavior = false;
            this.listViewMembre.Visible = false;
            // 
            // lbbMembreMission
            // 
            this.lbbMembreMission.AutoSize = true;
            this.lbbMembreMission.Location = new System.Drawing.Point(21, 558);
            this.lbbMembreMission.Name = "lbbMembreMission";
            this.lbbMembreMission.Size = new System.Drawing.Size(218, 25);
            this.lbbMembreMission.TabIndex = 8;
            this.lbbMembreMission.Text = "Membres (nbMembre) :";
            this.lbbMembreMission.Visible = false;
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.Location = new System.Drawing.Point(21, 498);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(85, 25);
            this.lblBudget.TabIndex = 7;
            this.lblBudget.Text = "Budget :";
            this.lblBudget.Visible = false;
            // 
            // lblObjectifDataBaz
            // 
            this.lblObjectifDataBaz.AutoSize = true;
            this.lblObjectifDataBaz.Location = new System.Drawing.Point(21, 442);
            this.lblObjectifDataBaz.Name = "lblObjectifDataBaz";
            this.lblObjectifDataBaz.Size = new System.Drawing.Size(166, 25);
            this.lblObjectifDataBaz.TabIndex = 6;
            this.lblObjectifDataBaz.Text = "Objectif dataBaz :";
            this.lblObjectifDataBaz.Visible = false;
            // 
            // txtFeuilleRoute
            // 
            this.txtFeuilleRoute.Location = new System.Drawing.Point(29, 261);
            this.txtFeuilleRoute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFeuilleRoute.Name = "txtFeuilleRoute";
            this.txtFeuilleRoute.ReadOnly = true;
            this.txtFeuilleRoute.Size = new System.Drawing.Size(617, 154);
            this.txtFeuilleRoute.TabIndex = 5;
            this.txtFeuilleRoute.Text = "";
            this.txtFeuilleRoute.Visible = false;
            // 
            // lblFeuilleRoute
            // 
            this.lblFeuilleRoute.AutoSize = true;
            this.lblFeuilleRoute.Location = new System.Drawing.Point(21, 214);
            this.lblFeuilleRoute.Name = "lblFeuilleRoute";
            this.lblFeuilleRoute.Size = new System.Drawing.Size(156, 25);
            this.lblFeuilleRoute.TabIndex = 4;
            this.lblFeuilleRoute.Text = "Feuille de route :";
            this.lblFeuilleRoute.Visible = false;
            // 
            // lblDateFin
            // 
            this.lblDateFin.AutoSize = true;
            this.lblDateFin.Location = new System.Drawing.Point(403, 162);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(221, 25);
            this.lblDateFin.TabIndex = 3;
            this.lblDateFin.Text = "Date de fin : 04/06/2026";
            this.lblDateFin.Visible = false;
            // 
            // lblDateDebut
            // 
            this.lblDateDebut.AutoSize = true;
            this.lblDateDebut.Location = new System.Drawing.Point(21, 162);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(250, 25);
            this.lblDateDebut.TabIndex = 2;
            this.lblDateDebut.Text = "Date de début : 04/06/2026";
            this.lblDateDebut.Visible = false;
            // 
            // lblChef
            // 
            this.lblChef.AutoSize = true;
            this.lblChef.Location = new System.Drawing.Point(21, 108);
            this.lblChef.Name = "lblChef";
            this.lblChef.Size = new System.Drawing.Size(163, 25);
            this.lblChef.TabIndex = 1;
            this.lblChef.Text = "Chef de mission :";
            this.lblChef.Visible = false;
            // 
            // lblPlanete
            // 
            this.lblPlanete.AutoSize = true;
            this.lblPlanete.Location = new System.Drawing.Point(21, 58);
            this.lblPlanete.Name = "lblPlanete";
            this.lblPlanete.Size = new System.Drawing.Size(89, 25);
            this.lblPlanete.TabIndex = 0;
            this.lblPlanete.Text = "Planète :";
            this.lblPlanete.Visible = false;
            // 
            // gpbChoixPlanete
            // 
            this.gpbChoixPlanete.Controls.Add(this.flpChoixPlanete);
            this.gpbChoixPlanete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbChoixPlanete.ForeColor = System.Drawing.Color.White;
            this.gpbChoixPlanete.Location = new System.Drawing.Point(713, 30);
            this.gpbChoixPlanete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbChoixPlanete.Name = "gpbChoixPlanete";
            this.gpbChoixPlanete.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbChoixPlanete.Size = new System.Drawing.Size(1201, 886);
            this.gpbChoixPlanete.TabIndex = 1;
            this.gpbChoixPlanete.TabStop = false;
            this.gpbChoixPlanete.Text = "Choix de la planète";
            this.gpbChoixPlanete.Visible = false;
            // 
            // flpChoixPlanete
            // 
            this.flpChoixPlanete.AutoScroll = true;
            this.flpChoixPlanete.BackColor = System.Drawing.Color.Transparent;
            this.flpChoixPlanete.Location = new System.Drawing.Point(49, 57);
            this.flpChoixPlanete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpChoixPlanete.Name = "flpChoixPlanete";
            this.flpChoixPlanete.Size = new System.Drawing.Size(1116, 800);
            this.flpChoixPlanete.TabIndex = 0;
            // 
            // gpbChoixMembreMission
            // 
            this.gpbChoixMembreMission.Controls.Add(this.lblNbMembreRestant);
            this.gpbChoixMembreMission.Controls.Add(this.flpMembreMission);
            this.gpbChoixMembreMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbChoixMembreMission.ForeColor = System.Drawing.Color.White;
            this.gpbChoixMembreMission.Location = new System.Drawing.Point(715, 28);
            this.gpbChoixMembreMission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbChoixMembreMission.Name = "gpbChoixMembreMission";
            this.gpbChoixMembreMission.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbChoixMembreMission.Size = new System.Drawing.Size(1201, 886);
            this.gpbChoixMembreMission.TabIndex = 6;
            this.gpbChoixMembreMission.TabStop = false;
            this.gpbChoixMembreMission.Text = "Choix des membres de la mission";
            this.gpbChoixMembreMission.Visible = false;
            // 
            // lblNbMembreRestant
            // 
            this.lblNbMembreRestant.AutoSize = true;
            this.lblNbMembreRestant.Location = new System.Drawing.Point(44, 57);
            this.lblNbMembreRestant.Name = "lblNbMembreRestant";
            this.lblNbMembreRestant.Size = new System.Drawing.Size(356, 25);
            this.lblNbMembreRestant.TabIndex = 2;
            this.lblNbMembreRestant.Text = "Nombre de membres restants à choisir :";
            // 
            // flpMembreMission
            // 
            this.flpMembreMission.AutoScroll = true;
            this.flpMembreMission.BackColor = System.Drawing.Color.Transparent;
            this.flpMembreMission.Location = new System.Drawing.Point(49, 108);
            this.flpMembreMission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpMembreMission.Name = "flpMembreMission";
            this.flpMembreMission.Size = new System.Drawing.Size(1101, 748);
            this.flpMembreMission.TabIndex = 0;
            // 
            // btnPrecedent
            // 
            this.btnPrecedent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrecedent.Location = new System.Drawing.Point(993, 930);
            this.btnPrecedent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrecedent.Name = "btnPrecedent";
            this.btnPrecedent.Size = new System.Drawing.Size(242, 43);
            this.btnPrecedent.TabIndex = 2;
            this.btnPrecedent.Text = "Etape précédente";
            this.btnPrecedent.UseVisualStyleBackColor = true;
            this.btnPrecedent.Click += new System.EventHandler(this.btnPrecedent_Click);
            // 
            // btnSuivant
            // 
            this.btnSuivant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuivant.Location = new System.Drawing.Point(1252, 930);
            this.btnSuivant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(230, 43);
            this.btnSuivant.TabIndex = 3;
            this.btnSuivant.Text = "Etape suivante";
            this.btnSuivant.UseVisualStyleBackColor = true;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // btnValiderMission
            // 
            this.btnValiderMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderMission.Location = new System.Drawing.Point(1612, 930);
            this.btnValiderMission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValiderMission.Name = "btnValiderMission";
            this.btnValiderMission.Size = new System.Drawing.Size(240, 43);
            this.btnValiderMission.TabIndex = 4;
            this.btnValiderMission.Text = "Valider la mission";
            this.btnValiderMission.UseVisualStyleBackColor = true;
            this.btnValiderMission.Click += new System.EventHandler(this.btnValiderMission_Click);
            // 
            // gpbChoixChef
            // 
            this.gpbChoixChef.Controls.Add(this.dtpFin);
            this.gpbChoixChef.Controls.Add(this.lblChoixChef);
            this.gpbChoixChef.Controls.Add(this.dtpDebut);
            this.gpbChoixChef.Controls.Add(this.flpChef);
            this.gpbChoixChef.Controls.Add(this.lblChoixFin);
            this.gpbChoixChef.Controls.Add(this.lblChoixDebut);
            this.gpbChoixChef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbChoixChef.ForeColor = System.Drawing.Color.White;
            this.gpbChoixChef.Location = new System.Drawing.Point(713, 30);
            this.gpbChoixChef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbChoixChef.Name = "gpbChoixChef";
            this.gpbChoixChef.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbChoixChef.Size = new System.Drawing.Size(1201, 886);
            this.gpbChoixChef.TabIndex = 5;
            this.gpbChoixChef.TabStop = false;
            this.gpbChoixChef.Text = "Choix des dates";
            this.gpbChoixChef.Visible = false;
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(753, 58);
            this.dtpFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(233, 30);
            this.dtpFin.TabIndex = 12;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtpDates_ValueChanged);
            // 
            // lblChoixChef
            // 
            this.lblChoixChef.AutoSize = true;
            this.lblChoixChef.Location = new System.Drawing.Point(47, 117);
            this.lblChoixChef.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChoixChef.Name = "lblChoixChef";
            this.lblChoixChef.Size = new System.Drawing.Size(241, 25);
            this.lblChoixChef.TabIndex = 6;
            this.lblChoixChef.Text = "Choix du chef de mission :";
            this.lblChoixChef.Visible = false;
            // 
            // dtpDebut
            // 
            this.dtpDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDebut.Location = new System.Drawing.Point(219, 57);
            this.dtpDebut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDebut.Name = "dtpDebut";
            this.dtpDebut.Size = new System.Drawing.Size(233, 30);
            this.dtpDebut.TabIndex = 11;
            this.dtpDebut.ValueChanged += new System.EventHandler(this.dtpDates_ValueChanged);
            // 
            // flpChef
            // 
            this.flpChef.AutoScroll = true;
            this.flpChef.BackColor = System.Drawing.Color.Transparent;
            this.flpChef.Location = new System.Drawing.Point(49, 177);
            this.flpChef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpChef.Name = "flpChef";
            this.flpChef.Size = new System.Drawing.Size(1103, 679);
            this.flpChef.TabIndex = 0;
            // 
            // lblChoixFin
            // 
            this.lblChoixFin.AutoSize = true;
            this.lblChoixFin.Location = new System.Drawing.Point(605, 58);
            this.lblChoixFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChoixFin.Name = "lblChoixFin";
            this.lblChoixFin.Size = new System.Drawing.Size(116, 25);
            this.lblChoixFin.TabIndex = 10;
            this.lblChoixFin.Text = "Date de fin :";
            // 
            // lblChoixDebut
            // 
            this.lblChoixDebut.AutoSize = true;
            this.lblChoixDebut.Location = new System.Drawing.Point(47, 58);
            this.lblChoixDebut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChoixDebut.Name = "lblChoixDebut";
            this.lblChoixDebut.Size = new System.Drawing.Size(145, 25);
            this.lblChoixDebut.TabIndex = 9;
            this.lblChoixDebut.Text = "Date de début :";
            // 
            // gpbChoixParametresMission
            // 
            this.gpbChoixParametresMission.Controls.Add(this.numBudget);
            this.gpbChoixParametresMission.Controls.Add(this.numObjDataBaz);
            this.gpbChoixParametresMission.Controls.Add(this.numNbMembre);
            this.gpbChoixParametresMission.Controls.Add(this.lblChoixBudget);
            this.gpbChoixParametresMission.Controls.Add(this.txtSaisieFeuilleRoute);
            this.gpbChoixParametresMission.Controls.Add(this.lblChoixObjDataBaz);
            this.gpbChoixParametresMission.Controls.Add(this.lblChoixNbMembre);
            this.gpbChoixParametresMission.Controls.Add(this.lblSaisieFeuilleRoute);
            this.gpbChoixParametresMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbChoixParametresMission.ForeColor = System.Drawing.Color.White;
            this.gpbChoixParametresMission.Location = new System.Drawing.Point(713, 30);
            this.gpbChoixParametresMission.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbChoixParametresMission.Name = "gpbChoixParametresMission";
            this.gpbChoixParametresMission.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbChoixParametresMission.Size = new System.Drawing.Size(1201, 886);
            this.gpbChoixParametresMission.TabIndex = 6;
            this.gpbChoixParametresMission.TabStop = false;
            this.gpbChoixParametresMission.Text = "Choix des dates";
            this.gpbChoixParametresMission.Visible = false;
            // 
            // numBudget
            // 
            this.numBudget.Location = new System.Drawing.Point(208, 681);
            this.numBudget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numBudget.Name = "numBudget";
            this.numBudget.Size = new System.Drawing.Size(80, 30);
            this.numBudget.TabIndex = 15;
            // 
            // numObjDataBaz
            // 
            this.numObjDataBaz.Location = new System.Drawing.Point(339, 613);
            this.numObjDataBaz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numObjDataBaz.Name = "numObjDataBaz";
            this.numObjDataBaz.Size = new System.Drawing.Size(80, 30);
            this.numObjDataBaz.TabIndex = 14;
            // 
            // numNbMembre
            // 
            this.numNbMembre.Location = new System.Drawing.Point(280, 546);
            this.numNbMembre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numNbMembre.Name = "numNbMembre";
            this.numNbMembre.Size = new System.Drawing.Size(80, 30);
            this.numNbMembre.TabIndex = 13;
            // 
            // lblChoixBudget
            // 
            this.lblChoixBudget.AutoSize = true;
            this.lblChoixBudget.Location = new System.Drawing.Point(44, 683);
            this.lblChoixBudget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChoixBudget.Name = "lblChoixBudget";
            this.lblChoixBudget.Size = new System.Drawing.Size(142, 25);
            this.lblChoixBudget.TabIndex = 12;
            this.lblChoixBudget.Text = "Budget (en €) :";
            // 
            // txtSaisieFeuilleRoute
            // 
            this.txtSaisieFeuilleRoute.Location = new System.Drawing.Point(52, 129);
            this.txtSaisieFeuilleRoute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSaisieFeuilleRoute.Name = "txtSaisieFeuilleRoute";
            this.txtSaisieFeuilleRoute.Size = new System.Drawing.Size(1087, 362);
            this.txtSaisieFeuilleRoute.TabIndex = 11;
            this.txtSaisieFeuilleRoute.Text = "";
            // 
            // lblChoixObjDataBaz
            // 
            this.lblChoixObjDataBaz.AutoSize = true;
            this.lblChoixObjDataBaz.Location = new System.Drawing.Point(44, 615);
            this.lblChoixObjDataBaz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChoixObjDataBaz.Name = "lblChoixObjDataBaz";
            this.lblChoixObjDataBaz.Size = new System.Drawing.Size(274, 25);
            this.lblChoixObjDataBaz.TabIndex = 6;
            this.lblChoixObjDataBaz.Text = "Objectif DataBaz (en tonnes) :";
            // 
            // lblChoixNbMembre
            // 
            this.lblChoixNbMembre.AutoSize = true;
            this.lblChoixNbMembre.Location = new System.Drawing.Point(47, 548);
            this.lblChoixNbMembre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChoixNbMembre.Name = "lblChoixNbMembre";
            this.lblChoixNbMembre.Size = new System.Drawing.Size(205, 25);
            this.lblChoixNbMembre.TabIndex = 10;
            this.lblChoixNbMembre.Text = "Nombre de membres :";
            // 
            // lblSaisieFeuilleRoute
            // 
            this.lblSaisieFeuilleRoute.AutoSize = true;
            this.lblSaisieFeuilleRoute.Location = new System.Drawing.Point(47, 82);
            this.lblSaisieFeuilleRoute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaisieFeuilleRoute.Name = "lblSaisieFeuilleRoute";
            this.lblSaisieFeuilleRoute.Size = new System.Drawing.Size(223, 25);
            this.lblSaisieFeuilleRoute.TabIndex = 9;
            this.lblSaisieFeuilleRoute.Text = "Saisir la feuille de route :";
            // 
            // grbChoixCaptures
            // 
            this.grbChoixCaptures.Controls.Add(this.flpCaptures);
            this.grbChoixCaptures.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbChoixCaptures.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grbChoixCaptures.Location = new System.Drawing.Point(713, 30);
            this.grbChoixCaptures.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbChoixCaptures.Name = "grbChoixCaptures";
            this.grbChoixCaptures.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbChoixCaptures.Size = new System.Drawing.Size(1201, 886);
            this.grbChoixCaptures.TabIndex = 7;
            this.grbChoixCaptures.TabStop = false;
            this.grbChoixCaptures.Text = "Choix des captures à réaliser";
            this.grbChoixCaptures.Visible = false;
            // 
            // flpCaptures
            // 
            this.flpCaptures.AutoScroll = true;
            this.flpCaptures.BackColor = System.Drawing.Color.Transparent;
            this.flpCaptures.Location = new System.Drawing.Point(49, 57);
            this.flpCaptures.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpCaptures.Name = "flpCaptures";
            this.flpCaptures.Size = new System.Drawing.Size(1103, 800);
            this.flpCaptures.TabIndex = 0;
            // 
            // FormSaisieNouvelleMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1924, 1013);
            this.Controls.Add(this.btnValiderMission);
            this.Controls.Add(this.btnSuivant);
            this.Controls.Add(this.btnPrecedent);
            this.Controls.Add(this.gpbRecapMission);
            this.Controls.Add(this.gpbChoixChef);
            this.Controls.Add(this.grbChoixCaptures);
            this.Controls.Add(this.gpbChoixMembreMission);
            this.Controls.Add(this.gpbChoixPlanete);
            this.Controls.Add(this.gpbChoixParametresMission);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSaisieNouvelleMission";
            this.Text = "Saisie de la nouvelle mission";
            this.gpbRecapMission.ResumeLayout(false);
            this.gpbRecapMission.PerformLayout();
            this.gpbChoixPlanete.ResumeLayout(false);
            this.gpbChoixMembreMission.ResumeLayout(false);
            this.gpbChoixMembreMission.PerformLayout();
            this.gpbChoixChef.ResumeLayout(false);
            this.gpbChoixChef.PerformLayout();
            this.gpbChoixParametresMission.ResumeLayout(false);
            this.gpbChoixParametresMission.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numObjDataBaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNbMembre)).EndInit();
            this.grbChoixCaptures.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbRecapMission;
        private System.Windows.Forms.GroupBox gpbChoixPlanete;
        private System.Windows.Forms.FlowLayoutPanel flpChoixPlanete;
        private System.Windows.Forms.Label lblObjectifDataBaz;
        private System.Windows.Forms.RichTextBox txtFeuilleRoute;
        private System.Windows.Forms.Label lblFeuilleRoute;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.Label lblDateDebut;
        private System.Windows.Forms.Label lblChef;
        private System.Windows.Forms.Label lblPlanete;
        private System.Windows.Forms.ListView listViewCapture;
        private System.Windows.Forms.Label lblObjectifCapture;
        private System.Windows.Forms.ListView listViewMembre;
        private System.Windows.Forms.Label lbbMembreMission;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.Button btnPrecedent;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Button btnValiderMission;
        private System.Windows.Forms.GroupBox gpbChoixChef;
        private System.Windows.Forms.FlowLayoutPanel flpChef;
        private System.Windows.Forms.Label lblChoixChef;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpDebut;
        private System.Windows.Forms.Label lblChoixFin;
        private System.Windows.Forms.Label lblChoixDebut;
        private System.Windows.Forms.GroupBox gpbChoixParametresMission;
        private System.Windows.Forms.Label lblChoixObjDataBaz;
        private System.Windows.Forms.Label lblChoixNbMembre;
        private System.Windows.Forms.Label lblSaisieFeuilleRoute;
        private System.Windows.Forms.RichTextBox txtSaisieFeuilleRoute;
        private System.Windows.Forms.NumericUpDown numBudget;
        private System.Windows.Forms.NumericUpDown numObjDataBaz;
        private System.Windows.Forms.NumericUpDown numNbMembre;
        private System.Windows.Forms.Label lblChoixBudget;
        private System.Windows.Forms.GroupBox gpbChoixMembreMission;
        private System.Windows.Forms.Label lblNbMembreRestant;
        private System.Windows.Forms.FlowLayoutPanel flpMembreMission;
        private System.Windows.Forms.GroupBox grbChoixCaptures;
        private System.Windows.Forms.FlowLayoutPanel flpCaptures;
    }
}

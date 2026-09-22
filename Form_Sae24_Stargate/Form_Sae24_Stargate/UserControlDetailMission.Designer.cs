namespace Form_Sae24_Stargate
{
    partial class UserControlMissionDetail
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
            this.lblNomMission = new System.Windows.Forms.Label();
            this.lblDateDep = new System.Windows.Forms.Label();
            this.lblRetour = new System.Windows.Forms.Label();
            this.lblSolde = new System.Windows.Forms.Label();
            this.lblBudget = new System.Windows.Forms.Label();
            this.lblFeuille = new System.Windows.Forms.Label();
            this.rtbFeuilleRoute = new System.Windows.Forms.RichTextBox();
            this.flptrombi = new System.Windows.Forms.FlowLayoutPanel();
            this.lblmembre = new System.Windows.Forms.Label();
            this.lblDatabaz = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnJournal = new System.Windows.Forms.Button();
            this.btnEditerMission = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.pbPlanete = new System.Windows.Forms.PictureBox();
            this.lblDatabazRecolte = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomMission
            // 
            this.lblNomMission.AutoSize = true;
            this.lblNomMission.BackColor = System.Drawing.Color.Transparent;
            this.lblNomMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomMission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNomMission.Location = new System.Drawing.Point(434, 70);
            this.lblNomMission.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomMission.Name = "lblNomMission";
            this.lblNomMission.Size = new System.Drawing.Size(123, 29);
            this.lblNomMission.TabIndex = 1;
            this.lblNomMission.Text = "Mission n°";
            // 
            // lblDateDep
            // 
            this.lblDateDep.AutoSize = true;
            this.lblDateDep.BackColor = System.Drawing.Color.Transparent;
            this.lblDateDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDep.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDateDep.Location = new System.Drawing.Point(435, 147);
            this.lblDateDep.Name = "lblDateDep";
            this.lblDateDep.Size = new System.Drawing.Size(143, 24);
            this.lblDateDep.TabIndex = 2;
            this.lblDateDep.Text = "Date de départ :";
            // 
            // lblRetour
            // 
            this.lblRetour.AutoSize = true;
            this.lblRetour.BackColor = System.Drawing.Color.Transparent;
            this.lblRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetour.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRetour.Location = new System.Drawing.Point(435, 200);
            this.lblRetour.Name = "lblRetour";
            this.lblRetour.Size = new System.Drawing.Size(192, 24);
            this.lblRetour.TabIndex = 3;
            this.lblRetour.Text = "Date de retour prevu :";
            // 
            // lblSolde
            // 
            this.lblSolde.AutoSize = true;
            this.lblSolde.BackColor = System.Drawing.Color.Transparent;
            this.lblSolde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolde.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSolde.Location = new System.Drawing.Point(98, 313);
            this.lblSolde.Name = "lblSolde";
            this.lblSolde.Size = new System.Drawing.Size(140, 24);
            this.lblSolde.TabIndex = 5;
            this.lblSolde.Text = "Budget restant :";
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.BackColor = System.Drawing.Color.Transparent;
            this.lblBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudget.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBudget.Location = new System.Drawing.Point(98, 274);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(80, 24);
            this.lblBudget.TabIndex = 4;
            this.lblBudget.Text = "Budget :";
            // 
            // lblFeuille
            // 
            this.lblFeuille.AutoSize = true;
            this.lblFeuille.BackColor = System.Drawing.Color.Transparent;
            this.lblFeuille.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeuille.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFeuille.Location = new System.Drawing.Point(52, 380);
            this.lblFeuille.Name = "lblFeuille";
            this.lblFeuille.Size = new System.Drawing.Size(152, 24);
            this.lblFeuille.TabIndex = 6;
            this.lblFeuille.Text = "Feuille de route :";
            // 
            // rtbFeuilleRoute
            // 
            this.rtbFeuilleRoute.BackColor = System.Drawing.Color.MidnightBlue;
            this.rtbFeuilleRoute.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbFeuilleRoute.Location = new System.Drawing.Point(52, 421);
            this.rtbFeuilleRoute.Name = "rtbFeuilleRoute";
            this.rtbFeuilleRoute.ReadOnly = true;
            this.rtbFeuilleRoute.Size = new System.Drawing.Size(647, 173);
            this.rtbFeuilleRoute.TabIndex = 7;
            this.rtbFeuilleRoute.Text = "";
            // 
            // flptrombi
            // 
            this.flptrombi.AutoScroll = true;
            this.flptrombi.BackColor = System.Drawing.Color.MidnightBlue;
            this.flptrombi.Location = new System.Drawing.Point(730, 115);
            this.flptrombi.Name = "flptrombi";
            this.flptrombi.Size = new System.Drawing.Size(547, 289);
            this.flptrombi.TabIndex = 8;
            // 
            // lblmembre
            // 
            this.lblmembre.AutoSize = true;
            this.lblmembre.BackColor = System.Drawing.Color.Transparent;
            this.lblmembre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmembre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblmembre.Location = new System.Drawing.Point(754, 74);
            this.lblmembre.Name = "lblmembre";
            this.lblmembre.Size = new System.Drawing.Size(190, 24);
            this.lblmembre.TabIndex = 9;
            this.lblmembre.Text = "Membre de l\'équipe :";
            // 
            // lblDatabaz
            // 
            this.lblDatabaz.AutoSize = true;
            this.lblDatabaz.BackColor = System.Drawing.Color.Transparent;
            this.lblDatabaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaz.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDatabaz.Location = new System.Drawing.Point(372, 274);
            this.lblDatabaz.Name = "lblDatabaz";
            this.lblDatabaz.Size = new System.Drawing.Size(87, 24);
            this.lblDatabaz.TabIndex = 11;
            this.lblDatabaz.Text = "Databaz :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(730, 421);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 173);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Objectif de capture";
            // 
            // btnJournal
            // 
            this.btnJournal.BackColor = System.Drawing.Color.Transparent;
            this.btnJournal.BackgroundImage = global::Form_Sae24_Stargate.Properties.Resources.journal;
            this.btnJournal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJournal.FlatAppearance.BorderSize = 0;
            this.btnJournal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnJournal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJournal.Location = new System.Drawing.Point(1109, 430);
            this.btnJournal.Name = "btnJournal";
            this.btnJournal.Size = new System.Drawing.Size(168, 164);
            this.btnJournal.TabIndex = 14;
            this.btnJournal.UseVisualStyleBackColor = false;
            this.btnJournal.Click += new System.EventHandler(this.btnJournal_Click);
            // 
            // btnEditerMission
            // 
            this.btnEditerMission.BackColor = System.Drawing.Color.DarkViolet;
            this.btnEditerMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditerMission.FlatAppearance.BorderSize = 0;
            this.btnEditerMission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnEditerMission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnEditerMission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditerMission.ForeColor = System.Drawing.Color.White;
            this.btnEditerMission.Location = new System.Drawing.Point(1109, 34);
            this.btnEditerMission.Name = "btnEditerMission";
            this.btnEditerMission.Size = new System.Drawing.Size(168, 53);
            this.btnEditerMission.TabIndex = 15;
            this.btnEditerMission.Text = "Editer la mission";
            this.btnEditerMission.UseVisualStyleBackColor = false;
            this.btnEditerMission.Visible = false;
            this.btnEditerMission.Click += new System.EventHandler(this.btnEditerMission_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.Transparent;
            this.btnRetour.BackgroundImage = global::Form_Sae24_Stargate.Properties.Resources.retour;
            this.btnRetour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRetour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetour.FlatAppearance.BorderSize = 0;
            this.btnRetour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnRetour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnRetour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetour.Location = new System.Drawing.Point(24, 8);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(110, 104);
            this.btnRetour.TabIndex = 16;
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // pbPlanete
            // 
            this.pbPlanete.BackColor = System.Drawing.Color.Transparent;
            this.pbPlanete.Location = new System.Drawing.Point(174, 47);
            this.pbPlanete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPlanete.Name = "pbPlanete";
            this.pbPlanete.Size = new System.Drawing.Size(209, 191);
            this.pbPlanete.TabIndex = 0;
            this.pbPlanete.TabStop = false;
            // 
            // lblDatabazRecolte
            // 
            this.lblDatabazRecolte.AutoSize = true;
            this.lblDatabazRecolte.BackColor = System.Drawing.Color.Transparent;
            this.lblDatabazRecolte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabazRecolte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDatabazRecolte.Location = new System.Drawing.Point(372, 313);
            this.lblDatabazRecolte.Name = "lblDatabazRecolte";
            this.lblDatabazRecolte.Size = new System.Drawing.Size(149, 24);
            this.lblDatabazRecolte.TabIndex = 17;
            this.lblDatabazRecolte.Text = "Databaz récolté :";
            // 
            // UserControlMissionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblDatabazRecolte);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnEditerMission);
            this.Controls.Add(this.btnJournal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDatabaz);
            this.Controls.Add(this.lblmembre);
            this.Controls.Add(this.flptrombi);
            this.Controls.Add(this.rtbFeuilleRoute);
            this.Controls.Add(this.lblFeuille);
            this.Controls.Add(this.lblSolde);
            this.Controls.Add(this.lblBudget);
            this.Controls.Add(this.lblRetour);
            this.Controls.Add(this.lblDateDep);
            this.Controls.Add(this.lblNomMission);
            this.Controls.Add(this.pbPlanete);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserControlMissionDetail";
            this.Size = new System.Drawing.Size(1369, 637);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlanete;
        private System.Windows.Forms.Label lblNomMission;
        private System.Windows.Forms.Label lblDateDep;
        private System.Windows.Forms.Label lblRetour;
        private System.Windows.Forms.Label lblSolde;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.Label lblFeuille;
        private System.Windows.Forms.RichTextBox rtbFeuilleRoute;
        private System.Windows.Forms.FlowLayoutPanel flptrombi;
        private System.Windows.Forms.Label lblmembre;
        private System.Windows.Forms.Label lblDatabaz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnJournal;
        private System.Windows.Forms.Button btnEditerMission;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Label lblDatabazRecolte;
    }
}
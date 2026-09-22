namespace UserControlMission
{
    partial class UCMission
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

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMission = new System.Windows.Forms.GroupBox();
            this.lblChef = new System.Windows.Forms.Label();
            this.lblArgent = new System.Windows.Forms.Label();
            this.lblRetour = new System.Windows.Forms.Label();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblStatusMission = new System.Windows.Forms.Label();
            this.btnInfoMission = new System.Windows.Forms.Button();
            this.lblBudget = new System.Windows.Forms.Label();
            this.lblChefMission = new System.Windows.Forms.Label();
            this.lblDateRetour = new System.Windows.Forms.Label();
            this.lblDateDepart = new System.Windows.Forms.Label();
            this.lblNomMision = new System.Windows.Forms.Label();
            this.picPlanete = new System.Windows.Forms.PictureBox();
            this.grpMission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlanete)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMission
            // 
            this.grpMission.BackColor = System.Drawing.Color.Transparent;
            this.grpMission.Controls.Add(this.lblChef);
            this.grpMission.Controls.Add(this.lblArgent);
            this.grpMission.Controls.Add(this.lblRetour);
            this.grpMission.Controls.Add(this.lblDepart);
            this.grpMission.Controls.Add(this.lblStatusMission);
            this.grpMission.Controls.Add(this.btnInfoMission);
            this.grpMission.Controls.Add(this.lblBudget);
            this.grpMission.Controls.Add(this.lblChefMission);
            this.grpMission.Controls.Add(this.lblDateRetour);
            this.grpMission.Controls.Add(this.lblDateDepart);
            this.grpMission.Controls.Add(this.lblNomMision);
            this.grpMission.Controls.Add(this.picPlanete);
            this.grpMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpMission.Location = new System.Drawing.Point(3, 3);
            this.grpMission.Name = "grpMission";
            this.grpMission.Size = new System.Drawing.Size(1017, 178);
            this.grpMission.TabIndex = 0;
            this.grpMission.TabStop = false;
            this.grpMission.Text = "Nom Mission";
            // 
            // lblChef
            // 
            this.lblChef.AutoSize = true;
            this.lblChef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChef.Location = new System.Drawing.Point(480, 135);
            this.lblChef.Name = "lblChef";
            this.lblChef.Size = new System.Drawing.Size(164, 25);
            this.lblChef.TabIndex = 12;
            this.lblChef.Text = "Chef de Mission :";
            // 
            // lblArgent
            // 
            this.lblArgent.AutoSize = true;
            this.lblArgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArgent.Location = new System.Drawing.Point(190, 135);
            this.lblArgent.Name = "lblArgent";
            this.lblArgent.Size = new System.Drawing.Size(85, 25);
            this.lblArgent.TabIndex = 11;
            this.lblArgent.Text = "Budget :";
            // 
            // lblRetour
            // 
            this.lblRetour.AutoSize = true;
            this.lblRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetour.Location = new System.Drawing.Point(480, 83);
            this.lblRetour.Name = "lblRetour";
            this.lblRetour.Size = new System.Drawing.Size(173, 25);
            this.lblRetour.TabIndex = 10;
            this.lblRetour.Text = "Date retour prévu :";
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepart.Location = new System.Drawing.Point(189, 83);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(124, 25);
            this.lblDepart.TabIndex = 9;
            this.lblDepart.Text = "Date départ :";
            // 
            // lblStatusMission
            // 
            this.lblStatusMission.AutoSize = true;
            this.lblStatusMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMission.Location = new System.Drawing.Point(190, 34);
            this.lblStatusMission.Name = "lblStatusMission";
            this.lblStatusMission.Size = new System.Drawing.Size(89, 25);
            this.lblStatusMission.TabIndex = 7;
            this.lblStatusMission.Text = "En cours";
            // 
            // btnInfoMission
            // 
            this.btnInfoMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfoMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfoMission.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnInfoMission.Location = new System.Drawing.Point(882, 34);
            this.btnInfoMission.Name = "btnInfoMission";
            this.btnInfoMission.Size = new System.Drawing.Size(100, 35);
            this.btnInfoMission.TabIndex = 6;
            this.btnInfoMission.Text = "Détails";
            this.btnInfoMission.UseVisualStyleBackColor = true;
            this.btnInfoMission.Click += new System.EventHandler(this.btnInfoMission_Click);
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudget.Location = new System.Drawing.Point(281, 135);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(74, 25);
            this.lblBudget.TabIndex = 5;
            this.lblBudget.Text = "Budget";
            // 
            // lblChefMission
            // 
            this.lblChefMission.AutoSize = true;
            this.lblChefMission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChefMission.Location = new System.Drawing.Point(650, 135);
            this.lblChefMission.Name = "lblChefMission";
            this.lblChefMission.Size = new System.Drawing.Size(153, 25);
            this.lblChefMission.TabIndex = 4;
            this.lblChefMission.Text = "Chef de Mission";
            // 
            // lblDateRetour
            // 
            this.lblDateRetour.AutoSize = true;
            this.lblDateRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRetour.Location = new System.Drawing.Point(650, 83);
            this.lblDateRetour.Name = "lblDateRetour";
            this.lblDateRetour.Size = new System.Drawing.Size(162, 25);
            this.lblDateRetour.TabIndex = 3;
            this.lblDateRetour.Text = "Date retour prévu";
            // 
            // lblDateDepart
            // 
            this.lblDateDepart.AutoSize = true;
            this.lblDateDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDepart.Location = new System.Drawing.Point(319, 83);
            this.lblDateDepart.Name = "lblDateDepart";
            this.lblDateDepart.Size = new System.Drawing.Size(113, 25);
            this.lblDateDepart.TabIndex = 2;
            this.lblDateDepart.Text = "Date départ";
            // 
            // lblNomMision
            // 
            this.lblNomMision.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomMision.Location = new System.Drawing.Point(0, 0);
            this.lblNomMision.Name = "lblNomMision";
            this.lblNomMision.Size = new System.Drawing.Size(100, 23);
            this.lblNomMision.TabIndex = 8;
            // 
            // picPlanete
            // 
            this.picPlanete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPlanete.BackColor = System.Drawing.Color.Transparent;
            this.picPlanete.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.picPlanete.Enabled = false;
            this.picPlanete.Location = new System.Drawing.Point(20, 34);
            this.picPlanete.Name = "picPlanete";
            this.picPlanete.Size = new System.Drawing.Size(151, 126);
            this.picPlanete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlanete.TabIndex = 0;
            this.picPlanete.TabStop = false;
            this.picPlanete.UseWaitCursor = true;
            // 
            // UCMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpMission);
            this.Name = "UCMission";
            this.Size = new System.Drawing.Size(1023, 183);
            this.grpMission.ResumeLayout(false);
            this.grpMission.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlanete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMission;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.Label lblChefMission;
        private System.Windows.Forms.Label lblDateRetour;
        private System.Windows.Forms.Label lblDateDepart;
        private System.Windows.Forms.Label lblNomMision;
        private System.Windows.Forms.PictureBox picPlanete;
        private System.Windows.Forms.Label lblStatusMission;
        private System.Windows.Forms.Button btnInfoMission;
        private System.Windows.Forms.Label lblChef;
        private System.Windows.Forms.Label lblArgent;
        private System.Windows.Forms.Label lblRetour;
        private System.Windows.Forms.Label lblDepart;
    }
}

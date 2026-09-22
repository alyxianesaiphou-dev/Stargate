namespace UserControlMembreEquipageDetail
{
    partial class UCEquipageDetail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPlanete = new System.Windows.Forms.Label();
            this.lblSpecialiteGrade = new System.Windows.Forms.Label();
            this.lblDateDeNaissance = new System.Windows.Forms.Label();
            this.lblNomMembreEquipage = new System.Windows.Forms.Label();
            this.lblMatricule = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPlanete);
            this.groupBox1.Controls.Add(this.lblSpecialiteGrade);
            this.groupBox1.Controls.Add(this.lblDateDeNaissance);
            this.groupBox1.Controls.Add(this.lblNomMembreEquipage);
            this.groupBox1.Controls.Add(this.lblMatricule);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 172);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // lblPlanete
            // 
            this.lblPlanete.AutoSize = true;
            this.lblPlanete.Location = new System.Drawing.Point(340, 34);
            this.lblPlanete.Name = "lblPlanete";
            this.lblPlanete.Size = new System.Drawing.Size(53, 16);
            this.lblPlanete.TabIndex = 14;
            this.lblPlanete.Text = "Planete";
            // 
            // lblSpecialiteGrade
            // 
            this.lblSpecialiteGrade.AutoSize = true;
            this.lblSpecialiteGrade.Location = new System.Drawing.Point(340, 63);
            this.lblSpecialiteGrade.Name = "lblSpecialiteGrade";
            this.lblSpecialiteGrade.Size = new System.Drawing.Size(109, 16);
            this.lblSpecialiteGrade.TabIndex = 12;
            this.lblSpecialiteGrade.Text = "Specialite/Grade";
            // 
            // lblDateDeNaissance
            // 
            this.lblDateDeNaissance.AutoSize = true;
            this.lblDateDeNaissance.Location = new System.Drawing.Point(166, 93);
            this.lblDateDeNaissance.Name = "lblDateDeNaissance";
            this.lblDateDeNaissance.Size = new System.Drawing.Size(120, 16);
            this.lblDateDeNaissance.TabIndex = 10;
            this.lblDateDeNaissance.Text = "Date de naissance";
            // 
            // lblNomMembreEquipage
            // 
            this.lblNomMembreEquipage.AutoSize = true;
            this.lblNomMembreEquipage.Location = new System.Drawing.Point(166, 63);
            this.lblNomMembreEquipage.Name = "lblNomMembreEquipage";
            this.lblNomMembreEquipage.Size = new System.Drawing.Size(86, 16);
            this.lblNomMembreEquipage.TabIndex = 8;
            this.lblNomMembreEquipage.Text = "Nom Prénom";
            this.lblNomMembreEquipage.Click += new System.EventHandler(this.lblNomMembreEquipage_Click);
            // 
            // lblMatricule
            // 
            this.lblMatricule.AutoSize = true;
            this.lblMatricule.Location = new System.Drawing.Point(166, 34);
            this.lblMatricule.Name = "lblMatricule";
            this.lblMatricule.Size = new System.Drawing.Size(61, 16);
            this.lblMatricule.TabIndex = 9;
            this.lblMatricule.Text = "Matricule";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 134);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UCEquipageDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCEquipageDetail";
            this.Size = new System.Drawing.Size(505, 181);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSpecialiteGrade;
        private System.Windows.Forms.Label lblPlanete;
        private System.Windows.Forms.Label lblDateDeNaissance;
        private System.Windows.Forms.Label lblNomMembreEquipage;
        private System.Windows.Forms.Label lblMatricule;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

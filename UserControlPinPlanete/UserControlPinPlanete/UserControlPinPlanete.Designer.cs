namespace UserControlPinPlanete
{
    partial class UCPinPlanete
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
            this.lblNomPlanete = new System.Windows.Forms.Label();
            this.picPlanete = new System.Windows.Forms.PictureBox();
            this.radPlanete = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picPlanete)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomPlanete
            // 
            this.lblNomPlanete.AutoSize = true;
            this.lblNomPlanete.ForeColor = System.Drawing.Color.Snow;
            this.lblNomPlanete.Location = new System.Drawing.Point(92, 50);
            this.lblNomPlanete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomPlanete.Name = "lblNomPlanete";
            this.lblNomPlanete.Size = new System.Drawing.Size(42, 20);
            this.lblNomPlanete.TabIndex = 5;
            this.lblNomPlanete.Text = "Nom";
            // 
            // picPlanete
            // 
            this.picPlanete.Location = new System.Drawing.Point(75, 76);
            this.picPlanete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPlanete.Name = "picPlanete";
            this.picPlanete.Size = new System.Drawing.Size(75, 77);
            this.picPlanete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlanete.TabIndex = 4;
            this.picPlanete.TabStop = false;
            // 
            // radPlanete
            // 
            this.radPlanete.AutoCheck = false;
            this.radPlanete.AutoSize = true;
            this.radPlanete.Location = new System.Drawing.Point(103, 161);
            this.radPlanete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radPlanete.Name = "radPlanete";
            this.radPlanete.Size = new System.Drawing.Size(21, 20);
            this.radPlanete.TabIndex = 3;
            this.radPlanete.TabStop = true;
            this.radPlanete.UseVisualStyleBackColor = true;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblNomPlanete);
            this.Controls.Add(this.picPlanete);
            this.Controls.Add(this.radPlanete);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(225, 231);
            ((System.ComponentModel.ISupportInitialize)(this.picPlanete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomPlanete;
        private System.Windows.Forms.PictureBox picPlanete;
        private System.Windows.Forms.RadioButton radPlanete;
    }
}

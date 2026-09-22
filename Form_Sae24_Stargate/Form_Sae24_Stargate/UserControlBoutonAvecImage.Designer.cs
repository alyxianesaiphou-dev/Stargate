namespace UserControlBoutonAvecImage
{
    
    partial class UCBoutonImage
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
            this.btnImage = new System.Windows.Forms.Button();
            this.lblBouton = new System.Windows.Forms.Label();
            this.picBouton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBouton)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImage
            // 
            this.btnImage.BackColor = System.Drawing.Color.White;
            this.btnImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImage.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnImage.Location = new System.Drawing.Point(13, 3);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(304, 75);
            this.btnImage.TabIndex = 0;
            this.btnImage.UseVisualStyleBackColor = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // lblBouton
            // 
            this.lblBouton.AutoSize = true;
            this.lblBouton.BackColor = System.Drawing.Color.White;
            this.lblBouton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBouton.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBouton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblBouton.Location = new System.Drawing.Point(102, 22);
            this.lblBouton.Name = "lblBouton";
            this.lblBouton.Size = new System.Drawing.Size(150, 29);
            this.lblBouton.TabIndex = 1;
            this.lblBouton.Text = "labelabelabelabel";
            // 
            // picBouton
            // 
            this.picBouton.BackColor = System.Drawing.Color.White;
            this.picBouton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBouton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBouton.Location = new System.Drawing.Point(25, 16);
            this.picBouton.Name = "picBouton";
            this.picBouton.Size = new System.Drawing.Size(59, 50);
            this.picBouton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBouton.TabIndex = 2;
            this.picBouton.TabStop = false;
            // 
            // UCBoutonImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picBouton);
            this.Controls.Add(this.lblBouton);
            this.Controls.Add(this.btnImage);
            this.Name = "UCBoutonImage";
            this.Size = new System.Drawing.Size(343, 89);
            ((System.ComponentModel.ISupportInitialize)(this.picBouton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Label lblBouton;
        private System.Windows.Forms.PictureBox picBouton;
    }
}

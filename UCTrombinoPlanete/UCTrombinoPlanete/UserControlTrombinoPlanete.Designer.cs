namespace UserControlTrombinoPlanete
{
    partial class UCTrombPlanete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTrombPlanete));
            this.picDataBaz = new System.Windows.Forms.PictureBox();
            this.lblGravite = new System.Windows.Forms.Label();
            this.picGravite = new System.Windows.Forms.PictureBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.picTemperature = new System.Windows.Forms.PictureBox();
            this.lblPlanete = new System.Windows.Forms.Label();
            this.picPlanete = new System.Windows.Forms.PictureBox();
            this.btnPlaneteDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picDataBaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGravite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlanete)).BeginInit();
            this.SuspendLayout();
            // 
            // picDataBaz
            // 
            this.picDataBaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.picDataBaz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picDataBaz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDataBaz.Location = new System.Drawing.Point(141, 236);
            this.picDataBaz.Name = "picDataBaz";
            this.picDataBaz.Size = new System.Drawing.Size(40, 43);
            this.picDataBaz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDataBaz.TabIndex = 6;
            this.picDataBaz.TabStop = false;
            // 
            // lblGravite
            // 
            this.lblGravite.AutoSize = true;
            this.lblGravite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblGravite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGravite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGravite.ForeColor = System.Drawing.Color.White;
            this.lblGravite.Location = new System.Drawing.Point(83, 262);
            this.lblGravite.Name = "lblGravite";
            this.lblGravite.Size = new System.Drawing.Size(18, 20);
            this.lblGravite.TabIndex = 5;
            this.lblGravite.Text = "g";
            // 
            // picGravite
            // 
            this.picGravite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.picGravite.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picGravite.BackgroundImage")));
            this.picGravite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picGravite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGravite.Location = new System.Drawing.Point(37, 253);
            this.picGravite.Name = "picGravite";
            this.picGravite.Size = new System.Drawing.Size(40, 43);
            this.picGravite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGravite.TabIndex = 4;
            this.picGravite.TabStop = false;
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTemperature.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.ForeColor = System.Drawing.Color.White;
            this.lblTemperature.Location = new System.Drawing.Point(83, 213);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(21, 20);
            this.lblTemperature.TabIndex = 3;
            this.lblTemperature.Text = "t°";
            // 
            // picTemperature
            // 
            this.picTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.picTemperature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picTemperature.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTemperature.Location = new System.Drawing.Point(37, 204);
            this.picTemperature.Name = "picTemperature";
            this.picTemperature.Size = new System.Drawing.Size(40, 43);
            this.picTemperature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTemperature.TabIndex = 2;
            this.picTemperature.TabStop = false;
            // 
            // lblPlanete
            // 
            this.lblPlanete.AutoSize = true;
            this.lblPlanete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblPlanete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPlanete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanete.ForeColor = System.Drawing.Color.White;
            this.lblPlanete.Location = new System.Drawing.Point(27, 162);
            this.lblPlanete.Name = "lblPlanete";
            this.lblPlanete.Size = new System.Drawing.Size(146, 20);
            this.lblPlanete.TabIndex = 1;
            this.lblPlanete.Text = "Nom Planeteeee";
            this.lblPlanete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picPlanete
            // 
            this.picPlanete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.picPlanete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picPlanete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPlanete.Location = new System.Drawing.Point(31, 13);
            this.picPlanete.Name = "picPlanete";
            this.picPlanete.Size = new System.Drawing.Size(142, 134);
            this.picPlanete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlanete.TabIndex = 0;
            this.picPlanete.TabStop = false;
            // 
            // btnPlaneteDetail
            // 
            this.btnPlaneteDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnPlaneteDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlaneteDetail.Location = new System.Drawing.Point(0, 0);
            this.btnPlaneteDetail.Name = "btnPlaneteDetail";
            this.btnPlaneteDetail.Size = new System.Drawing.Size(213, 310);
            this.btnPlaneteDetail.TabIndex = 2;
            this.btnPlaneteDetail.UseVisualStyleBackColor = false;
            this.btnPlaneteDetail.Click += new System.EventHandler(this.btnPlaneteDetail_Click);
            this.btnPlaneteDetail.MouseEnter += new System.EventHandler(this.btnPlaneteDetail_MouseEnter);
            this.btnPlaneteDetail.MouseLeave += new System.EventHandler(this.btnPlaneteDetail_MouseLeave);
            // 
            // UCTrombPlanete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picDataBaz);
            this.Controls.Add(this.lblGravite);
            this.Controls.Add(this.picGravite);
            this.Controls.Add(this.picPlanete);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.lblPlanete);
            this.Controls.Add(this.picTemperature);
            this.Controls.Add(this.btnPlaneteDetail);
            this.Name = "UCTrombPlanete";
            this.Size = new System.Drawing.Size(216, 310);
            ((System.ComponentModel.ISupportInitialize)(this.picDataBaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGravite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlanete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picDataBaz;
        private System.Windows.Forms.Label lblGravite;
        private System.Windows.Forms.PictureBox picGravite;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.PictureBox picTemperature;
        private System.Windows.Forms.Label lblPlanete;
        private System.Windows.Forms.PictureBox picPlanete;
        private System.Windows.Forms.Button btnPlaneteDetail;
    }
}

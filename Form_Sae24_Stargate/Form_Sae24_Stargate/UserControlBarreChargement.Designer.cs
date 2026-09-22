namespace Form_Sae24_Stargate
{
    partial class UserControlBarreChargement
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
            this.components = new System.ComponentModel.Container();
            this.pnlFondBarre = new System.Windows.Forms.Panel();
            this.pnlBarreViolette = new System.Windows.Forms.Panel();
            this.timerChargement = new System.Windows.Forms.Timer(this.components);
            this.pnlFondBarre.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondBarre
            // 
            this.pnlFondBarre.BackColor = System.Drawing.Color.SlateBlue;
            this.pnlFondBarre.Controls.Add(this.pnlBarreViolette);
            this.pnlFondBarre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFondBarre.Location = new System.Drawing.Point(0, 0);
            this.pnlFondBarre.Name = "pnlFondBarre";
            this.pnlFondBarre.Size = new System.Drawing.Size(267, 77);
            this.pnlFondBarre.TabIndex = 0;
            // 
            // pnlBarreViolette
            // 
            this.pnlBarreViolette.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnlBarreViolette.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBarreViolette.Location = new System.Drawing.Point(0, 0);
            this.pnlBarreViolette.Name = "pnlBarreViolette";
            this.pnlBarreViolette.Size = new System.Drawing.Size(267, 77);
            this.pnlBarreViolette.TabIndex = 0;
            // 
            // timerChargement
            // 
            this.timerChargement.Interval = 30;
            // 
            // UserControlBarreChargement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Controls.Add(this.pnlFondBarre);
            this.Name = "UserControlBarreChargement";
            this.Size = new System.Drawing.Size(267, 77);
            this.pnlFondBarre.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondBarre;
        private System.Windows.Forms.Panel pnlBarreViolette;
        private System.Windows.Forms.Timer timerChargement;
    }
}

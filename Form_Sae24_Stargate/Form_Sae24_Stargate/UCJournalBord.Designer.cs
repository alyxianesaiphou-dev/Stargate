namespace Form_Sae24_Stargate
{
    partial class UCJournalBord
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
            this.gpbEvenements = new System.Windows.Forms.GroupBox();
            this.lblCompteur = new System.Windows.Forms.Label();
            this.btnPremier = new System.Windows.Forms.Button();
            this.btnPrecedent = new System.Windows.Forms.Button();
            this.btnDernier = new System.Windows.Forms.Button();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.lblCommentaire = new System.Windows.Forms.Label();
            this.lblDateJ = new System.Windows.Forms.Label();
            this.gpbContacts = new System.Windows.Forms.GroupBox();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.gpbDepenses = new System.Windows.Forms.GroupBox();
            this.dgvDepenses = new System.Windows.Forms.DataGridView();
            this.lblTotalContacts = new System.Windows.Forms.Label();
            this.lblTotalDepenses = new System.Windows.Forms.Label();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.gpbEvenements.SuspendLayout();
            this.gpbContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.gpbDepenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepenses)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbEvenements
            // 
            this.gpbEvenements.Controls.Add(this.lblCompteur);
            this.gpbEvenements.Controls.Add(this.btnPremier);
            this.gpbEvenements.Controls.Add(this.btnPrecedent);
            this.gpbEvenements.Controls.Add(this.btnDernier);
            this.gpbEvenements.Controls.Add(this.btnSuivant);
            this.gpbEvenements.Controls.Add(this.lblCommentaire);
            this.gpbEvenements.Controls.Add(this.lblDateJ);
            this.gpbEvenements.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbEvenements.Location = new System.Drawing.Point(35, 52);
            this.gpbEvenements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gpbEvenements.Name = "gpbEvenements";
            this.gpbEvenements.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gpbEvenements.Size = new System.Drawing.Size(623, 185);
            this.gpbEvenements.TabIndex = 0;
            this.gpbEvenements.TabStop = false;
            this.gpbEvenements.Text = "Evenements du journal";
            // 
            // lblCompteur
            // 
            this.lblCompteur.AutoSize = true;
            this.lblCompteur.Location = new System.Drawing.Point(261, 147);
            this.lblCompteur.Name = "lblCompteur";
            this.lblCompteur.Size = new System.Drawing.Size(34, 25);
            this.lblCompteur.TabIndex = 6;
            this.lblCompteur.Text = "nb";
            // 
            // btnPremier
            // 
            this.btnPremier.BackColor = System.Drawing.Color.DarkViolet;
            this.btnPremier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPremier.FlatAppearance.BorderSize = 0;
            this.btnPremier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnPremier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnPremier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPremier.ForeColor = System.Drawing.Color.White;
            this.btnPremier.Location = new System.Drawing.Point(159, 95);
            this.btnPremier.Name = "btnPremier";
            this.btnPremier.Size = new System.Drawing.Size(54, 40);
            this.btnPremier.TabIndex = 5;
            this.btnPremier.Text = "<<";
            this.btnPremier.UseVisualStyleBackColor = true;
            this.btnPremier.Click += new System.EventHandler(this.btnPremier_Click);
            // 
            // btnPrecedent
            // 
            this.btnPrecedent.BackColor = System.Drawing.Color.DarkViolet;
            this.btnPrecedent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrecedent.FlatAppearance.BorderSize = 0;
            this.btnPrecedent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnPrecedent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnPrecedent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrecedent.ForeColor = System.Drawing.Color.White;
            this.btnPrecedent.Location = new System.Drawing.Point(240, 95);
            this.btnPrecedent.Name = "btnPrecedent";
            this.btnPrecedent.Size = new System.Drawing.Size(54, 40);
            this.btnPrecedent.TabIndex = 4;
            this.btnPrecedent.Text = "<";
            this.btnPrecedent.UseVisualStyleBackColor = true;
            this.btnPrecedent.Click += new System.EventHandler(this.btnPrecedent_Click);
            // 
            // btnDernier
            // 
            this.btnDernier.BackColor = System.Drawing.Color.DarkViolet;
            this.btnDernier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDernier.FlatAppearance.BorderSize = 0;
            this.btnDernier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnDernier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnDernier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDernier.ForeColor = System.Drawing.Color.White;
            this.btnDernier.Location = new System.Drawing.Point(439, 95);
            this.btnDernier.Name = "btnDernier";
            this.btnDernier.Size = new System.Drawing.Size(54, 40);
            this.btnDernier.TabIndex = 3;
            this.btnDernier.Text = ">>";
            this.btnDernier.UseVisualStyleBackColor = true;
            this.btnDernier.Click += new System.EventHandler(this.btnDernier_Click);
            // 
            // btnSuivant
            // 
            this.btnSuivant.BackColor = System.Drawing.Color.DarkViolet;
            this.btnSuivant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuivant.FlatAppearance.BorderSize = 0;
            this.btnSuivant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnSuivant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuivant.ForeColor = System.Drawing.Color.White;
            this.btnSuivant.Location = new System.Drawing.Point(362, 95);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(54, 40);
            this.btnSuivant.TabIndex = 2;
            this.btnSuivant.Text = ">";
            this.btnSuivant.UseVisualStyleBackColor = true;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.Location = new System.Drawing.Point(137, 45);
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(479, 47);
            this.lblCommentaire.TabIndex = 1;
            this.lblCommentaire.Text = "";
            // 
            // lblDateJ
            // 
            this.lblDateJ.AutoSize = true;
            this.lblDateJ.Location = new System.Drawing.Point(29, 45);
            this.lblDateJ.Name = "lblDateJ";
            this.lblDateJ.Size = new System.Drawing.Size(64, 25);
            this.lblDateJ.TabIndex = 0;
            this.lblDateJ.Text = "";
            // 
            // gpbContacts
            // 
            this.gpbContacts.Controls.Add(this.dgvContacts);
            this.gpbContacts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbContacts.Location = new System.Drawing.Point(35, 247);
            this.gpbContacts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gpbContacts.Name = "gpbContacts";
            this.gpbContacts.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gpbContacts.Size = new System.Drawing.Size(623, 220);
            this.gpbContacts.TabIndex = 1;
            this.gpbContacts.TabStop = false;
            this.gpbContacts.Text = "Contacts avec les informateurs";
            // 
            // dgvContacts
            // 
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Location = new System.Drawing.Point(7, 38);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.ReadOnly = true;
            this.dgvContacts.RowHeadersWidth = 51;
            this.dgvContacts.Size = new System.Drawing.Size(609, 173);
            this.dgvContacts.TabIndex = 1;
            // 
            // gpbDepenses
            // 
            this.gpbDepenses.Controls.Add(this.dgvDepenses);
            this.gpbDepenses.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbDepenses.Location = new System.Drawing.Point(716, 52);
            this.gpbDepenses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gpbDepenses.Name = "gpbDepenses";
            this.gpbDepenses.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gpbDepenses.Size = new System.Drawing.Size(530, 415);
            this.gpbDepenses.TabIndex = 2;
            this.gpbDepenses.TabStop = false;
            this.gpbDepenses.Text = "Dépenses effectués";
            // 
            // dgvDepenses
            // 
            this.dgvDepenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepenses.Location = new System.Drawing.Point(8, 45);
            this.dgvDepenses.Name = "dgvDepenses";
            this.dgvDepenses.ReadOnly = true;
            this.dgvDepenses.RowHeadersWidth = 51;
            this.dgvDepenses.Size = new System.Drawing.Size(515, 362);
            this.dgvDepenses.TabIndex = 0;
            // 
            // lblTotalContacts
            // 
            this.lblTotalContacts.AutoSize = true;
            this.lblTotalContacts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalContacts.Location = new System.Drawing.Point(222, 510);
            this.lblTotalContacts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalContacts.Name = "lblTotalContacts";
            this.lblTotalContacts.Size = new System.Drawing.Size(64, 25);
            this.lblTotalContacts.TabIndex = 3;
            this.lblTotalContacts.Text = "label1";
            // 
            // lblTotalDepenses
            // 
            this.lblTotalDepenses.AutoSize = true;
            this.lblTotalDepenses.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalDepenses.Location = new System.Drawing.Point(863, 510);
            this.lblTotalDepenses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDepenses.Name = "lblTotalDepenses";
            this.lblTotalDepenses.Size = new System.Drawing.Size(64, 25);
            this.lblTotalDepenses.TabIndex = 4;
            this.lblTotalDepenses.Text = "label2";
            // 
            // btnPdf
            // 
            this.btnPdf.BackColor = System.Drawing.Color.DarkViolet;
            this.btnPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPdf.FlatAppearance.BorderSize = 0;
            this.btnPdf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdf.ForeColor = System.Drawing.Color.White;
            this.btnPdf.Location = new System.Drawing.Point(549, 568);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(306, 57);
            this.btnPdf.TabIndex = 5;
            this.btnPdf.Text = "Générer un PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
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
            this.btnRetour.Location = new System.Drawing.Point(42, 547);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(147, 78);
            this.btnRetour.TabIndex = 6;
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // UCJournalBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.gpbDepenses);
            this.Controls.Add(this.lblTotalDepenses);
            this.Controls.Add(this.lblTotalContacts);
            this.Controls.Add(this.gpbContacts);
            this.Controls.Add(this.gpbEvenements);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UCJournalBord";
            this.Size = new System.Drawing.Size(1283, 661);
            this.gpbEvenements.ResumeLayout(false);
            this.gpbEvenements.PerformLayout();
            this.gpbContacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.gpbDepenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbEvenements;
        private System.Windows.Forms.GroupBox gpbContacts;
        private System.Windows.Forms.GroupBox gpbDepenses;
        private System.Windows.Forms.Label lblTotalContacts;
        private System.Windows.Forms.Label lblTotalDepenses;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Label lblCompteur;
        private System.Windows.Forms.Button btnPremier;
        private System.Windows.Forms.Button btnPrecedent;
        private System.Windows.Forms.Button btnDernier;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Label lblCommentaire;
        private System.Windows.Forms.Label lblDateJ;
        private System.Windows.Forms.DataGridView dgvDepenses;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Button btnRetour;
    }
}

namespace Form_Sae24_Stargate
{
    partial class FormDetailsMembre
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
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSpeGrade = new System.Windows.Forms.Label();
            this.lblOrigine = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxMissionsEffectuees = new System.Windows.Forms.ListBox();
            this.lblliste = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.picMembre = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMembre)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(272, 87);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(73, 25);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Née le ";
            // 
            // lblSpeGrade
            // 
            this.lblSpeGrade.AutoSize = true;
            this.lblSpeGrade.Location = new System.Drawing.Point(272, 139);
            this.lblSpeGrade.Name = "lblSpeGrade";
            this.lblSpeGrade.Size = new System.Drawing.Size(153, 25);
            this.lblSpeGrade.TabIndex = 1;
            this.lblSpeGrade.Text = "Specialite/grade";
            // 
            // lblOrigine
            // 
            this.lblOrigine.AutoSize = true;
            this.lblOrigine.Location = new System.Drawing.Point(272, 193);
            this.lblOrigine.Name = "lblOrigine";
            this.lblOrigine.Size = new System.Drawing.Size(172, 25);
            this.lblOrigine.TabIndex = 2;
            this.lblOrigine.Text = "Planete d\'origine : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 3;
            // 
            // listBoxMissionsEffectuees
            // 
            this.listBoxMissionsEffectuees.FormattingEnabled = true;
            this.listBoxMissionsEffectuees.ItemHeight = 25;
            this.listBoxMissionsEffectuees.Location = new System.Drawing.Point(648, 89);
            this.listBoxMissionsEffectuees.Name = "listBoxMissionsEffectuees";
            this.listBoxMissionsEffectuees.Size = new System.Drawing.Size(549, 129);
            this.listBoxMissionsEffectuees.TabIndex = 4;
            this.listBoxMissionsEffectuees.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblliste
            // 
            this.lblliste.AutoSize = true;
            this.lblliste.Location = new System.Drawing.Point(643, 48);
            this.lblliste.Name = "lblliste";
            this.lblliste.Size = new System.Drawing.Size(195, 25);
            this.lblliste.TabIndex = 13;
            this.lblliste.Text = "Missions effectuées :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.ForeColor = System.Drawing.Color.White;
            this.lblNom.Location = new System.Drawing.Point(329, 35);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(154, 29);
            this.lblNom.TabIndex = 14;
            this.lblNom.Text = "Nom prenom";
            // 
            // picMembre
            // 
            this.picMembre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMembre.Location = new System.Drawing.Point(39, 35);
            this.picMembre.Name = "picMembre";
            this.picMembre.Size = new System.Drawing.Size(180, 183);
            this.picMembre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMembre.TabIndex = 15;
            this.picMembre.TabStop = false;
            // 
            // FormDetailsMembre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1231, 244);
            this.Controls.Add(this.picMembre);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblliste);
            this.Controls.Add(this.listBoxMissionsEffectuees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblOrigine);
            this.Controls.Add(this.lblSpeGrade);
            this.Controls.Add(this.lblDate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormDetailsMembre";
            this.Text = "Détail du membre";
            ((System.ComponentModel.ISupportInitialize)(this.picMembre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSpeGrade;
        private System.Windows.Forms.Label lblOrigine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxMissionsEffectuees;
        private System.Windows.Forms.Label lblliste;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.PictureBox picMembre;
    }
}
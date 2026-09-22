namespace Form_Sae24_Stargate
{
    partial class FormEcranChargement
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
            this.userControlBarreChargement1 = new Form_Sae24_Stargate.UserControlBarreChargement();
            this.SuspendLayout();
            // 
            // userControlBarreChargement1
            // 
            this.userControlBarreChargement1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.userControlBarreChargement1.Location = new System.Drawing.Point(88, 185);
            this.userControlBarreChargement1.Name = "userControlBarreChargement1";
            this.userControlBarreChargement1.Size = new System.Drawing.Size(267, 29);
            this.userControlBarreChargement1.TabIndex = 0;
            // 
            // FormEcranChargement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(438, 450);
            this.Controls.Add(this.userControlBarreChargement1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEcranChargement";
            this.Opacity = 0.8D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormEcranChargement_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlBarreChargement userControlBarreChargement1;
    }
}
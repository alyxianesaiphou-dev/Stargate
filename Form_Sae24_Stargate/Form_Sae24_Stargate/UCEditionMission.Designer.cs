using Org.BouncyCastle.Tls.Crypto;
using System.Drawing;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    partial class UCEditionMission
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
            this.gpbNvContact = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.rtxtAppreciation = new System.Windows.Forms.RichTextBox();
            this.txtSomme = new System.Windows.Forms.TextBox();
            this.dtpDateContact = new System.Windows.Forms.DateTimePicker();
            this.cmbInformateur = new System.Windows.Forms.ComboBox();
            this.gpbEspece = new System.Windows.Forms.GroupBox();
            this.nudNombreCapture = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAnnulerCapture = new System.Windows.Forms.Button();
            this.btnValiderCapture = new System.Windows.Forms.Button();
            this.cmbEspece = new System.Windows.Forms.ComboBox();
            this.gpbNvDepense = new System.Windows.Forms.GroupBox();
            this.cmbEspeceAlliee = new System.Windows.Forms.ComboBox();
            this.lblEspece = new System.Windows.Forms.Label();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxtMotifDepense = new System.Windows.Forms.RichTextBox();
            this.txtMontantDepense = new System.Windows.Forms.TextBox();
            this.dtpDateDepense = new System.Windows.Forms.DateTimePicker();
            this.cmbTypeDepense = new System.Windows.Forms.ComboBox();
            this.btnAnnulerDepense = new System.Windows.Forms.Button();
            this.btnValiderDepense = new System.Windows.Forms.Button();
            this.gpbNvEvenement = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rtxtCommentaireEvenement = new System.Windows.Forms.RichTextBox();
            this.dtpDateEvenement = new System.Windows.Forms.DateTimePicker();
            this.btnAnnulerEvenement = new System.Windows.Forms.Button();
            this.btnValiderEvenement = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.btnNvEvenement = new System.Windows.Forms.Button();
            this.btnNvDepense = new System.Windows.Forms.Button();
            this.btnNvContact = new System.Windows.Forms.Button();
            this.gpbNvContact.SuspendLayout();
            this.gpbEspece.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreCapture)).BeginInit();
            this.gpbNvDepense.SuspendLayout();
            this.gpbNvEvenement.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbNvContact
            // 
            this.gpbNvContact.Controls.Add(this.label4);
            this.gpbNvContact.Controls.Add(this.label3);
            this.gpbNvContact.Controls.Add(this.label2);
            this.gpbNvContact.Controls.Add(this.label1);
            this.gpbNvContact.Controls.Add(this.btnAnnuler);
            this.gpbNvContact.Controls.Add(this.btnValider);
            this.gpbNvContact.Controls.Add(this.rtxtAppreciation);
            this.gpbNvContact.Controls.Add(this.txtSomme);
            this.gpbNvContact.Controls.Add(this.dtpDateContact);
            this.gpbNvContact.Controls.Add(this.cmbInformateur);
            this.gpbNvContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbNvContact.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbNvContact.Location = new System.Drawing.Point(54, 221);
            this.gpbNvContact.Name = "gpbNvContact";
            this.gpbNvContact.Size = new System.Drawing.Size(419, 495);
            this.gpbNvContact.TabIndex = 3;
            this.gpbNvContact.TabStop = false;
            this.gpbNvContact.Text = "Nouveau contact";
            this.gpbNvContact.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Appreciation :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Somme :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Informateur :";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.MediumPurple;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(188, 438);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(108, 41);
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.Text = "Réinitialiser";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.DarkViolet;
            this.btnValider.FlatAppearance.BorderSize = 0;
            this.btnValider.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnValider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.Location = new System.Drawing.Point(302, 438);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(108, 41);
            this.btnValider.TabIndex = 4;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // rtxtAppreciation
            // 
            this.rtxtAppreciation.Location = new System.Drawing.Point(9, 254);
            this.rtxtAppreciation.Name = "rtxtAppreciation";
            this.rtxtAppreciation.Size = new System.Drawing.Size(401, 135);
            this.rtxtAppreciation.TabIndex = 3;
            this.rtxtAppreciation.Text = "";
            // 
            // txtSomme
            // 
            this.txtSomme.Location = new System.Drawing.Point(169, 164);
            this.txtSomme.Name = "txtSomme";
            this.txtSomme.Size = new System.Drawing.Size(100, 26);
            this.txtSomme.TabIndex = 2;
            this.txtSomme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // dtpDateContact
            // 
            this.dtpDateContact.Location = new System.Drawing.Point(169, 109);
            this.dtpDateContact.Name = "dtpDateContact";
            this.dtpDateContact.Size = new System.Drawing.Size(241, 26);
            this.dtpDateContact.TabIndex = 1;
            // 
            // cmbInformateur
            // 
            this.cmbInformateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInformateur.FormattingEnabled = true;
            this.cmbInformateur.Location = new System.Drawing.Point(169, 52);
            this.cmbInformateur.Name = "cmbInformateur";
            this.cmbInformateur.Size = new System.Drawing.Size(241, 28);
            this.cmbInformateur.TabIndex = 0;
            // 
            // gpbEspece
            // 
            this.gpbEspece.Controls.Add(this.nudNombreCapture);
            this.gpbEspece.Controls.Add(this.label13);
            this.gpbEspece.Controls.Add(this.label14);
            this.gpbEspece.Controls.Add(this.btnAnnulerCapture);
            this.gpbEspece.Controls.Add(this.btnValiderCapture);
            this.gpbEspece.Controls.Add(this.cmbEspece);
            this.gpbEspece.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbEspece.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbEspece.Location = new System.Drawing.Point(54, 221);
            this.gpbEspece.Name = "gpbEspece";
            this.gpbEspece.Size = new System.Drawing.Size(419, 235);
            this.gpbEspece.TabIndex = 14;
            this.gpbEspece.TabStop = false;
            this.gpbEspece.Text = "Nouveau contact";
            this.gpbEspece.Visible = false;
            // 
            // nudNombreCapture
            // 
            this.nudNombreCapture.Location = new System.Drawing.Point(169, 112);
            this.nudNombreCapture.Name = "nudNombreCapture";
            this.nudNombreCapture.Size = new System.Drawing.Size(120, 26);
            this.nudNombreCapture.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(53, 114);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Nombre :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 20);
            this.label14.TabIndex = 6;
            this.label14.Text = "Espece :";
            // 
            // btnAnnulerCapture
            // 
            this.btnAnnulerCapture.BackColor = System.Drawing.Color.MediumPurple;
            this.btnAnnulerCapture.FlatAppearance.BorderSize = 0;
            this.btnAnnulerCapture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnAnnulerCapture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnAnnulerCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnulerCapture.ForeColor = System.Drawing.Color.White;
            this.btnAnnulerCapture.Location = new System.Drawing.Point(188, 170);
            this.btnAnnulerCapture.Name = "btnAnnulerCapture";
            this.btnAnnulerCapture.Size = new System.Drawing.Size(108, 41);
            this.btnAnnulerCapture.TabIndex = 5;
            this.btnAnnulerCapture.Text = "Réinitialiser";
            this.btnAnnulerCapture.UseVisualStyleBackColor = false;
            this.btnAnnulerCapture.Click += new System.EventHandler(this.btnAnnulerCapture_Click);
            // 
            // btnValiderCapture
            // 
            this.btnValiderCapture.BackColor = System.Drawing.Color.DarkViolet;
            this.btnValiderCapture.FlatAppearance.BorderSize = 0;
            this.btnValiderCapture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnValiderCapture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnValiderCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValiderCapture.ForeColor = System.Drawing.Color.White;
            this.btnValiderCapture.Location = new System.Drawing.Point(302, 170);
            this.btnValiderCapture.Name = "btnValiderCapture";
            this.btnValiderCapture.Size = new System.Drawing.Size(108, 41);
            this.btnValiderCapture.TabIndex = 4;
            this.btnValiderCapture.Text = "Valider";
            this.btnValiderCapture.UseVisualStyleBackColor = false;
            this.btnValiderCapture.Click += new System.EventHandler(this.btnValiderCapture_Click);
            // 
            // cmbEspece
            // 
            this.cmbEspece.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspece.FormattingEnabled = true;
            this.cmbEspece.Location = new System.Drawing.Point(169, 52);
            this.cmbEspece.Name = "cmbEspece";
            this.cmbEspece.Size = new System.Drawing.Size(241, 28);
            this.cmbEspece.TabIndex = 0;
            // 
            // gpbNvDepense
            // 
            this.gpbNvDepense.Controls.Add(this.cmbEspeceAlliee);
            this.gpbNvDepense.Controls.Add(this.lblEspece);
            this.gpbNvDepense.Controls.Add(this.txtQuantite);
            this.gpbNvDepense.Controls.Add(this.lblQuantite);
            this.gpbNvDepense.Controls.Add(this.label8);
            this.gpbNvDepense.Controls.Add(this.label7);
            this.gpbNvDepense.Controls.Add(this.label6);
            this.gpbNvDepense.Controls.Add(this.label5);
            this.gpbNvDepense.Controls.Add(this.rtxtMotifDepense);
            this.gpbNvDepense.Controls.Add(this.txtMontantDepense);
            this.gpbNvDepense.Controls.Add(this.dtpDateDepense);
            this.gpbNvDepense.Controls.Add(this.cmbTypeDepense);
            this.gpbNvDepense.Controls.Add(this.btnAnnulerDepense);
            this.gpbNvDepense.Controls.Add(this.btnValiderDepense);
            this.gpbNvDepense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbNvDepense.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbNvDepense.Location = new System.Drawing.Point(54, 221);
            this.gpbNvDepense.Name = "gpbNvDepense";
            this.gpbNvDepense.Size = new System.Drawing.Size(419, 495);
            this.gpbNvDepense.TabIndex = 10;
            this.gpbNvDepense.TabStop = false;
            this.gpbNvDepense.Text = "Nouvelle dépense";
            this.gpbNvDepense.Visible = false;
            // 
            // cmbEspeceAlliee
            // 
            this.cmbEspeceAlliee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspeceAlliee.FormattingEnabled = true;
            this.cmbEspeceAlliee.Location = new System.Drawing.Point(169, 207);
            this.cmbEspeceAlliee.Name = "cmbEspeceAlliee";
            this.cmbEspeceAlliee.Size = new System.Drawing.Size(241, 28);
            this.cmbEspeceAlliee.TabIndex = 13;
            this.cmbEspeceAlliee.Visible = false;
            // 
            // lblEspece
            // 
            this.lblEspece.AutoSize = true;
            this.lblEspece.Location = new System.Drawing.Point(40, 207);
            this.lblEspece.Name = "lblEspece";
            this.lblEspece.Size = new System.Drawing.Size(111, 20);
            this.lblEspece.TabIndex = 12;
            this.lblEspece.Text = "Espèce alliée :";
            this.lblEspece.Visible = false;
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(169, 165);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(100, 26);
            this.txtQuantite.TabIndex = 2;
            this.txtQuantite.Visible = false;
            this.txtQuantite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // lblQuantite
            // 
            this.lblQuantite.AutoSize = true;
            this.lblQuantite.Location = new System.Drawing.Point(54, 165);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(97, 20);
            this.lblQuantite.TabIndex = 10;
            this.lblQuantite.Text = "Quantité (t) :";
            this.lblQuantite.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Motif de la dépense :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Somme :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Type de dépense :";
            // 
            // rtxtMotifDepense
            // 
            this.rtxtMotifDepense.Location = new System.Drawing.Point(9, 284);
            this.rtxtMotifDepense.Name = "rtxtMotifDepense";
            this.rtxtMotifDepense.Size = new System.Drawing.Size(401, 135);
            this.rtxtMotifDepense.TabIndex = 3;
            this.rtxtMotifDepense.Text = "";
            // 
            // txtMontantDepense
            // 
            this.txtMontantDepense.Location = new System.Drawing.Point(169, 121);
            this.txtMontantDepense.Name = "txtMontantDepense";
            this.txtMontantDepense.Size = new System.Drawing.Size(100, 26);
            this.txtMontantDepense.TabIndex = 1;
            this.txtMontantDepense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // dtpDateDepense
            // 
            this.dtpDateDepense.Location = new System.Drawing.Point(169, 77);
            this.dtpDateDepense.Name = "dtpDateDepense";
            this.dtpDateDepense.Size = new System.Drawing.Size(241, 26);
            this.dtpDateDepense.TabIndex = 3;
            // 
            // cmbTypeDepense
            // 
            this.cmbTypeDepense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeDepense.FormattingEnabled = true;
            this.cmbTypeDepense.Location = new System.Drawing.Point(169, 33);
            this.cmbTypeDepense.Name = "cmbTypeDepense";
            this.cmbTypeDepense.Size = new System.Drawing.Size(241, 28);
            this.cmbTypeDepense.TabIndex = 2;
            this.cmbTypeDepense.SelectedIndexChanged += new System.EventHandler(this.cmbTypeDepense_SelectedIndexChanged);
            // 
            // btnAnnulerDepense
            // 
            this.btnAnnulerDepense.BackColor = System.Drawing.Color.MediumPurple;
            this.btnAnnulerDepense.FlatAppearance.BorderSize = 0;
            this.btnAnnulerDepense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnAnnulerDepense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnAnnulerDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnulerDepense.ForeColor = System.Drawing.Color.White;
            this.btnAnnulerDepense.Location = new System.Drawing.Point(188, 438);
            this.btnAnnulerDepense.Name = "btnAnnulerDepense";
            this.btnAnnulerDepense.Size = new System.Drawing.Size(108, 41);
            this.btnAnnulerDepense.TabIndex = 1;
            this.btnAnnulerDepense.Text = "Réinitialiser";
            this.btnAnnulerDepense.UseVisualStyleBackColor = false;
            this.btnAnnulerDepense.Click += new System.EventHandler(this.btnAnnulerDepense_Click);
            // 
            // btnValiderDepense
            // 
            this.btnValiderDepense.BackColor = System.Drawing.Color.DarkViolet;
            this.btnValiderDepense.FlatAppearance.BorderSize = 0;
            this.btnValiderDepense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnValiderDepense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnValiderDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValiderDepense.ForeColor = System.Drawing.Color.White;
            this.btnValiderDepense.Location = new System.Drawing.Point(302, 438);
            this.btnValiderDepense.Name = "btnValiderDepense";
            this.btnValiderDepense.Size = new System.Drawing.Size(108, 41);
            this.btnValiderDepense.TabIndex = 4;
            this.btnValiderDepense.Text = "Valider";
            this.btnValiderDepense.UseVisualStyleBackColor = false;
            this.btnValiderDepense.Click += new System.EventHandler(this.btnValiderDepense_Click);
            // 
            // gpbNvEvenement
            // 
            this.gpbNvEvenement.Controls.Add(this.label9);
            this.gpbNvEvenement.Controls.Add(this.label11);
            this.gpbNvEvenement.Controls.Add(this.rtxtCommentaireEvenement);
            this.gpbNvEvenement.Controls.Add(this.dtpDateEvenement);
            this.gpbNvEvenement.Controls.Add(this.btnAnnulerEvenement);
            this.gpbNvEvenement.Controls.Add(this.btnValiderEvenement);
            this.gpbNvEvenement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbNvEvenement.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbNvEvenement.Location = new System.Drawing.Point(54, 221);
            this.gpbNvEvenement.Name = "gpbNvEvenement";
            this.gpbNvEvenement.Size = new System.Drawing.Size(419, 495);
            this.gpbNvEvenement.TabIndex = 11;
            this.gpbNvEvenement.TabStop = false;
            this.gpbNvEvenement.Text = "Nouvel évenement";
            this.gpbNvEvenement.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Commentaire :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Date :";
            // 
            // rtxtCommentaireEvenement
            // 
            this.rtxtCommentaireEvenement.Location = new System.Drawing.Point(9, 170);
            this.rtxtCommentaireEvenement.Name = "rtxtCommentaireEvenement";
            this.rtxtCommentaireEvenement.Size = new System.Drawing.Size(401, 219);
            this.rtxtCommentaireEvenement.TabIndex = 5;
            this.rtxtCommentaireEvenement.Text = "";
            // 
            // dtpDateEvenement
            // 
            this.dtpDateEvenement.Location = new System.Drawing.Point(103, 76);
            this.dtpDateEvenement.Name = "dtpDateEvenement";
            this.dtpDateEvenement.Size = new System.Drawing.Size(241, 26);
            this.dtpDateEvenement.TabIndex = 3;
            // 
            // btnAnnulerEvenement
            // 
            this.btnAnnulerEvenement.BackColor = System.Drawing.Color.MediumPurple;
            this.btnAnnulerEvenement.FlatAppearance.BorderSize = 0;
            this.btnAnnulerEvenement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnAnnulerEvenement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnAnnulerEvenement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnulerEvenement.ForeColor = System.Drawing.Color.White;
            this.btnAnnulerEvenement.Location = new System.Drawing.Point(188, 438);
            this.btnAnnulerEvenement.Name = "btnAnnulerEvenement";
            this.btnAnnulerEvenement.Size = new System.Drawing.Size(108, 41);
            this.btnAnnulerEvenement.TabIndex = 1;
            this.btnAnnulerEvenement.Text = "Réinitialiser";
            this.btnAnnulerEvenement.UseVisualStyleBackColor = false;
            this.btnAnnulerEvenement.Click += new System.EventHandler(this.btnAnnulerEvenement_Click);
            // 
            // btnValiderEvenement
            // 
            this.btnValiderEvenement.BackColor = System.Drawing.Color.DarkViolet;
            this.btnValiderEvenement.FlatAppearance.BorderSize = 0;
            this.btnValiderEvenement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnValiderEvenement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnValiderEvenement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValiderEvenement.ForeColor = System.Drawing.Color.White;
            this.btnValiderEvenement.Location = new System.Drawing.Point(302, 438);
            this.btnValiderEvenement.Name = "btnValiderEvenement";
            this.btnValiderEvenement.Size = new System.Drawing.Size(108, 41);
            this.btnValiderEvenement.TabIndex = 0;
            this.btnValiderEvenement.Text = "Valider";
            this.btnValiderEvenement.UseVisualStyleBackColor = false;
            this.btnValiderEvenement.Click += new System.EventHandler(this.btnValiderEvenement_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnCapture.BackgroundImage = global::Form_Sae24_Stargate.Properties.Resources.Alien;
            this.btnCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCapture.FlatAppearance.BorderSize = 0;
            this.btnCapture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnCapture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Location = new System.Drawing.Point(385, 107);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(103, 97);
            this.btnCapture.TabIndex = 13;
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.Transparent;
            this.btnRetour.BackgroundImage = global::Form_Sae24_Stargate.Properties.Resources.retour;
            this.btnRetour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRetour.FlatAppearance.BorderSize = 0;
            this.btnRetour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnRetour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnRetour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetour.Location = new System.Drawing.Point(42, 3);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(76, 79);
            this.btnRetour.TabIndex = 12;
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // btnNvEvenement
            // 
            this.btnNvEvenement.BackColor = System.Drawing.Color.Transparent;
            this.btnNvEvenement.BackgroundImage = global::Form_Sae24_Stargate.Properties.Resources.evenement;
            this.btnNvEvenement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNvEvenement.FlatAppearance.BorderSize = 0;
            this.btnNvEvenement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnNvEvenement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnNvEvenement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNvEvenement.Location = new System.Drawing.Point(276, 107);
            this.btnNvEvenement.Name = "btnNvEvenement";
            this.btnNvEvenement.Size = new System.Drawing.Size(103, 97);
            this.btnNvEvenement.TabIndex = 2;
            this.btnNvEvenement.UseVisualStyleBackColor = false;
            this.btnNvEvenement.Click += new System.EventHandler(this.btnNvEvenement_Click);
            // 
            // btnNvDepense
            // 
            this.btnNvDepense.BackColor = System.Drawing.Color.Transparent;
            this.btnNvDepense.BackgroundImage = global::Form_Sae24_Stargate.Properties.Resources.depense;
            this.btnNvDepense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNvDepense.FlatAppearance.BorderSize = 0;
            this.btnNvDepense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnNvDepense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnNvDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNvDepense.Location = new System.Drawing.Point(157, 107);
            this.btnNvDepense.Name = "btnNvDepense";
            this.btnNvDepense.Size = new System.Drawing.Size(103, 97);
            this.btnNvDepense.TabIndex = 1;
            this.btnNvDepense.UseVisualStyleBackColor = false;
            this.btnNvDepense.Click += new System.EventHandler(this.btnNvDepense_Click);
            // 
            // btnNvContact
            // 
            this.btnNvContact.BackColor = System.Drawing.Color.Transparent;
            this.btnNvContact.BackgroundImage = global::Form_Sae24_Stargate.Properties.Resources.contact;
            this.btnNvContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNvContact.FlatAppearance.BorderSize = 0;
            this.btnNvContact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnNvContact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnNvContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNvContact.Location = new System.Drawing.Point(42, 107);
            this.btnNvContact.Name = "btnNvContact";
            this.btnNvContact.Size = new System.Drawing.Size(103, 97);
            this.btnNvContact.TabIndex = 0;
            this.btnNvContact.UseVisualStyleBackColor = true;
            this.btnNvContact.Click += new System.EventHandler(this.btnNvContact_Click);
            // 
            // UCEditionMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnNvEvenement);
            this.Controls.Add(this.btnNvDepense);
            this.Controls.Add(this.btnNvContact);
            this.Controls.Add(this.gpbNvDepense);
            this.Controls.Add(this.gpbEspece);
            this.Controls.Add(this.gpbNvContact);
            this.Controls.Add(this.gpbNvEvenement);
            this.Name = "UCEditionMission";
            this.Size = new System.Drawing.Size(532, 768);
            this.gpbNvContact.ResumeLayout(false);
            this.gpbNvContact.PerformLayout();
            this.gpbEspece.ResumeLayout(false);
            this.gpbEspece.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreCapture)).EndInit();
            this.gpbNvDepense.ResumeLayout(false);
            this.gpbNvDepense.PerformLayout();
            this.gpbNvEvenement.ResumeLayout(false);
            this.gpbNvEvenement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNvContact;
        private System.Windows.Forms.Button btnNvDepense;
        private System.Windows.Forms.Button btnNvEvenement;
        private System.Windows.Forms.GroupBox gpbNvContact;
        private System.Windows.Forms.RichTextBox rtxtAppreciation;
        private System.Windows.Forms.TextBox txtSomme;
        private System.Windows.Forms.DateTimePicker dtpDateContact;
        private System.Windows.Forms.ComboBox cmbInformateur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.GroupBox gpbNvDepense;
        private System.Windows.Forms.Button btnAnnulerDepense;
        private System.Windows.Forms.Button btnValiderDepense;
        private System.Windows.Forms.RichTextBox rtxtMotifDepense;
        private System.Windows.Forms.TextBox txtMontantDepense;
        private System.Windows.Forms.DateTimePicker dtpDateDepense;
        private System.Windows.Forms.ComboBox cmbTypeDepense;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gpbNvEvenement;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox rtxtCommentaireEvenement;
        private System.Windows.Forms.DateTimePicker dtpDateEvenement;
        private System.Windows.Forms.Button btnAnnulerEvenement;
        private System.Windows.Forms.Button btnValiderEvenement;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.Label lblQuantite;
        private System.Windows.Forms.ComboBox cmbEspeceAlliee;
        private System.Windows.Forms.Label lblEspece;
        private System.Windows.Forms.Button btnRetour;
        private Button btnCapture;
        private GroupBox gpbEspece;
        private Label label13;
        private Label label14;
        private Button btnAnnulerCapture;
        private Button btnValiderCapture;
        private ComboBox cmbEspece;
        private NumericUpDown nudNombreCapture;
    }
}

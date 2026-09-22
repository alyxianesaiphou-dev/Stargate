using System;
using System.Drawing;
using System.Windows.Forms;

namespace UserControlPinPlanete
{
    public delegate void afficherInfos(object sender, EventArgs e);

    public partial class UCPinPlanete : UserControl
    {
        public afficherInfos afficheur;

        public UCPinPlanete()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
            radPlanete.CheckedChanged += RadPlanete_CheckedChanged;
            this.Click += Zone_Click;
            picPlanete.Click += Zone_Click;
            lblNomPlanete.Click += Zone_Click;
            radPlanete.Click += Zone_Click;
        }

        public string NomPlanete
        {
            get { return lblNomPlanete.Text; }
            set { lblNomPlanete.Text = value; }
        }

        public void Decocher()
        {
            radPlanete.Checked = false;
        }

        private void Zone_Click(object sender, EventArgs e)
        {
            radPlanete.Checked = true;
            if (this.afficheur != null)
            {
                this.afficheur(sender, e);
            }
        }

        private void RadPlanete_CheckedChanged(object sender, EventArgs e)
        {
            if (radPlanete.Checked)
            {
                this.BackColor = Color.Transparent;
                lblNomPlanete.ForeColor = Color.LimeGreen;
                if (this.Parent != null)
                {
                    foreach (Control ctrl in this.Parent.Controls)
                    {
                        if (ctrl is UCPinPlanete autrePlanete && autrePlanete != this)
                        {
                            autrePlanete.Decocher();
                        }
                    }
                }
            }
            else
            {
                this.BackColor = Color.Transparent;
                lblNomPlanete.ForeColor = Color.White;
            }
        }
    }
}
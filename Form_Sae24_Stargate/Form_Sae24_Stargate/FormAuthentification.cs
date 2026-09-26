using BCrypt.Net;
using Form_Sae24_Stargate.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    public partial class FormAuthentification : Form
    {
        bool mdpVisible = false;
        public FormAuthentification()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            txtMdp.UseSystemPasswordChar = true;

            //picOeil.Image = Image.FromFile(@"Images\Icones\oeil.png");
        }

        private void FormAuthentification_Load(object sender, EventArgs e)
        {

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = $"select mdp from Admin where login = '{txtLogin.Text}'";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                object resultat = cmd.ExecuteScalar();

                if (resultat != DBNull.Value && resultat != null)
                {
                    string mdpStocke = resultat.ToString();
                    bool valide = BCrypt.Net.BCrypt.Verify(txtMdp.Text, mdpStocke);

                    if (valide)
                    {
                        MessageBox.Show("Authentification réussie", "Accès autorisé");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Échec de l'authentification", "Accès refusé");
                        txtMdp.Clear();
                        txtMdp.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erreur authentification");
            }
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void grpAuthentification_Enter(object sender, EventArgs e)
        {

        }

        private void txtMdp_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            string etat = "";
            if (mdpVisible)
            {
                etat = "oeil";
            }
            else
            {
                etat = "oeil_barre";
            }
            mdpVisible = !mdpVisible;
            txtMdp.UseSystemPasswordChar = !mdpVisible;

            string chemin = @"Images\Icones\" + etat + ".png";
            picOeil.Image = Image.FromFile(chemin);
        }



        private void txtMdp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    public partial class FormEcranChargement : Form
    {
        public FormEcranChargement()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


            userControlBarreChargement1.ChargementTermine += FinDuChargement;
        }

        private void FormEcranChargement_Load(object sender, EventArgs e)
        {
            //calcul du centre exact pour la largeur
            userControlBarreChargement1.Left = (this.Width - userControlBarreChargement1.Width) / 2;

            //calcul du centre exact pour la hauteur
            userControlBarreChargement1.Top = (this.Height - userControlBarreChargement1.Height) / 2;

            userControlBarreChargement1.LancerChargement();
        }
        private void FinDuChargement(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

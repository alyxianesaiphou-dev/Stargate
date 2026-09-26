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
    public partial class FormSucces : Form
    {
        public FormSucces(string messagePersonnalise, bool estErreur)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            this.Opacity = 0.85;


            lblMessage.Text = messagePersonnalise;


            lblMessage.AutoSize = true;
            lblMessage.MaximumSize = new Size(500, 0);


            lblMessage.ForeColor = Color.White;          //texte en blanc 
            lblMessage.Font = new Font("Segoe UI", 14, FontStyle.Bold);


            lblMessage.Padding = new Padding(30, 20, 30, 20);

            if (estErreur == true)
            {
                lblMessage.BackColor = Color.Crimson; //rouge pour les erreurs
                timerFermeture.Interval = 5000;       // 5 secondes
            }
            else
            {
                lblMessage.BackColor = Color.MediumSeaGreen; //vert pour les succès
                timerFermeture.Interval = 3000;              // 3 secondes 
            }

            timerFermeture.Tick += timerFermeture_Tick;

            timerFermeture.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //case au milieu de l'écran noir
            lblMessage.Left = (this.Width - lblMessage.Width) / 2;
            lblMessage.Top = (this.Height - lblMessage.Height) / 2;
        }

        private void FormSucces_Load(object sender, EventArgs e)
        {
            timerFermeture.Start();
        }

        private void timerFermeture_Tick(object sender, EventArgs e)
        {
            timerFermeture.Stop();
            this.Close();
        }

        //permet de l'appeler n'importe où
        public static void Afficher(string message, bool estErreur = false)
        {
            //on crée la fenêtre avec le message voulu
            FormSucces fenetreToast = new FormSucces(message, estErreur);


            fenetreToast.Show();
        }
    }
}

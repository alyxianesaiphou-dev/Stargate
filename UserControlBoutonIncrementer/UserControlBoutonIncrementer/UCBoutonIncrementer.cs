using System;
using System.Windows.Forms;

namespace UserControlBoutonIncrementer
{
    public partial class UCBoutonIncrementer : UserControl
    {
        public int PasMoinsMoins { get; set; } = 10;
        public int PasMoins { get; set; } = 1;
        public int PasPlus { get; set; } = 1;
        public int PasPlusPlus { get; set; } = 10;
        public string TexteUnite
        {
            get { return lblUnite.Text; }
            set { lblUnite.Text = value; }
        }

        public string TexteSymbole
        {
            get { return lblSymbole.Text; }
            set { lblSymbole.Text = value; }
        }
        public int Valeur
        {
            get
            {
                int resultatFinal;
                bool conversionReussie = int.TryParse(txtVal.Text, out resultatFinal);
                if (conversionReussie == true)
                {
                    return resultatFinal;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                txtVal.Text = value.ToString();
            }
        }

        public UCBoutonIncrementer()
        {
            InitializeComponent();
            txtVal.Text = "0";
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            Valeur -= PasMoinsMoins; 
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            Valeur -= PasMoins;
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            Valeur += PasPlus;
        }

        private void btnPP_Click(object sender, EventArgs e)
        {
            Valeur += PasPlusPlus;
        }

        private void txtVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
                errorProvider1.SetError(txtVal, "Veuillez ne saisir que des chiffres entiers.");
            }
        }
        private void txtVal_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtVal, "");
        }
    }
}
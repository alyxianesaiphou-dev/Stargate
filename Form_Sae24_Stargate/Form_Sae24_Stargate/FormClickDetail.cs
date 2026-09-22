using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlExtraterrestresDetail;
using UserControlMembreEquipageDetail;
using UserControlPlanete;

namespace Form_Sae24_Stargate
{
    public partial class FormClickDetail : Form
    {
        public FormClickDetail(UCExtraterrestresDetail alienDetail)
        {
            InitializeComponent();
            this.Controls.Add(alienDetail);
            this.ClientSize = new System.Drawing.Size(730, 190);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public FormClickDetail(UCPlaneteDetail planeteDetail)
        {
            InitializeComponent();
            this.Controls.Add(planeteDetail);
            this.Text = "Détails planète";
            this.ClientSize = new System.Drawing.Size(1300, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public FormClickDetail(UserControlMissionDetail missionDetail)
        {
            InitializeComponent();
            missionDetail.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(missionDetail);

            this.Text = "Détails mission";

            //récupère dynamiquement la taille du UserControl
            this.ClientSize = new System.Drawing.Size(missionDetail.Width, missionDetail.Height);

            this.StartPosition = FormStartPosition.CenterScreen;

            //empêche le redimensionnement manuel 
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        public FormClickDetail(UCEquipageDetail detailEquipage)
        {
            InitializeComponent();
            this.Controls.Add(detailEquipage);
            this.Text = "Détails equipage";
            this.ClientSize = new System.Drawing.Size(600, 525);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

    }
}

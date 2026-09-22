using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlPlanete
{

    public delegate void etatRdbRaces(object sender, EventArgs e);
    public delegate void etatRdbMission(object sender, EventArgs e);
    public partial class UCPlaneteDetail : UserControl
    {
        // Création d’une instance du delegate -> crée une variable capable de stocker une méthode
        public etatRdbRaces raceSelection;
        public etatRdbMission missionSelection;
        public UCPlaneteDetail()
        {
            InitializeComponent();
        }

        public UCPlaneteDetail(string nomPlanete, string temp, string gravite, string dtb)
        {
            InitializeComponent();
            //Récûperer le chemin pour les images sur chaque pc
            string cheminPlanete = @"Images\Planetes\" + nomPlanete + ".png";

            picPlanete.Image = Image.FromFile(cheminPlanete);
            lblPlanete.Text = nomPlanete;

            string thermometre = "TemperatureInconnue";
            if (temp == "") { temp = "?"; }
            if (temp != "?")
            {
                int temperature = Convert.ToInt32(temp);
                if (temperature < 0)
                {
                    thermometre = "TemperatureFroid";
                }
                else if (temperature > 100)
                {
                    thermometre = "TemperatureChaud";
                }
                else if (temperature >= 0 && temperature <= 100)
                {
                    thermometre = "TemperatureMoyen";
                }
                temp += "°C";
            }



            string cheminTemperature = @"Images\Planetes\Temperature\" + thermometre + ".png";
            picTemperature.Image = Image.FromFile(cheminTemperature);
            lblTemperature.Text = temp.ToString();

            lblGravite.Text = gravite;

            String iconeDataBaz = "InconnuDataBaz";
            if (dtb != "?")
            {
                int dataBaz = Convert.ToInt32(dtb);
                if (dataBaz == 0)
                {
                    iconeDataBaz = "AbsenceDataBaz";
                }
                if (dataBaz == 1)
                {
                    iconeDataBaz = "PresenceDataBaz";
                }
            }

            string cheminDataBaz = @"Images\Planetes\DataBaz\" + iconeDataBaz + ".png";
            picDataBaz.Image = Image.FromFile(cheminDataBaz);

        }

        public FlowLayoutPanel getFLPRaces
        {
            get { return this.flpRaces; }
            set {; }
        }

        public FlowLayoutPanel getFLPMission
        {
            get { return this.flpMission; }
            set {; }
        }

        public string nomPlanete
        {
            get { return this.lblPlanete.Text; }
        }
    }
}

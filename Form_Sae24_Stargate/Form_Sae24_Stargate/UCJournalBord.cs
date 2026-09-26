using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    public partial class UCJournalBord : UserControl
    {
        private int numeroEnCours;
        private string planeteEnCours;
        private DataSet dataSetGlobal;
        private DataTable dtEvenements;

        private BindingSource bsEvenements;

        public UCJournalBord()
        {
            InitializeComponent();
            bsEvenements = new BindingSource();

            bsEvenements.PositionChanged += new EventHandler((s, e) => MettreAJourCompteur());
        }

        public void ChargerJournal(int numero, string planete, DataSet dataSetGlobal)
        {
            this.numeroEnCours = numero;
            this.planeteEnCours = planete;
            this.dataSetGlobal = dataSetGlobal;

            try
            {

                SQLiteConnection conn = Connexion.Connec;

                //journal
                string reqJournal = @" SELECT * FROM JournalDeBord
                                        WHERE numero = " + numeroEnCours + @"
                                        AND nomPlanete = '" + planeteEnCours + "'ORDER BY dateJ";

                SQLiteCommand cmd = new SQLiteCommand(reqJournal, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                dtEvenements = new DataTable();
                dtEvenements.Load(reader);
                reader.Close();

                bsEvenements.DataSource = dtEvenements;

                lblCommentaire.DataBindings.Clear();
                lblDateJ.DataBindings.Clear();

                lblCommentaire.DataBindings.Add("Text", bsEvenements, "commentaires");

                MettreAJourCompteur();

                //dépense
                string reqDep = @"SELECT * FROM Depense
                                WHERE numeroMission = " + numeroEnCours + @"
                                AND nomPlanete = '" + planeteEnCours + "'";

                SQLiteDataAdapter daDep = new SQLiteDataAdapter(reqDep, conn);
                DataTable dtDep = new DataTable();
                daDep.Fill(dtDep);


                dgvDepenses.DataSource = dtDep;

                //contact
                string reqCont = @"SELECT * FROM Contact
                                WHERE numeroMission = " + numeroEnCours + @"
                                AND nomPlanete = '" + planeteEnCours + "'";

                SQLiteDataAdapter daCont = new SQLiteDataAdapter(reqCont, conn);
                DataTable dtCont = new DataTable();
                daCont.Fill(dtCont);

                dgvContacts.DataSource = dtCont;

                //total
                CalculerTotaux(dtDep, dtCont);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement journal : " + ex.Message);
            }
        }

        private void CalculerTotaux(DataTable dtDep, DataTable dtCont)
        {
            double totalDepenses = 0;
            double totalContacts = 0;

            foreach (DataRow ligne in dtDep.Rows)
            {
                if (ligne["montant"] != DBNull.Value)
                    totalDepenses += Convert.ToDouble(ligne["montant"]);
            }

            lblTotalDepenses.Text = "Total dépenses : " + totalDepenses.ToString("C2");

            foreach (DataRow ligne in dtCont.Rows)
            {
                if (ligne["sommeVersee"] != DBNull.Value)
                    totalContacts += Convert.ToDouble(ligne["sommeVersee"]);
            }

            lblTotalContacts.Text = "Total contacts : " + totalContacts.ToString("C2");
        }

        private void btnPremier_Click(object sender, EventArgs e)
        {
            bsEvenements.MoveFirst();
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            bsEvenements.MovePrevious();
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            bsEvenements.MoveNext();
        }

        private void btnDernier_Click(object sender, EventArgs e)
        {
            bsEvenements.MoveLast();
        }

        private void MettreAJourCompteur()
        {
            if (bsEvenements.Count > 0)
            {

                lblCompteur.Text = "Événement " + (bsEvenements.Position + 1) + " sur " + bsEvenements.Count;
                DataRowView ligneActuelle = (DataRowView)bsEvenements.Current;


                if (ligneActuelle["dateJ"] != DBNull.Value)
                {
                    //on force la conversion en vraie Date 
                    DateTime laDate = Convert.ToDateTime(ligneActuelle["dateJ"]);

                    //on écrit manuellement dans le label en éliminant définitivement l'heure 
                    lblDateJ.Text = laDate.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                lblCompteur.Text = "Aucun événement";
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                string nomTableBilan = "BilanCapture" + this.planeteEnCours.ToUpper();

                if (!dataSetGlobal.Tables.Contains(nomTableBilan))
                {
                    DataTable dtBilan = new DataTable(nomTableBilan);
                    dtBilan.Columns.Add("Nom de l'espèce", typeof(string));
                    dtBilan.Columns.Add("Objectif initial", typeof(int));
                    dtBilan.Columns.Add("Nombre de captures", typeof(int));
                    dtBilan.Columns.Add("Taux de réussite", typeof(string));

                    dataSetGlobal.Tables.Add(dtBilan);
                }


                DataTable tableBilanLocale = dataSetGlobal.Tables[nomTableBilan];
                tableBilanLocale.Rows.Clear();

                DataRow[] objectifs = dataSetGlobal.Tables["ObjectifCapture"].Select("numeroMission = " + this.numeroEnCours + " AND nomPlanete = '" + this.planeteEnCours + "'");

                foreach (DataRow ligneObj in objectifs)
                {

                    int idEspece = Convert.ToInt32(ligneObj["idEspeceEnnemi"]);
                    int objectifInitial = 0;

                    if (ligneObj["objectif"] != DBNull.Value)
                    {
                        objectifInitial = Convert.ToInt32(ligneObj["objectif"]);
                    }

                    string nomEspece = "Inconnu";
                    DataRow[] tabEspeces = dataSetGlobal.Tables["Espece"].Select("id = " + idEspece);
                    if (tabEspeces.Length > 0)
                    {
                        nomEspece = tabEspeces[0]["nom"].ToString();
                    }

                    int nombreCapture = 0;
                    DataRow[] tabCaptures = dataSetGlobal.Tables["Capturer"].Select("numeroMission = " + this.numeroEnCours + " AND nomPlanete = '" + this.planeteEnCours + "' AND idEspeceEnnemi = " + idEspece);

                    foreach (DataRow ligneCap in tabCaptures)
                    {
                        if (ligneCap["nombre"] != DBNull.Value)
                        {
                            nombreCapture += Convert.ToInt32(ligneCap["nombre"]);
                        }
                    }

                    double tauxReussite = 0;
                    if (objectifInitial > 0)
                    {
                        tauxReussite = ((double)nombreCapture / objectifInitial) * 100;
                    }
                    tableBilanLocale.Rows.Add(nomEspece, objectifInitial, nombreCapture, Math.Round(tauxReussite, 0) + " %");
                }



                Pdf.GenererRapportMission(this.planeteEnCours, this.numeroEnCours, tableBilanLocale);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du lancement de l'édition PDF : " + ex.Message, "Erreur");
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            Form fenetreParente = this.FindForm();

            if (fenetreParente != null)
            {
                fenetreParente.Close();
            }
        }
    }
}

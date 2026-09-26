using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    /// <summary>
    /// Fenêtre pour ajouter ou retirer des participants d'une mission déjà créée.
    /// Un membre ne peut être ajouté que s'il n'est sur aucune autre mission pendant les mêmes dates.
    /// </summary>
    public class FormModifierEquipage : Form
    {
        private readonly int numeroMission;
        private readonly string nomPlanete;
        private string dateDepart;
        private string dateRetour;
        private string matriculeChef;

        private ListBox lstEquipage;
        private ListBox lstDisponibles;
        private Label lblResume;

        //un membre affiché dans une des deux listes
        private class MembreListe
        {
            public string Matricule;
            public string Nom;
            public bool EstChef;

            public override string ToString()
            {
                return Nom + " (" + Matricule + ")" + (EstChef ? " - Chef" : "");
            }
        }

        public FormModifierEquipage(int numero, string planete)
        {
            this.numeroMission = numero;
            this.nomPlanete = planete;

            ConstruireFenetre();
            ChargerMission();
        }

        private void ConstruireFenetre()
        {
            this.Text = "Modifier l'équipage";
            this.ClientSize = new Size(760, 560);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.DarkSlateBlue;
            this.ForeColor = Color.White;
            this.Font = new Font("Microsoft Sans Serif", 12F);

            lblResume = new Label();
            lblResume.AutoSize = false;
            lblResume.Location = new Point(20, 15);
            lblResume.Size = new Size(720, 50);

            Label lblEquipage = new Label();
            lblEquipage.Text = "Équipage actuel";
            lblEquipage.AutoSize = true;
            lblEquipage.Location = new Point(20, 75);

            lstEquipage = new ListBox();
            lstEquipage.Location = new Point(20, 105);
            lstEquipage.Size = new Size(300, 380);
            lstEquipage.SelectionMode = SelectionMode.MultiExtended;
            lstEquipage.Sorted = true;
            lstEquipage.DoubleClick += btnRetirer_Click;

            Label lblDisponibles = new Label();
            lblDisponibles.Text = "Membres disponibles à ces dates";
            lblDisponibles.AutoSize = true;
            lblDisponibles.Location = new Point(440, 75);

            lstDisponibles = new ListBox();
            lstDisponibles.Location = new Point(440, 105);
            lstDisponibles.Size = new Size(300, 380);
            lstDisponibles.SelectionMode = SelectionMode.MultiExtended;
            lstDisponibles.Sorted = true;
            lstDisponibles.DoubleClick += btnAjouter_Click;

            Button btnAjouter = CreerBouton("← Ajouter", new Point(330, 220), Color.DarkViolet);
            btnAjouter.Click += btnAjouter_Click;

            Button btnRetirer = CreerBouton("Retirer →", new Point(330, 280), Color.MediumPurple);
            btnRetirer.Click += btnRetirer_Click;

            Button btnAnnuler = CreerBouton("Annuler", new Point(512, 500), Color.MediumPurple);
            btnAnnuler.Click += delegate { this.Close(); };

            Button btnEnregistrer = CreerBouton("Enregistrer", new Point(632, 500), Color.DarkViolet);
            btnEnregistrer.Click += btnEnregistrer_Click;

            this.Controls.Add(lblResume);
            this.Controls.Add(lblEquipage);
            this.Controls.Add(lstEquipage);
            this.Controls.Add(lblDisponibles);
            this.Controls.Add(lstDisponibles);
            this.Controls.Add(btnAjouter);
            this.Controls.Add(btnRetirer);
            this.Controls.Add(btnAnnuler);
            this.Controls.Add(btnEnregistrer);
        }

        private Button CreerBouton(string texte, Point position, Color couleur)
        {
            Button btn = new Button();
            btn.Text = texte;
            btn.Location = position;
            btn.Size = new Size(100, 41);
            btn.BackColor = couleur;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.Indigo;
            btn.FlatAppearance.MouseDownBackColor = Color.Indigo;
            btn.UseVisualStyleBackColor = false;
            return btn;
        }

        private void ChargerMission()
        {
            try
            {
                string reqMission = @"SELECT date(dateDepart) AS depart, date(dateRetour) AS retour, matriculeChef
                                    FROM Mission
                                    WHERE nomPlanete = @planete AND numero = @numero";

                SQLiteCommand cmdMission = new SQLiteCommand(reqMission, Connexion.Connec);
                cmdMission.Parameters.AddWithValue("@planete", nomPlanete);
                cmdMission.Parameters.AddWithValue("@numero", numeroMission);

                using (SQLiteDataReader lecteur = cmdMission.ExecuteReader())
                {
                    if (!lecteur.Read())
                    {
                        throw new Exception("Mission introuvable.");
                    }
                    dateDepart = lecteur["depart"].ToString();
                    dateRetour = lecteur["retour"].ToString();
                    matriculeChef = lecteur["matriculeChef"].ToString();
                }

                lblResume.Text = "Mission n°" + numeroMission + " - " + nomPlanete.ToUpper()
                    + "\nDu " + DateTime.Parse(dateDepart).ToString("dd/MM/yyyy")
                    + " au " + DateTime.Parse(dateRetour).ToString("dd/MM/yyyy");

                //équipage actuel
                string reqEquipage = @"SELECT Membre.matricule, Membre.nom, Membre.prenom
                                    FROM Composer
                                    INNER JOIN Membre ON Composer.matriculeMembre = Membre.matricule
                                    WHERE Composer.nomPlanete = @planete AND Composer.numeroMission = @numero
                                    ORDER BY Membre.nom";

                SQLiteCommand cmdEquipage = new SQLiteCommand(reqEquipage, Connexion.Connec);
                cmdEquipage.Parameters.AddWithValue("@planete", nomPlanete);
                cmdEquipage.Parameters.AddWithValue("@numero", numeroMission);
                RemplirListe(lstEquipage, cmdEquipage);

                //membres libres pendant toute la durée de la mission
                string reqDispo = @"SELECT Membre.matricule, Membre.nom, Membre.prenom
                                    FROM Membre
                                    WHERE Membre.matricule NOT IN
                                    (
                                        SELECT matriculeMembre FROM Composer
                                        WHERE nomPlanete = @planete AND numeroMission = @numero
                                    )
                                    AND " + ConditionLibre("Membre.matricule") + @"
                                    ORDER BY Membre.nom";

                SQLiteCommand cmdDispo = new SQLiteCommand(reqDispo, Connexion.Connec);
                AjouterParametresMission(cmdDispo);
                RemplirListe(lstDisponibles, cmdDispo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SQL lors du chargement de l'équipage : " + ex.Message);
            }
        }

        /// <summary>
        /// Condition SQL vraie si le membre n'est sur aucune autre mission (ni comme participant, ni comme chef)
        /// dont les dates chevauchent celles de cette mission
        /// </summary>
        private static string ConditionLibre(string colonneMatricule)
        {
            return colonneMatricule + @" NOT IN
                    (
                        SELECT Composer.matriculeMembre
                        FROM Composer
                        INNER JOIN Mission
                            ON Composer.nomPlanete = Mission.nomPlanete
                            AND Composer.numeroMission = Mission.numero
                        WHERE date(Mission.dateDepart) <= @dateRetour
                        AND date(Mission.dateRetour) >= @dateDepart
                        AND NOT (Mission.nomPlanete = @planete AND Mission.numero = @numero)
                    )
                    AND " + colonneMatricule + @" NOT IN
                    (
                        SELECT matriculeChef
                        FROM Mission
                        WHERE date(dateDepart) <= @dateRetour
                        AND date(dateRetour) >= @dateDepart
                        AND NOT (nomPlanete = @planete AND numero = @numero)
                        AND matriculeChef IS NOT NULL
                    )";
        }

        private void AjouterParametresMission(SQLiteCommand commande)
        {
            commande.Parameters.AddWithValue("@planete", nomPlanete);
            commande.Parameters.AddWithValue("@numero", numeroMission);
            commande.Parameters.AddWithValue("@dateDepart", dateDepart);
            commande.Parameters.AddWithValue("@dateRetour", dateRetour);
        }

        private void RemplirListe(ListBox liste, SQLiteCommand commande)
        {
            liste.Items.Clear();

            using (SQLiteDataReader lecteur = commande.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    MembreListe membre = new MembreListe();
                    membre.Matricule = lecteur["matricule"].ToString();
                    membre.Nom = lecteur["nom"].ToString() + " " + lecteur["prenom"].ToString();
                    membre.EstChef = membre.Matricule == matriculeChef;
                    liste.Items.Add(membre);
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            List<MembreListe> choisis = lstDisponibles.SelectedItems.Cast<MembreListe>().ToList();

            DeplacerMembres(choisis, lstDisponibles, lstEquipage);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            List<MembreListe> choisis = lstEquipage.SelectedItems.Cast<MembreListe>().ToList();

            //le chef reste obligatoirement dans l'équipage
            if (choisis.Any(m => m.EstChef))
            {
                FormSucces.Afficher("Le chef de mission ne peut pas être retiré de l'équipage.", true);
                choisis = choisis.Where(m => !m.EstChef).ToList();
            }

            DeplacerMembres(choisis, lstEquipage, lstDisponibles);
        }

        /// <summary>
        /// Passe des membres d'une liste à l'autre, puis les sélectionne et fait défiler
        /// la liste d'arrivée jusqu'à eux pour qu'on les voie tout de suite
        /// </summary>
        private void DeplacerMembres(List<MembreListe> membres, ListBox depart, ListBox arrivee)
        {
            if (membres.Count == 0)
            {
                return;
            }

            depart.BeginUpdate();
            arrivee.BeginUpdate();

            foreach (MembreListe membre in membres)
            {
                depart.Items.Remove(membre);
                arrivee.Items.Add(membre);
            }

            depart.ClearSelected();
            arrivee.ClearSelected();

            int premierIndex = arrivee.Items.Count;
            foreach (MembreListe membre in membres)
            {
                int index = arrivee.Items.IndexOf(membre);
                arrivee.SetSelected(index, true);
                premierIndex = Math.Min(premierIndex, index);
            }

            depart.EndUpdate();
            arrivee.EndUpdate();

            arrivee.TopIndex = premierIndex;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            List<string> nouvelEquipage = lstEquipage.Items.Cast<MembreListe>().Select(m => m.Matricule).ToList();

            SQLiteTransaction maTransaction = null;

            try
            {
                maTransaction = Connexion.Connec.BeginTransaction();

                //équipage enregistré avant la modification
                List<string> ancienEquipage = new List<string>();
                SQLiteCommand cmdAncien = new SQLiteCommand(
                    "SELECT matriculeMembre FROM Composer WHERE nomPlanete = @planete AND numeroMission = @numero",
                    Connexion.Connec, maTransaction);
                cmdAncien.Parameters.AddWithValue("@planete", nomPlanete);
                cmdAncien.Parameters.AddWithValue("@numero", numeroMission);
                using (SQLiteDataReader lecteur = cmdAncien.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        ancienEquipage.Add(lecteur["matriculeMembre"].ToString());
                    }
                }

                //on revérifie juste avant d'enregistrer que chaque nouveau membre est toujours libre
                SQLiteCommand cmdLibre = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Membre WHERE matricule = @matricule AND " + ConditionLibre("matricule"),
                    Connexion.Connec, maTransaction);
                AjouterParametresMission(cmdLibre);
                cmdLibre.Parameters.AddWithValue("@matricule", "");

                SQLiteCommand cmdAjout = new SQLiteCommand(
                    "INSERT INTO Composer (nomPlanete, numeroMission, matriculeMembre) VALUES (@planete, @numero, @matricule)",
                    Connexion.Connec, maTransaction);
                cmdAjout.Parameters.AddWithValue("@planete", nomPlanete);
                cmdAjout.Parameters.AddWithValue("@numero", numeroMission);
                cmdAjout.Parameters.AddWithValue("@matricule", "");

                foreach (string matricule in nouvelEquipage.Except(ancienEquipage))
                {
                    cmdLibre.Parameters["@matricule"].Value = matricule;
                    if (Convert.ToInt32(cmdLibre.ExecuteScalar()) == 0)
                    {
                        maTransaction.Rollback();
                        FormSucces.Afficher("Le membre " + matricule + " est déjà sur une autre mission à ces dates.", true);
                        ChargerMission();
                        return;
                    }

                    cmdAjout.Parameters["@matricule"].Value = matricule;
                    cmdAjout.ExecuteNonQuery();
                }

                SQLiteCommand cmdRetrait = new SQLiteCommand(
                    "DELETE FROM Composer WHERE nomPlanete = @planete AND numeroMission = @numero AND matriculeMembre = @matricule",
                    Connexion.Connec, maTransaction);
                cmdRetrait.Parameters.AddWithValue("@planete", nomPlanete);
                cmdRetrait.Parameters.AddWithValue("@numero", numeroMission);
                cmdRetrait.Parameters.AddWithValue("@matricule", "");

                foreach (string matricule in ancienEquipage.Except(nouvelEquipage))
                {
                    if (matricule == matriculeChef)
                    {
                        continue;
                    }
                    cmdRetrait.Parameters["@matricule"].Value = matricule;
                    cmdRetrait.ExecuteNonQuery();
                }

                //le nombre de membres de la mission suit la taille de l'équipage
                SQLiteCommand cmdNombre = new SQLiteCommand(
                    @"UPDATE Mission
                    SET nbMembreRequis = (SELECT COUNT(*) FROM Composer WHERE nomPlanete = @planete AND numeroMission = @numero)
                    WHERE nomPlanete = @planete AND numero = @numero",
                    Connexion.Connec, maTransaction);
                cmdNombre.Parameters.AddWithValue("@planete", nomPlanete);
                cmdNombre.Parameters.AddWithValue("@numero", numeroMission);
                cmdNombre.ExecuteNonQuery();

                maTransaction.Commit();
            }
            catch (Exception ex)
            {
                if (maTransaction != null)
                {
                    try { maTransaction.Rollback(); } catch { }
                }
                MessageBox.Show("Erreur lors de l'enregistrement de l'équipage : " + ex.Message);
                return;
            }

            MesDatas.RechargerTables("Composer", "Mission");

            FormSucces.Afficher("L'équipage de la mission a été mis à jour !");

            this.Close();
        }
    }
}

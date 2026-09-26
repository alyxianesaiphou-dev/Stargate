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

        private FlowLayoutPanel flpEquipage;
        private FlowLayoutPanel flpDisponibles;
        private Label lblEquipage;
        private Label lblDisponibles;
        private Label lblResume;

        //cartes cliquées (entourées en rose) en attente d'être ajoutées ou retirées
        private HashSet<CarteMembre> cartesSelectionnees = new HashSet<CarteMembre>();

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
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.DarkSlateBlue;
            this.ForeColor = Color.White;
            this.Font = new Font("Microsoft Sans Serif", 12F);
            this.AutoScaleMode = AutoScaleMode.None;

            //grande fenêtre (3 cartes par ligne de chaque côté), sans dépasser de l'écran
            Rectangle ecran = Screen.PrimaryScreen.WorkingArea;
            int largeur = Math.Min(1640, ecran.Width - 40);
            int hauteur = Math.Min(960, ecran.Height - 60);
            this.ClientSize = new Size(largeur, hauteur);

            int largeurMilieu = 160;
            int largeurPanneau = (largeur - 40 - largeurMilieu) / 2;
            int hauteurPanneau = hauteur - 105 - 70;
            int xDroite = 20 + largeurPanneau + largeurMilieu;

            lblResume = new Label();
            lblResume.AutoSize = false;
            lblResume.Location = new Point(20, 10);
            lblResume.Size = new Size(largeur - 40, 55);

            lblEquipage = new Label();
            lblEquipage.AutoSize = true;
            lblEquipage.Location = new Point(20, 75);

            flpEquipage = CreerTrombinoscope(new Point(20, 105), new Size(largeurPanneau, hauteurPanneau));

            lblDisponibles = new Label();
            lblDisponibles.AutoSize = true;
            lblDisponibles.Location = new Point(xDroite, 75);

            flpDisponibles = CreerTrombinoscope(new Point(xDroite, 105), new Size(largeurPanneau, hauteurPanneau));

            int xBoutons = 20 + largeurPanneau + (largeurMilieu - 130) / 2;
            int yBoutons = 105 + hauteurPanneau / 2;

            Button btnAjouter = CreerBouton("← Ajouter", new Point(xBoutons, yBoutons - 55), Color.DarkViolet);
            btnAjouter.Size = new Size(130, 45);
            btnAjouter.Click += btnAjouter_Click;

            Button btnRetirer = CreerBouton("Retirer →", new Point(xBoutons, yBoutons + 10), Color.MediumPurple);
            btnRetirer.Size = new Size(130, 45);
            btnRetirer.Click += btnRetirer_Click;

            Label lblAide = new Label();
            lblAide.Text = "Cliquez sur les photos pour les sélectionner, puis sur Ajouter ou Retirer.";
            lblAide.AutoSize = true;
            lblAide.Location = new Point(20, hauteur - 50);

            Button btnAnnuler = CreerBouton("Annuler", new Point(largeur - 260, hauteur - 60), Color.MediumPurple);
            btnAnnuler.Click += delegate { this.Close(); };

            Button btnEnregistrer = CreerBouton("Enregistrer", new Point(largeur - 140, hauteur - 60), Color.DarkViolet);
            btnEnregistrer.Size = new Size(120, 41);
            btnEnregistrer.Click += btnEnregistrer_Click;

            this.Controls.Add(lblResume);
            this.Controls.Add(lblEquipage);
            this.Controls.Add(flpEquipage);
            this.Controls.Add(lblDisponibles);
            this.Controls.Add(flpDisponibles);
            this.Controls.Add(btnAjouter);
            this.Controls.Add(btnRetirer);
            this.Controls.Add(lblAide);
            this.Controls.Add(btnAnnuler);
            this.Controls.Add(btnEnregistrer);
        }

        private FlowLayoutPanel CreerTrombinoscope(Point position, Size taille)
        {
            FlowLayoutPanel panneau = new FlowLayoutPanel();
            panneau.Location = position;
            panneau.Size = taille;
            panneau.AutoScroll = true;
            panneau.BackColor = CarteMembre.CouleurTrombinoscope;
            panneau.BorderStyle = BorderStyle.None;
            CarteMembre.CentrerColonnes(panneau);

            return panneau;
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
                RemplirTrombinoscope(flpEquipage, cmdEquipage);

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
                RemplirTrombinoscope(flpDisponibles, cmdDispo);

                MettreAJourTitres();
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

        private void RemplirTrombinoscope(FlowLayoutPanel panneau, SQLiteCommand commande)
        {
            panneau.Controls.Clear();
            cartesSelectionnees.Clear();

            using (SQLiteDataReader lecteur = commande.ExecuteReader())
            {
                while (lecteur.Read())
                {
                    string matricule = lecteur["matricule"].ToString();
                    string nom = lecteur["nom"].ToString() + " " + lecteur["prenom"].ToString();

                    CarteMembre carte = new CarteMembre(matricule, nom, matricule == matriculeChef);
                    carte.Clic += delegate { ClicSurUneCarte(carte); };
                    panneau.Controls.Add(carte);
                }
            }
        }

        //un clic sélectionne la carte (cadre rose), un deuxième clic la désélectionne
        private void ClicSurUneCarte(CarteMembre carte)
        {
            carte.Selectionnee = !carte.Selectionnee;

            if (carte.Selectionnee)
            {
                cartesSelectionnees.Add(carte);
            }
            else
            {
                cartesSelectionnees.Remove(carte);
            }
        }

        private void MettreAJourTitres()
        {
            lblEquipage.Text = "Équipage actuel (" + flpEquipage.Controls.Count + ")";
            lblDisponibles.Text = "Membres disponibles à ces dates (" + flpDisponibles.Controls.Count + ")";
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            DeplacerCartes(flpDisponibles, flpEquipage);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            //le chef reste obligatoirement dans l'équipage
            CarteMembre carteChef = cartesSelectionnees.FirstOrDefault(c => c.Parent == flpEquipage && c.EstChef);
            if (carteChef != null)
            {
                ClicSurUneCarte(carteChef);
                FormSucces.Afficher("Le chef de mission ne peut pas être retiré de l'équipage.", true);

                if (!cartesSelectionnees.Any(c => c.Parent == flpEquipage))
                {
                    return;
                }
            }

            DeplacerCartes(flpEquipage, flpDisponibles);
        }

        /// <summary>
        /// Passe les cartes sélectionnées d'un trombinoscope à l'autre, garde l'ordre alphabétique
        /// et fait défiler jusqu'à la première carte déplacée pour qu'on la voie tout de suite
        /// </summary>
        private void DeplacerCartes(FlowLayoutPanel depart, FlowLayoutPanel arrivee)
        {
            List<CarteMembre> cartes = cartesSelectionnees.Where(c => c.Parent == depart).ToList();

            if (cartes.Count == 0)
            {
                FormSucces.Afficher("Cliquez d'abord sur une ou plusieurs photos.", true);
                return;
            }

            depart.SuspendLayout();
            arrivee.SuspendLayout();

            foreach (CarteMembre carte in cartes)
            {
                depart.Controls.Remove(carte);
                arrivee.Controls.Add(carte);
                carte.Selectionnee = false;
                cartesSelectionnees.Remove(carte);
            }

            //remet les cartes dans l'ordre des noms
            List<CarteMembre> triees = arrivee.Controls.Cast<CarteMembre>().OrderBy(c => c.Nom).ToList();
            for (int i = 0; i < triees.Count; i++)
            {
                arrivee.Controls.SetChildIndex(triees[i], i);
            }

            depart.ResumeLayout();
            arrivee.ResumeLayout();

            MettreAJourTitres();

            CarteMembre premiere = triees.First(c => cartes.Contains(c));
            arrivee.ScrollControlIntoView(premiere);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            List<string> nouvelEquipage = flpEquipage.Controls.Cast<CarteMembre>().Select(c => c.Matricule).ToList();

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

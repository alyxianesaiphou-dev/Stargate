using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    public static class Statistiques
    {
        public static DataTable ObtenirMembreMemeMission(string matricul)
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            String requete = @"SELECT ci.matriculeMembre, mi.matriculeMembre, me.nom, me.prenom,ci.Specialite, mi.grade
                            FROM Membre me JOIN Composer co 
                            ON me.matricule = co.matriculeMembre
                            LEFT JOIN Civil ci 
                            ON me.matricule = ci.matriculeMembre
                            LEFT JOIN Militaire mi 
                            ON me.matricule = mi.matriculeMembre
                            WHERE EXISTS (
                                SELECT 1
                                FROM Composer c2
                                WHERE c2.matriculeMembre = '" + matricul.ToString() + "'AND c2.numeroMission = co.numeroMission AND c2.nomPlanete = co.nomPlanete )" +
                                "AND me.matricule != '" + matricul.ToString() + "' ORDER BY me.nom";


            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;

        }

        public static DataTable ObtenirMembreMemeMissionStatut(string matricul)
        {
            DataTable dt = ObtenirMembreMemeMission(matricul);
            DataTable dtResultat = new DataTable();
            dtResultat.Columns.Add("matricule", typeof(String));
            dtResultat.Columns.Add("type", typeof(String));
            dtResultat.Columns.Add("nom", typeof(String));
            dtResultat.Columns.Add("prenom", typeof(String));
            dtResultat.Columns.Add("spécialité", typeof(String));
            dtResultat.Columns.Add("grade", typeof(String));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string matricule = "";
                if (dt.Rows[i][0].ToString() == "")
                {
                    matricule = dt.Rows[i][1].ToString();
                }
                else
                {
                    matricule = dt.Rows[i][0].ToString();
                }
                string nom = dt.Rows[i][2].ToString();
                string prenom = dt.Rows[i][3].ToString();
                string statut = "";
                if (dt.Rows[i][4].ToString() == "")
                {
                    statut = "Militaire";
                }
                else
                {
                    statut = "Civil";
                }
                string specialite = "";
                string grade = "";
                if (dt.Rows[i][4].ToString() != "")
                {
                    specialite = dt.Rows[i][4].ToString();
                }
                if (dt.Rows[i][5].ToString() != "")
                {
                    grade = dt.Rows[i][5].ToString();
                }

                DataRow ligne = dtResultat.NewRow();
                ligne[0] = matricule;
                ligne[1] = statut;
                ligne[2] = nom;
                ligne[3] = prenom;
                ligne[4] = specialite;
                ligne[5] = grade;
                dtResultat.Rows.Add(ligne);
            }

            return dtResultat;
        }
        public static DataTable MissionPlusDixMembre()
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT d.motif, d.montant, t.libelle, mi.budget AS BudgetDep,
                                (mi.budget - (SELECT SUM(montant) FROM Depense WHERE numeroMission = mi.numero AND nomPlanete = mi.nomPlanete)) AS BudgetAct
                                FROM Mission mi JOIN Depense d 
                                ON d.numeroMission = mi.numero AND d.nomPlanete = mi.nomPlanete
							    JOIN TypeDepense t
							    ON d.idTypeDepense = t.id
                                WHERE nbMembreRequis > 10;";
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }

        public static DataTable NbMissionSurPlanet()
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT p.nom, Count(m.numero) AS NombreMission
                             FROM Planete p LEFT JOIN Mission m 
                             ON p.nom = m.nomPlanete
                             GROUP BY p.nom";

            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }

        public static DataTable DepensePlusElever()
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT (d.dateD || ' - '|| d.motif || ' - ' || d.montant || '€') AS 'Dépenses les plus importantes'
	                         , mi.nomPlanete as NomMission , me.nom, me.prenom
                             FROM Depense d JOIN Mission mi 
                             ON d.numeroMission = mi.numero AND d.nomPlanete = mi.nomPlanete
                             JOIN Membre me 
                             ON me.matricule = mi.matriculeChef
                             WHERE d.montant = (SELECT MAX(montant) 
		                                        FROM Depense d2
		                                        WHERE d2.numeroMission = mi.numero AND d2.nomPlanete = mi.nomPlanete)
                            ";

            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }

        public static DataTable InformateurMoinsCher(string numeroMiss, string planete)
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT i.nomCode, i.nom, i.idEspeceEnnemi, e.nom, SUM(c.sommeVersee) AS SommeTotale
                                FROM Contact c JOIN Informateur i
                                ON i.nomCode = c.nomCodeInformateur
                                JOIN Espece e
								ON i.idEspeceEnnemi=e.id
                                WHERE c.numeroMission = " + numeroMiss.ToString() + @" AND LOWER(c.nomPlanete) = '" + planete.ToLower() + @"'
                                GROUP BY i.nomCode, i.idEspeceEnnemi
                                ORDER BY SommeTotale ASC
                                LIMIT 1;";
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }



        // REQUETE PAS DEMANDER 

        public static DataTable InformationMission(int numMission, string planete)
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT mi.*, m.nom, m.prenom
                                FROM Mission mi JOIN Membre m
                                ON m.matricule = mi.matriculeChef
                                WHERE mi.numero = " + numMission.ToString() + " AND mi.nomPlanete = '" + planete + "'";
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }

        public static DataTable MembreMissionPrecise(int numMission, string planete)
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT m.nom, m.prenom
                                FROM Composer c JOIN Membre m
                                ON m.matricule = c.matriculeMembre
                                WHERE c.numeroMission = " + numMission.ToString() + " AND c.nomPlanete = '" + planete + "'";
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }

        public static DataTable JournalDeBord(int numMission, string planete)
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT dateJ, commentaires
                                FROM JournalDeBord  
                                WHERE numero = " + numMission.ToString() + " AND nomPlanete = '" + planete + "'";
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }

        public static DataTable Depense(int numMission, string planete)
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT d.dateD, d.montant, d.motif
                                FROM Depense d 
                                WHERE d.numeroMission = " + numMission.ToString() + " AND d.nomPlanete = '" + planete + "'";
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }


        public static DataTable Informateur(int numMission, string planete)
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;



            string requete = @"SELECT c.dateC, c.sommeVersee, c.appreciation, i.nom, i.commentaires, e.nom
                                FROM Contact c JOIN Informateur i
                                ON c.nomCodeInformateur = i.nomCode
                                JOIN Espece e ON e.id = i.idEspeceEnnemi
                                WHERE c.numeroMission = " + numMission.ToString() + " AND c.nomPlanete = '" + planete + "'";
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }


        public static DataTable ObjectifCapture(int numMission, string planete)
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT o.objectif, e.nom
                                FROM ObjectifCapture o JOIN Espece e
                                ON o.idEspeceEnnemi = e.id
                                WHERE o.numeroMission = " + numMission.ToString() + " AND o.nomPlanete = '" + planete + "'";
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }

        public static DataTable NégociationMission(int numMission, string planete)
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            string requete = @"SELECT n.qteDataBaz, a.instrumentMusique, e.nom 
                        FROM Negocier n
                        JOIN Allie a ON n.idEspeceAllie = a.idEspece
                        JOIN Espece e ON a.idEspece = e.id
                        WHERE n.numeroMission = " + numMission.ToString() + " AND n.nomPlanete = '" + planete + "'";
            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;
        }

        public static DataTable ObtenirMembreNomPrenom()
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            String requete = @"SELECT matricule, [prenom]|| ' ' || [nom] as NomPrenom FROM Membre ORDER BY NomPrenom";

            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;

        }

        public static DataTable ObtenirNomMission()
        {
            DataTable dt = new DataTable();
            SQLiteCommand maCommand = null;

            String requete = @"SELECT [nomPlanete] || [numero] as mission,[nomPlanete],[numero] FROM Mission ORDER BY mission";

            try
            {
                SQLiteConnection maConnexion = Connexion.Connec;
                maCommand = new SQLiteCommand(requete, maConnexion);
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = maCommand;
                da.Fill(dt);

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erreur d'accès à la base");
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Erreur de table");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Erreur de cast");
            }
            catch (Exception monErreur)
            {
                MessageBox.Show(monErreur.GetType().ToString());
            }
            return dt;

        }


    }
}

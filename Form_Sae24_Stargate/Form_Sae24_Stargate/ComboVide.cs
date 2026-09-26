using System;
using System.Data;
using System.Windows.Forms;

namespace Form_Sae24_Stargate
{
    // Outils pour que chaque liste déroulante ait un choix vide en premier
    // et commence sur ce choix vide
    internal static class ComboVide
    {
        /// <summary>
        /// Remplit la liste à partir d'une table en ajoutant une ligne vide en premier,
        /// puis sélectionne cette ligne vide
        /// </summary>
        public static void Remplir(ComboBox cbo, DataTable dt, string affichage, string valeur)
        {
            //Copie de la structure sans contraintes pour pouvoir ajouter une ligne vide
            DataTable dtAvecVide = dt.Clone();
            dtAvecVide.PrimaryKey = null;
            dtAvecVide.Constraints.Clear();
            foreach (DataColumn col in dtAvecVide.Columns)
            {
                col.AllowDBNull = true;
                col.ReadOnly = false;
                col.AutoIncrement = false;
            }

            dtAvecVide.Rows.Add(dtAvecVide.NewRow());
            foreach (DataRow dr in dt.Rows)
            {
                dtAvecVide.ImportRow(dr);
            }

            cbo.DataSource = null;
            cbo.DisplayMember = affichage;
            cbo.ValueMember = valeur;
            cbo.DataSource = dtAvecVide;
            cbo.SelectedIndex = 0;
        }

        /// <summary>
        /// Ajoute le choix vide dans une liste remplie à la main (si pas déjà là)
        /// </summary>
        public static void AjouterChoixVide(ComboBox cbo)
        {
            if (!cbo.Items.Contains(string.Empty))
            {
                cbo.Items.Insert(0, string.Empty);
            }
        }

        /// <summary>
        /// Remet la liste sur le choix vide
        /// </summary>
        public static void Vider(ComboBox cbo)
        {
            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
            else
            {
                cbo.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Vrai si rien n'est choisi (choix vide ou aucune sélection)
        /// </summary>
        public static bool EstVide(ComboBox cbo)
        {
            return cbo.SelectedValue == null || cbo.SelectedValue is DBNull
                || cbo.SelectedValue is DataRowView || cbo.SelectedIndex <= 0;
        }
    }
}

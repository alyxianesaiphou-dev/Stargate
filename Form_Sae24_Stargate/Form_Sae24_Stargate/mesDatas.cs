using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Form_Sae24_Stargate
{
    public class MesDatas
    {
        private static DataSet dsGlobal = new DataSet();
     
        public static DataSet DsGlobal { get {  return MesDatas.dsGlobal; } }

        /// <summary>
        /// Recharge depuis la base les tables indiquées, pour que le DataSet reste à jour après un ajout
        /// </summary>
        public static void RechargerTables(params string[] nomsTables)
        {
            foreach (string nomTable in nomsTables)
            {
                if (dsGlobal.Tables.Contains(nomTable))
                {
                    dsGlobal.Tables[nomTable].Clear();

                    using (SQLiteCommand cd = new SQLiteCommand("SELECT * FROM " + nomTable, Connexion.Connec))
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cd))
                    {
                        da.Fill(dsGlobal, nomTable);
                    }
                }
            }
        }

    }
}

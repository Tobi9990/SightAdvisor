using Stadtplanverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Stadtplanverwaltung.Controller
{  
    public class AdminManager
    {
        private static DatabaseConnection dc = new DatabaseConnection("OraOLEDB.Oracle", "aphrodite4/ora11g", "d5a04", "d5a");

        private static string sql = null;
        private static OleDbDataAdapter oledbAdapter;
        private static DataSet ds = new DataSet();
        private static DataTable dt = new DataTable();

        public static void CheckAdminLogin(string password)
        {
            sql = "Select * from stadtplanadmin where pPassword = '" + password + "'";

            oledbAdapter = new OleDbDataAdapter(sql, dc.GetConnectionString());
            oledbAdapter.Fill(ds, "stadtplanadmin");
            dt = ds.Tables["stadtplanadmin"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["pPassword"].ToString() == password)
                {
                    AdminStadtplanverwaltung adminS = new AdminStadtplanverwaltung();
                    adminS.Show();
                    i = dt.Rows.Count;
                    Console.WriteLine("Successfully logged into the Database");
                }

                if (dt.Rows[i]["pPassword"].ToString() != password)
                {
                    Console.WriteLine("Could not connect into the Database");
                }
            }
        }
    }
}

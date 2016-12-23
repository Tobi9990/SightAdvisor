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
    public class StadplanverwaltungManager
    {
        private static DatabaseConnection dc = new DatabaseConnection("OraOLEDB.Oracle", "aphrodite4/ora11g","d5a04","d5a");

        private static string sql = null;
        private static OleDbDataAdapter oledbAdapter;
        private static DataSet ds = new DataSet();
        private static DataTable dt = new DataTable();
        private static PointCollection pc = null;

        private static int aid = 1;
        private static string message;

        public static void GetSehenswuerdigkeiten(DataGrid grid)
        {
            sql = "Select swid, swname, beschreibung, aid from sehenswuerdigkeit";

            oledbAdapter = new OleDbDataAdapter(sql, dc.GetConnectionString());
            ds.Clear();
            oledbAdapter.Fill(ds);
            oledbAdapter.Dispose();

            for (int i = 0; i < ds.Tables[0].Rows.Count-1; i++)
            {
                grid.ItemsSource = ds.Tables[0].DefaultView;
            }

            Console.WriteLine("Sehenswuerdigkeiten loaded!");
        }

        public static void DrawStrassenabschnitte(Canvas myCanvas)
        {
            sql = "SELECT t.aid, ts.X, ts.Y, ts.id FROM strassenabschnittT t, TABLE(SDO_UTIL.GETVERTICES(t.objekt)) ts";
            oledbAdapter = new OleDbDataAdapter(sql, dc.GetConnectionString());
            oledbAdapter.Fill(ds, "strassenabschnittT");
            dt = ds.Tables["strassenabschnittT"];

            pc = new PointCollection();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                pc.Add(new Point(Convert.ToInt16(dt.Rows[i]["X"].ToString()), Convert.ToInt16(dt.Rows[i]["Y"].ToString())));
            }

            Polygon pAbschnitt = new Polygon();
            pAbschnitt.Stroke = Brushes.White;
            pAbschnitt.Fill = Brushes.Gray;
            pAbschnitt.StrokeThickness = 5;
            pAbschnitt.Points = pc;

            Polygon[] polygons = polygons = new Polygon[] { pAbschnitt };

            for (int i = 0; i < polygons.Length; i++)
            {
                myCanvas.Children.Add(polygons[i]);
            }


            Console.WriteLine("Strassenabschnitte wurden gezeichnet!");
        }

        public static void DrawSehenswuerdigkeiten(Canvas myCanvas)
        {
            sql = "SELECT t.swid, ts.X, ts.Y, ts.id FROM sehenswuerdigkeit t, TABLE(SDO_UTIL.GETVERTICES(t.objekt)) ts";
            oledbAdapter = new OleDbDataAdapter(sql, dc.GetConnectionString());
            oledbAdapter.Fill(ds, "sehenswuerdigkeit");
            dt = ds.Tables["sehenswuerdigkeit"];

            pc = new PointCollection();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                pc.Add(new Point(Convert.ToInt16(dt.Rows[i]["X"].ToString()), Convert.ToInt16(dt.Rows[i]["Y"].ToString())));
            }

            Polygon pAbschnitt = new Polygon();
            pAbschnitt.Stroke = Brushes.White;
            pAbschnitt.Fill = Brushes.Gray;
            pAbschnitt.StrokeThickness = 5;
            pAbschnitt.Points = pc;

            Polygon[] polygons = polygons = new Polygon[] { pAbschnitt };

            for (int i = 0; i < polygons.Length; i++)
            {
                myCanvas.Children.Add(polygons[i]);
            }


            Console.WriteLine("Sehenswuerdigkeiten wurden gezeichnet!");
        }

        public static async void AddSehenswuerdigkeit(string name, string info, double coordinateX, double coordinateY)
        {
            sql = "begin addSehenswuerdigkeit('" + name + "', '" + info + "', " + coordinateX + "," + coordinateY + "," + aid + "); end;";

            oledbAdapter = new OleDbDataAdapter(sql, dc.GetConnectionString());
            ds.Clear();
            oledbAdapter.Fill(ds);
            await Task.Delay(1000);
            oledbAdapter.Dispose();
           
            
            Console.WriteLine("Sehenswuerdigkeit " + name + " added");
        }

        public static void ChangeSehenswurdigkeit(int swid, string description)
        {
            sql = "Update sehenswuerdigkeit s set s.beschreibung = '" + description + "' where s.swid = " + swid + "";

            oledbAdapter = new OleDbDataAdapter(sql, dc.GetConnectionString());
            ds.Clear();
            oledbAdapter.Fill(ds);
            oledbAdapter.Dispose();
            Console.WriteLine("Sehenswuerdigkeit updated");
        }

        public static void DeleteSehenswurdigkeit(int swid)
        {
            sql = "Delete from sehenswuerdigkeit s where s.swid = " + swid;

            oledbAdapter = new OleDbDataAdapter(sql, dc.GetConnectionString());
            ds.Clear();
            oledbAdapter.Fill(ds);
            oledbAdapter.Dispose();
            Console.WriteLine("Sehenswuerdigkeit deleted");
        }

        public static void setMessage(string msg)
        {
            message = msg;
        }

        public static string getMessage()
        {
            return message;
        }
    }
}

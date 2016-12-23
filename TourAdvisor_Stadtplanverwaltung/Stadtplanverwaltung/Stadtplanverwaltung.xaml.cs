using Stadtplanverwaltung.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stadtplanverwaltung
{
    /// <summary>
    /// Interaction logic for Stadtplanverwaltung.xaml
    /// </summary>
    public partial class AdminStadtplanverwaltung : Window
    {
        private DialogBox box;
        private int swid;
        private string swName;
        private string description;

        public AdminStadtplanverwaltung()
        {
            InitializeComponent();

            try
            {
                StadplanverwaltungManager.GetSehenswuerdigkeiten(dataGridPoi);
                //StadplanverwaltungManager.GetStrassenabschnitte(canvasMap);
                //StadplanverwaltungManager.DrawSehenswuerdigkeiten(canvasMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured: " + ex.Message);
            }  
        }

        private async void canvasMap_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                box = new DialogBox();
                box.setCoordinateX(Mouse.GetPosition(canvasMap).X);
                box.setCoordinateY(Mouse.GetPosition(canvasMap).Y);
                box.Show();

                while (box.IsVisible)
                {
                    await Task.Delay(500);
                }

                StadplanverwaltungManager.GetSehenswuerdigkeiten(dataGridPoi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured: " + ex.Message);
            }      
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)dataGridPoi.SelectedItem;
                swid =  Convert.ToInt32(dataRow.Row.ItemArray[1]);
                swName = dataRow.Row.ItemArray[2].ToString();
                description = dataRow.Row.ItemArray[3].ToString();

                box = new DialogBox();
                box.UpdateDescription(swid, swName, description);
                box.Show();

                while(box.IsVisible) {
                    await Task.Delay(500);
                }

                StadplanverwaltungManager.GetSehenswuerdigkeiten(dataGridPoi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured: " + ex.Message);
            }   
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)dataGridPoi.SelectedItem;
                swid = Convert.ToInt32(dataRow.Row.ItemArray[0]);

                StadplanverwaltungManager.DeleteSehenswurdigkeit(swid);

                while (box.IsVisible)
                {
                    await Task.Delay(500);
                }

                StadplanverwaltungManager.GetSehenswuerdigkeiten(dataGridPoi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured: " + ex.Message);
            }   
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Welcome to the city map administration\n "
                           + "You can do the following things:\n "
                           + "1. Adding a point of interest by clicking on the map and add a description and name to it\n"
                           + "2. Selecting an existing point of interest from the Data Grid and changing the description\n"
                           + "3. Deleting an existing point of interest from the Data Grid\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured: " + ex.Message);
            }  
        }
    }
}

using Stadtplanverwaltung.Controller;
using System;
using System.Collections.Generic;
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
        private string info;
        private double coordinateX;
        private double coordinateY;

        public AdminStadtplanverwaltung()
        {
            InitializeComponent();

            StadplanverwaltungManager.DrawStrassenabschnitte(canvasMap);
            //StadplanverwaltungManager.DrawSehenswuerdigkeiten(canvasMap);
        }

        private void setInfo(string inf)
        {
            this.info = inf;
        }

        private void setCoordinateX(double x)
        {
            this.coordinateX = x;
        }

        private void setCoordinateY(double y)
        {
            this.coordinateY = y;
        }

        private async void canvasMap_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            box = new DialogBox();
            box.Show();

            while (box.IsVisible)
            {
                await Task.Delay(1000);
            }

            setInfo(box.getInfo());
            setCoordinateX(Mouse.GetPosition(canvasMap).X);
            setCoordinateY(Mouse.GetPosition(canvasMap).Y);
            btnSave.IsEnabled = true;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StadplanverwaltungManager.AddSehenswuerdigkeit(txtBoxName.Text, coordinateX, coordinateY, info);
            await Task.Delay(1000);
        }
    }
}

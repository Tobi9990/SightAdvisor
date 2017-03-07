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
using System.Windows.Shapes;

namespace Stadtplanverwaltung
{
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        private int swid;
        private string description;
        private string poiName;
        private double coordinateX;
        private double coordinateY;

        public DialogBox()
        {
            InitializeComponent();
        }

        private void setSwid(int swid)
        {
            this.swid = swid;
        }

        public int getSwid()
        {
            return swid;
        }

        private void setDescription(string description)
        {
            this.description = description;
        }

        public string getDescription() 
        {
            return description;
        }

        private void setPoiName(string poiName)
        {
            this.poiName = poiName;
        }

        public string getPoiName()
        {
            return poiName;
        }

        public void setCoordinateX(double x)
        {
            this.coordinateX = x;
        }

        public void setCoordinateY(double y)
        {
            this.coordinateY = y;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            setDescription(txtBoxInfo.Text);
            setPoiName(txtBoxPoiName.Text);
            StadplanverwaltungManager.AddSehenswuerdigkeit(poiName, description, coordinateX, coordinateY);
            this.Close();
        }

        public void UpdateDescription(int swid, string swName, string description)
        {
            txtBoxPoiName.Text = swName;
            txtBoxPoiName.IsEnabled = false;

            txtBoxInfo.Text = description;

            setSwid(swid);
            setDescription(txtBoxInfo.Text);
            setPoiName(txtBoxPoiName.Text);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            StadplanverwaltungManager.ChangeSehenswurdigkeit(swid, description);
        }
    }
}

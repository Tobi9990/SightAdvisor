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
        private string info;

        public DialogBox()
        {
            InitializeComponent();
        }

        public void setInfo(string inf)
        {
            this.info = inf;
        }

        public string getInfo() 
        {
            return info;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            setInfo(txtBoxInfo.Text);
            this.Close();
        }
    }
}

using Dem.Window;
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

namespace Dem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Client_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.Show();
            this.Close();
        }

        private void button_Realtor_Click(object sender, RoutedEventArgs e)
        {
            RealtorWindow realtorWindow = new RealtorWindow();
            realtorWindow.Show();
            this.Close();
        }

        private void button_RealProperties_Click(object sender, RoutedEventArgs e)
        {
            RealPropertiesWindow realPropertiesWindow = new RealPropertiesWindow();
            realPropertiesWindow.Show();
            this.Close();
        }
    }
}

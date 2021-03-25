using Dem.Model;
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

namespace Dem.Window
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow 
    {
        DemEntities demEntities = new DemEntities();
        public ClientWindow()
        {
            InitializeComponent();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = demEntities.Client.ToList();
        }

        private void button_Add_Client_Click(object sender, RoutedEventArgs e)
        {
            EditClientWindow editClientWindow = new EditClientWindow();
            editClientWindow.Show();
        }

        private void button_Update_Click(object sender, RoutedEventArgs e)
        {
            demEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dataGrid.ItemsSource = demEntities.Client.ToList();
        }

        private void button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItems.Count > 0)
            {
                Client client = (Client)dataGrid.SelectedItems[0];
                EditClientWindow editClientWindow = new EditClientWindow(client);
                editClientWindow.Show();
            }
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                Client client = (Client)dataGrid.SelectedItems[0];
                if (MessageBox.Show("Удалить?", "Внимание",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                {
                    try
                    {
                        demEntities.Client.Remove(client);
                        demEntities.SaveChanges();
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            var client = demEntities.Client.Where(cl => cl.Name.ToLower().Contains(textBoxSearch.Text.ToLower())).ToList();
            dataGrid.ItemsSource = client.ToList();
        }
    }
}

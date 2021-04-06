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
    /// Логика взаимодействия для NeedWindow.xaml
    /// </summary>
    public partial class NeedWindow
    {
        DemEntities demEntities = new DemEntities();
        public NeedWindow()
        {
            InitializeComponent();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = demEntities.Need.ToList();
        }

        private void button_Add_Need_Click(object sender, RoutedEventArgs e)
        {
            EditNeedWindow editNeedWindow = new EditNeedWindow();
            editNeedWindow.Show();
        }

        private void button_Edit_Need_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItems.Count > 0)
            {
                Need need = (Need)dataGrid.SelectedItems[0];
                EditNeedWindow editNeedWindow = new EditNeedWindow(need);
                editNeedWindow.Show();
            }
        }

        private void button_Delete_Need_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                Need need = (Need)dataGrid.SelectedItems[0];
                try
                {
                    if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        demEntities.Need.Remove(need);
                        demEntities.SaveChanges();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void button_Update_Need_Click(object sender, RoutedEventArgs e)
        {
            demEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dataGrid.ItemsSource = demEntities.Need.ToList();
        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

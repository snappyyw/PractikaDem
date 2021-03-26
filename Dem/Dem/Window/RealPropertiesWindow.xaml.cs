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
    /// Логика взаимодействия для RealPropertiesWindow.xaml
    /// </summary>
    public partial class RealPropertiesWindow
    {
        DemEntities demEntities = new DemEntities();
        List<string> list = new List<string>() { "Дом", "Земля", "Квартира" };
        public RealPropertiesWindow()
        {
            InitializeComponent();
            dataGrid.AutoGenerateColumns = false;
            comboBox.ItemsSource = list;
            dataGrid.ItemsSource = demEntities.RealProperties.ToList();
        }

        private void button_Add_RealProperties_Click(object sender, RoutedEventArgs e)
        {
            EditRealPropertiesWindow editRealPropertiesWindow = new EditRealPropertiesWindow();
            editRealPropertiesWindow.Show();
        }

        private void button_Edit_RealProperties_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                RealProperties realProperties = (RealProperties)dataGrid.SelectedItems[0];
                EditRealPropertiesWindow editRealPropertiesWindow = new EditRealPropertiesWindow(realProperties);
                editRealPropertiesWindow.Show();
            }
        }

        private void button_Delete_RealProperties_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                RealProperties realProperties = (RealProperties)dataGrid.SelectedItems[0];
                try
                {
                    if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        demEntities.RealProperties.Remove(realProperties);
                        demEntities.SaveChanges();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void button_Update_RealProperties_Click(object sender, RoutedEventArgs e)
        {
            demEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dataGrid.ItemsSource = demEntities.RealProperties.ToList();
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
            var realProperties = demEntities.RealProperties.Where(cl => cl.Street.ToLower().Contains(textBoxSearch.Text.ToLower())).ToList();
            dataGrid.ItemsSource = realProperties.ToList();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = comboBox.SelectedItem.ToString();
            var realProperties = demEntities.RealProperties.Where(cl => cl.Type.ToLower().Contains(filter.ToLower())).ToList();
            dataGrid.ItemsSource = realProperties.ToList();
        }
    }
}

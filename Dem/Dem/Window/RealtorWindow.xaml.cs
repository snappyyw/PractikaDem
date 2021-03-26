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
    /// Логика взаимодействия для RealtorWindow.xaml
    /// </summary>
    public partial class RealtorWindow 
    {
        DemEntities demEntities = new DemEntities(); 
        public RealtorWindow()
        {
            InitializeComponent();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = demEntities.Realtor.ToList();
        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void button_Add_Realtor_Click(object sender, RoutedEventArgs e)
        {
            EditRealtorWindow editRealtorWindow = new EditRealtorWindow();
            editRealtorWindow.Show();
        }

        private void button_Edit_Realtor_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItems.Count > 0)
            {
                Realtor realtor = (Realtor)dataGrid.SelectedItems[0];
                EditRealtorWindow editRealtorWindow = new EditRealtorWindow(realtor);
                editRealtorWindow.Show();
            }
        }

        private void button_Delete_Realtor_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                Realtor realtor = (Realtor)dataGrid.SelectedItems[0];
                try
                {
                    if(MessageBox.Show("Удалить?","Внимание",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        demEntities.Realtor.Remove(realtor);
                        demEntities.SaveChanges();
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void button_Update_Realtor_Click(object sender, RoutedEventArgs e)
        {
            demEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dataGrid.ItemsSource = demEntities.Realtor.ToList();
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            var realtors = demEntities.Realtor.Where(cl => cl.Name.ToLower().Contains(textBoxSearch.Text.ToLower())).ToList();
            dataGrid.ItemsSource = realtors.ToList();
        }
    }
}

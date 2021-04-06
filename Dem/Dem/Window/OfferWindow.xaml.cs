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
    /// Логика взаимодействия для OfferWindow.xaml
    /// </summary>
    public partial class OfferWindow
    {
        DemEntities demEntities = new DemEntities();
        public OfferWindow()
        {
            InitializeComponent();
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = demEntities.Offer.ToList();
        }

        private void button_Add_Offer_Click(object sender, RoutedEventArgs e)
        {
            EditOfferWindow editOfferWindow = new EditOfferWindow();
            editOfferWindow.Show();
        }

        private void button_Edit_Offer_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                Offer offer = (Offer)dataGrid.SelectedItems[0];
                EditOfferWindow editOfferWindow = new EditOfferWindow(offer);
                editOfferWindow.Show();
            }
        }

        private void button_Delete_Offer_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                Offer offer = (Offer)dataGrid.SelectedItems[0];
                try
                {
                    if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        demEntities.Offer.Remove(offer);
                        demEntities.SaveChanges();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void button_Update_Offer_Click(object sender, RoutedEventArgs e)
        {
            demEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dataGrid.ItemsSource = demEntities.Offer.ToList();
        }
    }
}

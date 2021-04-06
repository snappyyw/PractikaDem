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
    /// Логика взаимодействия для EditOfferWindow.xaml
    /// </summary>
    public partial class EditOfferWindow
    {
        DemEntities demEntities = new DemEntities();
        Offer _offer = new Offer();
        public EditOfferWindow()
        {
            InitializeComponent();
            comboBoxClient.ItemsSource = demEntities.Client.Select(cl => cl.Surname).ToList();
            comboBoxRealtor.ItemsSource = demEntities.Realtor.Select(rl => rl.Surname).ToList();
            comboBoxRealProperties.ItemsSource = demEntities.RealProperties.Select(rp => rp.id).ToList();
            comboBoxClient.SelectedIndex = 0;
            comboBoxRealtor.SelectedIndex = 0;
            comboBoxRealProperties.SelectedIndex = 0;
        }
        public EditOfferWindow(Offer offer)
        {
            InitializeComponent();
            comboBoxClient.ItemsSource = demEntities.Client.Select(cl => cl.Surname).ToList();
            comboBoxRealtor.ItemsSource = demEntities.Realtor.Select(rl => rl.Surname).ToList();
            comboBoxRealProperties.ItemsSource = demEntities.RealProperties.Select(rp => rp.id).ToList();
            comboBoxClient.SelectedIndex = 0;
            comboBoxRealtor.SelectedIndex = 0;
            comboBoxRealProperties.SelectedIndex = 0;
            textBoxPrice.Text = offer.Price.ToString();
            _offer.id = offer.id;
        }

        private void button_Save_Offer_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                try
                {
                    if (_offer.id == 0)
                    {
                        var cl = demEntities.Client.FirstOrDefault(c => c.Surname == comboBoxClient.SelectedItem.ToString());
                        _offer.idClient = cl.id;
                        var rl = demEntities.Realtor.FirstOrDefault(r => r.Surname == comboBoxRealtor.SelectedItem.ToString());
                        _offer.idRealtor = rl.id;
                        _offer.idRealProperties = int.Parse(comboBoxRealProperties.SelectedItem.ToString());
                        _offer.Price = int.Parse(textBoxPrice.Text);
                        demEntities.Offer.Add(_offer);
                        MessageBox.Show("Предложение добавлено");
                    }
                    else
                    {
                        Offer tempOffer = demEntities.Offer.FirstOrDefault(of => of.id == _offer.id);
                        var cl = demEntities.Client.FirstOrDefault(c => c.Surname == comboBoxClient.SelectedItem.ToString());
                        tempOffer.idClient = cl.id;
                        var rl = demEntities.Realtor.FirstOrDefault(r => r.Surname == comboBoxRealtor.SelectedItem.ToString());
                        tempOffer.idRealtor = rl.id;
                        tempOffer.idRealProperties = int.Parse(comboBoxRealProperties.SelectedItem.ToString());
                        tempOffer.Price = int.Parse(textBoxPrice.Text);
                        MessageBox.Show("Предложение изменено");
                    }
                    demEntities.SaveChanges();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }
        private bool Check()
        {
            StringBuilder error = new StringBuilder();
            if (textBoxPrice.Text == "")
            {
                error.AppendLine("Введите цену");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

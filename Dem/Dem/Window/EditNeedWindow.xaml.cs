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
    /// Логика взаимодействия для EditNeedWindow.xaml
    /// </summary>
    public partial class EditNeedWindow
    {
        DemEntities demEntities = new DemEntities();
        Need _need = new Need();
        List<string> list = new List<string>() { "Дом", "Земля", "Квартира" };
        public EditNeedWindow()
        {
            InitializeComponent();
            comboBoxClient.ItemsSource = demEntities.Client.Select(cl => cl.Surname).ToList();
            comboBoxRealtor.ItemsSource = demEntities.Realtor.Select(rl => rl.Surname).ToList();
            comboBoxClient.SelectedIndex = 0;
            comboBoxRealtor.SelectedIndex = 0;
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
        }
        public EditNeedWindow(Need need)
        {
            InitializeComponent();
            comboBoxClient.ItemsSource = demEntities.Client.Select(cl => cl.Surname).ToList();
            comboBoxRealtor.ItemsSource = demEntities.Realtor.Select(rl => rl.Surname).ToList();
            comboBoxClient.SelectedIndex = 0;
            comboBoxRealtor.SelectedIndex = 0;
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
            textBoxAddress.Text = need.Address;
            textBoxMaxNumberOfFloors.Text = need.MaxNumberOfFloors.ToString();
            textBoxMaxNumberOfRooms.Text = need.MaxNumberOfRooms.ToString();
            textBoxMaxPrice.Text = need.MaxPrice.ToString();
            textBoxMaxSquare.Text = need.MaxSquare;
            textBoxMinNumberOfFloors.Text = need.MinNumberOfFloors.ToString();
            textBoxMinNumberOfRooms.Text = need.MinNumberOfRooms.ToString();
            textBoxMinPrice.Text = need.MinPrice.ToString();
            textBoxMinSquare.Text = need.MinSquare;

            _need.id = need.id;
        }

        private void button_Save_Need_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_need.id == 0)
                {
                    _need.Address = textBoxAddress.Text;
                    var cl = demEntities.Client.FirstOrDefault(c => c.Surname == comboBoxClient.SelectedItem.ToString());
                    _need.idClient = cl.id;
                    var rl = demEntities.Realtor.FirstOrDefault(r => r.Surname == comboBoxRealtor.SelectedItem.ToString());
                    _need.idRealtor = rl.id;
                    _need.MaxNumberOfFloors = int.Parse(textBoxMaxNumberOfFloors.Text);
                    _need.MaxNumberOfRooms = int.Parse(textBoxMaxNumberOfRooms.Text);
                    _need.MaxPrice = int.Parse(textBoxMaxPrice.Text);
                    _need.MaxSquare = textBoxMaxSquare.Text;
                    _need.MinNumberOfFloors = int.Parse(textBoxMinNumberOfFloors.Text);
                    _need.MinNumberOfRooms = int.Parse(textBoxMinNumberOfRooms.Text);
                    _need.MinPrice = int.Parse(textBoxMinPrice.Text);
                    _need.MinSquare = textBoxMinSquare.Text;
                    _need.Type = comboBox.SelectedItem.ToString();
                    demEntities.Need.Add(_need);
                    MessageBox.Show("Потребность добавлена");
                }
                else
                {
                    Need tempNeed = demEntities.Need.FirstOrDefault(n => n.id == _need.id);
                    tempNeed.Address = textBoxAddress.Text;
                    var cl = demEntities.Client.FirstOrDefault(c => c.Surname == comboBoxClient.SelectedItem.ToString());
                    tempNeed.idClient = cl.id;
                    var rl = demEntities.Realtor.FirstOrDefault(r => r.Surname == comboBoxRealtor.SelectedItem.ToString());
                    tempNeed.idRealtor = rl.id;
                    tempNeed.MaxNumberOfFloors = int.Parse(textBoxMaxNumberOfFloors.Text);
                    tempNeed.MaxNumberOfRooms = int.Parse(textBoxMaxNumberOfRooms.Text);
                    tempNeed.MaxPrice = int.Parse(textBoxMaxPrice.Text);
                    tempNeed.MaxSquare = textBoxMaxSquare.Text;
                    tempNeed.MinNumberOfFloors = int.Parse(textBoxMinNumberOfFloors.Text);
                    tempNeed.MinNumberOfRooms = int.Parse(textBoxMinNumberOfRooms.Text);
                    tempNeed.MinPrice = int.Parse(textBoxMinPrice.Text);
                    tempNeed.MinSquare = textBoxMinSquare.Text;
                    tempNeed.Type = comboBox.SelectedItem.ToString();
                    MessageBox.Show("Потребность изменена");
                }
                demEntities.SaveChanges();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}

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
    /// Логика взаимодействия для EditRealPropertiesWindow.xaml
    /// </summary>
    public partial class EditRealPropertiesWindow
    {
        DemEntities demEntities = new DemEntities();
        RealProperties _realProperties = new RealProperties();
        List<string> list = new List<string>() {"Дом","Земля","Квартира" };
        public EditRealPropertiesWindow()
        {
            InitializeComponent();
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
        }
        public EditRealPropertiesWindow(RealProperties realProperties)
        {
            InitializeComponent();
            textBoxApartmentNumber.Text = realProperties.ApartmentNumber;
            textBoxFloor.Text = realProperties.Floor.ToString();
            textBoxHouseNumber.Text = realProperties.HouseNumber;
            textBoxLatitude.Text = realProperties.Latitude.ToString();
            textBoxLongitude.Text = realProperties.Longitude.ToString();
            textBoxNumberOfFloors.Text = realProperties.NumberOfFloors.ToString();
            textBoxNumberOfRooms.Text = realProperties.NumberOfRooms.ToString();
            textBoxSquare.Text = realProperties.Square;
            textBoxStreet.Text = realProperties.Street;
            textBoxСity.Text = realProperties.Сity;
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
            _realProperties.id = realProperties.id;

        }

        private void button_Save_Realtor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_realProperties.id == 0)
                {
                    _realProperties.ApartmentNumber = textBoxApartmentNumber.Text;
                    _realProperties.Floor = int.Parse(textBoxFloor.Text);
                    _realProperties.HouseNumber = textBoxHouseNumber.Text;
                    _realProperties.Latitude = int.Parse(textBoxLatitude.Text);
                    _realProperties.Longitude = int.Parse(textBoxLongitude.Text);
                    _realProperties.NumberOfFloors = int.Parse(textBoxNumberOfFloors.Text);
                    _realProperties.NumberOfRooms = int.Parse(textBoxNumberOfRooms.Text);
                    _realProperties.Square = textBoxSquare.Text;
                    _realProperties.Street = textBoxStreet.Text;
                    _realProperties.Type = comboBox.SelectedItem.ToString();
                    _realProperties.Сity = textBoxСity.Text;
                    demEntities.RealProperties.Add(_realProperties);
                    MessageBox.Show("Объект недвижимости добавлен");
                }
                else
                {
                    RealProperties tempRealProperties = demEntities.RealProperties.FirstOrDefault(rp => rp.id == _realProperties.id);
                    tempRealProperties.ApartmentNumber = textBoxApartmentNumber.Text;
                    tempRealProperties.Floor = int.Parse(textBoxFloor.Text);
                    tempRealProperties.HouseNumber = textBoxHouseNumber.Text;
                    tempRealProperties.Latitude = int.Parse(textBoxLatitude.Text);
                    tempRealProperties.Longitude = int.Parse(textBoxLongitude.Text);
                    tempRealProperties.NumberOfFloors = int.Parse(textBoxNumberOfFloors.Text);
                    tempRealProperties.NumberOfRooms = int.Parse(textBoxNumberOfRooms.Text);
                    tempRealProperties.Square = textBoxSquare.Text;
                    tempRealProperties.Street = textBoxStreet.Text;
                    tempRealProperties.Type = comboBox.SelectedItem.ToString();
                    tempRealProperties.Сity = textBoxСity.Text;
                    MessageBox.Show("Объект недвижимости изменен");
                }
                demEntities.SaveChanges();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}

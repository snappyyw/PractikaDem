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
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow
    {
        Client _client = new Client();
        DemEntities demEntities = new DemEntities();
        public EditClientWindow()
        {
            InitializeComponent();
        }
        public EditClientWindow(Client client)
        {
            InitializeComponent();
            textBoxName.Text = client.Name;
            textBoxEmail.Text = client.Email;
            textBoxPatronymic.Text = client.Patronymic;
            textBoxPhone.Text = client.Phone;
            textBoxSurname.Text = client.Surname;
            _client.id = client.id;
        }

        private void button_Save_Client_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                try
                {
                    if (_client.id == 0)
                    {
                        _client.Name = textBoxName.Text;
                        _client.Surname = textBoxSurname.Text;
                        _client.Patronymic = textBoxPatronymic.Text;
                        _client.Phone = textBoxPhone.Text;
                        _client.Email = textBoxEmail.Text;
                        demEntities.Client.Add(_client);
                        MessageBox.Show("Клиент добавлен");
                    }
                    else
                    {
                        Client tempClient = demEntities.Client.FirstOrDefault(cl => cl.id == _client.id);
                        tempClient.Email = textBoxEmail.Text;
                        tempClient.Name = textBoxName.Text;
                        tempClient.Surname = textBoxSurname.Text;
                        tempClient.Patronymic = textBoxPatronymic.Text;
                        tempClient.Phone = textBoxPhone.Text;
                        MessageBox.Show("Клиент изменен");
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
            if (textBoxEmail.Text == "" && textBoxPhone.Text == "")
            {
                error.Append("Введите телефон или Email");
            }
            if(error.Length > 0)
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

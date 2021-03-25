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
    /// Логика взаимодействия для EditRealtorWindow.xaml
    /// </summary>
    public partial class EditRealtorWindow 
    {
        DemEntities demEntities = new DemEntities();
        Realtor _realtor = new Realtor();
        public EditRealtorWindow()
        {
            InitializeComponent();
        }

        public EditRealtorWindow(Realtor realtor)
        {
            InitializeComponent();
            textBoxName.Text = realtor.Name;
            textBoxPatronymic.Text = realtor.Patronymic;
            textBoxShareOfCommission.Text = realtor.ShareOfCommission.ToString();
            textBoxSurname.Text = realtor.Surname;
            _realtor.id = realtor.id;
        }

        private bool Check()
        {
            StringBuilder error = new StringBuilder();
            int a;
            if(int.TryParse(textBoxShareOfCommission.Text, out a))
            {
                if (int.Parse(textBoxShareOfCommission.Text) <= 0 || int.Parse(textBoxShareOfCommission.Text) >= 100)
                {
                    error.AppendLine("Доля от комиссии от 0 до 100");
                }
            }
            if(textBoxName.Text == "")
            {
                error.AppendLine("Введите имя");
            }
            if (textBoxSurname.Text == "")
            {
                error.AppendLine("Введите фамилию");
            }
            if (textBoxPatronymic.Text == "")
            {
                error.AppendLine("Введите отчество");
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

        private void button_Save_Realtor_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                try
                {
                    if (_realtor.id == 0)
                    {
                        _realtor.Name = textBoxName.Text;
                        _realtor.Surname = textBoxSurname.Text;
                        _realtor.Patronymic = textBoxPatronymic.Text;
                        _realtor.ShareOfCommission = int.Parse(textBoxShareOfCommission.Text);
                        demEntities.Realtor.Add(_realtor);
                        MessageBox.Show("Риэлтор добавлен");
                    }
                    else
                    {
                        Realtor tempRealtor = demEntities.Realtor.FirstOrDefault(re => re.id == _realtor.id);
                        tempRealtor.ShareOfCommission = int.Parse(textBoxShareOfCommission.Text);
                        tempRealtor.Name = textBoxName.Text;
                        tempRealtor.Surname = textBoxSurname.Text;
                        tempRealtor.Patronymic = textBoxPatronymic.Text;
                        MessageBox.Show("Риэлтор изменен");
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
}

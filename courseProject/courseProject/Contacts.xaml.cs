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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace courseProject
{
    public partial class Contacts : Page
    {
        ApplicationContext db;
        public Contacts()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void ButtonAddMessage(object sender, RoutedEventArgs e)
        {
            try
            {
                string Name_acc = TextBoxContactsName_acc.Text.Trim();
            string Number = TextBoxContactsNumber.Text.Trim();
            string Message = TextBoxContactsMessage.Text.Trim();

            

            if (Name_acc.Length >= 2 && Name_acc.Length <= 20 && !Name_acc.Contains(" ") && Regex.IsMatch(Name_acc, @"^([a-zA-Zа-яА-Я0-9])*$"))
            {
                if (Number.Length != 0 && Number.Length >= 11 && Number.Length <= 13 && Regex.IsMatch(Number, @"^([0-9\d+])*$"))
                {
                    if (Message.Length <= 300 && Regex.IsMatch(Message, @"^([a-zA-Zа-яА-Я\d,.\s])*$"))
                    {
                        MessageBox.Show("Сообщение отправлено");

                        Contact cntct = new Contact(Name_acc, Number, Message);

                        db.Contacts.Add(cntct);
                        db.SaveChanges();

                    }
                    else
                    {
                        MessageBox.Show("Поле 'Сообщение' может содержать не более 300 символов и не может содержать специальные символы");
                    }
                }
                else
                {
                    MessageBox.Show("Поле 'Ваш номер' не может быть пустым, может содержать не менее одиннадцати символов и не более тринадцати символов и не может содержать специальные символы");
                }
            }
            else
            {
                MessageBox.Show("Поле 'Ваше имя' может содержать не менее двух и не более двадцати символов и не может содержать специальные символы и пробелы");
            }
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }
    }
}

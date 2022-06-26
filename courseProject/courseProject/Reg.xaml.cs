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
    public partial class Reg : Page
    {
        ApplicationContext db;
        public Reg()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            string Name_acc = TextBox_Reg_NameAcc.Text.Trim();
            string Email = TextBoxEmail_Reg_Acc.Text.Trim().ToLower();
            string Password = PasswordBox_first.Password.Trim();
            string Password_2 = PasswordBox_Second.Password.Trim();

            int name = db.Users.Where(b => b.name_acc == Name_acc).Count();

            

            if (Name_acc.Length >= 2 && Name_acc.Length <= 20 && !Name_acc.Contains(" ") && Regex.IsMatch(Name_acc, @"^([a-zA-Z0-9])*$"))
            {
                if (name == 0)
                {
                    if (Email.Length != 0 && Email.Length <= 50 && !Email.Contains(" ") && Regex.IsMatch(Email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                    {
                        if (Password.Length != 0 && Password.Length >= 8 && Password.Length <= 25 && !Password.Contains(" ") && Regex.IsMatch(Password, @"^([a-zA-Z0-9])*$"))
                        {
                            if (Password_2 == Password)
                            {
                                MessageBox.Show("Вы зарегистрированы");

                                User user = new User(Name_acc, Email, Password, "user");
                                db.Users.Add(user);
                                db.SaveChanges();
                                var us = db.Users.Where(t => t.name_acc == Name_acc).Single().ID;
                                db.User_information.Add(new User_information(us));
                                db.SaveChanges();

                                NavigationService.Navigate(new Auth());
                            }
                            else
                            {
                                MessageBox.Show("Пароли не совпадают");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароль может содержать не менее восьми и не более двадцати пяти сиволов и не может содержать специальных символов и пробелы");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректный email");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с таким именем уже существует");
                }
            }
            else
            {
                MessageBox.Show("Имя аккаунта может содержать не менее двух и не более двадцати символов и не включает специальные символы и пробелы");
            }
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }
        private void Button_Page_Auth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }
    }
}

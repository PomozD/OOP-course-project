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
    public partial class Auth : Page
    {
        ApplicationContext db;
        static Window1 main = (Window1)Application.Current.MainWindow;
        public Auth()
        {
            InitializeComponent();
            db = new ApplicationContext();

        }
        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Name_acc = TextBox_Auth_NameAcc.Text.Trim();
            string Password = PasswordBox_Auth.Password.Trim();

            

            if (Name_acc.Length >= 2 && Name_acc.Length <= 20 && !Name_acc.Contains(" ") && Regex.IsMatch(Name_acc, @"^([a-zA-Z0-9])*$"))
            {
                if (Password.Length != 0 && Password.Length >= 8 && Password.Length <= 25 && !Password.Contains(" ") && Regex.IsMatch(Password, @"^([a-zA-Z0-9])*$"))
                {
                    User Active_user = new User();
                    Active_user = null;
                    User user_inf = new User();
                    user_inf = null;
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        Active_user = db.Users.Where(b => b.name_acc == Name_acc && b.password == Password).FirstOrDefault();
                    }



                    if (Active_user != null)
                    {
                        MessageBox.Show("Вы авторизованы");
                        main.active_user = Active_user;
                        NavigationService.Navigate(new MainFrame(Active_user));
                    }
                    else
                    {
                        MessageBox.Show("Введите правильные данные");
                    }
                }
                else
                {
                    MessageBox.Show("Пароль может содержать не менее восьми символов и не может содержать специальных символов и пробелы");
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
        private void button_window_reg_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Reg());
        }
    }
}

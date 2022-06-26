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
    public partial class Profile : Page
    {
        static Window1 main = (Window1)Application.Current.MainWindow;
        public Profile()
        {
            try
            {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {

                var profile_User_information = db.User_information.Where(t=> t.user_id == main.active_user.ID);
                var profile_User = db.Users.Where(t => t.ID == main.active_user.ID);


                TextBox_First_Name.Text = profile_User_information.First().first_name;
                TextBox_Last_Name.Text = profile_User_information.First().last_name;
                TextBox_Number.Text = profile_User_information.First().number;
                TextBox_Email.Text = profile_User.First().email;
                TextBox_NameAcc.Content = profile_User.First().name_acc;
                TextBox_Password_Old.Password = profile_User.First().password;

                    Order_pet orders = db.Orders_pet.Where(t => t.order_id_user == main.active_user.ID).FirstOrDefault();
                    if(orders == null)
                    {
                        otvet.Content = "Вы еще не отправили заявку"; return;
                    }

                    Order_pet ordertrue = db.Orders_pet.Where(t => t.Order_agreeOrNotAgree == true && t.order_id_user == main.active_user.ID).FirstOrDefault();
                    Order_pet orderfalse = db.Orders_pet.Where(t => t.Order_agreeOrNotAgree == false && t.order_id_user == main.active_user.ID).FirstOrDefault();
                    Order_pet ordernull = db.Orders_pet.Where(t => t.Order_agreeOrNotAgree == null && t.order_id_user == main.active_user.ID).FirstOrDefault();
                    if (ordertrue != null)
                    {
                        otvet.Content = "Ваша заявка принята";
                    }
                    else if (orderfalse != null)
                    {
                        otvet.Content = "Ваша заявка отклонена";
                    }
                    else
                    {
                        otvet.Content = "Ваша заявка рассматривается";
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Повторите попытку позже");
            }
        }
        private void Button_SaveEdit_User_Information(object sender, RoutedEventArgs e)
        {
            try
            {
                string first_name = TextBox_First_Name.Text.Trim();
                string last_name = TextBox_Last_Name.Text.Trim();
                string email = TextBox_Email.Text.Trim().ToLower();
                string number = TextBox_Number.Text.Trim();
                string Password = TextBox_Password_Old.Password.Trim();
                string Password_new = TextBox_Password_First.Password.Trim();
                string Password_new_2 = TextBox_Password_Second.Password.Trim();


                /*User profile_User_information = new User();
                profile_User_information = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    profile_User_information = db.Users.Where
                        (b =>
                         b.email == email &&
                         b.password == Password).FirstOrDefault();


                }*/

                using (ApplicationContext db = new ApplicationContext())
                {
                    try
                    {
                        User us = db.Users.Find(main.active_user.ID);
                        us.email = email;
                        main.active_user.email = email;
                        us.password = Password_new;
                        main.active_user.password = Password_new;


                        User_information usI = db.User_information.Where(t => t.user_id == us.ID).Single();

                        usI.first_name = first_name;
                        usI.last_name = last_name;
                        usI.number = number;
                        

                        if (first_name.Length <= 20 && !first_name.Contains(" ") && Regex.IsMatch(first_name, @"^([a-zA-Zа-яА-Я0-9])*$"))
                        {
                            if (last_name.Length <= 20 && !last_name.Contains(" ") && Regex.IsMatch(last_name, @"^([a-zA-Zа-яА-Я0-9])*$"))
                            {

                                if (number.Length == 0 || number.Length >= 11 && number.Length <= 13 && Regex.IsMatch(number, @"^([0-9\d+])*$"))
                                {
                                    if (email.Length != 0 && email.Length <= 50 && !email.Contains(" ") && Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                                    {
                                        if (Password_new.Length != 0 && Password_new.Length >= 8 && Password_new.Length <= 25 && !Password_new.Contains(" ") && Regex.IsMatch(Password_new, @"^([a-zA-Z0-9])*$"))
                                        {
                                            if (Password_new_2 == Password_new)
                                            {
                                                MessageBox.Show("Информация о Вашем профиле обновлена");
                                                db.SaveChanges();
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
                                    MessageBox.Show("Поле 'Номер телефона' может быть пустым, может содержать не менее одиннадцати символов и не более тринадцати символов и не может содержать специальные символы");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Поле 'Ваша фамилия' может содержать не более двадцати символов и не может содержать специальные символы");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Поле 'Ваше имя' может содержать не более двадцати символов и не может содержать специальные символы ");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Введите корректные данные");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }
        }

        private void Button_ExitProfile(object sender, RoutedEventArgs e)
        {
            main.Frames.Content = new Auth();
        }
    }
}

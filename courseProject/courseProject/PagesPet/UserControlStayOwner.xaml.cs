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

namespace courseProject.PagesPet
{
    public partial class UserControlStayOwner : UserControl
    {
        static Window1 main = (Window1)Application.Current.MainWindow;
        ApplicationContext db;
        public UserControlStayOwner(string name)
        {
            InitializeComponent();
            mainNamePet.Content = name;
            db = new ApplicationContext();


        }

        private void Button_EnterOrderPet(object sender, RoutedEventArgs e)
        {
            string Name_acc = name_user.Text.Trim();
            string Number = number_user.Text.Trim();
            string Comment = Comment_user.Text.Trim();
            string name_pet = mainNamePet.Content.ToString();

            try
            {


            if (Name_acc.Length >= 2 && Name_acc.Length <= 20 && !Name_acc.Contains(" ") && Regex.IsMatch(Name_acc, @"^([a-zA-Zа-яА-Я0-9])*$"))
            {
                if (Number.Length != 0 && Number.Length >= 11 && Number.Length <= 13 && Regex.IsMatch(Number, @"^([0-9\d+])*$"))
                {
                    if (Comment.Length <= 300 && Regex.IsMatch(Comment, @"^([a-zA-Zа-яА-Я\d,.\s])*$"))
                    {
                        MessageBox.Show("Вы оформили питомца");

                        Order_pet order = new Order_pet(name_pet, Number, Name_acc, Comment, main.active_user.ID, main.active_control.ID, null);

                        db.Orders_pet.Add(order);
                        db.SaveChanges();

                    }
                    else
                    {
                        MessageBox.Show("Поле 'Комментарий' может содержать не более 300 символов и не может содержать специальные символы");
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

        public static readonly RoutedEvent ExitControlEvent
            = EventManager.RegisterRoutedEvent("ExitControl", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserControlStayOwner));

        public event RoutedEventHandler ExitControl
        {
            add { AddHandler(ExitControlEvent, value); }
            remove { RemoveHandler(ExitControlEvent, value); }
        }

        private void closeUserControlButton(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ExitControlEvent));
        }
    }
}

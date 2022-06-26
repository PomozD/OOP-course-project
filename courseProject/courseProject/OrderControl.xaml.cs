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

namespace courseProject
{
    public partial class OrderControl : UserControl
    {
        ApplicationContext db;
        public Order_pet ID { get; set; }
        public int IDZakaz;
        public OrderControl(int id)
        {
            try 
            {
                InitializeComponent();
                db = new ApplicationContext();
                IDZakaz = id;
                using (ApplicationContext db = new ApplicationContext())
                {

                    Order_pet order_inf = db.Orders_pet.Where(t => t.ID == id).ToArray()[0];
                    LabelName_acc.Content = order_inf.Order_name_user;
                    LabelNumber.Content = order_inf.Order_number_user;
                    LabelWantGet.Content = order_inf.Name_pet;
                    LabelComment.Text = order_inf.Order_comment;
                    if(order_inf.Order_agreeOrNotAgree != null)
                    {
                        Agree.Visibility = Visibility.Hidden;
                        NotAgree.Visibility = Visibility.Hidden;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }
        }

        private void ButtonAgree(object sender, RoutedEventArgs e)
        {
            Order_pet us = db.Orders_pet.Where(t=> t.ID == IDZakaz).FirstOrDefault();
            us.Order_agreeOrNotAgree = true;
            db.SaveChanges();
            MessageBox.Show("Вы подтвердили заявку");
            RaiseEvent(new RoutedEventArgs(OrderActionEvent));
        }

        private void ButtonNotAgree(object sender, RoutedEventArgs e)
        {
            Order_pet us = db.Orders_pet.Where(t => t.ID == IDZakaz).FirstOrDefault();
            us.Order_agreeOrNotAgree = false;
            db.SaveChanges();
            MessageBox.Show("Вы отказали в заявке");
            RaiseEvent(new RoutedEventArgs(OrderActionEvent));
        }
        public static readonly RoutedEvent OrderActionEvent
            = EventManager.RegisterRoutedEvent("OrderAction", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OrderControl));

        public event RoutedEventHandler OrderAction
        {
            add { AddHandler(OrderActionEvent, value); }
            remove { RemoveHandler(OrderActionEvent, value); }
        }
    }
}

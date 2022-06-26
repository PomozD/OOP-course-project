using courseProject.PagesPet;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Orders : Page
    {
        ApplicationContext db;
        public Order_pet ID { get; set; }
        private OrderControl AddOrderControl(Order_pet id)
        {
            OrderControl orderControl = new OrderControl(id.ID);
            orderControl.Margin = new Thickness(50, 20, 20, 50);
            orderControl.OrderAction += (o,e) => WrapPanelGrid.Children.Remove(orderControl);
            return orderControl;
        }
        public Orders()
        {
            try
            {
                db = new ApplicationContext();
                InitializeComponent();
                List<Order_pet> orders = db.Orders_pet.ToList();
                foreach (Order_pet pet in orders)
                {
                    OrderControl order = AddOrderControl(pet);
                    if (pet.Order_agreeOrNotAgree == null)
                    {
                        WrapPanelGrid.Children.Add(order);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }
        }
    }
}

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
    public partial class Messages : Page
    {
        ApplicationContext db;
        public Contact ID { get; set; }
        private MessageControl AddMessageControl(Contact id)
        {
            MessageControl messageControl = new MessageControl(id.ID);
            messageControl.Margin = new Thickness(50, 20, 20, 50);
            return messageControl;
        }
        public Messages()
        {
            try
            {
            db = new ApplicationContext();
            InitializeComponent();
            List<Contact> messages = db.Contacts.ToList();
            foreach (Contact id in messages)
            {
                
                WrapPanelGrid.Children.Add(AddMessageControl(id));
            }
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }
        }
    }
}

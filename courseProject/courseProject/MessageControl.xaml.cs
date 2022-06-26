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
    public partial class MessageControl : UserControl
    {
        public MessageControl(int id)
        {
            try {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {

                Contact message_inf = db.Contacts.Where(t => t.ID == id).ToArray()[0];
                labelName_acc.Content = message_inf.User_name;
                labelNumber.Content = message_inf.User_number;
                labelComment.Text = message_inf.Comment;

            }
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }
        }
    }
}

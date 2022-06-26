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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace courseProject
{
    public partial class Window1 : Window
    {
        public User active_user { get; set; }
        public User_information active_pet { get; set; }
        public Information_pet active_control { get; set; }
        public Window1()
        {
            InitializeComponent();
            Frames.Content = new Auth();
        }

        private void Frames_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e) => Frames.NavigationService.RemoveBackEntry();
    }
}

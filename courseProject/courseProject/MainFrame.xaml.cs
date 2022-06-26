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
    public partial class MainFrame : Page
    {
        public MainFrame(User Active_user)
        {
            try {
            InitializeComponent();
            Frames.Content = new Profile();
            Frames.NavigationService.RemoveBackEntry();

            if (Active_user.role == "user")
            {
                AdminFunctionsButton.Visibility = Visibility.Hidden;
            }
            else
            {
                AdminFunctionsButton.Visibility = Visibility.Visible;
            }
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }

        }



        private void Button_ChooseAPet(object sender, RoutedEventArgs e)
        {
            Frames.Content = new ChooseAPets();
        }

        private void Button_Profile(object sender, RoutedEventArgs e)
        {
            Frames.Content = new Profile();
        }

        private void Button_AdminFunctions(object sender, RoutedEventArgs e)
        {
            Frames.Content = new AdminFunctions();
        }

        private void Button_Contacts(object sender, RoutedEventArgs e)
        {
            Frames.Content = new Contacts();
        }

        private void Frames_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e) => Frames.NavigationService.RemoveBackEntry();
    }
}

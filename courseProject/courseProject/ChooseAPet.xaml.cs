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
    public partial class ChooseAPet : Page
    {
        public ChooseAPet()
        {
            InitializeComponent();
        }

        private void ButtonCats_Pages(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cats());
        }

        private void ButtonDogs_Pages(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Dogs());
        }

        private void ButtonPuppies_Pages(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Puppies());
        }

        private void ButtonKitten_Pages(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Kittens());
        }
    }
}

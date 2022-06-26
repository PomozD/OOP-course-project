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
    public partial class Catlink : UserControl
    {
        public Catlink(byte[] image)
        {
            try {
            InitializeComponent();
            MemoryStream memory = new MemoryStream(image);
            userControlBorderImageBrush.Source = BitmapFrame.Create(memory, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }
        }

        public static readonly RoutedEvent GoToPagePetEvent
            = EventManager.RegisterRoutedEvent("GoToPagePet", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Catlink));

        public event RoutedEventHandler GoToPagePet
        {
            add { AddHandler(GoToPagePetEvent, value); }
            remove { RemoveHandler(GoToPagePetEvent, value); }
        }
        private void OpenPagePet(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(GoToPagePetEvent));

        }
    }
}

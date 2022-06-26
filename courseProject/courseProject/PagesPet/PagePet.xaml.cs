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

namespace courseProject.PagesPet
{
    public partial class PagePet : Page
    {
        static Window1 main = (Window1)Application.Current.MainWindow;
        public string name_pet;
        bool isModalOpened = false;

        public PagePet(int id)
        {
            try { 
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {

                Information_pet profile_Information_pet = db.Informations_pet.Where(t => t.ID == id).ToArray()[0];

                var type_pet = from p in db.Informations_pet
                               join c in db.Type_pet
                               on p.id_type equals c.ID
                               where p.ID == id
                               select new { type = c.type_pett };

                main.active_control = profile_Information_pet;

                string type = "";
                foreach (var typee in type_pet)
                {
                    type += typee.type;
                }

                if (profile_Information_pet.Main_photo != null)
                    {
                        MemoryStream memoryMain = new MemoryStream(profile_Information_pet.Main_photo);
                        imageBrushMainPhoto.Source = BitmapFrame.Create(memoryMain, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    else
                    {
                        imageBrushMainPhoto.Source = null;
                    }
                    if (profile_Information_pet.Secondary_photo1 != null)
                    {
                        MemoryStream memory1 = new MemoryStream(profile_Information_pet.Secondary_photo1);
                        imageBrushSecondaryPhoto1.Source = BitmapFrame.Create(memory1, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    else
                    {
                        imageBrushSecondaryPhoto1.Source = null;
                        borderImageBrushSecondaryPhoto1.Visibility = Visibility.Hidden;
                    }
                    if (profile_Information_pet.Secondary_photo2 != null)
                    {
                        MemoryStream memory2 = new MemoryStream(profile_Information_pet.Secondary_photo2);
                        imageBrushSecondaryPhoto2.Source = BitmapFrame.Create(memory2, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    else
                    {
                        imageBrushSecondaryPhoto2.Source = null;
                        borderImageBrushSecondaryPhoto2.Visibility = Visibility.Hidden;
                    }
                    if (profile_Information_pet.Secondary_photo3 != null)
                    {
                        MemoryStream memory3 = new MemoryStream(profile_Information_pet.Secondary_photo3);
                        imageBrushSecondaryPhoto3.Source = BitmapFrame.Create(memory3, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    else
                    {
                        imageBrushSecondaryPhoto3.Source = null;
                        borderImageBrushSecondaryPhoto3.Visibility = Visibility.Hidden;
                    }

                textBlockTypePet.Text = type;
                labelNamePet.Content = profile_Information_pet.Name;
                name_pet = labelNamePet.Content.ToString();
                labelHistory.Text = profile_Information_pet.History;
                labelCharacter.Text = profile_Information_pet.Character;
                labelAge.Content = profile_Information_pet.Age;
                labelSex.Content = profile_Information_pet.Sex;
                labelCastrated.Content = profile_Information_pet.Castrated;


            }
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }
        }


        private void imageBrushSecondaryPhoto1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (imageBrushMainPhoto.Source, imageBrushSecondaryPhoto1.Source) = (imageBrushSecondaryPhoto1.Source, imageBrushMainPhoto.Source);
        }

        private void imageBrushSecondaryPhoto2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (imageBrushMainPhoto.Source, imageBrushSecondaryPhoto2.Source) = (imageBrushSecondaryPhoto2.Source, imageBrushMainPhoto.Source);

        }

        private void imageBrushSecondaryPhoto3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (imageBrushMainPhoto.Source, imageBrushSecondaryPhoto3.Source) = (imageBrushSecondaryPhoto3.Source, imageBrushMainPhoto.Source);

        }

        private void Button_StayOwner(object sender, RoutedEventArgs e)
        {
            try {
            if (isModalOpened) return;

            UserControlStayOwner ucso = new UserControlStayOwner(name_pet);
            ucso.Height = 521;
            ucso.Width = 532;
            AddUserControl.Children.Add(ucso);
            ucso.ExitControl += (o, ev) =>
            {
                AddUserControl.Children.Remove(ucso);
                isModalOpened = false;
            };
            isModalOpened = true;
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }
        }
    }
}

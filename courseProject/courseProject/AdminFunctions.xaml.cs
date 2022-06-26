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
using System.Collections;
using System.Data.Linq;
using Microsoft.Win32;
using System.IO;

namespace courseProject
{
    public partial class AdminFunctions : Page
    {
        ApplicationContext db;

        public Type_pet Type_pet { get; set; }
        public Information_pet Information_Pet { get; set; }

        static Window1 main = (Window1)Application.Current.MainWindow;
        public List<Type_pet> typePet { get; set; }
        public ArrayList combolist;
        byte[] main_photo;
        byte[] secondary_photo1;
        byte[] secondary_photo2;
        byte[] secondary_photo3;
        public AdminFunctions()
        {
            try {
            InitializeComponent();
            db = new ApplicationContext();

            Type_pet = new Type_pet();
            var item = from Type_pet in db.Type_pet select Type_pet;
            typesOfPets.ItemsSource = item.ToList();
            typesOfPets.DisplayMemberPath = "type_pett";
            typesOfPets.SelectedValuePath = "ID";
            typesOfPets.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Повторите попытку позже");
            }
        }

        private void AddMainPhoto_button(object sender, RoutedEventArgs e)
        {
            try
            {

            
            OpenFileDialog Upload = new OpenFileDialog();
            Upload.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF,*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            if (Upload.ShowDialog() == true)
            {
                string shortFileName = Upload.FileName.Substring(Upload.FileName.LastIndexOf('\\') + 1);
                using (System.IO.FileStream fs = new System.IO.FileStream(Upload.FileName, FileMode.Open))
                {
                    main_photo = new byte[fs.Length];
                    fs.Read(main_photo, 0, main_photo.Length);
                }
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(Upload.FileName);
                image.EndInit();
            }
            else
            {
                MessageBox.Show("Фото не было выбрано. Это поле обязательное. Пожалуйста, выберите главную фотографию");
            }
            }
            catch
            {
                MessageBox.Show("Выберите корректную фотографию");
            }

        }
        private void AddSecondaryPhoto1_button(object sender, RoutedEventArgs e)
        {
            try
            {

            
            OpenFileDialog Upload = new OpenFileDialog();
            Upload.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF,*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            if (Upload.ShowDialog() == true)
            {
            string shortFileName = Upload.FileName.Substring(Upload.FileName.LastIndexOf('\\') + 1);
            using (System.IO.FileStream fs = new System.IO.FileStream(Upload.FileName, FileMode.Open))
            {
                secondary_photo1 = new byte[fs.Length];
                fs.Read(secondary_photo1, 0, secondary_photo1.Length);
            }
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(Upload.FileName);
            image.EndInit();
            }
            else
            {
                MessageBox.Show("Фото не было выбрано");
            }
            }
            catch
            {
                MessageBox.Show("Выберите корректную фотографию");
            }
        }

        private void AddSecondaryPhoto2_button(object sender, RoutedEventArgs e)
        {
            try
            {
            OpenFileDialog Upload = new OpenFileDialog();
            Upload.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF,*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            if (Upload.ShowDialog() == true)
            {

            string shortFileName = Upload.FileName.Substring(Upload.FileName.LastIndexOf('\\') + 1);
            using (System.IO.FileStream fs = new System.IO.FileStream(Upload.FileName, FileMode.Open))
            {
                secondary_photo2 = new byte[fs.Length];
                fs.Read(secondary_photo2, 0, secondary_photo2.Length);
            }
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(Upload.FileName);
            image.EndInit();
            }
            else
            {
                MessageBox.Show("Фото не было выбрано");
            }
            }
            catch
            {
                MessageBox.Show("Выберите корректную фотографию");
            }
        }

        private void AddSecondaryPhoto3_button(object sender, RoutedEventArgs e)
        {
            try
            {

            
            OpenFileDialog Upload = new OpenFileDialog();
            Upload.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF,*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            if (Upload.ShowDialog() == true)
            {
            string shortFileName = Upload.FileName.Substring(Upload.FileName.LastIndexOf('\\') + 1);
            using (System.IO.FileStream fs = new System.IO.FileStream(Upload.FileName, FileMode.Open))
            {
                secondary_photo3 = new byte[fs.Length];
                fs.Read(secondary_photo3, 0, secondary_photo3.Length);
            }
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(Upload.FileName);
            image.EndInit();
            }
            else
            {
                MessageBox.Show("Фото не было выбрано");
            }
            }
            catch
            {
                MessageBox.Show("Выберите корректную фотографию");
            }

        }
        private void ButtonAddPet(object sender, RoutedEventArgs e)
        {
            try
            {
            string name = addPet_name.Text.Trim();
            string history = addHistory.Text.Trim();
            string character = addPet_character.Text.Trim();
            string age = addPet_age.Text.Trim();
            string sex = addPet_sex.Text.Trim();
            string castrated = addPet_castrated.Text.Trim();

            var comboItem = typesOfPets.SelectedIndex;
            int id_type = comboItem + 1;

            if (name.Length >= 2 && name.Length <= 15 && !name.Contains(" ") && Regex.IsMatch(name, @"^([a-zA-Zа-яА-Я0-9])*$"))
            {
                if (history.Length <= 200 && Regex.IsMatch(history, @"^([a-zA-Zа-яА-Я\d,.\s])*$"))
                {
                    if (character.Length <= 200 && Regex.IsMatch(character, @"^([a-zA-Zа-яА-Я\d,.\s])*$"))
                    {
                        if (age.Length <= 20 && Regex.IsMatch(age, @"^([a-zA-Zа-яА-Я\d,.\s])*$"))
                        {
                            if (sex.Length <= 20 && Regex.IsMatch(sex, @"^([a-zA-Zа-яА-Я\d,.\s])*$"))
                            {
                                if (castrated.Length <= 20 && Regex.IsMatch(castrated, @"^([a-zA-Zа-яА-Я\d,.\s])*$"))
                                {
                                    Information_pet inf = new Information_pet(name, history, character, age, sex, castrated, id_type, main_photo, secondary_photo1, secondary_photo2, secondary_photo3);
                                    db.Informations_pet.Add(inf);
                                    db.SaveChanges();
                                    MessageBox.Show("Питомец добавлен");
                                }
                                else
                                {
                                    MessageBox.Show("Поле 'Кастрирован/стерилизована' может содержать не более двадцати символов и не может содержать специальных символов");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Поле 'Пол' может содержать не более двадцати символов и не может содержать специальных символов");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Поле 'Возраст' может содержать не более двадцати символов и не может содержать специальных символов");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поле 'Характер' может содержать не более 200 символов и не может содержать специальных символов");
                    }
                }
                else
                {
                    MessageBox.Show("Поле 'История' может содержать не более 200 символов и не может содержать специальных символов");
                }
            }
            else
            {
                MessageBox.Show("Поле 'Имя питомца' может содержать не менее двух и не более пятнадцати символов и не может содержать специальных символов и пробелов");
            }
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void ButtonOpenPageOrders(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Orders());
        }

        private void ButtonOpenPageMessages(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Messages());
        }
    }
}

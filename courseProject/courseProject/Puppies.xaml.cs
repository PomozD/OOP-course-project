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
    public partial class Puppies : Page
    {
        ApplicationContext db;
        public Information_pet ID { get; set; }
        private Catlink AddCatlinkControl(byte[] pet, Information_pet id)
        {
            Catlink catlinkControl = new Catlink(pet);
            catlinkControl.Margin = new Thickness(50, 20, 20, 50);
            catlinkControl.Name = "_" + id.ID.ToString();
            catlinkControl.GoToPagePet += (o, e) => NavigationService.Navigate(new PagePet(id.ID));
            return catlinkControl;
        }
        public Puppies()
        {
            try
            {
                db = new ApplicationContext();
                InitializeComponent();

                List<Information_pet> userctrlid = db.Informations_pet.Where(b => b.id_type == 4).ToList();

                foreach (Information_pet id in userctrlid)
                {
                    var pet = db.Orders_pet.Where(b => b.order_id_pet == id.ID && b.Order_agreeOrNotAgree == true);

                    if (pet.Count() == 0)
                    {
                        if (id.Main_photo != null)
                        {

                            byte[] img = id.Main_photo.ToArray();

                            WrapPanelGrid.Children.Add(AddCatlinkControl(img, id));
                        }
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

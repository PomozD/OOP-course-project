using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
    public class Order_pet
    {

        public int ID { get; set; }
        private string name_pet, order_number_user, order_name_user, order_comment;
        private bool? order_agreeOrNotAgree;
        public int order_id_user { get; set; }
        public int order_id_pet { get; set; }

        public string Name_pet
        {
            get { return name_pet; }
            set { name_pet = value; }
        }
        public string Order_number_user
        {
            get { return order_number_user; }
            set { order_number_user = value; }
        }
        public string Order_name_user
        {
            get { return order_name_user; }
            set { order_name_user = value; }
        }
        public string Order_comment
        {
            get { return order_comment; }
            set { order_comment = value; }
        }
        public bool? Order_agreeOrNotAgree
        {
            get { return order_agreeOrNotAgree; }
            set { order_agreeOrNotAgree = value; }
        }

        public Order_pet() { }
        public Order_pet(string name_pet, string order_number_user, string order_name_user, string order_comment, int order_id_user, int order_id_pet, bool? order_agreeOrNotAgree)
        {
            this.name_pet = name_pet;
            this.order_number_user = order_number_user;
            this.order_name_user = order_name_user;
            this.order_comment = order_comment;
            this.order_id_user = order_id_user;
            this.order_id_pet = order_id_pet;
            this.Order_agreeOrNotAgree = order_agreeOrNotAgree;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
    public class Contact
    {

        public int ID { get; set; }

        private string user_name, user_number, comment;

        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        public string User_number
        {
            get { return user_number; }
            set { user_number = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public Contact() { }
        public Contact(string user_name, string user_number, string comment)
        {
            this.user_name = user_name;
            this.user_number = user_number;
            this.comment = comment;
        }
    }
}

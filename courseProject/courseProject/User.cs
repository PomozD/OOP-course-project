using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
    public class User
    {

        public int ID { get; set; }

        private string Name_acc, Email, Password;

        private string Role;

        public string role
        {
            get { return Role; }
            set { Role = value; }
        }

        public string name_acc
        {
            get { return Name_acc; }
            set { Name_acc = value; }
        }

        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public User() { }

        public User(string Name_acc, string Email, string Password, string Role)
        {
            this.Name_acc = Name_acc;
            this.Email = Email;
            this.Password = Password;
            this.Role = Role;
        }
    }
}

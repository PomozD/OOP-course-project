using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{

    public class User_information
    {
        public int ID { get; set; }
        public string first_name
        {
            get; set;
        }
        public string last_name
        {
            get; set;
        }
        public string number
        {
            get; set;
        }
        public int user_id
        {
            get; set;
        }
        public User_information() { }
        public User_information(int user_id)
        {
            this.first_name = null;
            this.last_name = null;
            this.number = null;
            this.user_id = user_id;
        }
        public User_information(string first_name, string last_name, string number, int user_id)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.number = number;
            this.user_id = user_id;
        }
    }
}

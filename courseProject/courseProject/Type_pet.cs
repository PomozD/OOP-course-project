using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
    public class Type_pet
    {
        public int ID { get; set; }
        public string type_pett { get; set; }
        
        public Type_pet() { }
        public Type_pet(string type_pett)
        {
            this.type_pett = type_pett;
        }
    }
}

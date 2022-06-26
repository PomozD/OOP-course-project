using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
    public class Information_pet
    {

        public int ID { get; set; }
        private string name, history, character, age, sex, castrated;

        private byte[] main_photo, secondary_photo1, secondary_photo2, secondary_photo3;

        public int id_type
        {
            get; set;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string History
        {
            get { return history; }
            set { history = value; }
        }

        public string Character
        {
            get { return character; }
            set { character = value; }
        }

        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Castrated
        {
            get { return castrated; }
            set { castrated = value; }
        }
        public byte[] Main_photo
        {
            get { return main_photo; }
            set { main_photo = value; }
        }
        public byte[] Secondary_photo1
        {
            get { return secondary_photo1; }
            set { secondary_photo1 = value; }
        }
        public byte[] Secondary_photo2
        {
            get { return secondary_photo2; }
            set { secondary_photo2 = value; }
        }
        public byte[] Secondary_photo3
        {
            get { return secondary_photo3; }
            set { secondary_photo3 = value; }
        }

        public Information_pet() { }

        public Information_pet(string name, string history, string character, string age, string sex, string castrated, int id_type, byte[] main_photo, byte[] secondary_photo1, byte[] secondary_photo2, byte[] secondary_photo3)
        {
            this.name = name;
            this.history = history;
            this.character = character;
            this.age = age;
            this.sex = sex;
            this.castrated = castrated;
            this.id_type = id_type;
            this.main_photo = main_photo;
            this.secondary_photo1 = secondary_photo1;
            this.secondary_photo2 = secondary_photo2;
            this.secondary_photo3 = secondary_photo3;
        }
    }
}

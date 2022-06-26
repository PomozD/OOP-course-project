using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace courseProject
{
    class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<User_information> User_information { get; set; }
        public DbSet<Information_pet> Informations_pet { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order_pet> Orders_pet { get; set; }
        public DbSet<Type_pet> Type_pet { get; set; }
         
        public ApplicationContext() : base("DefaultConnection") { }
    }
}

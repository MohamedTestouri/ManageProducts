using ManageProducts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProducts.Data
{
    public class MyContext :DbContext
    {
        //ctor+double tab
        //public MyContext():base("mabase_4sim4")// le nom de la base de données
        //{

        //}
        public MyContext():base("name=MaChaine")//le nom de la chaine : app.config du projet de démarrage
        {

        }
        public DbSet<Product> Products { get; set; } // TPH : 1 seule table pour 3 classes(product+chemical+biological)
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

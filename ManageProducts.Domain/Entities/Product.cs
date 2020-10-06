using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProducts.Domain.Entities
{
    public class Product
    {
        //Pro de base
        public DateTime DateProd { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // prop de navigation
        //public List<Provider> Providers { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
        public virtual Category Category { get; set; }
        //constr ctor + doublr tab
        public Product()
        {

        }

        public Product(DateTime dateProd, string description, string name, 
            double price, int productId, int quantity)
        {
            DateProd = dateProd;
            Description = description;
            Name = name;
            Price = price;
            ProductId = productId;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return "DateProd = " + DateProd
                + "Description = "+ Description
                + "Name = "+ Name
                + "Price = "+ Price
                + "ProductId = "+ ProductId
                + "Quantity = "+ Quantity;
        }

    }
     public class Exemple
    {
        // prop + double tab  :light version
        public int MyProperty { get; set; }
        //propfull + double tab : full version
        private int age;
        public int MyProperty2
        {
            get { return age; }
            set { age = value; }
        }
        //propg : secure version
        public int MyProperty3 { get; private set; }

    }
}

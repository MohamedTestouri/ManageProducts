using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProducts.Domain.Entities
{
    public class Product
    {
        //prop + double tab : light version
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime DateProd { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        /* propfull+ double tab : full version (if we need to override the var)
        private int ProductId;
        public int MyProperty
        {
            get { return ProductId; }
            set { ProductId = value; }
        }*/

        //navigation prop
        /*List: 
        public List<Provider> Providers { get; set;}
         */
        // ICollection
        public virtual ICollection<Provider> Providers { get; set; }
        public virtual Category Category { get; set; }
        // ctor + double tab : construct 
        public Product()
        {

        }

        public Product(int productId, int quantity, double price, DateTime dateProd, string description, string name)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            DateProd = dateProd;
            Description = description;
            Name = name;
        }
        public override string ToString()
        {
            return "Id: " + ProductId
                + " Quantity: " + Quantity
                + " Price: " + Price
                + " Date: " + DateProd
                + " Description: " + Description
                + " Name: " + Name;
        }
    }
}

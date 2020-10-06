using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProducts.Domain.Entities
{
    public class Chemical:Product
    {
        public string City { get; set; }
        public string LabName { get; set; }
        public string StreetAddress { get; set; }
        public Chemical():base()
        {

        }
       
        public Chemical(DateTime dateProd, string description, string name,
            double price, int productId, int quantity,/*product*/
            string city, string labName, string streetAddress/*chemical*/)
            :base(dateProd,description,name,price,productId,quantity)/*const product*/
        {
            City = city;
            LabName = labName;
            StreetAddress = streetAddress;
        }

        public override string ToString()
        {
            return base.ToString()+ "City = "+City+ " LabName = "
                +LabName+ " StreetAddress = " + StreetAddress;
        }
    }
}

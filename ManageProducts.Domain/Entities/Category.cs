using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProducts.Domain.Entities
{
    public class Category
    {
        //prop de base
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //prop de navig
        public virtual ICollection<Product> Products { get; set; }
    }
}

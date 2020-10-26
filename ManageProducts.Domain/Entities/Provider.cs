using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProducts.Domain.Entities
{
    public class Provider
    {
        public string ConfirmPassword { get; set; }
        public string DateCreated { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public bool IsApproved { get; set; }
       // public string Password { get; set; }
        public string UserName { get; set; }
        private string password;

        public string Password
        {
            get { return password; }
            set { if (value.Length>=5 && value.Length<=20)password = value;
                else Console.WriteLine("out of range [5..20]");           
              }
        }

        public virtual ICollection<Product> Products { get; set; }

        // 

        public void SetIsApproved(Provider P)
        {
           // this.IsApproved == P.IsApproved;
        }
       

    }
}

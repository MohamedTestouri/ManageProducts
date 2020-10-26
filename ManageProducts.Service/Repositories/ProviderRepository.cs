using ManageProducts.Data;
using ManageProducts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProducts.Service.Repositories
{
    public class ProviderRepository
    {
        private MyContext myContext;
        public ProviderRepository()
        {
            myContext = new MyContext();

        }

        public bool IsApproved { get; set; }
        public void Commit()
        {
            myContext.SaveChanges();
        }

        public void AddProvider(Provider prov)
        {
            myContext.Providers.Add(prov);
        }

        public void DeleteProvider(Provider prov)
        {
            myContext.Providers.Remove(prov);
        }
        public IEnumerable<Provider> GetProviders()
        {
            return myContext.Providers;
        }
        // TP1
        public bool SetIsApproved(Provider P)
        {
            return P.IsApproved = string.Compare(P.Password, P.ConfirmPassword) == 0;
        }
        public string SetIsApproved(string password, string confirmPassword, bool isApproved)
        {
            this.IsApproved = string.Compare(password, confirmPassword) == 0;
            return "password : " + password + " confirmPassword : " + confirmPassword + " IsApproved : " + IsApproved;
        }

        public bool login(string login, string password)
        {
            //recupre a partire de la base de données
            foreach (Provider p in GetProviders())
            {
                if (p.UserName == login && p.Password == password)
                    return true;
            }
            return false;
        }

        public Provider GetProviderId(int ID)
        {
            return myContext.Providers.Find(ID);

        }
        public bool login(string login, string password, int id)
        {
            Provider test = GetProviderId(id);
            if (test.UserName == login && test.Password == password)
                return true;
            else
                return false;

        }


        //  TP2
        public IEnumerable<Provider> GetProvidersByName(string name)
        {
            /*  List<Provider> maListe = new List<Provider>;
              foreach (Provider p in GetProviders())
              {
                  if (p.UserName.Equals(name))
                      maListe.Add(p);
              }
              return maListe.AsEnumerable();
          }*/
            //linq
            var query = from prov in myContext.Providers
                        where prov.UserName.Equals(name)
                        select prov;
            return query.AsEnumerable();
        }
        public Provider GetFirstProviderByName(string name)
        {
            var query = from prov in myContext.Providers
                        where prov.UserName.Equals(name)
                        select prov;
            return query.FirstOrDefault();
        }
        public Provider GetProviderById(int id)
        {
            var query = from prov in myContext.Providers
                        where prov.Id == id
                        select prov;
            return query.FirstOrDefault();
        }



    }
}

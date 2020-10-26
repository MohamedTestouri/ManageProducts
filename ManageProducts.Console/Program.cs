using ManageProducts.Data;
using ManageProducts.Domain.Entities;
using ManageProducts.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProducts.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //avec un constructeur
            Product prod = new Product(12, 999, 5014, DateTime.Now, "myProd", "new prod");
            System.Console.WriteLine("my product name is : " + prod.Name);
            System.Console.WriteLine(prod.ToString());
            //avec initialiseur d'objet
            Product prod2 = new Product
            {
                Name = "mySecondProd",
                Quantity = 100
            };
            System.Console.WriteLine("my second prod name is " + prod2.Name);
            Chemical chem = new Chemical
            {
                Price = 100,
                Name = "Chemical product",
                DateProd = new DateTime(2020, 10, 01),
                City = "Ghazela"
            };

            Biological biological = new Biological
            {
                Herbs = "herbs",
                DateProd = new DateTime(2020, 10, 01),
                Name = "bio pruduct"

            };
            //ToString()
            System.Console.WriteLine(" chemical prod " + chem.ToString());

            /*//sans la chouche service
            //Création de la base de données
            MyContext myContext = new MyContext();
            myContext.Products.Add(prod);//ajout du product au DbSet<Products>
            myContext.Products.Add(chem);
            myContext.Products.Add(biological);

            myContext.SaveChanges();//synchronisation avec la base 
            System.Console.WriteLine(" product added successfully");*/

            //avec la couche service***

            Provider prov = new Provider
            {
                UserName = "wassim",
                Email = "wassim@esprit.tn",
                Password = "12345",
                ConfirmPassword = "12345",
                IsApproved = false

            };

            Provider prov2 = new Provider
            {
                UserName = "amine",
                Email = "amine@esprit.tn",
                Password = "126645",
                ConfirmPassword = "126645",
                IsApproved = false

            };

            Provider prov3 = new Provider
            {
                UserName = "raed",
                Email = "raed@esprit.tn",
                Password = "123345",
                ConfirmPassword = "123345",
                IsApproved = false

            };
            ProviderRepository provRepo = new ProviderRepository();
            provRepo.AddProvider(prov);
            provRepo.AddProvider(prov2);
            provRepo.AddProvider(prov3);
            provRepo.Commit();

            foreach (Provider p in provRepo.GetProviders())
            {
                System.Console.WriteLine("My Provider =" + p.UserName);
            }

            //passage par  reference
            System.Console.WriteLine(prov.Password + "  " + prov.ConfirmPassword);
            System.Console.WriteLine(provRepo.SetIsApproved(prov));
            //passage par valeur
            System.Console.WriteLine(provRepo.SetIsApproved("123", "123", false));





            #region TP 2

            System.Console.WriteLine("**************test provider service***************");
            System.Console.WriteLine(" @ first prov : " + provRepo.GetFirstProviderByName("wassim").Email);
            System.Console.WriteLine(" @ first prov by id : " + provRepo.GetProviderById(2).Email);

            foreach (Provider p in provRepo.GetProvidersByName("amine"))
            {
                System.Console.WriteLine("@ by name " + p.Email);
            }
            System.Console.WriteLine("**************test product service***************");


            ProductRepository produit = new ProductRepository();
            produit.AddPoduct(prod);
            produit.AddPoduct(prod2);
            produit.AddPoduct(chem);
            produit.AddPoduct(biological);
            produit.Commit();

            System.Console.WriteLine("le prix moyen de tous les produits : " + produit.GetAveragePrice());
            System.Console.WriteLine("le nombre de produits. : " + produit.GetCountProduct());
            produit.AddPoduct(prod);
            produit.Commit();
            foreach (Chemical c in produit.Get5ChemicalByPrice(10))
            {
                System.Console.WriteLine("Get5ChemicalByPrice" + c.Name+"/"+c.City);
            }
            foreach (Product p in produit.GetProductPrice(8))
            {
                System.Console.WriteLine("GetProductPrice"+p.Name);
            }

            #endregion

            System.Console.WriteLine("Fin");
            System.Console.ReadKey();
            //Polymorphisem
            // System.Console.WriteLine(prod.GetType);


        }
    } 
       /* {
            //avec un constructeur
            Product prod = new Product(12, 999, 5014, DateTime.Now, "myProd", "new prod");
            System.Console.WriteLine("my product name is : " + prod.Name);
            System.Console.WriteLine(prod.ToString());
            //avec initialiseur d'objet
            Product prod2 = new Product
            {
                Name = "mySecondProd",
                Quantity = 100
            };
            System.Console.WriteLine("my second prod name is " + prod2.Name);
            Chemical chem = new Chemical
            {
                Price = 100,
                Name = "Chemical product",
                DateProd = new DateTime(2020, 10, 01),
                City = "Ghazela"
            };

            Biological biological = new Biological
            {
                Herbs = "herbs",
                DateProd = new DateTime(2020, 10, 01),
                Name = "bio pruduct"

            };
            //ToString()
            System.Console.WriteLine(" chemical prod " + chem.ToString());

            //sans la chouche service
            //Création de la base de données
            MyContext myContext = new MyContext();
            myContext.Products.Add(prod);//ajout du product au DbSet<Products>
            myContext.Products.Add(chem);
            myContext.Products.Add(biological);

            myContext.SaveChanges();//synchronisation avec la base 
            System.Console.WriteLine(" product added successfully");
            //avec la couche service
            Provider prov = new Provider
            {
                UserName = "Mohamed",
                Email = "mohamed.testouri@esprit.tn",
                Password = "12345",
                ConfirmPassword = "12345",
                IsApproved = false

            };
            ProviderRepository provRepo = new ProviderRepository();
            provRepo.AddProvider(prov);
            foreach (Provider p in provRepo.GetProviders())
            {
                System.Console.WriteLine("My Provider =" + p.UserName);
            }

            //passage par  reference
            System.Console.WriteLine(prov.Password + "  " + prov.ConfirmPassword);
            System.Console.WriteLine(provRepo.SetIsApproved(prov));
            //passage par valeur
            System.Console.WriteLine(provRepo.SetIsApproved("123", "123", false));

            System.Console.WriteLine("Fin");
            

            //Polymorphisem
            // System.Console.WriteLine(prod.GetType);
            #region TP2
            System.Console.WriteLine("first provider" + provRepo.GetFirstProviderByName("Mohamed").Email);
            System.Console.WriteLine("first provider" + provRepo.GetProviderById(1).Email);
            System.Console.WriteLine("first provider" + provRepo.GetProvidersByName("Mohamed"));

            #endregion
            System.Console.ReadKey();
        }

    }*/
}

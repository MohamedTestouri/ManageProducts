using ManageProducts.Data;
using ManageProducts.Domain.Entities;
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
            Product prod = new Product(DateTime.Now,
                "new prod","myProd",500,12,100);
            System.Console.WriteLine("my product name is : "+prod.Name);
            System.Console.WriteLine(prod.ToString());
            //avec initialiseur d'objet
            Product prod2 = new Product
            { 
                Name="mySecondProd",
                Quantity=100
            };
            System.Console.WriteLine("my second prod name is " + prod2.Name);
            Chemical chem = new Chemical 
            { 
                Price=100,
                Name = "Chemical product",
                DateProd=new DateTime(2020,10,01),
                City = "Ghazela"
            };
            //ToString()
            System.Console.WriteLine(" chemical prod "+chem.ToString());

            //Création de la base de données
            MyContext myContext = new MyContext();
            myContext.Products.Add(prod);//ajout du product au DbSet<Products>
            myContext.Products.Add(chem);
            myContext.SaveChanges();//synchronisation avec la base 
            System.Console.WriteLine(" product added successfully");

            System.Console.ReadKey();
        }
    }
}

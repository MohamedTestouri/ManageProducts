using ManageProducts.Data;
using ManageProducts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageProducts.Service.Repositories
{
    public class ProductRepository
    {
        private MyContext context;
        private IEnumerable<Product> products;

        public ProductRepository()
        {
            context = new MyContext();

        }

        public bool IsApproved { get; set; }
        public void Commit()
        {
            context.SaveChanges();
        }

        public void AddPoduct(Product p)
        {
            context.Products.Add(p);
        }

        public IEnumerable<Chemical> Get5ChemicalByPrice(double price)
        {
            /*var query = from Product in context.Products.OfType<Chemical>()
                        where Product.Price > price
                        select Product;
            return query.Take(5);*/
            return context.Products
                .OfType<Chemical>()
                .Where(p => p.Price > price)
                .Take(5);
        }

        public IEnumerable<Product> GetProductPrice(double price)
        {
            /*var query = from Product in context.Products
                        where Product.Price > price
                        select Product;
            return query.Skip(3);*/

            return (from Product in context.Products
                    where Product.Price > price
                    select Product).AsEnumerable().Skip(3);
        }

        public double GetAveragePrice()
        {
            /* return (from Product in context.Products
                     select Product.Price).Average();*/
            return context.Products.Average(p => p.Price);

        }

        public Product GetProductByMaxPrice()
        {
            /*var maxPrice = (from product in context.Products
                            select product.Price).Max();
            var query = from product in context.Products
                        where product.Price == maxPrice
                        select product;
            return query.FirstOrDefault();*/
        
            double maxPrice = context.Products.Max(p => p.Price);
            return context.Products.FirstOrDefault(p => p.Price == maxPrice);
        }
        public double GetCountProduct()
        {
            return (from Product in context.Products
                    select Product).Count();

        }
        public IEnumerable<Chemical> GetChemicalByCity(string city)
        {
            return from product in context.Products.OfType<Chemical>()
                   orderby product.City ascending
                   select product;
        }
        public void GetChemicalBroupByCity()
        {
            var query = from product in context.Products.OfType<Chemical>()
                        orderby product.City ascending
                        group product by product.City;
            foreach (var item in query)
            {
                Console.WriteLine("city =" + item.Key);
                Console.WriteLine("Liste des prouits =");

                foreach (var prod in products)
                {
                    Console.WriteLine(" Product = " + prod.Name + "\t" + prod.Price);
                }

            }
        }
        public IGrouping<string, IEnumerable<Chemical>> ChemicalsGroupByCity()
        {
            var query = from product in context.Products.OfType<Chemical>()
                        orderby product.City ascending
                        group product by product.City
                        into variable
                        select new
                        {
                            city = variable.Key,
                            liste = variable.ToList()
                        };

            return (IGrouping<string, IEnumerable<Chemical>>)query;

        }
    }
}

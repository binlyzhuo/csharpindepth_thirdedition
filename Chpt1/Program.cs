using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string msg = "";
            Console.WriteLine("CHPT1");

            var products = Product.GetSampleProducts();
            products.Sort(new ProductNameComparer());

            products.Sort(delegate(Product x,Product y) { return x.Name.CompareTo(y.Name); });

            products.Sort((x, y) => x.Name.CompareTo(y.Name));

            foreach(Product p in products)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("********************");
            foreach(Product p in products.OrderBy(u=>u.Name))
            {
                Console.WriteLine(p.Name);
            }

            //=================
            // Search
            Console.WriteLine("Search Function!!");

            Predicate<Product> test = delegate (Product p)
            {
                return p.Price > 10m;
            };


            List<Product> matchs = products.FindAll(test);

            Action<Product> print = Console.WriteLine;
            matchs.ForEach(print);
            Console.WriteLine("//===next!!");
            //===================
            products.FindAll(delegate (Product p) { return p.Price > 10m; }).ForEach(Console.WriteLine);

            foreach(Product p in products.Where(u=>u.Price>10m))
            {
                Console.WriteLine(p.Name);
            }
            Console.ReadLine();
        }
    }
}

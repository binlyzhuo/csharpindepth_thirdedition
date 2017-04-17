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

            foreach(Product p in products)
            {
                Console.WriteLine(p.Name);
            }
            Console.ReadLine();
        }
    }
}

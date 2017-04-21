using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt4
{
    class Program
    {
        static void Main(string[] args)
        {
            int? num = null;
            bool isHasValue = num.HasValue;
            Console.WriteLine(isHasValue);
            Console.WriteLine(num.GetHashCode());

            Nullable<int> x = 5;
            object boxed = x;
            Console.WriteLine(x.GetType());
            int normal = (int)boxed;
            Console.WriteLine(normal.GetType());

            int? nullable = 5;
            nullable = (int?)boxed;
            Console.WriteLine(nullable);

            nullable = new Nullable<int>();
            boxed = nullable;
            Console.WriteLine(boxed == null);

            nullable = (int?)boxed;
            Console.WriteLine(nullable.HasValue);

            Console.WriteLine("/*************/");
            Console.WriteLine("Instance with value:");
            Display(x);
            Console.WriteLine("Instance without value:");
            x = null;
            Display(x);

            Console.WriteLine("-------------------------------------\n\n");
            Console.WriteLine(Nullable.Compare<int>(null,1));
            int? xx=null;
            Type nullType = xx.GetType();
            Type underlyingType = Nullable.GetUnderlyingType(nullType);
            Console.WriteLine(Nullable.GetUnderlyingType(xx.GetType()).FullName);
            Console.ReadLine();
        }

        static void Display(Nullable<int> x)
        {
            if(x.HasValue)
            {
                Console.WriteLine("Value:{0}",x.Value);
                Console.WriteLine("Explicit Value:{0}",(int)x);
            }

            Console.WriteLine("GetValueOrDefault():{0}",x.GetValueOrDefault());
            Console.WriteLine("GetValueOrDefault(10):{0}", x.GetValueOrDefault(10));
        }
    }
}

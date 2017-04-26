using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chpt9");
            Func<string, int> returnLen = delegate (string txt) { return txt.Length; };
            Func<string, int> getLen = (txt) => txt.Length;
            Console.WriteLine(getLen("Hello"));
            Console.WriteLine(returnLen("get"));
            Console.ReadLine();
        }
    }
}

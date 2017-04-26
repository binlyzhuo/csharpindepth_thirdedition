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

            Action<Film> print = (file)=>Console.WriteLine("Name:{0},Year:{1}",file.Name,file.Year);
            Film.SampleData().ForEach(print);
            Film.SampleData().FindAll(u => u.Year > 1955).ForEach(print);
            Film.SampleData().Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
            Film.SampleData().ForEach(print);
            Console.ReadLine();
        }
    }
}

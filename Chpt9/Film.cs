using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt9
{
    public class Film
    {
        public string Name { set; get; }
        public int Year { set; get; }

        public static List<Film> SampleData()
        {
            return new List<Film>() {
                new Film(){ Name="Jaws",Year=1952},
                new Film(){ Name = "Sing in the rain",Year=1959}
            };
        }
    }
}

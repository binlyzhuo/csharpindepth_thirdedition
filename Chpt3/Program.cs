using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chpt3
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeWithField<int>.field = "string";
            TypeWithField<int>.PrintField();


            TypeWithField<DateTime>.field = "Datetime";
            TypeWithField<DateTime>.PrintField();
            Console.ReadLine();
        }
    }

    class TypeWithField<T>
    {
        public static string field;
        public static void PrintField()
        {
            Console.WriteLine(field+":"+typeof(T).Name);
        }
    }
}

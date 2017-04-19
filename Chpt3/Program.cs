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

            PrintTypeOf<int>();

            TypeReflector();

            //GetType();

            List<object> objList = new List<object>();
            List<string> strList = new List<string>();

            //objList = strList;

            Console.ReadLine();
        }

        static void PrintTypeOf<X>()
        {
            Console.WriteLine(typeof(X));
            Console.WriteLine(typeof(List<>));
            Console.WriteLine(typeof(List<X>));
        }

        static void GetType()
        {
            //Person p = new Person("Bin");
            Type t = typeof(Person<int>);
            Type t2=t.GetGenericTypeDefinition();
        }

        static void TypeReflector()
        {
            string listTypeName = "System.Collections.Generic.List`1";
            Type defByName = Type.GetType(listTypeName);

            Type closedByName = Type.GetType(listTypeName + "[System.String]");
            Type closedByMethod = defByName.MakeGenericType(typeof(string));

            Type closedBtTypeOf = typeof(List<string>);
            Console.WriteLine(closedByMethod==closedByName);
            Console.WriteLine(closedByName == closedBtTypeOf);

            //=========================
            Type defByTypeOf = typeof(List<>);
            Type defByMethod = closedByName.GetGenericTypeDefinition();

            Console.WriteLine(defByTypeOf == defByName);
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

    class Person<T>
    {
        public string Name;

        public Person(string name)
        {
            this.Name = name;
        }
        public void Say()
        {
            Console.WriteLine("Say Hello!!");
        }
    }
}

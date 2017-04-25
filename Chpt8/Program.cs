using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chpt8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chpt8");

            Person p1 = new Person("user001",10);
            Person p2 = new Person("user002",20);
            Person p3 = new Person("user003",30);
            p3.Dispose();
            Console.WriteLine(Person.InstanceCounter);
            Console.ReadLine();
        }
    }

    public class Person:IDisposable
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public static int InstanceCounter { set; get; }
        private static readonly object countLocker = new object();

        public Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;

            lock(countLocker)
            {
                InstanceCounter++;
            }
        }

        
        public void Dispose()
        {
            //base.Dispose();
            lock (countLocker)
            {
                InstanceCounter--;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chpt2
{
    class Program
    {
        delegate void StringProcessor(string input);
        static void Main(string[] args)
        {
            StringProcessor p = new StringProcessor(PrintString);
            p += PrintObject;
            p("String");

            Person jon = new Person("Jon");
            Person tom = new Person("Tom");

            StringProcessor jonVoice, tomVoice, background;
            jonVoice = new StringProcessor(jon.Say);
            tomVoice = new StringProcessor(tom.Say);
            background = new StringProcessor(Background.Note);

            jonVoice("Hello,Jon!");
            tomVoice.Invoke("Hello,Tom!");
            background("An airplane files past..");
            Console.ReadLine();
        }

        static void PrintString(string x)
        {
            Console.WriteLine("PrintString:{0}",x);
        }

        static void PrintInt(int x)
        {
            Console.WriteLine("PrintInt:{0}",x);
        }

        static void PrintTwoString(string x,string y)
        {
            Console.WriteLine("String:{0},String:{1}",x,y);
        }

        static int GetStringLen(string s)
        {
            return s.Length;
        }

        static void PrintObject(object obj)
        {
            Console.WriteLine("PrintObject:{0}",obj);
        }
    }

    class Person
    {
        string name;
        public Person(string name)
        {
            this.name = name;
        }

        public void Say(string msg)
        {
            Console.WriteLine("{0} says:{1}",name,msg);
        }
    }

    class Background
    {
        public static void Note(string note)
        {
            Console.WriteLine("({0})",note);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace Chpt6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chpt6.Enumerable");
            var iterable = CreateEnumable();

            var iterator = iterable.GetEnumerator();
            //Console.WriteLine(iterable.Count());
            Console.WriteLine("Sarting to iterate:");
            while(true)
            {
                Console.WriteLine("Calling MoveNext()..");
                bool result = iterator.MoveNext();
                Console.WriteLine("....MoveNext Result={0}",result);
                if(!result)
                {
                    break;
                }

                Console.WriteLine("Fetching Current...");
                Console.WriteLine("....Current result={0}",iterator.Current);
            }

            //==================

            DateTime stop = DateTime.Now.AddSeconds(2);
            foreach(int i in CountWithTimeLimit(stop))
            {
                Console.WriteLine("Received:{0}",i);
                Thread.Sleep(300);
            }

            Console.WriteLine("\n\n...........................");
            PrintResult();

            PrintFile();
            Console.WriteLine("\n\n...........................");
            Console.ReadLine();
        }

        static readonly string Padding = new string(' ',30);
        static IEnumerable<int> CreateEnumable()
        {
            Console.WriteLine("{0}Start of CreateEnumable()",Padding);
            for(int i=0;i<3;i++)
            {
                Console.WriteLine("{0}About to yield {1}",Padding,i);
                yield return i;
                Console.WriteLine("{0}After yield",Padding);
            }
            Console.WriteLine("{0}Yielding final value",Padding);
            yield return -1;
            Console.WriteLine("{0}End of CreateEnumable()",Padding);
        }

        static IEnumerable<int> CountWithTimeLimit(DateTime limit)
        {
            try
            {
                for (int i = 0; i <= 100; i++)
                {
                    if (DateTime.Now > limit)
                    {
                        yield break;
                    }
                    yield return i;
                }
            }
            finally
            {
                Console.WriteLine("Stopping");
            }
            
        }

        static void PrintResult()
        {
            DateTime stop = DateTime.Now.AddSeconds(2);
            foreach(int i in CountWithTimeLimit(stop))
            {
                Console.WriteLine("Received:{0}",i);
                if(i>3)
                {
                    Console.WriteLine("Returning..");
                    return;
                }

                Thread.Sleep(300);
            }
        }

        static void PrintFile()
        {
            using (TextReader reader = File.OpenText("read.txt"))
            {
                string line;
                while((line=reader.ReadLine())!=null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        static IEnumerable<string> ReadLines(Func<TextReader> provider)
        {
            using (TextReader reader = provider())
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        static IEnumerable<string> ReadLines(string fileName, Encoding encoding)
        {
            return ReadLines(delegate {
                return File.OpenText(fileName);
            });
        }
    }
}

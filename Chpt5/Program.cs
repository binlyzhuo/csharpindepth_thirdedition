using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chpt5
{
    class Program
    {
        delegate Stream StreamFactory();
        static void Main(string[] args)
        {
            Console.WriteLine("");

            Button btn = new Button();
            btn.Text = "Click me!!";
            //btn.Click += LogPlainEvent;
            //btn.KeyPress += LogPlainEvent;
            btn.MouseClick += LogMouseEvent;
            Form form = new Form();
            form.Controls.Add(btn);
            form.AutoSize = true;
            Application.Run(form);
            Console.ReadLine();
        }


        static void LogPlainEvent(object obj,EventArgs e)
        {
            Console.WriteLine("LogPlain");
        }

        static void LogKeyEvent(object obj,KeyPressEventArgs e)
        {
            Console.WriteLine("LogKey");
        }

        static void LogMouseEvent(Object obj,MouseEventArgs e)
        {
            Console.WriteLine("LogMouse");

            ThreadStart ts = new ThreadStart(MyMethod);
            ThreadStart ts2 = MyMethod;
            Thread t = new Thread(ts2);
            t.Start();

            StreamFactory factory = GenerateSampleData;
            using (Stream stream = factory())
            {
                int data;
                while((data=stream.ReadByte())!=-1)
                {
                    Console.WriteLine(data);
                }
            }

            //=======================
            EventHandler handler = new EventHandler(LogPlainEvent);
            KeyPressEventHandler keyHandler = new KeyPressEventHandler(handler);

            //==============
            Dervied x = new Dervied();
            SampleDelegate fac = new SampleDelegate(x.CandidateAction);
            fac("TEST!!");

            ActionMethod();

        }



        static void ActionMethod()
        {
            Console.WriteLine("\n\nAction Delegate~\n\n");
            Action<string> printReverse = delegate (string text)
            {
                char[] chars = text.ToCharArray();
                Array.Reverse(chars);
                Console.WriteLine(new string(chars));
            };

            printReverse("HelloWorld!");

            Action<int> printRoot = delegate (int num)
            {
                Console.WriteLine(Math.Sqrt(num));
            };

            printRoot(2);

            Action<IList<double>> printMean = delegate (IList<double> numbers)
            {
                double total = 0d;
                foreach(double d in numbers)
                {
                    total += d;
                }

                Console.WriteLine(total/numbers.Count);
            };

            printMean(new double[] { 1,2,3,4,5,6});
        }

        static void MyMethod()
        {
            Console.WriteLine("MyMethod!!");
        }

        static MemoryStream GenerateSampleData()
        {
            byte[] buffer = new byte[16];
            for(int i=0;i<buffer.Length;i++)
            {
                buffer[i] = (byte)i;
            }

            return new MemoryStream(buffer);
        }


        delegate void SampleDelegate(string x);
        class Snippet
        {
            public void CandidateAction(string x)
            {
                Console.WriteLine("Snippet.CandidateAction");
            }
        }

        class Dervied:Snippet
        {
            public void CandidateAction(object obj)
            {
                Console.WriteLine("Dervied.CandidateAction");
            }
        }
    }
}

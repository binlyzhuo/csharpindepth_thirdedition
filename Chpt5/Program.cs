﻿using System;
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chpt5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");

            Button btn = new Button();
            btn.Text = "Click me!!";
            btn.Click += new EventHandler(LogPlainEvent);
            btn.KeyPress += new KeyPressEventHandler(LogKeyEvent);
            btn.MouseClick += new MouseEventHandler(LogMouseEvent);
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
        }
    }
}

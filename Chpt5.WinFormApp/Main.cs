using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chpt5.WinFormApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 1;
            int y = 2;

            if(x>y)
            {
                string r = "0";
            }

            if(x-y>0)
            {
                string r = "0";
            }
        }
    }
}

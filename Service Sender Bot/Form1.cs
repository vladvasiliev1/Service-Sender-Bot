using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Service_Sender_Bot
{

    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            
            
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Browser.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Browser.StartWork();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Browser.Stop();
        }
    }
}

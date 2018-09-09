using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            s = textBox1.Text;
            double m = double.Parse(s);
            string d = "";
            d = textBox2.Text;
            double n = double.Parse(d);
            double p = m * n;
            textBox3.Text = m +"*" + n + "=" + p;
        }
    }
}

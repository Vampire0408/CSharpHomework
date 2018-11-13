using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderDetails order = new OrderDetails(1, "WX",123456, comboBox1.Text,1 ,1);
            Form1.os.AddOrder(order);
            MessageBox.Show("添加成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Cheese" + "Milk" + "Bread" + "Egg";
            comboBox1.SelectedIndex = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Convert.ToInt32(textBox2.Text);
        }
    }
}

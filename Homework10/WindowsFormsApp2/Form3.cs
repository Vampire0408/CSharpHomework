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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Form1.os.OrderList.Exists(a => a.ordernumber.Equals(textBox1.Text)) )
            {
                Form1.os.DeleteOrder(1);
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("没有此订单！");
                return;
            }
        }
    }
}

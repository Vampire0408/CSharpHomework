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
    public partial class Form1 : Form
    {
        public List<OrderDetails> OrderList = new List<OrderDetails>();
        public static OrderService os = new OrderService();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();            
        }

        private void button2_Click(object sender, EventArgs e)//显示订单按钮
        {
            if (os.OrderList.Count() == 0)
                MessageBox.Show("无订单！");
            orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(os.OrderList);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<OrderDetails> ol = new List<OrderDetails>();
            OrderList = os.OrderList;
            if (OrderList.Count() == 0)
            {
                MessageBox.Show("当前没有订单！");
                return;
            }

            var VirtualOrder = OrderList.Where(a => a.GoodsName.Equals(textBox1.Text));
            if (VirtualOrder.Count() == 0)
            {
                MessageBox.Show("未查询到相关订单！");
                return;
            }

            orderDetailsBindingSource.DataSource = VirtualOrder;
            foreach (OrderDetails a in VirtualOrder)
                ol.Add(a);
            orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(ol[0].OrderList);

        }
    }
}

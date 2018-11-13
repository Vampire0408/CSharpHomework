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
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

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

        private void Button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();            
        }

        private void Button2_Click(object sender, EventArgs e)//显示订单按钮
        {
            if (os.OrderList.Count() == 0)
                MessageBox.Show("无订单！");
            orderDetailsBindingSource.DataSource = new BindingList<OrderDetails>(os.OrderList);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
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

        public bool OrderNumber(string ordernumber)         //核查信息
        {
            bool r1 = Regex.IsMatch(ordernumber, null );
            bool r2 = Regex.IsMatch(ordernumber, "2018[0-12][1-31] + [0-9]{2}");
            return r1 && r2;
        }

        public bool PhoneNumber(string phonenumber)    //核查电话号码
        {
            return Regex.IsMatch(phonenumber, @"[0-9] + \d{6}");
        }

        public static void Export(List<Order> or, string xmlFileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));  //Xml序列化
            using (FileStream fs = new FileStream(xmlFileName, FileMode.Create))
            {
                xmlser.Serialize(fs, or);
            }
        }

        private void Button5_Click(object sender, EventArgs e)   //生成html
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"./OrderList.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslTransform xt = new XslTransform();
                xt.Load(@"./OrderList.xslt");

                FileStream outfileStream = File.OpenWrite(@"./OrderList.html");
                XmlTextWriter writer = new XmlTextWriter(outfileStream,System.Text.Encoding.UTF8);

                xt.Transform(nav, null, writer);
                MessageBox.Show("已实现");
            }

            catch(XmlException wx)
            {
                Console.WriteLine("Xml.Exception: " + wx.ToString());
            }

            catch(XsltException wx)
            {
                Console.WriteLine("Xslt.Exception: " + wx.ToString());
            }
        }
    }
}

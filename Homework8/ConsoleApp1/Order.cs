using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        public int OrderNumber { set; get; }               //订单号
        public string CustomerName { set; get; }             //客户 
        public int CustomerPhoneNumber { set; get; }         //客户电话
        public string GoodsName { set; get; }   //商品名称
        public int GoodsNumber { set; get; }    //商品数量
        public double GoodsPrice { set; get; }  //商品价格
    }
}

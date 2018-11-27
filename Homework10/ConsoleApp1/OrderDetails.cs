using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderDetails:order
    {
        public OrderDetails()
        {

        }
        public OrderDetails(int OrderNumber, string CustomerName, string GoodsName, int GoodsNumber, double GoodsPrice)  //重载构造函数 对订单进行初始化
        {
            this.ordernumber = OrderNumber;
            this.customername = CustomerName;
            this.goodsname = GoodsName;
            this.goodsnumber = GoodsNumber;
            this.goodsprice = GoodsPrice;
        }
        public List<OrderDetails> OrderList = new List<OrderDetails>();        //创建列表
    }
}

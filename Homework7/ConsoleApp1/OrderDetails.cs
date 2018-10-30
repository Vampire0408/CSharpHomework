using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderDetails:Order
    {
        public OrderDetails()
        {

        }
        public OrderDetails(int OrderNumber, string CustomerName, string GoodsName, int GoodsNumber, double GoodsPrice)  //重载构造函数 对订单进行初始化
        {
            this.OrderNumber = OrderNumber;
            this.CustomerName = CustomerName;
            this.GoodsName = GoodsName;
            this.GoodsNumber = GoodsNumber;
            this.GoodsPrice = GoodsPrice;
        }
        public List<OrderDetails> OrderList = new List<OrderDetails>();        //创建列表
    }
}

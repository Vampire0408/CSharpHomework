using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        List<OrderDetails> OrderList = new List<OrderDetails>();        //创建列表
        OrderDetails First = new OrderDetails(01, "wx1", "Cheese", 1, 10);         //设置订单信息
        OrderDetails Second = new OrderDetails(02, "wx2", "Bread", 1, 5);
        OrderDetails Third = new OrderDetails(03, "wx3", "Milk", 2, 5);

        [TestMethod()]
        public void AddOrderTest()                                 //添加订单测试
        {
            OrderService Oporder = new OrderService();
            Oporder.AddOrder(Third);
            OrderDetails order1 = OrderList.Last();
            OrderDetails order2 = OrderList.First();
            Assert.AreSame(Third, order1);
            Assert.AreNotSame(Third, order2);
        }

        [TestMethod()]
        public void DeleteOrderTest()                          //删除订单测试
        {
            OrderService Oporder = new OrderService();
            Oporder.DeleteOrder(01);
            OrderDetails order1 = OrderList.First();
            Assert.AreSame(Second, order1);
            Assert.AreNotSame(First, order1);
        }

        [TestMethod()]
        public void ChangeOrderTest()               //修改订单测试
        {
            OrderService Oporder = new OrderService();
            Oporder.ChangeOrder(01, 5);
            int n = First.GoodsNumber;
            Assert.AreSame(n, 5);
            Assert.AreNotSame(n, 5);
        }

        [TestMethod()]
        public void SearchOrder1Test()                             //查询订单测试（根据订单号）
        {
            OrderService Oporder = new OrderService();
            Oporder.SearchOrder1(01);
        }



    }
}
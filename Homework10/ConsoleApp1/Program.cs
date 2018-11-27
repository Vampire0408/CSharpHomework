using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestClass
    {
        static void Main()
        {
            OrderDetails First = new OrderDetails(01, "wx1", "Cheese", 1, 10);         //设置订单信息
            OrderDetails Second = new OrderDetails(02, "wx2", "Bread", 1, 5);
            OrderDetails Third = new OrderDetails(03, "wx3", "Milk", 2, 5);
            OrderService Oporder = new OrderService();
            Oporder.AddOrder(Third);                         //添加订单
            Oporder.DeleteOrder(11);                         //删除订单
            Oporder.ChangeOrder(First);                      //修改订单
            Oporder.SearchOrder2("wx21");                    //查找订单

            OrderDetails[] arr = { First, Second, Third };           //筛选出订单金额大于1000的
            var m = arr.Where(a => a.goodsprice > 1000);
            Console.WriteLine(m);
            var n = from x in arr                                     //按照商品名查找订单
                    select x.goodsname;
            foreach (string i in n)
            {
                Console.WriteLine(i);
            }
            var p = from w in arr                                     //按照顾客名查找订单
                    select w.customername;
            foreach (string c in p)
            {
                Console.WriteLine(c);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderService
    {
        public List<OrderDetails> OrderList = new List<OrderDetails>();        //创建列表

        public void regist(int num)                                     //异常处理
        {
            if (num < 0 || num > OrderList.Count)
            {
                Console.WriteLine("订单号" + num);
                throw new MyException("订单不存在，不合理", 0);
            }
        }
        public void manager()
        {
            try
            {
                regist(12);
            }
            catch (MyException e)
            {
                Console.WriteLine("失败，出错种类" + e.getId());
            }
            Console.WriteLine("结束");
        }

        public void AddOrder(OrderDetails last)                          //增加订单
        {
            OrderList.Add(last);
        }

        public void DeleteOrder(int Number)                              //删除订单
        {
            int m = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (Number == OrderList[i].OrderNumber)
                {
                    OrderList.Remove(OrderList[i]);
                    m++;
                }
            }
            if (m == 0)
            {
                Console.WriteLine("未查到该订单,删除失败");
            }
        }

        public void ChangeOrder(int Number, int newNumber)               //修改订单
        {
            int m = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (Number == OrderList[i].OrderNumber)
                {
                    OrderList[i].GoodsNumber = newNumber;
                    m++;
                }
            }
            if (m == 0)
            {
                Console.WriteLine("未查找到该商品，修改失败");
            }
        }

        public void SearchOrder1(int Number)                             //查询订单（根据订单号）
        {
            int m = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (Number == OrderList[i].OrderNumber)
                {
                    Console.WriteLine(" 商品名称： " + OrderList[i].GoodsName +
                                      " 商品数量： " + OrderList[i].GoodsNumber +
                                      " 商品价格： " + OrderList[i].GoodsPrice);
                    m++;
                }
            }
            if (m == 0)
            {
                Console.WriteLine("未找到该订单");
            }
        }

        public void SearchOrder2(string Name)                         //查询订单（根据商品名称或客户名）
        {
            int m = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (Name == OrderList[i].CustomerName || Name == OrderList[i].GoodsName)
                {
                    Console.WriteLine(" 商品名称： " + OrderList[i].GoodsName +
                                      " 商品数量： " + OrderList[i].GoodsNumber +
                                      " 商品价格： " + OrderList[i].GoodsPrice);
                    m++;
                }
            }
            if (m == 0)
            {
                Console.WriteLine("未找到该订单");
            }
        }
    }
}

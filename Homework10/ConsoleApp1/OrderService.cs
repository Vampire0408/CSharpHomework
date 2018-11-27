using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void AddOrder(OrderDetails order)                          //增加订单
        {
            using (var db = new Model1())
            {
                db.order.Add(order);
                db.SaveChanges();
            }
        }

        public void DeleteOrder(int Number)                              //删除订单
        {
            using (var db = new Model1())
            {

                var order = db.order.Include("Details").SingleOrDefault(or => or.ordernumber.Equals(Number));
                foreach (var good in order.Items)
                {
                    db.OrderItem.Remove(good);
                }

                db.OrderItem.RemoveRange(order.Items);
                db.order.Remove(order);
                db.SaveChanges();
            }
        }

        public void ChangeOrder(order order)               //修改订单
        {
            using (var db = new Model1())
            {
                db.order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.Items.ForEach(item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public order SearchOrder1(int Number)                             //查询订单（根据订单号）
        {
            using (var db = new Model1())
            {
                return db.order.Include("Items").SingleOrDefault(or => or.ordernumber == Number);
            }
        }

        public order SearchOrder2(string Name)                         //查询订单（根据商品名称或客户名）
        {
            using (var db = new Model1())
            {
                return db.order.Include("Items").
                  SingleOrDefault(or => or.goodsname == Name || or.customername == Name);
            }
        }

        public List<order> GetAllOrders()                   //显示所有订单
        {
            //using (var db = new OrderDB())
            //{
            //    return db.Order.Include("items").ToList<Order>();
            //}
            using (var db = new Model1())
            {

                db.OrderDetails.Include("Goods").ToList<OrderDetails>();
                db.order.Include("details").ToList<order>();
                return db.order.Include("items").ToList<order>();
            }
        }
    }
}

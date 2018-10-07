using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MyException : ApplicationException       //自定义异常类
{
    private int IdNumber;
    public MyException(String message, int id)
        : base(message)
    {
        this.IdNumber = id;
    }
    public int getId()
    {
        return IdNumber;
    }
}

public class Order                          //创建订单类
{
    public int OrderNumber;                 //订单号
    public string CustomerName;             //客户 
    public string GoodsName { set; get; }   //商品名称
    public int GoodsNumber { set; get; }    //商品数量
    public double GoodsPrice { set; get; }  //商品价格
}

public class OrderDetails : Order
{
    public OrderDetails(int OrderNumber, string CustomerName, string GoodsName, int GoodsNumber, double GoodsPrice)  //重载构造函数 对订单进行初始化
    {
        this.OrderNumber = OrderNumber;
        this.CustomerName = CustomerName;
        this.GoodsName = GoodsName;
        this.GoodsNumber = GoodsNumber;
        this.GoodsPrice = GoodsPrice;
    }
}

public class OrderService
{
    List<OrderDetails> OrderList = new List<OrderDetails>();        //创建列表

    public void regist(int num)                                     //异常处理
    {
        if (num < 0 ||num > OrderList.Count)
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
        Oporder.ChangeOrder(11, 5);                      //修改订单
        Oporder.SearchOrder2("wx21");                    //查找订单
    }
}
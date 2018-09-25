using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Shape
{
    private string myId;
    public Shape(string s)
    {
        Id = s;
    }
    public string Id              //类型
    {
        get
        {
            return myId;
        }
        set
        {
            myId = value;
        }
    }
    public abstract double Area             //面积 抽象属性
    {
        get;
    }
    public override string ToString()        //覆盖object的虚方法
    {
        return Id + "Area = " + string.Format("{0:F2}", Area);
    }
}

//正方形类
public class Square : Shape
{
    private int mySide;       //边长
    public Square(int side,string id):base(id)
    {
        mySide = side;
    }
    public override double Area      //实现面积
    {
        get
        {
            return mySide * mySide;
        }
    }
}

//圆类
public class Circle : Shape
{
    private int myRadius;             //半径
    public Circle(int radius,string id):base(id)
    {
        myRadius = radius;
    }
    public override double Area         //实现面积
    {
        get
        {
            return myRadius * myRadius * System.Math.PI;
        }
    }
}

//矩形类
public class Rectangle : Shape
{
    private int myWidth;            //设置宽高
    private int myHeight;

    public Rectangle(int width,int height,string id):base(id)
    {
        myWidth = width;
        myHeight = height;
    }
    public override double Area               //实现面积
    {
        get
        {
            return myWidth * myHeight;
        }
    }
}

//三角形类
public class Triangle : Shape
{
    private int mySide1;             //设置边长
    private int mySide2;
    private int mySide3;
    private int p;
    public Triangle(int side1,int side2,int side3,string id):base(id)
    {
        mySide1 = side1;
        mySide2 = side2;
        mySide3 = side3;
        p = (mySide1 + mySide2 + mySide3)/2;
    }
    public override double Area         //实现面积
    {
        get
        {
            return Math.Sqrt(p * (p - mySide1) * (p - mySide2) * (p - mySide3));
        }
    }
}

//实现
public class TestClass
{
    public static void Main()
    {
        Shape[] shapes =
        {
            new Square(5,"Square #1"),
            new Circle(3,"Circle #1"),
            new Rectangle(4,5,"Rectangle #1"),
            new Triangle(3,4,5,"Triangle #1")
        };

        System.Console.WriteLine("Shape Collection");
        foreach(Shape s in shapes)
        {
            System.Console.WriteLine(s);
        }
    }
}
      
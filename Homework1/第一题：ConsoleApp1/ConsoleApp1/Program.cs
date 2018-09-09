using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int n = 0;
            int d = 0;
            Console.WriteLine("Please input an number:");
            s = Console.ReadLine();
            n = Int32.Parse(s);
            Console.WriteLine("Please input an number:");
            s = Console.ReadLine();
            d = Int32.Parse(s);
            Console.WriteLine("The product of the two number is " + (n * d));
        }
    }
}

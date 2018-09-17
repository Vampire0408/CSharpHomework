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
            Console.WriteLine("Please input a number: ");
            string s = Console.ReadLine();
            int n = Int32.Parse(s);
            int i = 2;
            while (n >= i)
            {
                if (n % i == 0)
                {
                    n = n / i;
                    Console.WriteLine(i);
                }
                else
                    i++;
            }
        }
    }
}

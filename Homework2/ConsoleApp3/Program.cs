using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 0;
            for(int i = 2; i<=100;i++)
            {
                for(int j = 2;j <= i; j++)
                {
                    if((i % j ==0) && (i != j))
                    {
                        m = i;
                        break;
                    }
                }
                if(i != m)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

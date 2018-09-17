using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 12, 13, 5, 81, 64, 91, 2, 17, 20 };
            int aMax = numbers[0];
            for(int i = 0;i < numbers.Length ; i++)
            {
                if(numbers[i+1] > aMax)
                {
                    aMax = numbers[i + 1];
                }
            }
            Console.WriteLine(aMax);
            int aMin = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i + 1] < aMin)
                {
                    aMin = numbers[i + 1];
                }
            }
            Console.WriteLine(aMin);
            int aSum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                aSum = numbers[i];
            }
            Console.WriteLine(aSum);
            int n = (aSum / numbers.Length);
            Console.WriteLine(n);
        }
    }
}

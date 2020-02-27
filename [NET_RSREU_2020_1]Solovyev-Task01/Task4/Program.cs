using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Введите число звеньев ёлки");
            n = int.Parse(Console.ReadLine()) + 1;
            for (int i=1; i<=n; i++)
            {
                for (int j=1; j<i; j++)
                {
                    for (int k = n - 1; k > j; k--) Console.Write(" ");
                    for (int k = 0; k < (j*2)-1; k++) Console.Write("*");
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}

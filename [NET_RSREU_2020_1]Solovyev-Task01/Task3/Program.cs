using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Число строк: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = n; j > i; j--) Console.Write(" ");
                for (int j = 0; j <= (i*2); j++) Console.Write("*");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

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
            int[,] Mas = new int[8, 8];
            int sum = 0;
            Random r = new Random();
            Console.WriteLine("Двумерный массив: ");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0,4} ", Mas[i, j] = r.Next(0, 100));
                    if (i + j % 2 == 0) sum += Mas[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сумма: {0}", sum);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] Mas = new int[2,4,8];
            Random r = new Random();
            Console.WriteLine("Изначальный трехмерный массив: ");
            for (int i=0; i<2; i++)
            {
                Console.WriteLine("Матрица {0}", i);
                for (int j=0; j<4; j++)
                {
                    for (int k = 0; k < 8; k++) 
                        Console.Write("{0,4} ", Mas[i, j, k] = r.Next(-100, 100));
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Полученный трехмерный массив: ");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Матрица {0}", i);
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        if (Mas[i, j, k] > 0) Mas[i, j, k] = 0;
                        Console.Write("{0,4} ", Mas[i, j, k]);
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}

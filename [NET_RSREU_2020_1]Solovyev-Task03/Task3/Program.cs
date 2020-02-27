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
            int[] mas = new int[32];
            int sum = 0;
            Random r = new Random();
            Console.WriteLine("Массив:");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write("{0} ", mas[i] = r.Next(-100, 100));
                if (i >= 0) sum += mas[i];
            }
            Console.WriteLine();
            Console.WriteLine("Сумма: {0}", sum);
            Console.ReadKey();
        }
    }
}

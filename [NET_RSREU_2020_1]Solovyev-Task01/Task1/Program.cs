using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            Console.Write("Введите сторону а: ");
            a = double.Parse(Console.ReadLine());

            Console.Write("Введите сторону b: ");
            b = double.Parse(Console.ReadLine());

            if (a <= 0 || b <= 0)
            {
                Console.WriteLine("Вводить можно только положительные числа");
                return;
            }

            c = a * b;
            Console.WriteLine("Площадь прямоугольника: {0}", c);
            Console.ReadKey();
        }
    }
}

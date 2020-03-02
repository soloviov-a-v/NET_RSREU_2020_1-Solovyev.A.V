using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        private static void cultureCompare(CultureInfo c1, CultureInfo c2)
        {
            Console.WriteLine("{0,20} {1,25} {2,25}", "Название", c1.Name, c2.Name);
            Console.WriteLine("{0,20} {1,25} {2,25}", "Дата", DateTime.Now.ToString("d", c1), DateTime.Now.ToString("d", c2));
            Console.WriteLine("{0,20} {1,25} {2,25}", "Время", DateTime.Now.ToString("t", c1), DateTime.Now.ToString("t", c2));
            Console.WriteLine("{0,20} {1,25} {2,25}", "Разделитель груп", c1.NumberFormat.NumberGroupSeparator, c2.NumberFormat.NumberGroupSeparator);
            Console.WriteLine("{0,20} {1,25} {2,25}", "Разделитель числа", c1.NumberFormat.NumberDecimalSeparator, c2.NumberFormat.NumberDecimalSeparator);
        }
        static void Main(string[] args)
        {
            CultureInfo c1 = new CultureInfo("ru");
            CultureInfo c2 = new CultureInfo("en");
            CultureInfo c3 = new CultureInfo("");
            cultureCompare(c1, c2);
            cultureCompare(c2, c3);
            cultureCompare(c1, c3);
            Console.ReadKey();
        }
    }
}

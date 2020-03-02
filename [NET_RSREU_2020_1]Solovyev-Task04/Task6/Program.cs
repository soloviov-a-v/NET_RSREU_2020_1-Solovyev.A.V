using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            string num = Console.ReadLine();
            Regex r1 = new Regex(@"(-?[0-9]+([.][0-9]*)?)");
            Regex r2 = new Regex(@"(-?[0-9]+([.][0-9]*)?[e]-?[0-9]+)");
            if (r1.Matches(num).Count == 1) Console.WriteLine("Это число в обычной нотации");
            else if (r2.Matches(num).Count == 1) Console.WriteLine("Это число в научной нотации");
            else Console.WriteLine("Это не число");
            Console.ReadKey();
        }
    }
}

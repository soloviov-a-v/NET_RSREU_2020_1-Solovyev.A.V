using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");
            string str = Console.ReadLine();
            Regex r = new Regex(@"([0-2]?[0-9][:][0-5][0-9])");
            Console.WriteLine("Время встречается {0} раз", r.Matches(str).Count);
            Console.ReadKey();
        }
    }
}

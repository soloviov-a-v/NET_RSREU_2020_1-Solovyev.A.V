using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите HTML текст: ");
            string str = Console.ReadLine();
            Regex r = new Regex(@"<([^<>]*)>");
            MatchCollection m = r.Matches(str);
            while (m.Count != 0)
            {
                str = str.Remove(m[0].Index, m[0].Length);
                str = str.Insert(m[0].Index, "_");
                m = r.Matches(str);
            }
            Console.Write("Результат замены: ");
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}

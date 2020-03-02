using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку 1: ");
            string str1 = Console.ReadLine();
            string str1_copy = str1;
            Console.Write("Введите строку 2: ");
            string str2 = Console.ReadLine();

            int j = 1;
            for (int i=0; i<str1_copy.Length; i++)
            {
                string s = "" + str1_copy[i];
                if (str2.IndexOf(s) != -1)
                {
                    str1 = str1.Insert(j, s);
                    j++;
                }
                j++;
            }
            Console.WriteLine(str1);
            Console.ReadKey();
        }
    }
}

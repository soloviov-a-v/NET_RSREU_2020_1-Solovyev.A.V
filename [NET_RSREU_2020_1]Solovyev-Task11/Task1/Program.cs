using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("30! = " + Library.Factorial(30));
            Console.WriteLine("2^8 = " + Library.Pow(2, 8));
            Console.ReadKey();
        }
    }
}
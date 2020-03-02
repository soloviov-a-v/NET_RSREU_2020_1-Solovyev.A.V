using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            StringBuilder sb = new StringBuilder("");
            Stopwatch w = new Stopwatch();
            w.Start();
            for (int i = 0; i < 100000; i++) str += "+";
            w.Stop();
            Console.WriteLine("string: {0}", w.ElapsedMilliseconds.ToString());
            w.Reset();
            w.Start();
            for (int i = 0; i < 100000; i++) sb.Append("+");
            w.Stop();
            Console.WriteLine("StringBuilder: {0}", w.ElapsedMilliseconds.ToString());
            Console.ReadKey();
        }
    }
}

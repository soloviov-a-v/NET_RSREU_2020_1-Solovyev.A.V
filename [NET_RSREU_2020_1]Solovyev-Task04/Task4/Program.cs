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
            for (int i = 0; i < 10; i++) str += "+";
            w.Stop();
            Console.WriteLine("string: {0}", w.ElapsedTicks.ToString());
            w.Reset();
            w.Start();
            for (int i = 0; i < 10; i++) sb.Append("+");
            w.Stop();
            Console.WriteLine("StringBuilder: {0}", w.ElapsedTicks.ToString());
            Console.ReadKey();
        }
    }
}

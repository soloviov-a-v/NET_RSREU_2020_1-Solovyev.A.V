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
            int[] mas = new int[32];
            int min=0, max=0;
            Random r = new Random();
            Console.WriteLine("Изначальный массив:");
            for (int i=0; i<mas.Length; i++)
            {
                Console.Write("{0} ", mas[i] = r.Next(0, 100));
                if (mas[i] < min || i == 0) min = mas[i];
                if (mas[i] > max || i == 0) max = mas[i];
                
            }
            Console.WriteLine("Минимум: {0}", min);
            Console.WriteLine("Максимум: {0}", max);
            for (int i=0; i<mas.Length; i++)
                for (int j=0; j<i; j++)
                    if (mas[i] < mas[j])
                    {
                        int Buf = mas[i];
                        mas[i] = mas[j];
                        mas[j] = Buf;
                    }
            Console.WriteLine("Сортированный массив:");
            for (int i = 0; i < mas.Length; i++)
                Console.Write(mas[i] + " ");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{

    class Program
    {
        public event EventHandler<string[]> SortingEnd;
        delegate bool Operation(string s1, string s2);
        private static void SortingEnds(object sender, string[] e)
        {
            Console.WriteLine("\nСортировка закончена.");

            for (int i = 0; i < e.Length; i++)
                Console.WriteLine(e[i]);
        }
        private static bool is1tStringLengerThen2String(string s1, string s2)
        {
            return s1.Length > s2.Length || (s1.Length == s2.Length && string.Compare(s1, s2) == 1);
        }
        void SortArrayByLength(string[] array, Operation compare, string a)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (compare(array[i], array[j]))
                    {
                        string Buf = array[i];
                        array[i] = array[j];
                        array[j] = Buf;
                    }
                    Thread.Sleep(200);
                    Console.WriteLine(a);
                }


            //SortingEnd += SortingEnds;
            SortingEnd?.Invoke(this, array);
            //SortingEnd -= SortingEnds;
            Console.WriteLine("\nСортировка ниже выполнилась в потоке " + Thread.CurrentThread.Name);
        }
        void SortingInSeparateThread(string[] strArr, Operation compare)
        {
            Thread t = new Thread(() => SortArrayByLength(strArr, compare, "доп поток"));
            t.Name = "Дополнительный поток";
            t.Start();
            //t.Join();
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Thread.CurrentThread.Name = "Основной поток";
            
            string[] stringArray1 = new string[] { "2", "1", "ффfфф", "фыва", "пролджэ", "22222" };
            string[] stringArray2 = new string[] { "2", "1", "ффfфф", "фыва", "пролджэ", "22222" };
            p.SortingEnd += SortingEnds;
            p.SortingInSeparateThread(stringArray1, is1tStringLengerThen2String);


           // for (int i = 0; i < stringArray1.Length; i++)
           //     Console.WriteLine(stringArray1[i]);


            p.SortArrayByLength (stringArray2, is1tStringLengerThen2String, "осн поток");
            //for (int i = 0; i < stringArray2.Length; i++)
           //     Console.WriteLine(stringArray2[i]);
            Console.ReadKey();
        }
    }
}

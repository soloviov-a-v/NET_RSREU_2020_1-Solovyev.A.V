using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        // ght
        delegate bool Comparation(string s1, string s2);
        private static bool CompareStrings(string s1, string s2)
        {
            return s1.Length > s2.Length || (s1.Length == s2.Length && string.Compare(s1, s2) == 1);
        }
        private static void SortStringArrayByLength(ref string[] Array, Comparation compare)
        {
            for (int i = 0; i < Array.Length; i++)
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (compare(Array[i], Array[j]))
                    {
                        String Buf = Array[i];
                        Array[i] = Array[j];
                        Array[j] = Buf;
                    }
                }
        }
        static void Main(string[] args)
        {
            string[] stringArray = new string[] { "1", "2", "фффф", "фыва", "пролджэ", "22222" };
            Comparation compare = CompareStrings;
            SortStringArrayByLength(ref stringArray, compare);
            for (int i = 0; i < stringArray.Length; i++)
                Console.WriteLine(stringArray[i]);
            Console.ReadLine();
        }
    }
}

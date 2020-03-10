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
            Console.WriteLine("Введите строку: ");
            int sumWordLengths = 0, wordCount = 0;
            string str = Console.ReadLine();

            string[] words = str.Split(new char[] { ' ', ',', '-', '.', '/', ':'});
            foreach (string word in words) if (!string.IsNullOrEmpty(word))
                {
                    wordCount++;
                    sumWordLengths += word.Length;
                }

            double avLength = (double)sumWordLengths / (double)wordCount;
            Console.WriteLine("Средняя длина слова: {0}", avLength);
            Console.ReadKey();
        }
    }
}

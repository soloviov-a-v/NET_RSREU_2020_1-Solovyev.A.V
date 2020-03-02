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
            int wordCount = 0, sumWordLengths = 0;
            string str = Console.ReadLine();
            for (int i = 0; i < str.Length; i += 0)
            {
                char s = str[i];
                bool u = !Char.IsLetter(s) && s!=' ';
                if (u) 
                    str = str.Remove(i, 1); 
                else i++;
            }
            do
            {
                string word;
                if (str.IndexOf(" ") != -1) word = str.Substring(0, str.IndexOf(" "));
                else word = str;
                if (word.Length != 0) wordCount++;
                sumWordLengths += word.Length;
                if (str.IndexOf(" ") != -1) str = str.Remove(0, str.IndexOf(" ") + 1);
                else break;
            } while (true);

            double avLength = (double)sumWordLengths / (double)wordCount;
            Console.WriteLine("Средняя длина слова: {0}", avLength);
            Console.ReadKey();
        }
    }
}

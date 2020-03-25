using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // добвить словарь
            string text = "Hello world! Hello guys! Hi all! How are you guys?";
            Console.WriteLine(text);
            List<string> words = new List<string>(Regex.Split(text, @"[\W|\W\s|\s]"));
            List<int> wordsCount = new List<int>();
            for (int k = 0; k < words.Count; k++) words[k].ToUpper();
            ;
            int count = 0;
            for (int i = 0; i < words.Count; i++)
            {
                for (int j = i + 1; j < words.Count; j++)
                {
                    if (string.Compare(words[i], words[j], false) == 0)
                    {
                        words.RemoveAt(j);
                        count++;
                    }
                }
                wordsCount.Add(count);
                count = 0;
            }
            for (int i = 0; i < words.Count; i++)
            {
                if (string.IsNullOrEmpty(words[i])) continue;
                Console.WriteLine("Слово {0} встречается {1} раз", words[i], wordsCount[i] + 1);
            }
                
            Console.ReadLine();
        }
    }
}

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
            string text = "Hello world! hello guys! Hi all! How are you guys?";
            Console.WriteLine(text);

            //Dictionary<string, int> wordsAndTheirsCount = new Dictionary<string, int>();

            List<string> words = new List<string>(Regex.Split(text, @"[\W|\W\s|\s]"));
            Dictionary<string, int> wordsAndTheirsCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word)) continue;
                //int i;
                if (wordsAndTheirsCount.ContainsKey(word)) 
                    wordsAndTheirsCount[word]++;
                else 
                    wordsAndTheirsCount.Add(word, 1);
            }

            foreach (KeyValuePair<string, int> pair in wordsAndTheirsCount)
            {
                Console.WriteLine("Слово {0} встречается {1} раз", pair.Key, pair.Value);
            }

            Console.ReadLine();
        }
    }
}

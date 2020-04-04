using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            List<string> linesFromFile = new List<string>(File.ReadAllLines("disposable_task_file.txt", Encoding.UTF8));
            for(int i=0; i<linesFromFile.Count; i++)
            {
                string[] words = linesFromFile[i].Split(" ,/.!?-=".ToCharArray());
                foreach (string word in words)
                    if (int.TryParse(word, out n))
                        linesFromFile[i] = linesFromFile[i].Replace(word, Math.Pow(n, 2).ToString());
            }
            File.WriteAllLines("disposable_task_file.txt", linesFromFile, Encoding.UTF8);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        private class AdvancedString
        {
            protected char[] str;
            public AdvancedString(string value)
            { 
                str = new char[value.Length];
                for (int i = 0; i < value.Length; i++) str[i] = value[i];
                Length = str.Length;
            }
            public int Length;

            protected AdvancedString(AdvancedString a, string b)
            {
                str = new char[a.Length + b.Length];
                for (int i = 0; i < str.Length; i++) if (i < a.Length) str[i] = a.str[i]; else str[i] = b[i - a.Length];
                Length = str.Length;
            }

            public static AdvancedString operator +(AdvancedString a, string b) => new AdvancedString(a, b);
            public static AdvancedString operator -(AdvancedString a, string b)
            {
                AdvancedString nstr = new AdvancedString("");
                bool changed = false;
                for (int i = 0; i < a.str.Length; i++)
                {
                    bool ext = false;
                    int start = i, stop = i + b.Length;
                    for (int j = 0; j < b.Length; j++) if (a.str[i + j] != b[j])
                        {
                            ext = true;
                            char c1 = a.str[i + j];
                            char c2 = b[j];
                            break;
                        }
                    if (ext) continue;
                    changed = true;
                    nstr.str = new char[a.Length - b.Length];
                    int p = 0;
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (j < start || j > stop)
                        {
                            nstr.str[p] = a.str[j]; p++;
                        }
                    }
                    nstr.Length = nstr.str.Length;
                    break;
                }
                if (!changed)
                {
                    nstr.str = new char[a.Length];
                    for (int i = 0; i < a.Length; i++) nstr.str[i] = a.str[i];
                    nstr.Length = nstr.str.Length;
                }
                return nstr;
            }
            public static bool operator ==(AdvancedString a, AdvancedString b)
            {
                if (a.Length != b.Length) return false;
                for (int i = 0; i < a.Length; i++) if (a.str[i] != b.str[i]) return false;
                return true;
            }
            public static bool operator !=(AdvancedString a, AdvancedString b)
            {
                if (a.Length != b.Length) return true;
                for (int i = 0; i < a.Length; i++) if (a.str[i] != b.str[i]) return true;
                return false;
            }
            public override string ToString()
            {
                string s = "";
                for (int i = 0; i < str.Length; i++) s += str[i];
                return s;
            }
        }
        static void Main(string[] args)
        {
            AdvancedString advs1 = new AdvancedString("пажилой");
            advs1 += " крол";
            Console.WriteLine(advs1);

            AdvancedString advs2 = new AdvancedString("пажилой кролик");
            advs2 -= "ик";
            Console.WriteLine(advs2);

            if (advs1 == advs2) Console.WriteLine("Строки равны"); else Console.WriteLine("Строки не равны");
            Console.ReadKey();
        }
    }
}

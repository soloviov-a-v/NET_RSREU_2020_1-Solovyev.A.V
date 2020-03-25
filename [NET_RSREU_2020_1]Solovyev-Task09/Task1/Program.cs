using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        private static void RemoveEachSecondItem<T>(ref ICollection<T> list)
        {
            List<T> secondList = new List<T>(list);
            bool check = false;
            while (list.Count > 1)
            {
                foreach (T element in list)
                {
                    if (check) secondList.Remove(element);
                    check = !check;
                    /*if (check == false)
                        check = true;
                    else
                        check = false;*/
                }
                list = new List<T>(secondList) as ICollection<T>;
            }
            ;
        }
        static string AllElements<T>(ICollection<T> list)
        {
            StringBuilder str = new StringBuilder();
            foreach (T element in list) str.Append(element.ToString() + " ");
            return str.ToString();
        }
        static void Main(string[] args)
        {
            ICollection<string> list = new List<string>() { "Артем", "Боря", "Вова", "Глеб" , "Данил", "Евгений", "Жора", "Захар" };
            ICollection<string> linkedList = new LinkedList<string>(list);
            Console.WriteLine("List: " + AllElements(list));
            Console.WriteLine("LinkedList: " + AllElements(linkedList));
            RemoveEachSecondItem(ref list);
            RemoveEachSecondItem(ref linkedList);
            Console.WriteLine("Оставшийся элемент в List: " + AllElements(list));
            Console.Write("Оставшийся элемент в LinkedList: " + AllElements(linkedList));
            Console.ReadKey();
        }
    }
}

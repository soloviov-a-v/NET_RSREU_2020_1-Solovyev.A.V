using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        class Office : HashSet<Person> { }
        public delegate void officeEvent(object sender, DateTime dateTime);
        class Person
        {
            private string name;
            private event officeEvent came;
            private event officeEvent left;
            private Office office;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public Person(string name, Office office) { this.Name = name; this.office = office; }
            public void Greeting(string name, DateTime dateTime)
            {
                StringBuilder str = new StringBuilder("");
                str.Append(this.name);
                str.Append(" сказал: ");
                if (dateTime.Hour < 12) str.Append("доброе утро, ");
                else if (dateTime.Hour > 17) str.Append("добрый вечер, ");
                else str.Append("добрый день, ");
                str.Append(name);
                Console.WriteLine(str);
            }
            public void Parting(string name)
            {
                Random R = new Random();
                int r = R.Next(0, 5);
                switch (r){
                    default: Console.WriteLine("{0} сказал: до свидания, {1}", this.name, name); break;
                    case 1: Console.WriteLine("{0} сказал: всего доброго, {1}", this.name, name); break;
                    case 2: Console.WriteLine("{0} сказал: счастливо, {1}", this.name, name); break;
                    case 3: Console.WriteLine("{0} сказал: хорошего дня, {1}", this.name, name); break;
                    case 4: Console.WriteLine("{0} сказал: до встречи, {1}", this.name, name); break;
                }
            }
            public void Came(DateTime time)
            {
                Console.WriteLine($"*На работу пришёл {name}*");
                foreach (Person p in office)
                {
                    came += (sender, time1) => { p.Greeting(this.Name, time); };
                }
                came?.Invoke(this, time);
                office.Add(this);
                came = null;
                Console.WriteLine();
            }
            public void Leave()
            {
                Console.WriteLine($"*{name} ушёл домой*");
                office.Remove(this);
                foreach (Person p in office)
                {
                    left += (sender, time1) => { p.Parting(this.Name); };
                }
                left?.Invoke(this, DateTime.Now);
                left = null;
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Office office = new Office();
            Person Ivan = new Person("Ваня", office);
            Person Anatoly = new Person("Толян", office);
            Person Boss = new Person("Дмитрий Сергеевич", office);
            Ivan.Came(DateTime.Now);
            Anatoly.Came(DateTime.Now);
            Boss.Came(DateTime.Now);
            Boss.Leave();
            Ivan.Leave();
            Anatoly.Leave();
            Console.ReadLine();
        }
    }
}

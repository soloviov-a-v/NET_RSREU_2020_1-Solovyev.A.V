using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public delegate void officeEvent(object sender, DateTime dateTime);

    public class OfficeEventArgs : EventArgs
    {
        public String Name;
        public DateTime Time;
        public OfficeEventArgs(string Name, DateTime Time) 
        {
            this.Name = Name; 
            this.Time = Time;
        }
    }

    public class Office
    {
        public event EventHandler<OfficeEventArgs> PersonComes;
        public event EventHandler<OfficeEventArgs> PersonLeaves;

        public void Come(Person person)
        {
            Console.WriteLine($"*На работу пришел {person.Name}*");
            if (PersonComes != null)
            {
                PersonComes.Invoke(this, new OfficeEventArgs(person.Name, DateTime.Now));
            }
            PersonComes += person.Greet;
            PersonLeaves += person.Part;
        }

        public void Leave(Person person)
        {
            PersonComes -= person.Greet;
            PersonLeaves -= person.Part;
            Console.WriteLine($"*{person.Name} Ушёл с работы*");
            if (PersonLeaves != null)
            {
                PersonLeaves.Invoke(this, new OfficeEventArgs(person.Name, DateTime.Now));
            }
        }
    }

    public class Person
    {
        private string name;
        //private event officeEvent came;
        //private event officeEvent left;
        //private List<Person> office;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Person(string name) { this.Name = name; }
        /*
        public void Greeting(string name, DateTime dateTime)
        { // эти методы должны подписываться на делегат
            StringBuilder str = new StringBuilder("");
            str.Append(this.name);
            str.Append(" сказал: ");
            if (dateTime.Hour < 12) str.Append("доброе утро, ");
            else if (dateTime.Hour > 17) str.Append("добрый вечер, ");
            else str.Append("добрый день, ");
            str.Append(name);
            Console.WriteLine(str);
        }*/
        public void Part(object sender, OfficeEventArgs officeEventArgs)
        {
            Random R = new Random();
            int r = R.Next(0, 5);
            switch (r)
            {
                default: Console.WriteLine("{0} сказал: до свидания, {1}", this.name, officeEventArgs.Name); break;
                case 1: Console.WriteLine("{0} сказал: всего доброго, {1}", this.name, officeEventArgs.Name); break;
                case 2: Console.WriteLine("{0} сказал: счастливо, {1}", this.name, officeEventArgs.Name); break;
                case 3: Console.WriteLine("{0} сказал: хорошего дня, {1}", this.name, officeEventArgs.Name); break;
                case 4: Console.WriteLine("{0} сказал: до встречи, {1}", this.name, officeEventArgs.Name); break;
            }
        }
        public void Greet(object sender, OfficeEventArgs officeEventArgs)
        {
            //Console.WriteLine($"*На работу пришёл {officeEventArgs.Name}*");
            /*foreach (Person p in office)
            {
                came += (sender, time1) => { p.Greeting(this.Name, time); };
            }
            came?.Invoke(this, time);
            office.Add(this);
            came = null;
            Console.WriteLine();*/
            StringBuilder str = new StringBuilder("");
            str.Append(this.name);
            str.Append(" сказал: ");
            if (officeEventArgs.Time.Hour < 12) str.Append("доброе утро, ");
            else if (officeEventArgs.Time.Hour > 17) str.Append("добрый вечер, ");
            else str.Append("добрый день, ");
            str.Append(officeEventArgs.Name);
            Console.WriteLine(str);
        }
        /*
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
        }*/
    }
    class Program
    {
        //List<Person> Office = new List<Person>();// { }
        
        static void Main(string[] args)
        {
            Office office = new Office();
            Person Ivan = new Person("Ваня");
            Person Anatoly = new Person("Толян");
            Person Boss = new Person("Дмитрий Сергеевич");
            office.Come(Ivan);
            office.Come(Anatoly);
            office.Come(Boss);
            office.Leave(Ivan);
            office.Leave(Boss);
            office.Leave(Anatoly);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public class User
        {
            protected string Surname;
            protected string Name;
            protected string Patronymic;
            protected DateTime BirthDate;
            protected int Age;

            public void setSurname(string Surname) { this.Surname = Surname; }
            public void setName(string Name) { this.Name = Name; }
            public void setPatronymic(string Patronymic) { this.Patronymic = Patronymic; }
            public void setBirthDate(DateTime BirthDate) { this.BirthDate = BirthDate; this.calculateVozr(); }
            public void calculateVozr()
            {
                this.Age = DateTime.Now.Year - this.BirthDate.Year;
            }

            public string getSurname() { return Surname; }
            public string getName() { return Name; }
            public string getPatronymic() { return Patronymic; }
            public DateTime getBirthDate() { return BirthDate; }
            public int getVozr() { return Age; }
            public User() { }
            public User(string Surname, string Name, string Patronymic, DateTime BirthDate)
            {
                this.Surname = Surname; this.Name = Name; this.Patronymic = Patronymic; this.BirthDate = BirthDate; this.calculateVozr();
            }

            public override string ToString()
            {
                string str = Surname + " " + Name + " " + Patronymic + ". Дата рождения: " + BirthDate.ToString("d");
                return str;
            }
        }
        public class Employee : User
        {
            private int stag;
            private string dolzh;
            private int zp;

            protected int Stag
            {
                set { if (value >= 0) stag = value; else throw new ArgumentException(); }
                get { return stag; }
            }
            protected string Dolzh
            {
                set { if (value != "") dolzh = value; else throw new ArgumentException(); }
                get { return dolzh; }
            }
            protected int ZP
            {
                get { return 10000 + 2000 * Stag; }
            }

            public Employee() : base() { }
            public Employee(string Surname, string Name, string Patronymic, DateTime BirthDate, int Stag, string Dolzh)
            {
                this.Surname = Surname; 
                this.Name = Name; 
                this.Patronymic = Patronymic; 
                this.BirthDate = BirthDate; this.calculateVozr();
                this.Stag = Stag;
                this.Dolzh = Dolzh;
            }
            public override string ToString()
            {
                string str = Surname + " " + Name + " " + Patronymic + ". Дата рождения: " + BirthDate.ToString("d");
                str += ". Работает уже " + Stag.ToString() + ". " + Dolzh + ".";
                return str;
            }
        }
        static void Main(string[] args)
        {
            int n = 3;
            User[] mas = new User[3];
            mas[0] = new Employee("Соловьев", "Александр", "Вадимович", DateTime.Parse("02.11.1999"), 4, "Директор");
            mas[1] = new Employee("Шумак", "Антон", "Дмитриевич", DateTime.Parse("01.11.1999"), 6, "Секретарь");
            mas[2] = new Employee("Елисеев", "Владимир", "Александрович", DateTime.Parse("14.07.1999"), 2, "Зам директора");

            for (int i = 0; i < n; i++) Console.WriteLine("Работкик: {0}. Возраст: {1}.", mas[i], mas[i].getVozr());
            Console.ReadKey();
        }
    }
}

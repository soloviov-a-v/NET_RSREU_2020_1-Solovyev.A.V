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
            public void setBirthDate(DateTime BirthDate) { this.BirthDate = BirthDate; this.calculateAge(); }
            public void calculateAge()
            {
                this.Age = DateTime.Now.Year - this.BirthDate.Year;
            }

            public string getSurname() { return Surname; }
            public string getName() { return Name; }
            public string getPatronymic() { return Patronymic; }
            public DateTime getBirthDate() { return BirthDate; }
            public int getAge() { return Age; }
            public User() { }
            public User(string Surname, string Name, string Patronymic, DateTime BirthDate)
            {
                this.Surname = Surname; 
                this.Name = Name; 
                this.Patronymic = Patronymic; 
                this.BirthDate = BirthDate; 
                this.calculateAge();
            }

            public override string ToString()
            {
                string str = Surname + " " + Name + " " + Patronymic + ". Дата рождения: " + BirthDate.ToString("d");
                return str;
            }
        }
        public class Employee : User
        {
            private DateTime dateOfStartWork;
            private string dolzh;

            public DateTime DateOfStartWork
            {
                get { return dateOfStartWork; }
                set { dateOfStartWork = value; }
            }
            public int Experience
            {
                get 
                {
                    return DateTime.Now.Year - this.BirthDate.Year;
                }
            }
            public string Dolzh
            {
                set { if (value != "") dolzh = value; else throw new ArgumentException(); }
                get { return dolzh; }
            }
            public int ZP
            {
                get { return 10000 + 2000 * Experience; }
            }

            public Employee() : base() { }
            public Employee(string Surname, string Name, string Patronymic, DateTime BirthDate, DateTime DateOfStartWork, string Dolzh)
            {
                this.Surname = Surname; 
                this.Name = Name; 
                this.Patronymic = Patronymic;
                this.DateOfStartWork = DateOfStartWork;
                this.BirthDate = BirthDate; this.calculateAge();
                this.Dolzh = Dolzh;
            }
            public override string ToString()
            {
                string str = Surname + " " + Name + " " + Patronymic + ". Дата рождения: " + BirthDate.ToString("d");
                str += ". Работает уже " + Experience.ToString() + " лет. " + Dolzh + ".";
                return str;
            }
        }
        static void Main(string[] args)
        {
            int n = 3;
            User[] mas = new User[3];
            mas[0] = new Employee("Соловьев", "Александр", "Вадимович", DateTime.Parse("02.11.1999"), DateTime.Parse("09.09.2014"), "Директор");
            mas[1] = new Employee("Шумак", "Антон", "Дмитриевич", DateTime.Parse("01.11.1999"), DateTime.Parse("07.11.2016"), "Секретарь");
            mas[2] = new Employee("Елисеев", "Владимир", "Александрович", DateTime.Parse("14.07.1999"), DateTime.Parse("29.05.2015"), "Зам директора");

            for (int i = 0; i < n; i++) Console.WriteLine("Работкик: {0}. Возраст: {1}.", mas[i], mas[i].getAge());
            Console.ReadKey();
        }
    }
}

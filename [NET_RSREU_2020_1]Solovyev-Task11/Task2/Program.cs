using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
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
        public class Employee : User, IEquatable<Employee>
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
            public override bool Equals(object obj)
            {
                return Equals(obj as Employee);
            }
            public bool Equals(Employee secondEmployee)
            {
                if (secondEmployee is null) return false;
                return ((this.Name == secondEmployee.Name) 
                    && (this.Surname == secondEmployee.Surname) 
                    && (this.Patronymic == secondEmployee.Patronymic)
                    && (this.DateOfStartWork == secondEmployee.DateOfStartWork)
                    && (this.BirthDate == secondEmployee.BirthDate)
                    && (this.Dolzh == secondEmployee.Dolzh));
            }
        }
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Иванченко", "Иван", "Кириллович", DateTime.Parse("01.01.1970"), DateTime.Parse("01.01.1992"), "механик");
            Employee emp2 = new Employee("Иванченко", "Иван", "Кириллович", DateTime.Parse("01.01.1970"), DateTime.Parse("01.01.1992"), "механик");
            if (emp1.Equals(emp2)) Console.WriteLine("равны"); else Console.WriteLine("не равны");
            Console.ReadKey();
        }
    }
}

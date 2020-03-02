using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        private class User
        {
            protected string Surname;
            protected string Name;
            protected string Patronymic;
            protected DateTime BirthDate;
            protected int Vozr;

            public void setSurname(string Surname) { this.Surname = Surname; }
            public void setName(string Name) { this.Name = Name; }
            public void setPatronymic(string Patronymic) { this.Patronymic = Patronymic; }
            public void setBirthDate(DateTime BirthDate) { this.BirthDate = BirthDate; this.calculateVozr(); }
            public void calculateVozr() { 
                this.Vozr = DateTime.Now.Year - this.BirthDate.Year; 
            }

            public string getSurname() { return Surname; }
            public string getName() { return Name; }
            public string getPatronymic() { return Patronymic; }
            public DateTime getBirthDate() { return BirthDate; }
            public int getVozr() { return Vozr; }

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
        static void Main(string[] args)
        {
            int n = 3;
            User[] mas = new User[3];
            mas[0] = new User("Соловьев", "Александр", "Вадимович", DateTime.Parse("02.11.1999"));
            mas[1] = new User("Шумак", "Антон", "Дмитриевич", DateTime.Parse("01.11.1999"));
            mas[2] = new User("Елисеев", "Владимир", "Александрович", DateTime.Parse("14.07.1999"));

            for (int i=0; i<n; i++) Console.WriteLine("Пользователь: {0}. Возраст: {1}.", mas[i], mas[i].getVozr());
            Console.ReadKey();
        }
    }
}

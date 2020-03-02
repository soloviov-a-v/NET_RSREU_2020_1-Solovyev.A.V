using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        private class Round
        {
            protected double X;
            protected double Y;
            protected double Rad;
            protected double Length;
            protected double Square;

            public void setX(double X) { this.X = X; }
            public void setY(double Y) { this.Y = Y; }
            public void Move(double X, double Y) { this.X += X; this.Y += Y; }
            public void MoveTo(double X, double Y) { this.X = X; this.Y = Y; }
            public void setRad(double Rad) { this.Rad = Rad; calcLength(); calcSquare(); }
            public void calcLength() { this.Length = 2 * Math.PI * this.Rad; }
            public void calcSquare() { this.Square = Math.PI * this.Rad * this.Rad; }

            public double getX() { return X; }
            public double getY() { return Y; }
            public double getRad() { return Rad; }
            public double getLength() { return Length; }
            public double getSquare() { return Square; }

            public Round() { X = 0; Y = 0; Rad = 0; calcLength(); calcSquare(); }
            public Round(double X, double Y, double Rad)
            {
                this.X = X; this.Y = Y; this.Rad = Rad; calcLength(); calcSquare();
            }
            public override string ToString()
            {
                string str = "Координаты: (" + X + ";" + Y + ")" + ". Радиус: " + Rad + ". Длина: " + Length + ". Площадь:" + Square;
                return str;
            }
        }
        static void Main(string[] args)
        {
            int n = 3;
            Round[] mas = new Round[3];
            mas[0] = new Round();
            mas[1] = new Round(3, 4, 5);
            mas[2] = new Round(7, 2, 3.14);
            for (int i = 0; i < n; i++) Console.WriteLine(mas[i]);
            Console.ReadKey();
        }
    }
}

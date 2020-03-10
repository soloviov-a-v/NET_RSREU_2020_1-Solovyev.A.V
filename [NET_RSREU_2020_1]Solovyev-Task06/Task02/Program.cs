using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        public class Round
        {
            protected double X;
            protected double Y;
            protected double Rad;
            public double x
            {
                get { return X; }
                set { X = value; }
            }
            public double y
            {
                get { return Y; }
                set { Y = value; }
            }
            public double rad
            {
                get { return Rad; }
                set { if (value >= 0) Rad = value; else throw new ArgumentOutOfRangeException(); }
            }
            public double length
            {
                get { return 2 * Math.PI * this.rad; }
            }
            public double square
            {
                get { return Math.PI * this.rad * this.rad; }
            }
            public Round() { x = 0; y = 0; rad = 0; }
            public Round(double X, double Y, double Rad)
            {
                this.x = X; this.y = Y; this.rad = Rad;
            }
            public override string ToString()
            {
                string str = "Координаты: (" + X + ";" + Y + ")" + ". Радиус: " + Rad + ". Длина: " + length + ". Площадь:" + square;
                return str;
            }
        }
        public class Ring : Round
        {
            protected double InternalRad;
            public double internalRad
            {
                set { if (value >= 0 && value <= rad) InternalRad = value; else throw new ArgumentOutOfRangeException(); }
                get { return InternalRad; }
            }
            public double sumLength
            {
                get { return 2 * Math.PI * rad + 2 * Math.PI * internalRad; }
            }
            public double ringSquare
            {
                get { return Math.PI * rad * rad - Math.PI * rad * internalRad; }
            }
            public Ring() : base() { x = 0; y = 0; rad = 0; internalRad = 0; }
            public Ring(double X, double Y, double Rad, double InternalRad)
            {
                this.x = X; this.y = Y; this.rad = Rad; this.internalRad = InternalRad;
            }

            public override string ToString()
            {
                string str = "Координаты: (" + X + ";" + Y + ")" + ". Радиус: " + Rad + ". Внут.радиус" + internalRad + ". Длина: " + sumLength + ". Площадь:" + ringSquare;
                return str;
            }
        }
        static void Main(string[] args)
        {
            int n = 4;
            Round[] mas = new Round[n];
            mas[0] = new Ring();
            mas[1] = new Ring(3, 4, 5, 4.5);
            mas[2] = new Ring(7, 2, 3.14, 2.28);

            for (int i = 0; i < n; i++) Console.WriteLine(mas[i]);
            Console.ReadKey();

            Round round = new Round(2, 2, -0.001);
        }
    }
}

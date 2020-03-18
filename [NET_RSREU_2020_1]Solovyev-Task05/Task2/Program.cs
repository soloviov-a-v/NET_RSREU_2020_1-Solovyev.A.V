using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public class Round
        {
            private double X;
            private double Y;
            private double Rad;
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
                get 
                { 
                    return Rad;
                }
                set 
                { 
                    if (value >= 0) 
                        Rad = value; 
                    else
                        throw new ArgumentOutOfRangeException(); 
                }
            }
            public double length
            {
                get { return 2 * Math.PI * this.rad; }
            }
            public double square
            {
                get { return Math.PI * this.rad * this.rad; ; }
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
        static void Main(string[] args)
        {
            int n = 4;
            Round[] mas = new Round[n];
            mas[0] = new Round();
            mas[1] = new Round(3, 4, 5);
            mas[2] = new Round(7, 2, 3.14);

            for (int i = 0; i < n; i++) Console.WriteLine(mas[i]);
            Console.ReadKey();

            Round round = new Round(2, 2, -0.001);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        private class Triangle
        {
            protected double a;
            protected double b;
            protected double c;
            public double A
            {
                set { if (value >= 0) a = value; else throw new ArgumentOutOfRangeException(); }
                get { return a; }
            }
            public double B
            {
                set { if (value >= 0) b = value; else throw new ArgumentOutOfRangeException(); }
                get { return a; }
            }
            public double C
            {
                set { if (value >= 0) c = value; else throw new ArgumentOutOfRangeException(); }
                get { return a; }
            }

            /*
            public void setA(double a) { this.a = a; }
            public void setB(double b) { this.b = b; }
            public void setC(double c) { this.c = c; }

            public double getA() { return a; }
            public double getB() { return b; }
            public double getC() { return c; }
            */

            public double getPerimeter() { return A + B + C; }
            public double getSquare() { return A + (B + C) / 2; }

            public Triangle() { A = 0; B = 0; C = 0; }
            public Triangle(double a, double b, double c) { this.A = a; this.B = b; this.C = c; }
            public override string ToString()
            {
                return a + "; " + b + "; " + c;
            }

        }
        static void Main(string[] args)
        {
            int n = 3;
            Triangle[] mas = new Triangle[n];
            mas[0] = new Triangle();
            mas[1] = new Triangle(2, 3, 4);
            mas[2] = new Triangle(2.1, 3.1, 4.4);

            for (int i = 0; i < n; i++) Console.WriteLine("Длины сторон: {0}. Периметр: {1}. Площадь: {2}.", mas[i], mas[i].getPerimeter(), mas[i].getSquare());
            Console.ReadKey();

            Triangle triangle = new Triangle(-2, 1, 4);
        }
    }
}

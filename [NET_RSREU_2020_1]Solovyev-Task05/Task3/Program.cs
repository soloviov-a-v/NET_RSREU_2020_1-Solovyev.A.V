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

            public void setA(double a) { this.a = a; }
            public void setB(double b) { this.b = b; }
            public void setC(double c) { this.c = c; }

            public double getA() { return a; }
            public double getB() { return b; }
            public double getC() { return c; }

            public double getPerimeter() { return a + b + c; }
            public double getSquare() { return a + (b + c) / 2; }

            public Triangle() { a = 0; b = 0; c = 0; }
            public Triangle(double a, double b, double c) { this.a = a; this.b = b; this.c = c; }
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
        }
    }
}

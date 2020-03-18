using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        abstract class Figure
        {
            protected double X;
            protected double Y;
            public double x
            {
                set { X = value; }
                get { return X; }
            }
            public double y
            {
                set { Y = value; }
                get { return Y; }
            }
            public Figure() { }
            public override string ToString()
            {
                return ("Произвольная фигура. Х: " + X.ToString() + "; Y:" + Y.ToString());
            }
        }

        class Line : Figure
        {
            protected double XEnd;
            protected double YEnd;
            public double xEnd
            {
                set { if (value >= 0) XEnd = value; else throw new ArgumentOutOfRangeException(); }
                get { return XEnd; }
            }
            public double yEnd
            {
                set { if (value >= 0) YEnd = value; else throw new ArgumentOutOfRangeException(); }
                get { return YEnd; }
            }
            public Line() : base() { }
            public Line(double x, double y, double xEnd, double yEnd) { this.x = x; this.y = y; this.xEnd = xEnd; this.yEnd = yEnd; }
            public override string ToString()
            {
                return ("Линия. Хн: " + X.ToString() + "; Yн:" + Y.ToString() + "; Хк:" + XEnd.ToString() + "; Yк:" + YEnd.ToString());
            }
        }

        class Rectangle : Figure
        {
            protected double Width;
            protected double Height;
            public double width
            {
                set { if (value >= 0) Width = value; else throw new ArgumentOutOfRangeException(); }
                get { return Width; }
            }
            public double height
            {
                set { if (value >= 0) Height = value; else throw new ArgumentOutOfRangeException(); }
                get { return Height; }
            }
            public Rectangle() : base() { }
            public Rectangle(double x, double y, double height, double width) { this.x = x; this.y = y; this.height = height; this.width = width; }
            public override string ToString()
            {
                return ("Прямоугольник. Х: " + X.ToString() + "; Y:" + Y.ToString() + "; Высота:" + Width.ToString() + "; Ширина:" + Height.ToString());
            }
        }

        class Ellipse : Figure
        {
            protected double Width;
            protected double Height;
            public double width
            {
                set { if (value >= 0) Width = value; else throw new ArgumentOutOfRangeException(); }
                get { return Width; }
            }
            public double height
            {
                set { if (value >= 0) Height = value; else throw new ArgumentOutOfRangeException(); }
                get { return Height; }
            }
            public Ellipse() : base() { }
            public Ellipse(double x, double y, double height, double width) { this.x = x; this.y = y; this.height = height; this.width = width; }
            public override string ToString()
            {
                return ("Эллипс. Х: " + X.ToString() + "; Y:" + Y.ToString() + "; Высота:" + Height.ToString() + "; Ширина:" + Width.ToString());
            }
        }

        class Round : Figure
        {
            protected double Radius;
            public double radius
            {
                set { if (value >= 0) Radius = value; else throw new ArgumentOutOfRangeException(); }
                get { return Radius; }
            }
            public Round() : base() { }
            public Round(double x, double y, double rad) { this.x = x; this.y = y; this.radius = rad; }
            public override string ToString()
            {
                return ("Окружность. Х: " + X.ToString() + "; Y:" + Y.ToString() + "; Радиус:" + Radius.ToString());
            }
        }

        class Ring : Round
        {
            protected double InternalRadius;
            public double internalRadius
            {
                set { if (value >= 0) InternalRadius = value; else throw new ArgumentOutOfRangeException(); }
                get { return InternalRadius; }
            }
            public Ring() : base() { }
            public Ring(double x, double y, double rad, double internalRadius) : base(x, y, rad) 
            {
                this.x = x; 
                this.y = y; 
                this.radius = rad;
                this.internalRadius = internalRadius; 
            }
            public override string ToString()
            {
                return ("Кольцо. Х: " + X.ToString() + "; Y:" + Y.ToString() + "; Радиус:" + Radius.ToString() + "; Внутренний радиус:" + internalRadius.ToString());
            }
        }

        static void Main(string[] args)
        {
            int selected, selected1;
            double x, y, rad, heigth, width, a, b;
            List<Figure> Array = new List<Figure>();
            do
            {
                Console.WriteLine("Меню. Выберите действие.\n  1 - добавить фигуру.\n  2 - Вывесли все фигуры.\n  3  - Выход");
                selected = int.Parse(Console.ReadLine());
                if (selected == 1)
                {
                    Console.WriteLine("Выберите фигуру.\n  1 - Линия.\n  2 - Окружность.\n  3 - Прямоугольник.\n  4 - Круг.\n  5 - Кольцо.");
                    selected1 = int.Parse(Console.ReadLine());
                    Console.Write("X = "); x = int.Parse(Console.ReadLine());
                    Console.Write("Y = "); y = int.Parse(Console.ReadLine());
                    switch (selected1)
                    {
                        case 1:
                            Console.Write("X конечный = "); a = double.Parse(Console.ReadLine());
                            Console.Write("Y конечный = "); b = double.Parse(Console.ReadLine());
                            Array.Add(new Line(x, y, a, b));
                            break;
                        case 2:
                            Console.Write("Радиус = "); rad = double.Parse(Console.ReadLine());
                            Array.Add(new Round(x, y, rad));
                            break;
                        case 3:
                            Console.Write("Ширина = "); heigth = double.Parse(Console.ReadLine());
                            Console.Write("Высота = "); width = double.Parse(Console.ReadLine());
                            Array.Add(new Line(x, y, heigth, width));
                            break;
                        case 4:
                            Console.Write("Ширина = "); heigth = double.Parse(Console.ReadLine());
                            Console.Write("Высота = "); width = double.Parse(Console.ReadLine());
                            Array.Add(new Ellipse(x, y, heigth, width));
                            break;
                        case 5:
                            Console.Write("Внешний радиус = "); rad = double.Parse(Console.ReadLine());
                            Console.Write("Внутренний радиус = "); a = double.Parse(Console.ReadLine());
                            Array.Add(new Ring(x, y, rad, a));
                            break;
                        default: break;
                    }
                }
                if (selected == 2) foreach (Figure figure in Array) Console.WriteLine(figure.ToString());
            } while (selected != 3);
        }
    }
}

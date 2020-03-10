using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        class Figure
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
        }


        static void Main(string[] args)
        {

        }
    }
}

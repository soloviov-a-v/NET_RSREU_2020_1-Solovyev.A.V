using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public interface ISeries
        {
            double GetCurrent();
            void Next();
            void Reset();
        }
        public class ArithmeticalProgression : ISeries, IIndexable
        {
            double start, step;
            int index;

            public ArithmeticalProgression(double start, double step)
            {
                this.start = start;
                this.step = step;
                this.index = 1;
            }

            public double GetCurrent() { return start + step * index; }

            public void Next() { index++; }

            public void Reset() { index = 1; }
            public double this[int index]
            {
                get { return start + step * index; }
            }
        }
        public class List : ISeries
        {
            private double[] series;
            private int index = 0;

            public List(double[] series) { this.series = series; }

            public double GetCurrent() { return series[index]; }

            public void Next(){ if (index < series.Length - 1) index++; else index = 0; }

            public void Reset() { index = 0;}
            public double this[int index]
            {
                get
                { return series[index]; }
            }
        }
        public interface IIndexable
        {
            double this[int index] { get; }
        }

        static void PrintSeries(ISeries series)
        {
            series.Reset();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.Next();
            }
        }
        static void Main(string[] args)
        {
            ISeries progression = new ArithmeticalProgression(2, 2);
            Console.WriteLine("Progression:");
            PrintSeries(progression);
            ISeries list = new List(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 5421.5 });
            Console.WriteLine();
            Console.WriteLine("List:");
            PrintSeries(list);
            Console.ReadLine();
        }
    }
}

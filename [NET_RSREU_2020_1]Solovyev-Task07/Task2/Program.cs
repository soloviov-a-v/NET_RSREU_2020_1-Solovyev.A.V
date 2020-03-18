using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public interface ISeries
        {
            double GetCurrent();
            void Next();
            void Reset();
        }
        public class GeometricProgression : ISeries
        {
            double start, step;
            int index;

            public GeometricProgression(double start, double step)
            {
                this.start = start;
                this.step = step;
                this.index = 1;
            }

            public double GetCurrent(){ return start * Math.Pow(step, index); }
            public void Next() { index++; }
            public void Reset() { index = 1;}
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
            ISeries progression = new GeometricProgression(1, 10);
            Console.WriteLine("Геометрическая прогрессия:");
            PrintSeries(progression);

            Console.ReadKey();
        }
    }
}

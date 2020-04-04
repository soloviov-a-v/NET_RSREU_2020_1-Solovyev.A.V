using System;

namespace ClassLibrary
{
    public class Library
    {
        public static int Factorial(int number)
        {
            if (number < 0)
                throw new Exception("Неверное значение! Число должно быть больше или равно 0!");

            int result = 1;
            for (int i = 1; i <= number; i++)
                result *= i;
            return result;
        }
        public static double Pow(double number, int degree)
        {
            double result = 1;
            for (int i = 0; i < degree; i++)
                result *= number;
            return result;
        }
    }
}

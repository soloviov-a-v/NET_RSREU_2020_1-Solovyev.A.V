﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        class DynamicArray<T>
        {
            public T[] array;
            private int capasity;
            private int length;
            public int Capasity
            {
                get
                { return array.Length; }
                set
                { capasity = value; }
            }
            public int Length
            {
                get
                { return length; }
                set
                { length = value; }
            }
            public DynamicArray()
            {
                Capasity = 8;
                array = new T[Capasity];
                //Length = 0;
                //for (int i = 0; i < Capasity; i++) array[i] = default;
            }
            public DynamicArray(int capasity)
            {
                array = new T[capasity];
                Capasity = capasity;
                //Length = 0;
            }
            public DynamicArray(T[] mas)
            {
                array = new T[mas.Length];
                Capasity = mas.Length;
                Length = mas.Length;
                for (int i = 0; i < Capasity; i++) array[i] = mas[i];
            }
            private void Resize()
            {
                T[] newArray = new T[Capasity * 2];
                for (int i = 0; i < Capasity; i++) 
                    newArray[i] = array[i];
                array = newArray;
                Capasity *= 2;
            }
            public void Add(T element)
            {
                //if (Length + 1 > Capasity) Resize();

                //array[Length] = element;
                //Length++;

                Insert(element, Length);
            }
            public void AddRange(T[] myArray)
            {
                while (Length + myArray.Length > Capasity) Resize();
                for (int i = 0; i < myArray.Length; i++)
                {
                    array[Length] = myArray[i];
                    Length++;
                }
            }
            public bool Remove(int index)
            {
                if (index < Length)
                {
                    for (int i = 0; i < Length - 1; i++) 
                        if (i >= index) 
                            array[i] = array[i + 1];

                    array[Length - 1] = default;
                    Length--;
                    return true;
                }
                else return false;
            }
            public void Insert(T element, int index)
            {
                if (index > Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    if (Length + 1 > Capasity) Resize();
                    for (int i = Length - 1; i >= index; i--) array[i + 1] = array[i];
                    array[index] = element;
                    Length++;
                }
            }
            public T this[int index]
            {
                get
                {
                    if (index >= Capasity) throw new ArgumentOutOfRangeException();
                    return array[index];
                }
            }
            public void PrintArray()
            {
                Console.WriteLine("Массив:");
                for (int i = 0; i < Capasity; i++)
                    Console.WriteLine(array[i]);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            DynamicArray<int> arr = new DynamicArray<int>(1);
            arr.Add(1);
            arr.Add(2);
            arr.PrintArray();
            int[] number = new int[] { 1, 2, 3, 4, 5, 12};
            arr.AddRange(number);
            arr.PrintArray();

            if (arr.Remove(6)) Console.WriteLine("Элемент удален"); else Console.WriteLine("Элемент не удален");
            arr.PrintArray();

            try
            {
                arr.Insert(8, 5);
                arr.PrintArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Третий элемент массива: " + arr[2]);
            Console.ReadLine();
        }
    }
}

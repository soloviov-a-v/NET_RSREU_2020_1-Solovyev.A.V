using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class DynamicArray<T>
    {
        public T[] array;
        private int capasity;
        private int length;
        private int index;
        public int Capasity
        {
            get { return array.Length; }
            set { capasity = value; }
        }
        public int Length
        {
            get { return length; }
            set { length = value; }
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
        public DynamicArray(IEnumerable<T> array)
        {
            this.array = array.ToArray();
            Capasity = this.array.Length;
            Length = this.array.Length;
            index = 0;
        }
        private void Resize()
        {
            T[] newArray = new T[Capasity * 2];
            for (int i = 0; i < Capasity; i++)
                newArray[i] = array[i];
            array = newArray;
            Capasity *= 2;
        }
        public void Add(T element) { Insert(element, Length); }
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
        public void Reset() { index = 0; }
        public void Next() { index++; }
        public T Current() { return array[index]; }
        public IEnumerator GetEnumerator()
        {
            for (int i=0; i<length; i++)
            {
                yield return array[i];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            DynamicArray<int> arr1 = new DynamicArray<int>(numList);

            Console.WriteLine("Выводим массив: ");
            foreach (var s in arr1) { Console.WriteLine(s.ToString()); }

            //arr1.PrintArray();
            Console.WriteLine("Текущий элемент " + arr1.Current());
            arr1.Next();
            Console.WriteLine("Текущий элемент " + arr1.Current());
            
            
            //foreach (var s in arr1) { Console.WriteLine(s.ToString()); }
            Console.ReadKey();
        }
    }
}

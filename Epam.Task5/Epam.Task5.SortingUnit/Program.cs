using System;
using System.Collections.Generic;
using System.Threading;

namespace Epam.Task5.SortingUnit
{
    public class Program
    {
        private static object locker = new object();

        private static Thread thread;

        public delegate void SortingFihish(string message);

        public static event SortingFihish SortFinish;

        public static void SortingFinish(string message)
        {
            Show(message);
        }

        public static void Quicksort<T>(T[] elements, int left, int right, Func<T, T, int> compare)
        {
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (compare(elements[i], pivot) < 0)
                {
                    i++;
                }

                while (compare(elements[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(elements, left, j, compare);
            }

            if (i < right)
            {
                Quicksort(elements, i, right, compare);
            }
        }

        public static void ShowArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void Show(string line)
        {
            Console.WriteLine(line);
        }

        public static void LockingSort<T>(T[] array, int left, int start, Func<T, T, int> compare)
        {
            lock (locker)
            {
                Quicksort(array, 0, array.Length - 1, compare);
            }

            SortFinish("Sorting finished its work");
        }

        public static void Main(string[] args)
        {
            Show($"Demostration sorting with delegate");
            Show(string.Empty);

            int[] array = GenerateNewArray();
            int[] anotherArray = GenerateNewArray();
            SortFinish += SortingFinish;

            Show("Randomly generated array: ");
            ShowArray(array);

            Show("Another randomly generated array: ");
            ShowArray(anotherArray);

            Func<int, int, int> deleg = IntCompare;

            SortingInNewThread(anotherArray, 0, array.Length - 1, deleg);
            LockingSort(array, 0, array.Length - 1, deleg);

            Show("Sorted array: ");
            ShowArray(array);

            Show("Another sorted array: ");
            ShowArray(anotherArray);
        }

        private static int IntCompare(int firstElement, int secondElement)
        {
            if (firstElement > secondElement)
            {
                return 1;
            }
            else if (firstElement < secondElement)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static int DoubleCompare(double firstElement, double secondElement)
        {
            if (firstElement > secondElement)
            {
                return 1;
            }
            else if (firstElement < secondElement)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static int StringCompare(string firstElement, string secondElement)
        {
            return string.Compare(firstElement, secondElement);
        }

        private static int[] GenerateNewArray()
        {
            int[] array = new int[Randomizer.GeneratePositiveNumber(10)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Randomizer.GenereateNumber(50);
            }

            return array;
        }

        private static void SortingInNewThread<T>(T[] array, int left, int start, Func<T, T, int> compare)
        {
            thread = new Thread(() => LockingSort<T>(array, 0, start, compare));
            thread.Start();
            thread.Join();
        }
    }
}

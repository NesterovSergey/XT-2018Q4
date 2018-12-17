using System;
using System.Collections.Generic;

namespace Epam.Task5.CustomSort
{
    public class Program
    {
        public static void Quicksort<T>(T[] elements, int left, int right, Func<T, T, int> сompare)
        {
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (сompare(elements[i], pivot) < 0)
                {
                    i++;
                }

                while (сompare(elements[j], pivot) > 0)
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
                Quicksort(elements, left, j, сompare);
            }

            if (i < right)
            {
                Quicksort(elements, i, right, сompare);
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

        public static void Main(string[] args)
        {
            Show($"Demostration sorting with delegate");
            Show(string.Empty);

            int[] array = GenerateNewArray();

            Show("Randomly generated array: ");
            ShowArray(array);

            Func<int, int, int> del = IntCompare;
            Quicksort(array, 0, array.Length - 1, del);

            Show("Sorted array: ");
            ShowArray(array);
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
    }
}

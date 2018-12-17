using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Task5.CustomSortDemo
{
    public class Program
    {
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
            Console.Write(array[0]);

            for (int i = 1; i < array.Length; i++)
            {
                Console.Write($", {array[i]}");
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

            string[] array = GenerateNewArray();

            Show("Your array: ");
            ShowArray(array);

            Func<string, string, int> del = StringCompare;
            Quicksort(array, 0, array.Length - 1, del);

            Show("Sorted array:");
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

        private static string[] GenerateNewArray()
        {
            var array = new List<string>();

            string input = ".";

            Show("Please, enter any string line or just leave blank to stop");

            while (true)
            {
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    return array.ToArray();
                }

                array.Add(input);

                if (array.Count == 1 && string.IsNullOrEmpty(array[0]))
                {
                    Show("You have to enter something");
                    input = "1";
                    array.Clear();
                }
            }
        }
    }
}
using System;

namespace Epam.Task2.ArrayProcessing
{
    class Program
    {
        static void DeterminationOfMinAndMax(int[] array)
        {
            int min = array[0];
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
                if (max < array[i])
                {
                    max = array[i];
                }
            }

            Console.WriteLine("Minimal element of the array: " + min);
            Console.WriteLine("Maximal element of the array: " + max);
        }

        static void Sorting(int[] array)
        {
            int temporaryElement;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temporaryElement = array[i];
                        array[i] = array[j];
                        array[j] = temporaryElement;
                    }
                }
            }

            Console.Write("Sorted array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] array = new int[11];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(100);
            }
            DeterminationOfMinAndMax(array);
            Sorting(array);
        }
    }
}

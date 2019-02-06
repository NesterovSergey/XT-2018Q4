using System;

namespace Epam.Task2.NonNegativeSum
{
    public class Program
    {
        private static int[] array = new int[10];

        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.ArrayProcessing");
            Console.WriteLine();

            FillArray();
            ShowArray();
            CalculateSumOfPositive();
        }

        public static void CalculateSumOfPositive()
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    sum += array[i];
                }
            }

            Console.WriteLine("\nSum of positive elements in the array: " + sum);
        }

        public static void FillArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Randomizer.GenerateInteger(10);
            }
        }

        public static void ShowArray()
        {
            Console.WriteLine("Array:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}

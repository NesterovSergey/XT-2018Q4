using System;

namespace Epam.Task2.NonNegativeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int[] array = new int[10];
            int sum = 0;

            Console.WriteLine("Array:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-10, 10);
                Console.Write(array[i] + " ");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    sum += array[i];
                }
            }
            Console.WriteLine("\nSum of positive elements in the array: " + sum);
        }
    }
}

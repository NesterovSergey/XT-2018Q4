using System;

namespace Epam.Task2._2DArray
{
    public class Program
    {
        private static int[,] array = new int[7, 7];

        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.2DArray");
            Console.WriteLine();

            CalculateSum();
        }

        public static void CalculateSum()
        {
            int sum = 0;

            Console.WriteLine("Array:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = Randomizer.GenerateInteger(10);
                    Console.Write(array[i, j] + " ");

                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("Sum of the elements in even positions  " + sum);
        }
    }
}

using System;

namespace Epam.Task2._2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int[,] array = new int[7, 7];
            int sum = 0;

            Console.WriteLine("Array:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(10);
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

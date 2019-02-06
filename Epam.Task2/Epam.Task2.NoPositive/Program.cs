using System;

namespace Epam.Task2.NoPositive
{
    public class Program
    {
        private static int[,,] array = new int[3, 3, 3];

        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.NoPositive");
            Console.WriteLine();

            ToFillArray();
            ToShowArray();
            ToDeletePositive();
            ToShowArray();
        }

        public static void ToFillArray()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int q = 0; q < array.GetLength(2); q++)
                    {
                        array[i, j, q] = Randomizer.GenerateInteger(10);
                    }
                }
            }
        }

        public static void ToShowArray()
        {
            Console.WriteLine("Your array:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int q = 0; q < array.GetLength(2); q++)
                    {
                        Console.Write("{0} ", array[i, j, q]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        public static void ToDeletePositive()
        {
            Console.WriteLine("Deleting positive numbers...");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int q = 0; q < array.GetLength(2); q++)
                    {
                        if (array[i, j, q] > 0)
                        {
                            array[i, j, q] = 0;
                        }
                    }
                }
            }
        }
    }
}

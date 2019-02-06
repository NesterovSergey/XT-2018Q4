using System;

namespace Epam.Task2.Triangle
{
    public class Program
    {
        private const char SYMBOL = '*';

        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.Triangle");
            Console.WriteLine();

            MakeTriangle();
        }

        public static void MakeTriangle()
        {
            int n;
            int amountOfStars = 1;

            while (true)
            {
                Console.Write("Enter amount of lines: ");

                if (int.TryParse(Console.ReadLine(), out n))
                {
                    if (n <= 0)
                    {
                        Console.WriteLine("You have to enter a number more than 0");
                        continue;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("You have to enter a number");
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < amountOfStars; j++)
                {
                    Console.Write(SYMBOL);
                }

                amountOfStars++;
                Console.WriteLine();
            }
        }
    }
}

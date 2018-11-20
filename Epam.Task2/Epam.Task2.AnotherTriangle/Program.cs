using System;

namespace Epam.Task2.AnotherTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int amountOfStars = 1;
            int mid;

            Console.Write("Enter amount of lines: ");
            n = int.Parse(Console.ReadLine());

            mid = n - 1;

            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < mid; k++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < amountOfStars; j++)
                {
                    Console.Write("*");
                }

                mid--;
                amountOfStars += 2;
                Console.WriteLine();
            }
        }
    }
}

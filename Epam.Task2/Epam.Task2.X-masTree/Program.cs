using System;

namespace Epam.Task2.XmasTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int amountOfStars;
            int mid;
            int tempMid;

            Console.Write("Enter amount of lines: ");
            n = int.Parse(Console.ReadLine());
            mid = n - 1;

            for (int amountOfTriangle = 0; amountOfTriangle <= n; amountOfTriangle++)
            {
                amountOfStars = 1;
                tempMid = mid;

                for (int i = 1; i <= amountOfTriangle; i++)
                {
                    for (int j = 0; j < tempMid; j++)
                    {
                        Console.Write(" ");
                    }

                    for (int q = 0; q < amountOfStars; q++)
                    {
                        Console.Write("*");
                    }

                    tempMid--;
                    amountOfStars += 2;
                    Console.WriteLine();
                }

            }
        }
    }
}

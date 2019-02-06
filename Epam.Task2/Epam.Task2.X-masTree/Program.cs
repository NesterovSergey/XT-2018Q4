using System;

namespace Epam.Task2.XmasTree
{
    public class Program
    {
        private const char SYMBOL = '*';
        private const char EMPTYSYMBOL = ' ';

        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.XmasTree");
            Console.WriteLine();

            MakeXmasTree();
        }

        public static void MakeXmasTree()
        {
            int n;
            int amountOfStars;
            int mid;
            int tempMid;

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

            mid = n - 1;

            for (int amountOfTriangle = 0; amountOfTriangle <= n; amountOfTriangle++)
            {
                amountOfStars = 1;
                tempMid = mid;

                for (int i = 1; i <= amountOfTriangle; i++)
                {
                    for (int j = 0; j < tempMid; j++)
                    {
                        Console.Write(EMPTYSYMBOL);
                    }

                    for (int q = 0; q < amountOfStars; q++)
                    {
                        Console.Write(SYMBOL);
                    }

                    tempMid--;
                    amountOfStars += 2;
                    Console.WriteLine();
                }
            }
        }
    }
}

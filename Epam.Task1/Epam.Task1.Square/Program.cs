using System;

namespace Epam.Task1.Square
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task1.Square");
            Console.WriteLine();

            int n;

            Console.WriteLine("Enter size of the square: ");
            while (true)
            {
                Console.Write(">> ");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("You had to enter a number");
                }
                else if (n % 2 != 0 && n > 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You had to enter an odd number more than 1");
                }
            }

            Square(n);
        }

        public static void Square(int n)
        {
            int mid = n / 2;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(i == mid && j == mid ? "  " : "* ");
                }

                Console.WriteLine();
            }
        }
    }
}

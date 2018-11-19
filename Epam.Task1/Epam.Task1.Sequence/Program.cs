using System;

namespace Epam.Task1.Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Enter a number: ");
            while (true)
            {
                Console.Write(">> ");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("You had to enter a number");
                }
                else if (n > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You had to enter a positive number");
                }
            }

            Sequence(n);
        }

        static void Sequence(int n)
        {
            Console.Write(1);

            for (int i = 1; i < n; i++)
            {
                Console.Write(", " + (i + 1));
            }

            Console.WriteLine();
        }
    }
}
using System;

namespace Epam.Task2.Rectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.Rectangle");
            Console.WriteLine();

            CalculateArea();
        }

        public static void CalculateArea()
        {
            while (true)
            {
                Console.Write($"Enter A side {Environment.NewLine}>> ");
                if (!int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("You have to enter a number");
                    continue;
                }
                else if (a <= 0)
                {
                    Console.WriteLine("A side equals or less than 0");
                    continue;
                }

                Console.Write($"Enter B side {Environment.NewLine}>> ");
                if (!int.TryParse(Console.ReadLine(), out int b))
                {
                    Console.WriteLine("You entered incorrect B side");
                    continue;
                }
                else if (b <= 0)
                {
                    Console.WriteLine("B side equals or less than 0");
                    continue;
                }

                Console.WriteLine("Area of the rectagle = " + (a * b));
                break;
            }
        }
    }
}

using System;

namespace Epam.Task2.Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;

            while (true)
            {
                Console.Write($"Enter A side {Environment.NewLine}>> ");
                a = int.Parse(Console.ReadLine());
                if (a <= 0)
                {
                    Console.WriteLine("A side equals or less than 0");
                    continue;
                }

                Console.Write($"Enter B side {Environment.NewLine}>> ");
                b = int.Parse(Console.ReadLine());
                if (b <= 0)
                {
                    Console.WriteLine("B side equals or less than 0");
                }
                else
                {
                    Console.WriteLine("Area of the rectagle = " + (a * b));
                    break;
                }
            }
        }
    }
}

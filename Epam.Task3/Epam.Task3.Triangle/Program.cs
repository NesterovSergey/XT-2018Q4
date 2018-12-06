using System;

namespace Epam.Task3.Triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Triangle triangle;
            int a;
            int b;
            int c;

            while (true)
            {
                Console.WriteLine("Enter A side: ");
                a = int.Parse(Console.ReadLine());
                if (a <= 0)
                {
                    Console.WriteLine($"A equals or less than 0 {Environment.NewLine}");
                    continue;
                }

                Console.WriteLine("Enter B side: ");
                b = int.Parse(Console.ReadLine());
                if (b <= 0)
                {
                    Console.WriteLine($"B equals or less than 0 {Environment.NewLine}");
                    continue;
                }

                Console.WriteLine("Enter C side: ");
                c = int.Parse(Console.ReadLine());
                if (c <= 0)
                {
                    Console.WriteLine($"C equals or less than 0 {Environment.NewLine}");
                    continue;
                }

                if (a + b > c && a + c > b && b + c > a)
                {
                    triangle = new Triangle(a, b, c);
                    break;
                }
                else
                {
                    Console.WriteLine("the sum of any two sides have to be greater than the third");
                }
            }

            Console.WriteLine("The area equals = {0}", triangle.Area);
            Console.WriteLine("The perimeter equals = {0}", triangle.Perimeter);
        }
    }
}
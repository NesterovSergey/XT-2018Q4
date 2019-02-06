using System;

namespace Epam.Task2.SumOfNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.SumOfNumbers");
            Console.WriteLine();

            Console.WriteLine("Sum of numbers that divide by 3 or 5 within 1000: {0}", CalculateSumOfNumbers());
        }

        public static int CalculateSumOfNumbers()
        {
            int sumOfTriples = (3 + 999) * 333 / 2;
            int sumOfFives = (5 + 995) * 199 / 2;
            int sumOfFifteens = (15 + 990) * 66 / 2;

            return sumOfTriples + sumOfFives - sumOfFifteens;
        }
    }
}

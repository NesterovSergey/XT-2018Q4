using System;

namespace Epam.Task1.Simple
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

            Console.WriteLine(Simple(n));
        }

        static bool Simple(int n)
        {
            if (n < 2)
            {
                return false;
            }

            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

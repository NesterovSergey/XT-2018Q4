using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int amountOfStars = 1;

            Console.Write("Enter amount of lines: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < amountOfStars; j++)
                {
                    Console.Write("*");
                }

                amountOfStars++;
                Console.WriteLine();
            }
        }
    }
}

using System;

namespace Epam.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            while (true)
            {
                try
                {
                    Console.Write(">> ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n % 2 != 0 && n > 0)
                    {
                        break;
                    }
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Нужно нечетное положительное число");
                }
            }

            Square(n);

        }

        static void Square(int n)
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


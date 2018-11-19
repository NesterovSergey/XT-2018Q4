using System;

namespace Epam.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                try
                {
                    Console.Write(">> ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n > 0)
                    {
                        break;
                    }
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Нужно положительное Целое число");
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
            for (int i = 2; i < n; i++)
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

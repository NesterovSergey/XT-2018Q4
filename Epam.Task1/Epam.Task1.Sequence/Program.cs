using System;

namespace Epam.Task2
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
                    Console.WriteLine("Нужно положительное число");
                }

            }
            Console.WriteLine(Sequence(n));
        }

        static string Sequence(int n)
        {
            string str = "";

            for (int i = 0; i < n; i++)
            {
                str += i + 1 + ", ";
            }

            return str.Remove(str.Length - 2);
        }
    }
}
using System;

namespace Epam.Task2.FontAdjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            bool bold = false;
            bool italic = false;
            bool underline = false;

            while (true)
            {
                Console.WriteLine("\nВведите: \n 1: bold \n 2: italic \n 3: underline");
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    if (x == 1)
                    {
                        bold = !bold;
                    }
                    if (bold)
                    {
                        Console.Write("bold ");
                    }

                    if (x == 2)
                    {
                        italic = !italic;
                    }
                    if (italic)
                    {
                        Console.Write("italic ");
                    }

                    if (x == 3)
                    {
                        underline = !underline;
                    }
                    if (underline)
                    {
                        Console.Write("underline ");
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}



using System;

namespace Epam.Task2.FontAdjustment
{
    class Program
    {
        [Flags]
        public enum Options
        {
            italic = 1,
            bold = 2,
            underline = 4,
        }

        static void Main(string[] args)
        {
            Options currentFont = 0;
            int x;
            bool italic = true;
            bool bold = true;
            bool underline = true;

            Console.Write($"Current font parameters: None{Environment.NewLine}" +
                          $"Enter: {Environment.NewLine}" +
                          $"1: italic {Environment.NewLine}" +
                          $"2: bold {Environment.NewLine}" +
                          $"3: underline {Environment.NewLine}" +
                          $"4: exit {Environment.NewLine}");

            while (true)
            {
                x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        currentFont = italic ? currentFont + 1 : currentFont - 1;
                        italic = !italic;
                        break;
                    case 2:
                        currentFont = bold ? currentFont + 2 : currentFont - 2;
                        bold = !bold;
                        break;
                    case 3:
                        currentFont = underline ? currentFont + 4 : currentFont - 4;
                        underline = !underline;
                        break;
                    case 4:
                        currentFont -= 10;
                        break;
                    default:
                        Console.WriteLine("This option is not exist");
                        break;
                }

                if (currentFont > 0)
                {
                    Console.Write("Current font parameters: ");
                    Console.WriteLine(currentFont);
                }
                else if (currentFont == 0)
                {
                    Console.Write("Current font parameters: ");
                    Console.WriteLine("None");
                }
                else
                {
                    break;
                }
            }
        }
    }
}



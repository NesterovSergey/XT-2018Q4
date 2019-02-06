using System;

namespace Epam.Task2.FontAdjustment
{
    public class Program
    {
        private static Options currentFont = 0;

        [Flags]
        public enum Options
        {
            italic = 1,
            bold = 2,
            underline = 4,
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.FontAdjustment");
            Console.WriteLine();

            InteractionWithFont();
        }

        public static void InteractionWithFont()
        {
            string x;

            Console.Write($"Current font parameters: None{Environment.NewLine}" +
                          $"Enter: {Environment.NewLine}" +
                          $"1: italic {Environment.NewLine}" +
                          $"2: bold {Environment.NewLine}" +
                          $"3: underline {Environment.NewLine}" +
                          $"4: exit {Environment.NewLine}");

            while (true)
            {
                x = Console.ReadLine();

                switch (x)
                {
                    case "1":
                        currentFont ^= Options.italic;
                        break;
                    case "2":
                        currentFont ^= Options.bold;
                        break;
                    case "3":
                        currentFont ^= Options.underline;
                        break;
                    case "4":
                        currentFont -= 10;
                        break;
                    default:
                        Console.WriteLine("This option is not exist");
                        break;
                }

                if (currentFont < 0)
                {
                    break;
                }

                ShowFonts();
            }
        }

        public static void ShowFonts()
        {
            if (currentFont > 0)
            {
                Console.WriteLine("Current font parameters: {0}", currentFont);
            }
            else if (currentFont == 0)
            {
                Console.WriteLine("Current font parameters: None");
            }
        }
    }
}

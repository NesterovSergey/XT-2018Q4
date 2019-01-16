using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.TimeCounter
{
    public class Program
    {
        private static readonly string RegString = @"\b((([0-1])?[0-9])|(2[0-3])):([0-5][0-9])\b";

        public static void Main(string[] args)
        {
            ConsoleWriteLine("Epam.Task8.TimeCounter");
            ConsoleWriteLine(string.Empty);

            TimeCounter();
        }

        public static void TimeCounter()
        {
            string text;
            int counter;
            Regex regex = new Regex(RegString);

            ConsoleWriteLine("Please, enter a text you want to check for number of appearances of time");
            while (true)
            {
                text = ConsoleReadLine();

                if (text.ToLower().Equals("exit"))
                {
                    ConsoleWriteLine("Good luck!");
                    break;
                }
                
                counter = regex.Matches(text).Count;
                ConsoleWriteLineWithNumber($"A number of appearances of time: ", counter);
            }
        }

        public static void ConsoleWriteLineWithNumber(string line, int counter)
        {
            Console.WriteLine($"{line}{counter}");
        }

        public static string ConsoleReadLine()
        {
            return Console.ReadLine();
        }

        public static void ConsoleWriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}

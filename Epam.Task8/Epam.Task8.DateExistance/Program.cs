using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.DateExistance
{
    public class Program
    {
        private static readonly string SuperRegString = @"\b((((([0-2]?[0-9])|(3[01]))-(([0]?[13578])|([1][02])))"
                                                        + @"|((([0-2]?[0-9])|(30))-((([0]?[469]))|11))"
                                                        + @"|((([01]?[0-9])|(2[0-8]))-(0?2)))-(\d{1,4}))\b";

        public static void Main(string[] args)
        {
            ConsoleWriteLine("Epam.Task8.DateExistance");
            ConsoleWriteLine(string.Empty);

            DateExistance();
        }

        public static void DateExistance()
        {
            Regex regex = new Regex(SuperRegString);

            string text;

            ConsoleWriteLine("Enter text where you want to find a date");
            while (true)
            {
                text = ConsoleReadLine();

                if (text.Equals("exit"))
                {
                    ConsoleWriteLine("Good luck!");
                    break;
                }

                if (regex.IsMatch(text))
                {
                    ConsoleWriteLine("This text includes a date");
                }
                else
                {
                    ConsoleWriteLine("Date is not found");
                }
            }
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

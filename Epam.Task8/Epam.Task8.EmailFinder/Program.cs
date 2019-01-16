using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.EmailFinder
{
    public class Program
    {
        private static readonly string RegString = @"\b(\w+|-|,)@\w+\.[a-z]{2,6}\b";

        public static void Main(string[] args)
        {
            ConsoleWriteLine("Epam.Task8.EmailFinder");
            ConsoleWriteLine(string.Empty);

            EmailFinder();
        }

        public static void EmailFinder()
        {
            Regex regex = new Regex(RegString, RegexOptions.IgnoreCase);
            string mail;

            ConsoleWriteLine("Enter a text where you want to find email addresses or enter exit to exit");
            while (true)
            {
                mail = ConsoleReadLine();

                if (mail.ToLower().Equals("exit"))
                {
                    break;
                }

                foreach (var match in regex.Matches(mail))
                {
                    ConsoleWriteLine(match.ToString());
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

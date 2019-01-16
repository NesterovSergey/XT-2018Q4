using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Epam.Task8.HtmlReplacer
{
    public class Program
    {
        private static readonly string RegString = @"(<.+?>)|(<\/.+?>)";

        public static void Main(string[] args)
        {
            ConsoleWriteLine("Epam.Task8.HtmlReplacer");
            ConsoleWriteLine(string.Empty);

            HtmlReplacer();
        }

        public static void HtmlReplacer()
        {
            StringBuilder stringBuilderText = new StringBuilder();
            Regex regex = new Regex(RegString);

            ConsoleWriteLine("Please, enter a text in which you want to replace all of tags");
            while (true)
            {
                stringBuilderText.Append(ConsoleReadLine());

                foreach (var match in regex.Matches(stringBuilderText.ToString()))
                {
                    stringBuilderText.Replace($"{match}", "_");
                }

                ConsoleWriteLine("The result: ");
                ConsoleWriteLine(stringBuilderText.ToString());

                stringBuilderText.Clear();
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

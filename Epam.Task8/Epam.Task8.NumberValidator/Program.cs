using System;

namespace Epam.Task8.NumberValidator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleWriteLine("Epam.Task8.NumberValidator");
            ConsoleWriteLine(string.Empty);

            NumberValidation();
        }

        public static void NumberValidation()
        {
            string number;

            ConsoleWriteLine("Please, enter a number you want to check for notation or enter exit to exit");
            while (true)
            {
                number = ConsoleReadLine();

                if (RegularExpression.UsualCheck(number))
                {
                    ConsoleWriteLine("The number is in usual notation");
                }
                else if (RegularExpression.ScientificCheck(number))
                {
                    ConsoleWriteLine("The number is in scientific notation");
                }
                else if (number.ToLower().Equals("exit"))
                {
                    ConsoleWriteLine("Good luck!");
                    break;
                }
                else
                {
                    ConsoleWriteLine("Incorrect data");
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

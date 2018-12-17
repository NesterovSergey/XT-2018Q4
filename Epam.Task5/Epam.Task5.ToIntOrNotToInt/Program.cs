using System;

namespace Epam.Task5.ToIntOrNotToInt
{
    public class Program
    {
        private const string WhiteSpace = " ";

        public static string Input()
        {
            Output.WriteLine("Enter your line");
            var input = Console.ReadLine();

            return input;
        }

        public static void ShowAll(params string[] lineArray)
        {
            foreach (var item in lineArray)
            {
                Output.Write(item);
                Output.Write(WhiteSpace);
                Output.WriteLine(item.IsPositiveNumber());
            }
        }

        public static void Main(string[] args)
        {
            Output.WriteLine("ToIntOrNotToInt task");
            Output.WriteLine(string.Empty);

            string line1 = "Don't bite me kitty";
            string line2 = "123";
            string line3 = "-123";
            string line4 = "12.2";
            string line5 = string.Empty;

            string myLine = Input();

            ShowAll(line1, line2, line3, line4, line5, myLine);
        }
    }
}

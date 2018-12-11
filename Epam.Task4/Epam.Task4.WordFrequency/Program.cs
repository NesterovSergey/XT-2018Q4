using System;
using System.Collections.Generic;

namespace Epam.Task4.WordFrequency
{
    public class Program
    {
        private static ConsoleInput input = new ConsoleInput();
        private static ConsoleOutput output = new ConsoleOutput();

        public static string Enter()
        {
            output.Write("Enter a line of text: ");
            return input.ReadLine();
        }

        public static void Output(Dictionary<string, int> array)
        {
            foreach (var item in array)
            {
                output.Write(" Word: ");
                output.WriteLine(item.Key);
                output.Write(" Amount: ");
                output.WriteLine(item.Value);
                output.WriteLine(string.Empty);
            }
        }

        public static void Main(string[] args)
        {
            var textAnalyzer = new TextAnalyzer();

            textAnalyzer.Text = Enter();
            textAnalyzer.Counter();
            Output(textAnalyzer.Count);
        }
    }
}

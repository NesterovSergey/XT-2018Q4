using System;

namespace Epam.Task2.AverageStringLength
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.AverageStringLength");
            Console.WriteLine();

            CalculateAverageLength();
        }

        public static void CalculateAverageLength()
        {
            Console.WriteLine("Enter a line of text you like: ");
            string str = Console.ReadLine();
            double sum = 0;
            int amountOfWords = 0;
            bool word = false;
            double averageLength;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    sum++;
                    word = true;
                }
                else if (word)
                {
                    amountOfWords++;
                    word = false;
                }
            }

            if (word)
            {
                amountOfWords++;
            }

            averageLength = sum / amountOfWords;

            Console.WriteLine("Amount of the words in the line: " + amountOfWords);
            Console.WriteLine("Average length of the words: " + averageLength);
        }
    }
}

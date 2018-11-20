using System;

namespace Epam.Task2.AverageStringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a line of text you like: ");
            string[] str = Console.ReadLine().Split(new char[] { '.', ',', ':', '-', ' ' });
            float sum = 0f;
            int amountOfWords = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (!string.IsNullOrEmpty(str[i]))
                {
                    sum += str[i].Length;
                    amountOfWords++;
                }
            }
            Console.WriteLine("Amount of the words in the line: " + amountOfWords);
            Console.WriteLine("Average length of the words: " + sum / amountOfWords);
        }
    }
}

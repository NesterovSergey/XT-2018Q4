using System;

namespace Epam.Task2.AverageStringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a line of text you like: ");
            string str = Console.ReadLine();
            float sum = 0f;
            int amountOfWords = 1;
            bool word = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    word = true;
                    sum++;
                }
                else
                {
                    if (word)
                    {
                        amountOfWords++;
                    }
                    word = false;
                }
            }
            Console.WriteLine("Amount of the words in the line: " + amountOfWords);
            Console.WriteLine("Average length of the words: " + sum / amountOfWords);
        }
    }
}

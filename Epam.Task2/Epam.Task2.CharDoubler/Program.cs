using System;

namespace Epam.Task2.CharDoubler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first line: ");
            string firstLine = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the second line: ");
            string secondLine = Console.ReadLine().ToLower();

            string currentLetter;

            for (int i = 0; i < secondLine.Length; i++)
            {
                currentLetter = "" + secondLine[i];
                firstLine = firstLine.Replace(currentLetter, currentLetter + currentLetter);
            }
            Console.WriteLine("The result: " + firstLine);
        }
    }
}

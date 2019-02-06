using System;
using System.Text;

namespace Epam.Task2.CharDoubler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task2.CharDoubler");
            Console.WriteLine();

            DuplicateLetters();
        }

        public static void DuplicateLetters()
        {
            Console.WriteLine("Enter the first line: ");
            string firstLine = Console.ReadLine();
            StringBuilder sb = new StringBuilder(firstLine);

            Console.WriteLine("Enter the second line: ");
            string secondLine = Console.ReadLine();

            string currentLetter;
            for (int i = 0; i < secondLine.Length; i++)
            {
                if (firstLine.IndexOf(secondLine[i]) != -1)
                {
                    currentLetter = secondLine[i].ToString();
                    sb.Replace(currentLetter, currentLetter + currentLetter);

                    secondLine = secondLine.Replace(currentLetter, string.Empty);
                    i--;
                }
            }

            Console.WriteLine("The result: " + firstLine);
        }
    }
}

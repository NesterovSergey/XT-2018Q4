using System;

namespace Epam.Task2.CharDoubler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first line: ");
            string firstLine = Console.ReadLine();

            Console.WriteLine("Enter the second line: ");
            string secondLine = Console.ReadLine();
            
            string currentLetter;
            for (int i = 0; i < secondLine.Length; i++)
            {
                if(firstLine.IndexOf(secondLine[i]) != -1)
                {
                    currentLetter = secondLine[i].ToString();
                    firstLine = firstLine.Replace(currentLetter, currentLetter + currentLetter);

                    secondLine = secondLine.Replace(currentLetter, "");
                    i--;
                }

            }
            Console.WriteLine("The result: " + firstLine);
        }
    }
}

using System;

namespace Epam.Task3.Round
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Round round = new Round();

            Console.WriteLine("Enter X coordinate: ");
            round.X = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y coordinate: ");
            round.Y = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a radius: ");
            while (true)
            {
                Console.WriteLine("Enter a radius: ");
                try
                {
                    round.Radius = int.Parse(Console.ReadLine());

                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("The area equals: {0}", round.Area);
            Console.WriteLine("The length equals: {0}", round.Length);
        }
    }
}

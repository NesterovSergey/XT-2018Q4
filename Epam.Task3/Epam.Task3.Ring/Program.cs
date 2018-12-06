using System;

namespace Epam.Task3.Ring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ring = new Ring();

            Console.WriteLine("Enter X coordinate: ");
            ring.X = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y coordinate: ");
            ring.Y = int.Parse(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Enter a radius: ");
                try
                {
                    ring.Radius = int.Parse(Console.ReadLine());

                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                Console.WriteLine("Enter an inner radius: ");
                try
                {
                    ring.InnerRadius = int.Parse(Console.ReadLine());

                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Area of the circle = {0}", ((RoundShape)ring).Area);
            Console.WriteLine("Length of the circle = {0}", ((RoundShape)ring).Length);
            Console.WriteLine("Area of the ring = {0}", ring.Area);
            Console.WriteLine("Sum of Lengths = {0}", ring.Length);
        }
    }
}
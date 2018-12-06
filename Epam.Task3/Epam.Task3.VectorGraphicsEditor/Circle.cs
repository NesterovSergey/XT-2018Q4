using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Circle : RoundShape
    {
        public double Area => Math.PI * Radius * Radius;

        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("X coordinate: {0}", X);
            Console.WriteLine("Y coordinate: {0}", Y);
            Console.WriteLine("Round radius: {0}", Radius);
            Console.WriteLine("Area: {0}", Area);
        }

        public override void Create()
        {
            Console.WriteLine("Circle!");
            Console.WriteLine("Enter X coordinate: ");
            X = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y coordinate: ");
            Y = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a radius: ");
            while (true)
            {
                try
                {
                    Radius = int.Parse(Console.ReadLine());

                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

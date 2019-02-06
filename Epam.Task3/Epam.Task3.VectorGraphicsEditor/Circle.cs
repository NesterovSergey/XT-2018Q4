using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Circle : RoundShape
    {
        public double Area => Math.PI * base.Radius * base.Radius;

        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("X coordinate: {0}", base.X);
            Console.WriteLine("Y coordinate: {0}", base.Y);
            Console.WriteLine("Round radius: {0}", base.Radius);
            Console.WriteLine("Area: {0}", this.Area);
        }

        public override void Create()
        {
            Console.WriteLine("Circle!");

            Console.WriteLine("Enter X coordinate: ");
            try
            {
                this.X = int.Parse(Console.ReadLine());
            }
            catch
            {
                throw new ArgumentException("X coodinate was entered incorrect");
            }

            Console.WriteLine("Enter Y coordinate: ");
            try
            {
                this.Y = int.Parse(Console.ReadLine());
            }
            catch
            {
                throw new ArgumentException("Y coodinate was entered incorrect");
            }

            Console.WriteLine("Enter a radius: ");
            while (true)
            {
                try
                {
                    base.Radius = int.Parse(Console.ReadLine());

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

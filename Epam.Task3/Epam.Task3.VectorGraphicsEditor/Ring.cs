using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Ring : RoundShape
    {
        private double innerRadius;

        public double InnerRadius
        {
            get
            {
                return this.innerRadius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The inner radius cannot be less or equal 0");
                }
                else if (value > base.Radius)
                {
                    throw new ArgumentException("The inner radius cannot be more than outer radius");
                }
                else
                {
                    this.innerRadius = value;
                }
            }
        }

        public double Area => (Math.PI * base.Radius * base.Radius) - (Math.PI * this.innerRadius * this.innerRadius);

        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("X coordinate: {0}", this.X);
            Console.WriteLine("Y coordinate: {0}", this.Y);
            Console.WriteLine("Round radius: {0}", base.Radius);
            Console.WriteLine("Area: {0}", this.Area);
        }

        public override void Create()
        {
            Console.WriteLine($"{Environment.NewLine}Ring!");
            Console.WriteLine("Enter X coordinate: ");
            this.X = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y coordinate: ");
            this.Y = int.Parse(Console.ReadLine());

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
                    Console.WriteLine("Enter an inner radius: ");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter an inner radius: ");
                try
                {
                    this.InnerRadius = int.Parse(Console.ReadLine());

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

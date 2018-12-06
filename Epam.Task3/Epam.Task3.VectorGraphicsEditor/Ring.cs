using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Ring : RoundShape
    {
        private double innerRadius;

        public double InnerRadius
        {
            get
            {
                return innerRadius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The inner radius cannot be less or equal 0");
                }
                else if (value > Radius)
                {
                    throw new ArgumentException("The inner radius cannot be more than outer radius");
                }
                else
                {
                    innerRadius = value;
                }
            }
        }

        public double Area => (Math.PI * Radius * Radius) - (Math.PI * innerRadius * innerRadius);

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
            Console.WriteLine($"{Environment.NewLine}Ring!");
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
                    Console.WriteLine("Enter an inner radius: ");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter an inner radius: ");
                try
                {
                    InnerRadius = int.Parse(Console.ReadLine());

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

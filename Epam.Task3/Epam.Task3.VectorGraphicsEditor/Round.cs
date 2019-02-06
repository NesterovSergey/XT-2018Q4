using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Round : RoundShape
    {
        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("X coordinate: {0}", this.X);
            Console.WriteLine("Y coordinate: {0}", this.Y);
            Console.WriteLine("Round radius: {0}", base.Radius);
        }

        public override void Create()
        {
            Console.WriteLine($"{Environment.NewLine}Round!");
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
                }
            }
        }
    }
}

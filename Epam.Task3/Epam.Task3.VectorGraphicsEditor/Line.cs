using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Line : Figure
    {
        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("Coordinates of the first point ({0}, {1})", this.X1, this.Y1);
            Console.WriteLine("Coordinates of the second point ({0}, {1})", this.X2, this.Y2);
        }

        public override void Create()
        {
            Console.WriteLine($"{Environment.NewLine}Line!");
            Console.WriteLine("Enter X1 coordinate: ");
            this.X1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y1 coordinate: ");
            this.Y1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter X2 coordinate: ");
            this.X2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y2 coordinate: ");
            this.Y2 = int.Parse(Console.ReadLine());
        }
    }
}

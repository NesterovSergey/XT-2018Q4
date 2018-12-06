using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Coordinates of first point ({0}, {1})", X1, Y1);
            Console.WriteLine("Coordinates of second point ({0}, {1})", X2, Y2);
        }

        public override void Create()
        {
            Console.WriteLine($"{Environment.NewLine}Line!");
            Console.WriteLine("Enter X1 coordinate: ");
            X1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y1 coordinate: ");
            Y1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter X2 coordinate: ");
            X2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y2 coordinate: ");
            Y2 = int.Parse(Console.ReadLine());
        }
    }
}

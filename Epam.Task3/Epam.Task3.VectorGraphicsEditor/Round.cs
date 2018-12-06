using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Round : RoundShape
    {
        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("X coordinate: {0}", X);
            Console.WriteLine("Y coordinate: {0}", Y);
            Console.WriteLine("Round radius: {0}", Radius);
        }

        public override void Create()
        {
            Console.WriteLine($"{Environment.NewLine}Round!");
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

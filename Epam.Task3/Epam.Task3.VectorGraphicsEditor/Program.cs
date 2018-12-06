using System;
using System.Collections.Generic;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<Figure>
            {
                new Circle(),
                new Round(),
                new Line(),
                new Rectangle(),
                new Ring(),
            };

            foreach (var item in list)
            {
                item.Create();
                item.Show();
            }
        }
    }
}
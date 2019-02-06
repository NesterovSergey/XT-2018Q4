using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public abstract class RoundShape : Figure
    {
        private double radius;

        public int X { get; set; }

        public int Y { get; set; }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentException("The radius cannot be less than 0");
                }
            }
        }
    }
}

using System;

namespace Epam.Task3.Ring
{
    public class RoundShape
    {
        private double radius;

        public RoundShape()
        {
            radius = 1;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value > 0)
                {
                    radius = value;
                }
                else
                {
                    throw new ArgumentException("The radius cannot be less than 0");
                }
            }
        }

        public double Area => Math.PI * radius * radius;

        public double Length => 2 * Math.PI * radius;
    }
}

using System;

namespace Epam.Task3.Round
{
    public class Round
    {
        private int radius;

        public int X { get; set; }

        public int Y { get; set; }

        public int Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius should be positive");
                }

                this.radius = value;
            }
        }

        public double Area => Math.PI * this.Radius * this.Radius;

        public double Length => 2 * Math.PI * this.Radius;
    }
}
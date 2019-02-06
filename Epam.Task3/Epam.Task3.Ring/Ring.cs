using System;

namespace Epam.Task3.Ring
{
    public class Ring
    {
        private RoundShape roundShape;
        private double innerRadius;

        public Ring()
        {
            this.roundShape = new RoundShape();
        }

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
                else if (value > this.roundShape.Radius)
                {
                    throw new ArgumentException("The inner radius cannot be more than outer radius");
                }
                else
                {
                    this.innerRadius = value;
                }
            }
        }

        public new double Area => this.roundShape.Area - (Math.PI * this.innerRadius * this.innerRadius);

        public new double Length => this.roundShape.Length + (2 * Math.PI * this.innerRadius);
    }
}

using System;

namespace Epam.Task3.Ring
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

        public new double Area => base.Area - (Math.PI * innerRadius * innerRadius);

        public new double Length => base.Length + (2 * Math.PI * innerRadius);
    }
}

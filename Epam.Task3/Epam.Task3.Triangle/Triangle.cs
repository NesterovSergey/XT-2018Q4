using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Triangle
{
    public class Triangle
    {
        private int a;
        private int b;
        private int c;
        private int perimeter;
        private double area;

        public Triangle() : this(1, 1, 1)
        {
        }

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            perimeter = a + b + c;
            area = GetArea(perimeter);
        }

        public int A => a;

        public int B => b;

        public int C => c;

        public int Perimeter => perimeter;

        public double Area => area;

        private double GetArea(int perimeter)
        {
            double semiPerimeter = perimeter / 2d;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
        }
    }
}

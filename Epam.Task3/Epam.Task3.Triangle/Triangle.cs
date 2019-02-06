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

            this.perimeter = a + b + c;
            this.area = this.GetArea(this.perimeter);
        }

        public int A => this.a;

        public int B => this.b;

        public int C => this.c;

        public int Perimeter => this.perimeter;

        public double Area => this.area;

        private double GetArea(int perimeter)
        {
            double semiPerimeter = perimeter / 2d;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - this.a) * (semiPerimeter - this.b) * (semiPerimeter - this.c));
        }
    }
}

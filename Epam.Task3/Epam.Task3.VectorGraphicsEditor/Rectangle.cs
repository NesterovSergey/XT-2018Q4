using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Rectangle : Figure
    {
        private int a;
        private int b;

        public int Area => this.a * this.b;

        public int A
        {
            get
            {
                return this.a;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side cannot be less or equal 0");
                }
                else
                {
                    this.a = value;
                }
            }
        }

        public int B
        {
            get
            {
                return this.b;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side cannot be less or equal 0");
                }
                else
                {
                    this.b = value;
                }
            }
        }

        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("First side: {0}", this.A);
            Console.WriteLine("Second side: {0}", this.B);
            Console.WriteLine("Area: {0}", this.Area);
        }

        public override void Create()
        {
            Console.WriteLine($"{Environment.NewLine}Rectangle!");
            while (true)
            {
                Console.WriteLine("Enter length of A side: ");
                try
                {
                    this.A = int.Parse(Console.ReadLine());
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            {
                while (true)
                {
                    Console.WriteLine("Enter length of B side: ");
                    try
                    {
                        this.B = int.Parse(Console.ReadLine());
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
}

using System;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Rectangle : Figure
    {
        private int a;
        private int b;

        public int Area => a * b;

        public int A
        {
            get
            {
                return a;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side cannot be less or equal 0");
                }
                else
                {
                    a = value;
                }
            }
        }

        public int B
        {
            get
            {
                return b;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side cannot be less or equal 0");
                }
                else
                {
                    b = value;
                }
            }
        }

        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("First side: {0}", A);
            Console.WriteLine("Second side: {0}", B);
            Console.WriteLine("Area: {0}", Area);
        }

        public override void Create()
        {
            Console.WriteLine($"{Environment.NewLine}Rectangle!");
            while (true)
            {
                Console.WriteLine("Enter length of A side: ");
                try
                {
                    A = int.Parse(Console.ReadLine());
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
                        B = int.Parse(Console.ReadLine());
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

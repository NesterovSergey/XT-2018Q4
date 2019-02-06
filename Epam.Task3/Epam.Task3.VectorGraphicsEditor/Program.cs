using System;
using System.Collections.Generic;

namespace Epam.Task3.VectorGraphicsEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task3.VectorGraphicsEditor");
            Console.WriteLine();

            ShowMenu();
        }

        public static void ShowMenu()
        {
            var list = new List<Figure>
            {
                new Circle(),
                new Round(),
                new Line(),
                new Rectangle(),
                new Ring(),
            };

            while (true)
            {
                Console.WriteLine("1. Circle 2. Round 3. Line 4. Rectangle 5. Ring");
                if (int.TryParse(Console.ReadLine(), out int x))
                {
                    if (x > 0 && x <= list.Count)
                    {
                        try
                        {
                            list[x - 1].Create();
                            list[x - 1].Show();
                            Console.WriteLine();
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your number does not exist");
                    }
                }
                else
                {
                    Console.WriteLine("You entered incorrect data");
                }
            }
        }
    }
}
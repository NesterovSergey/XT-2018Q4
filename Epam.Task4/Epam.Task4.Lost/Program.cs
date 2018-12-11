using System;
using System.Collections.Generic;

namespace Epam.Task4.Lost
{
    public class Program
    {
        private static CircleOfPeople circleOfPeople;

        private static ConsoleInput input = new ConsoleInput();
        private static ConsoleOutput output = new ConsoleOutput();

        public static void Enter()
        {
            int result;

            output.WriteLine("Please, enter humber of people");

            while (true)
            {
                if (!int.TryParse(input.ReadLine(), out result))
                {
                    output.WriteLine("You had to enter a number");
                }
                else
                {
                    try
                    {
                        circleOfPeople.N = result;
                        break;
                    }
                    catch (ArgumentException e)
                    {
                        output.WriteLine(e.Message);
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            List<int> list;
            circleOfPeople = new CircleOfPeople();
            Enter();
            circleOfPeople.CreateCircle();
            circleOfPeople.Counter();
            list = circleOfPeople.GetCircleOfPeople();

            output.Write("Remaining number: ");
            output.WriteLine(list[0]);
        }
    }
}
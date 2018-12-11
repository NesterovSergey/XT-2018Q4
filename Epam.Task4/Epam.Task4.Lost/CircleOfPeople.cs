using System;
using System.Collections.Generic;

namespace Epam.Task4.Lost
{
    public class CircleOfPeople
    {
        private int numberOfPeople;

        private List<int> circleOfPeople = new List<int>();

        private ConsoleOutput output = new ConsoleOutput();
        private ConsoleInput input = new ConsoleInput();

        public int N
        {
            get
            {
                return this.numberOfPeople;
            }

            set
            {
                if (value > 0)
                {
                    this.numberOfPeople = value;
                }
                else
                {
                    throw new ArgumentException("You had to enter a positive number");
                }
            }
        }

        public List<int> GetCircleOfPeople()
        {
            return this.circleOfPeople;
        }

        public void CreateCircle()
        {
            this.circleOfPeople.Capacity = this.numberOfPeople;

            for (int i = 0; i < this.numberOfPeople; i++)
            {
                this.circleOfPeople.Add(i);
            }
        }

        public void Counter()
        {
            int i = 1;
            int count = this.circleOfPeople.Count;

            while (true)
            {
                while (count > i)
                {
                    this.circleOfPeople.RemoveAt(i);

                    i += 1;
                    count -= 1;
                }

                if (this.circleOfPeople.Count == 1)
                {
                    break;
                }

                i = i - count;
            }
        }
    }
}

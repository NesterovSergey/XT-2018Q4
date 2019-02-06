using System;

namespace Epam.Task3.Employee
{
    public class Employee : User
    {
        private int workExperience;
        private string position;

        private string[] positions = { "accountant", "director", "builder" };

        public int WorkExperience
        {
            get
            {
                return this.workExperience;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The experience cannot be less than 0");
                }
                else if (value > base.Age - 14)
                {
                    throw new ArgumentException("You cannot work officially before you got your passport");
                }
                else if (base.Age < 14)
                {
                    this.workExperience = 0;
                    throw new ArgumentException("You cannot work officially");
                }
                else
                {
                    this.workExperience = value;
                }
            }
        }

        public string Position
        {
            get
            {
                return this.position;
            }

            set
            {
                bool lever = true;

                foreach (var item in this.positions)
                {
                    if (item == value.ToLower())
                    {
                        lever = false;
                        this.position = item;
                    }
                }

                if (lever)
                {
                    throw new ArgumentException("You entered incorrect position");
                }
            }
        }
    }
}

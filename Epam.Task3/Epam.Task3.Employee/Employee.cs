using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return workExperience;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The experience cannot be less than 0");
                }
                else if (value > Age - 14)
                {
                    throw new ArgumentException("You cannot work officially before you got your passport");
                }
                else if (Age < 14)
                {
                    workExperience = 0;
                    throw new ArgumentException("You cannot work officially");
                }
                else
                {
                    workExperience = value;
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

                foreach (var item in positions)
                {
                    if (item == value.ToLower())
                    {
                        lever = false;
                        position = item;
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

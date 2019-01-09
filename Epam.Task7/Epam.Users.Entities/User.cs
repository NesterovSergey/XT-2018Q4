using System;
using System.Collections.Generic;

namespace Epam.Users.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;

                var tempAge = now.Year - this.DateOfBirth.Year;

                if (now.Month > this.DateOfBirth.Month || (now.Month == this.DateOfBirth.Month && now.Day > this.DateOfBirth.Day))
                {
                    return tempAge;
                }
                else
                {
                    return tempAge - 1;
                }
            }
        }

        public override string ToString()
        {
            return $"{Id} {Name} {DateOfBirth.Date.ToShortDateString()} {Age}";
        }
    }
}

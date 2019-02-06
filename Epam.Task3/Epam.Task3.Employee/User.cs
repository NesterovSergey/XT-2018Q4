using System;

namespace Epam.Task3.Employee
{
    public class User
    {
        private string name;
        private string lastName;
        private string secondName;
        private int age;
        private DateTime dateOfBirth;
        private DateTime now;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.NameCheck(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect name");
                }
            }
        }

        public string SecondName
        {
            get
            {
                return this.secondName;
            }

            set
            {
                if (this.NameCheck(value))
                {
                    this.secondName = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect second name");
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (this.NameCheck(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect last name");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                if (value.Year < 1900)
                {
                    throw new ArgumentException("Your date of birth seems too suspicious");
                }

                this.now = DateTime.Now;
                this.dateOfBirth = value;
                this.age = this.now.Year - this.dateOfBirth.Year;

                if (this.dateOfBirth.Month >= this.now.Month && this.dateOfBirth.Day >= this.now.Day)
                {
                    this.age++;
                }
            }
        }

        public int Age
        {
            get
            {
                if (this.age != 0)
                {
                    return this.age;
                }
                else
                {
                    throw new Exception("You did not enter the date of birth");
                }
            }
        }

        private bool NameCheck(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

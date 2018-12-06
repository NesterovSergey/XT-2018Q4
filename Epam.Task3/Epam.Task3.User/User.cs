using System;

namespace Epam.Task3.User
{
    public class User
    {
        private string name;
        private string lastName;
        private string secondName;
        private int age;
        private DateTime dateOfBirth;
        private DateTime now = DateTime.Now;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (NameCheck(value))
                {
                    name = value;
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
                return secondName;
            }

            set
            {
                if (NameCheck(value))
                {
                    secondName = value;
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
                return lastName;
            }

            set
            {
                if (NameCheck(value))
                {
                    lastName = value;
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
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;

                age = now.Year - dateOfBirth.Year;

                if (dateOfBirth.Month >= now.Month && dateOfBirth.Day >= now.Day)
                {
                    age++;
                }
            }
        }

        public int Age
        {
            get
            {
                if (age != 0)
                {
                    return age;
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

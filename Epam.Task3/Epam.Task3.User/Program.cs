using System;

namespace Epam.Task3.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User user = new User();

            string name;
            string lastName;
            string secondName;

            DateTime date;
            int day;
            int month;
            int year;

            while (true)
            {
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();
                try
                {
                    user.Name = name;

                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                Console.WriteLine("Enter your second name: ");
                secondName = Console.ReadLine();
                try
                {
                    user.SecondName = secondName;

                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                Console.WriteLine("Enter your last name: ");
                lastName = Console.ReadLine();
                try
                {
                    user.LastName = lastName;

                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                Console.WriteLine("Enter day of your birth: ");
                day = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter month of your birth: ");
                month = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter year of your birth: ");
                year = int.Parse(Console.ReadLine());

                try
                {
                    date = new DateTime(year, month, day);
                    user.DateOfBirth = date;
                    break;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Name: {0}", user.Name);
            Console.WriteLine("Second name: {0}", user.SecondName);
            Console.WriteLine("Last name: {0}", user.LastName);
            Console.WriteLine("Date of Birth: {0:d}", user.DateOfBirth);
            Console.WriteLine("Age: {0}", user.Age);
        }
    }
}

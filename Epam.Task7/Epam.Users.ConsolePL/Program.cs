using System;
using Epam.Users.BLL.Interface;
using Epam.Users.Common;

namespace Epam.Users.ConsolePL
{
    public class Program
    {
        private static IUserLogic userLogic = DependencyResolver.UserLogic;
        private static IAwardLogic awardLogic = DependencyResolver.AwardLogic;
        private static IUserAndAwardlogic userAndAwardLogic = DependencyResolver.UserAndAwardLogic;

        public static void Main(string[] args)
        {
            Console.WriteLine("Epam.Task6.Users");
            Console.WriteLine();

            Interaction();
        }

        public static void Interaction()
        {
            string input;
            string name;
            string dateOfBirth;
            string title;

            while (true)
            {
                Console.WriteLine("1 - Add a new user");
                Console.WriteLine("2 - Delete user");
                Console.WriteLine("3 - Get all users");
                Console.WriteLine("4 - Add a new award");
                Console.WriteLine("5 - Delete award");
                Console.WriteLine("6 - Get all awards");
                Console.WriteLine("7 - Give an user an award");
                Console.WriteLine("0 - Exit");
                Console.WriteLine(string.Empty);
                Console.Write(">>");

                input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Your name can contain only letters and digits and be not longer than 15 symbols");
                    Console.WriteLine("Enter your name: ");

                    name = Console.ReadLine();

                    Console.WriteLine("Enter your date fo birth in format DD/MM/YYYY: ");
                    dateOfBirth = Console.ReadLine();

                    try
                    {
                        userLogic.Add(name, dateOfBirth);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter id you want to delete: ");

                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        if (id >= 0)
                        {
                            userLogic.Delete(id);
                            Console.WriteLine("Deleting is successful");
                        }
                        else
                        {
                            Console.WriteLine("Id cannot be less than 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have to enter id correctly");
                    }
                }
                else if (input == "3")
                {
                    foreach (var user in userLogic.GetAll())
                    {
                        Console.Write(user);

                        foreach (var award in userAndAwardLogic.GetAll(user.Id))
                        {
                            Console.Write($" {award}");
                        }

                        Console.WriteLine();
                    }
                }
                else if (input == "4")
                {
                    Console.WriteLine("A title can contain only letters and digits and be not longer than 15 symbols");
                    Console.WriteLine("Enter a title: ");

                    title = Console.ReadLine();

                    try
                    {
                        awardLogic.Add(title);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (input == "5")
                {
                    Console.WriteLine("Enter id you want to delete: ");

                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        if (id >= 0)
                        {
                            awardLogic.Delete(id);
                            Console.WriteLine("Deleting is successful");
                        }
                        else
                        {
                            Console.WriteLine("Id cannot be less than 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have to enter id correctly");
                    }
                }
                else if (input == "6")
                {
                    foreach (var award in awardLogic.GetAll())
                    {
                        Console.WriteLine(award);
                    }
                }
                else if (input == "7")
                {
                    Console.WriteLine("Enter an id of user you want to award");
                    if (int.TryParse(Console.ReadLine(), out int userId))
                    {
                        Console.WriteLine("Enter an id of award you want to award");
                        if (int.TryParse(Console.ReadLine(), out int awardId))
                        {
                            try
                            {
                                userAndAwardLogic.Add(userId, awardId);
                                Console.WriteLine("Success!");
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have to enter award id correctly");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have to enter user id correctly");
                    }
                }
                else if (input == "0")
                {
                    Console.WriteLine("Good luck!");
                    break;
                }
                else
                {
                    Console.WriteLine("You entered incorrect data");
                }

                Console.WriteLine();
            }
        }
    }
}
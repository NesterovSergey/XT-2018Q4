using System;
using System.Collections.Generic;
using System.Linq;
using Epam.Users.BLL.Interface;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;

namespace Epam.Users.BLL
{
    public class UserLogic : IUserLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";

        private IUserDao userDao;
        private ICacheLogic cacheLogic;

        public UserLogic(IUserDao userDao, ICacheLogic cacheLogic)
        {
            this.userDao = userDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(string name, string dateOfBirth, byte[] image)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("You cannot leave the name field empty");
            }
            else if (string.IsNullOrEmpty(dateOfBirth))
            {
                throw new ArgumentException("You cannot leave the date of birth field empty");
            }

            if (!name.All(element => char.IsLetterOrDigit(element)))
            {
                throw new ArgumentException("Your name can contain only letters and digits");
            }
            else if (name.Length > 15)
            {
                throw new ArgumentException("Your name cannot be longer than 15 symbols");
            }

            if (!DateTime.TryParse(dateOfBirth, out DateTime resultTime))
            {
                throw new ArgumentException("You have to enter date of birth correctly");
            }
            else if (DateTime.Now.Year - resultTime.Year <= 3 || DateTime.Now.Year - resultTime.Year >= 150)
            {
                throw new ArgumentException("You cannot be younger than 3 years old or older than 150 years old");
            }

            var user = new User
            {
                Name = name,
                DateOfBirth = resultTime,
                Image = image,
            };

            this.cacheLogic.Delete(AllUsersCacheKey);
            this.userDao.Add(user);
        }

        public void Delete(int id)
        {
            this.cacheLogic.Delete(AllUsersCacheKey);
            this.userDao.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<User>>(AllUsersCacheKey);

            if (cacheResult == null)
            {
                var result = this.userDao.GetAll();
                this.cacheLogic.Add(AllUsersCacheKey, this.userDao.GetAll());

                return result;
            }

            return cacheResult;
        }

        public void Update(int id, string newName, string newDateOfBirth, byte[] newImage)
        {
            if (id < 0)
            {
                throw new ArgumentException("You cannot leave the id field empty or less than 0");
            }

            if (!newName.All(element => char.IsLetterOrDigit(element)))
            {
                throw new ArgumentException("The title can contain only letters and digits");
            }
            else if (newName.Length > 15)
            {
                throw new ArgumentException("The title cannot be longer than 15 symbols");
            }

            if (string.IsNullOrEmpty(newName))
            {
                newName = null;
            }
            
            DateTime resultTime;

            if (!string.IsNullOrEmpty(newDateOfBirth))
            {
                if (!DateTime.TryParse(newDateOfBirth, out resultTime))
                {
                    throw new ArgumentException("You have to enter date of birth correctly");
                }
                else if (DateTime.Now.Year - resultTime.Year <= 3 || DateTime.Now.Year - resultTime.Year >= 150)
                {
                    throw new ArgumentException("You cannot be younger than 3 years old or older than 150 years old");
                }
            }
            else
            {
                resultTime = default(DateTime);
            }

            this.cacheLogic.Delete(AllUsersCacheKey);
            this.userDao.Update(id, newName, resultTime, newImage);
        }
    }
}

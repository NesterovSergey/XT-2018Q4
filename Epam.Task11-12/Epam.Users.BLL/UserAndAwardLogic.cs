using System;
using System.Collections.Generic;
using Epam.Users.BLL.Interface;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;

namespace Epam.Users.BLL
{
    public class UserAndAwardLogic : IUserAndAwardlogic
    {
        private IUserAndAwardDao userAndAwardDao;

        private IUserDao userDao;

        public UserAndAwardLogic(IUserAndAwardDao userAndAwardDao, IUserDao userDao)
        {
            this.userDao = userDao;
            this.userAndAwardDao = userAndAwardDao;
        }

        public void Add(int userId, int awardId)
        {
            var userAndAward = new UserAndAward()
            {
                UserId = userId,
                AwardId = awardId,
            };

            try
            {
                this.userAndAwardDao.Add(userAndAward);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        public void Delete(int id)
        {
            this.userAndAwardDao.Delete(id);
        }

        public IEnumerable<int> GetAll(int userId)
        {
            if (userId < 0)
            {
                throw new ArgumentException("The id cannot be less than 0");
            }

            return this.userAndAwardDao.GetAll(userId);
        }
    }
}

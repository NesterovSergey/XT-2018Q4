using Epam.Users.DAL.Interface;
using Epam.Users.Entities;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.DAL.SQL
{
    public class FakeUserAndAwardSqlDao : IUserAndAwardDao
    {
        public void Add(UserAndAward userAndAward)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAll(User user)
        {
            throw new NotImplementedException();
        }
    }
}

using Epam.Users.DAL.Interface;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.DAL.SQL
{
    public class FakeUserSqlDao : IUserDao
    {
        public void Add(Users.Entities.User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users.Entities.User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Users.Entities.User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, string newName, DateTime date, string image)
        {
            throw new NotImplementedException();
        }
    }
}

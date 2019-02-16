using Epam.Users.DAL.Interface;
using Epam.Users.Entities;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.DAL.SQL
{
    public class FakeAwardSqlDao : IAwardDao
    {
        public void Add(Award award)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAll()
        {
            throw new NotImplementedException();
        }

        public Award GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, string newTitle, string image)
        {
            throw new NotImplementedException();
        }
    }
}

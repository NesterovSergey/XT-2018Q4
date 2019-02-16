using Epam.Users.DAL.Interface;
using Epam.Users.Entities;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.DAL.SQL
{
    public class FakeAccountSqlDao : IAccountDao
    {
        public void AssignRole(string username, string role)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetRole(string username)
        {
            throw new NotImplementedException();
        }

        public string LogIn(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Registration(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}

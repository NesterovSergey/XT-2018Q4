using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.DAL.Interface
{
    public interface IAccountDao
    {
        bool Registration(string username, string password);

        string LogIn(string username);

        string GetRole(string username);

        void AssignRole(string username, string role);

        IEnumerable<Account> GetAll();
    }
}

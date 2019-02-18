using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.BLL.Interface
{
    public interface IAccountLogic
    {
        bool Registration(string username, string password);

        bool LogIn(string username, string password);

        string GetRole(string username);

        void AssignRole(string username, string role);

        IEnumerable<Account> GetAll();
    }
}

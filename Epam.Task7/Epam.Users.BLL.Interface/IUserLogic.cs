using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.BLL.Interface
{
    public interface IUserLogic
    {
        void Add(string name, string dateOfBirth);

        void Delete(int id);

        IEnumerable<User> GetAll();
    }
}

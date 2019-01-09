using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.DAL.Interface
{
    public interface IUserDao
    {
        void Add(User user);

        bool Delete(int id);

        User GetById(int id);

        IEnumerable<User> GetAll();
    }
}

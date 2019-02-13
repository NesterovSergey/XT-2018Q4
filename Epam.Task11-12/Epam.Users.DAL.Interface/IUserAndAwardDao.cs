using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.DAL.Interface
{
    public interface IUserAndAwardDao
    {
        void Add(UserAndAward userAndAward);

        IEnumerable<Award> GetAll(User user);

        void Delete(int id);
    }
}

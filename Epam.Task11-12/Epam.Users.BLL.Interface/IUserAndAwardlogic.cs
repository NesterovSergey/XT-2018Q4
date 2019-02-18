using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.BLL.Interface
{
    public interface IUserAndAwardlogic
    {
        void Add(int userId, int awardId);

        IEnumerable<int> GetAll(int userId);

        void Delete(int id);
    }
}

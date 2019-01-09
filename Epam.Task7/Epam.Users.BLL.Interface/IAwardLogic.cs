using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.BLL.Interface
{
    public interface IAwardLogic
    {
        void Add(string name);

        void Delete(int id);

        IEnumerable<Award> GetAll();
    }
}

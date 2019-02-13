using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.DAL.Interface
{
    public interface IAwardDao
    {
        void Add(Award award);

        bool Delete(int id);

        bool Update(int id, string newTitle, string image);

        Award GetById(int id);

        IEnumerable<Award> GetAll();
    }
}

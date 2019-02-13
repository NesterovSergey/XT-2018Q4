using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.BLL.Interface
{
    public interface IAwardLogic
    {
        void Add(string name, string image);

        void Delete(int id, bool consent);

        void Update(int id, string newTitle, string newImage);

        IEnumerable<Award> GetAll();
    }
}

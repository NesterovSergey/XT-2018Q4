using System.Collections.Generic;
using Epam.Users.Entities;

namespace Epam.Users.BLL.Interface
{
    public interface IUserLogic
    {
        void Add(string name, string dateOfBirth, byte[] image);

        void Delete(int id);

        void Update(int id, string newName, string newDate, byte[] newImage);

        IEnumerable<User> GetAll();
    }
}

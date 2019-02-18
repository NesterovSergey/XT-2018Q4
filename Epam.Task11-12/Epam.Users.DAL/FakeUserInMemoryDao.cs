using System;
using System.Collections.Generic;
using System.Linq;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;

namespace Epam.Users.DAL
{
    public class FakeUserInMemoryDao : IUserDao
    {
        private static Dictionary<int, User> repoUsers;

        public FakeUserInMemoryDao()
        {
            repoUsers = new Dictionary<int, User>();
        }

        public void Add(User user)
        {
            var lastId = repoUsers.Any()
                ? repoUsers.Keys.Max()
                : 0;
            user.Id = ++lastId;

            repoUsers.Add(user.Id, user);
        }

        public User GetById(int id)
        {
            return repoUsers.TryGetValue(id, out var student)
                ? student
                : null;
        }

        public bool Delete(int id)
        {
            return repoUsers.Remove(id);
        }

        public IEnumerable<User> GetAll()
        {
            return repoUsers.Values;
        }

        public bool Update(int id, string newName, DateTime date, byte[] image)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Epam.Users.BLL.Interface;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;

namespace Epam.Users.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private const string AllAwardsCacheKey = "GetAllAwards";

        private IAwardDao awardDao;
        private ICacheLogic cacheLogic;
        private IUserAndAwardlogic userAndAwardlogic;

        public AwardLogic(IAwardDao awardDao, ICacheLogic cacheLogic, IUserAndAwardlogic userAndAwardlogic)
        {
            this.awardDao = awardDao;
            this.cacheLogic = cacheLogic;
            this.userAndAwardlogic = userAndAwardlogic;
        }

        public void Add(string title, byte[] image)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("You cannot leave the title field empty");
            }

            if (!title.All(element => char.IsLetterOrDigit(element)))
            {
                throw new ArgumentException("The title can contain only letters and digits");
            }
            else if (title.Length > 15)
            {
                throw new ArgumentException("The title cannot be longer than 15 symbols");
            }

            var award = new Award
            {
                Title = title,
                Image = image,
            };

            this.cacheLogic.Delete(AllAwardsCacheKey);
            this.awardDao.Add(award);
        }

        public void Delete(int id, bool consent)
        {
            this.cacheLogic.Delete(AllAwardsCacheKey);
            this.awardDao.Delete(id);

            if (consent)
            {
                this.userAndAwardlogic.Delete(id);
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Award>>(AllAwardsCacheKey);

            if (cacheResult == null)
            {
                var result = this.awardDao.GetAll();
                this.cacheLogic.Add(AllAwardsCacheKey, this.awardDao.GetAll());

                return result;
            }

            return cacheResult;
        }

        public void Update(int id, string newTitle, byte[] image)
        {
            if (id < 0)
            {
                throw new ArgumentException("You cannot leave the id field empty");
            }
            if (string.IsNullOrEmpty(newTitle))
            {
                newTitle = null;
                //throw new ArgumentException("You cannot leave the title field empty");
            }
            else if (!newTitle.All(element => char.IsLetterOrDigit(element)))
            {
                throw new ArgumentException("The title can contain only letters and digits");
            }
            else if (newTitle.Length > 15)
            {
                throw new ArgumentException("The title cannot be longer than 15 symbols");
            }

            this.cacheLogic.Delete(AllAwardsCacheKey);
            this.awardDao.Update(id, newTitle, image);
        }
    }
}

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

        public AwardLogic(IAwardDao awardDao, ICacheLogic cacheLogic)
        {
            this.awardDao = awardDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(string title)
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
            };

            this.cacheLogic.Delete(AllAwardsCacheKey);
            this.awardDao.Add(award);
        }

        public void Delete(int id)
        {
            this.cacheLogic.Delete(AllAwardsCacheKey);
            this.awardDao.Delete(id);
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
    }
}

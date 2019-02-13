using System.Configuration;
using Epam.Users.BLL;
using Epam.Users.BLL.Interface;
using Epam.Users.DAL;
using Epam.Users.DAL.Interface;
using Epam.Users.DAL.TextFiles;

namespace Epam.Users.Common
{
    public class DependencyResolver
    {
        private static IUserDao userDao;
        private static IAwardDao awardDao;
        private static IUserAndAwardDao userAndAwardDao;
        private static IUserLogic userLogic;
        private static ICacheLogic cacheLogic;
        private static IAwardLogic awardLogic;
        private static IUserAndAwardlogic userAndAwardLogic;

        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserKey"];

                if (userDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "textfiles":
                            {
                                userDao = new FakeUserTextDao();
                                break;
                            }

                        case "memory":
                            {
                                userDao = new FakeUserInMemoryDao();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return userDao;
            }
        }

        public static IAwardDao AwardDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoAwardKey"];

                if (awardDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "textfiles":
                            {
                                awardDao = new FakeAwardTextDao();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return awardDao;
            }
        }

        public static IUserAndAwardDao UserAndAwardDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserAndAwardKey"];

                if (userAndAwardDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "textfiles":
                            {
                                userAndAwardDao = new FakeUserAndAwardDao();
                                break;
                            }

                        default:
                            break;
                    }
                }

                return userAndAwardDao;
            }
        }

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao, CacheLogic));

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());

        public static IAwardLogic AwardLogic => awardLogic ?? (awardLogic = new AwardLogic(AwardDao, CacheLogic, UserAndAwardLogic));

        public static IUserAndAwardlogic UserAndAwardLogic => userAndAwardLogic ?? (userAndAwardLogic = new UserAndAwardLogic(UserAndAwardDao, UserDao));
    }
}

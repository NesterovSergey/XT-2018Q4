using System;
using System.Web.Security;
using Epam.Users.BLL.Interface;
using Epam.Users.Common;

namespace Epam.UsersAndAwards.WebPagesPL
{
    public class MyRoleProvider : RoleProvider
    {
        private static IAccountLogic accountLogic;
        private string currentName;
        private string currentRole;

        public MyRoleProvider()
        {
            accountLogic = DependencyResolver.AccountLogic;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == null)
            {
                return false;
            }

            if (roleName == null)
            {
                return false;
            }

            foreach (var role in this.GetRolesForUser(username))
            {
                if (role == roleName)
                {
                    return true;
                }
            }

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            if (this.currentName != username || this.currentName == null)
            {
                this.currentName = username;
                this.currentRole = accountLogic.GetRole(this.currentName);
            }

            switch (this.currentRole)
            {
                case "admin":
                    return new[] { "admin", "user" };
                case "user":
                    return new[] { "user" };
                default:
                    return new[] { "anonym" };
            }
        }

        #region IsNotImplemented

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
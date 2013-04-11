using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ScrumProject.Models
{
    public class SMRPORoleProvider : RoleProvider
    {
        private UserRepository userR;

        public SMRPORoleProvider()
        {
            this.userR = new UserRepository();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            User user = userR.GetByUsername(username);
            bool admin = (user.isAdmin.Equals(null) ? false : (bool)user.isAdmin);
            if (admin)
                return new string[1] {"admin"};
            else
                return new string[1] {"user"};
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            User user = userR.GetByUsername(username);
            bool admin = (user.isAdmin.Equals(null) ? false : (bool) user.isAdmin);
            if (roleName == "admin" && admin)
                return true;
            else if (roleName == "user" && !admin)
                return true;
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
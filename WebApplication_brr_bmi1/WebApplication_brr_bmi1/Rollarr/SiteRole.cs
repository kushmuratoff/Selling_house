using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication_brr_bmi1.Models;

namespace WebApplication_brr_bmi1.Rollarr
{
    public class SiteRole : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (BazaContext db = new BazaContext())
            {
                // var roles = "";
                // Получаем пользователя
                var roleid = db.Users.Where(u => u.Login == username).First().RolesId;
                if (roleid != null)
                {
                    var rolee = db.Roles.Where(r => r.Id == roleid).First().Nomi;
                    // получаем роль
                    roles = new string[] { rolee };
                }
                return roles;
            }
            //return roles;
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            //using (UserContext db = new UserContext())
            //{
            //    // Получаем пользователя
            //    User user = db.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == username);

            //    if (user != null && user.Role != null && user.Role.Name == roleName)
            //        return true;
            //    else
            //        return false;
            //}
            return false;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
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

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;
using System.Security.Principal;

namespace Auction.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private IRoleService roleService;
        private IUserService userService;
        private IUserInRoleService userInRoleService;

        public CustomRoleProvider(IRoleService roleService, IUserService userService, IUserInRoleService userInRoleService)
        {
            this.roleService = roleService;
            this.userService = userService;
            this.userInRoleService = userInRoleService;
        }

        public override bool IsUserInRole(string login, string roleName)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(roleName)) return false;
            bool outputResult = false;

            try
            {

                UserEntity user = userService.GetUserByLogin(login);

                if (user != null)
                {
                    var userInRole = userInRoleService.GetUserInRoleByUserId(user.Id);
                    var role = roleService.GetRoleByName(roleName);
                    if ((userInRole != null) && (role != null))
                    {
                        foreach (var entity in userInRole)
                        {
                            if (entity.RoleId == role.Id)
                            {
                                return true;
                            }
                        }
                    }
                    else
                        return false;
                }

            }
            catch
            {
                outputResult = false;
            }

            return outputResult;
        }
        public override string[] GetRolesForUser(string login)
        {
            if (login == null) return null;

            string[] roles = new string[] { };

            try
            {
                UserEntity user = userService.GetUserByLogin(login);

                if (user == null)
                {
                    return roles;
                }
                var userInRole = userInRoleService.GetUserInRoleByUserId(user.Id);
                int i = 0;
                foreach (var entity in userInRole)
                {
                    roles[i++] = roleService.GetRoleById(entity.RoleId).Name;
                }
            }
            catch
            {
                return roles;
            }
            return roles;
        }
        public override void CreateRole(string roleName)
        {
            roleService.Create(new RoleEntity() { Name = roleName });
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            bool isDeleted = false;

            try
            {
                RoleEntity role = roleService.GetRoleByName(roleName);
                if (role != null)
                {
                    roleService.Delete(role.Id);
                    isDeleted = true;
                }
            }
            catch
            {
                isDeleted = false;
            }
            return isDeleted;
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}
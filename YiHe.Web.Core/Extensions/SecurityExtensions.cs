﻿using System.Linq;
using System.Security.Principal;
using YiHe.Web.Core.Models;


namespace YiHe.Web.Core.Extensions
{
    public static class SecurityExtensions
    {
        public static string Name(this IPrincipal user)
        {
            return user.Identity.Name;
        }

        public static bool InAnyRole(this IPrincipal user, params string[] roles)
        {
            return roles.Any(user.IsInRole);
        }

        public static bool IsManagerRole(this IPrincipal user)
        {
            return InAnyRole(user, new[] {Roles.MANAGER});
        }

        public static bool IsAdminRole(this IPrincipal user)
        {
            return InAnyRole(user, new[] {Roles.ADMIN});
        }

        public static YiHeUser GetYiHeUser(this IPrincipal principal)
        {
            if (principal.Identity is YiHeUser)
                return (YiHeUser) principal.Identity;

            return new YiHeUser(string.Empty, new UserInfo());
        }

        public static int GetRoleID(this IPrincipal user)
        {
            return GetYiHeUser(user).RoleId;
        }
    }
}
using System;
using System.Web.Mvc;


namespace YiHe.Web.Core.ActionFilters
{
    public class YiHeAuthorize : AuthorizeAttribute
    {
        public YiHeAuthorize(params string[] roles)
        {
            Roles = String.Join(", ", roles);
        }
    }
}
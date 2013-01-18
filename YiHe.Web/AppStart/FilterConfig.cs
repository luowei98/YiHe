using System.Web.Mvc;
using YiHe.Web.Core.ActionFilters;


namespace YiHe.Web.AppStart
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UserFilter());
        }
    }
}
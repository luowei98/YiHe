using System.Web.Mvc;
using System.Web.Routing;


namespace YiHe.Web.AppStart
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Article",
                "Article/Article{id}",
                new {controller = "Article", action = "Article", id = UrlParameter.Optional},
                new[] {"YiHe.Web.Controllers"}
                );

            routes.MapRoute(
                "ArticleCategory",
                "Article/Category{cid}",
                new {controller = "Article", action = "Category", cid = UrlParameter.Optional},
                new[] {"YiHe.Web.Controllers"}
                );

            routes.MapRoute(
                "ArticleTag",
                "Article/Tag{tid}",
                new {controller = "Article", action = "Tag", tid = UrlParameter.Optional},
                new[] {"YiHe.Web.Controllers"}
                );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}
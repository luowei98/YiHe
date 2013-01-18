using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using YiHe.Web.AppStart;
using YiHe.Web.Core.Authentication;
using YiHe.Web.Core.Models;


namespace YiHe.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public override void Init()
        {
            PostAuthenticateRequest += PostAuthenticateRequestHandler;

            base.Init();
        }

        private void PostAuthenticateRequestHandler(object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (IsValidAuthCookie(authCookie))
            {
                var formsAuthentication = DependencyResolver.Current.GetService<IFormsAuthentication>();

                if (authCookie != null)
                {
                    FormsAuthenticationTicket ticket = formsAuthentication.Decrypt(authCookie.Value);
                    var yiheUser = new YiHeUser(ticket);
                    string[] userRoles = {yiheUser.RoleName};
                    Context.User = new GenericPrincipal(yiheUser, userRoles);
                    formsAuthentication.SetAuthCookie(Context, ticket);
                }
            }
        }

        private static bool IsValidAuthCookie(HttpCookie authCookie)
        {
            return authCookie != null && !String.IsNullOrEmpty(authCookie.Value);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            Bootstrapper.Run();
        }
    }
}
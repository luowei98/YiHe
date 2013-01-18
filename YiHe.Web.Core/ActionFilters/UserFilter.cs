using System.Web.Mvc;
using YiHe.Web.Core.Extensions;
using YiHe.Web.Core.Models;


namespace YiHe.Web.Core.ActionFilters
{
    //Inject a ViewBag object to Views for getting information about an authenticated user
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            UserModel userModel;
            if (filterContext.Controller.ViewBag.UserModel == null)
            {
                userModel = new UserModel();
                filterContext.Controller.ViewBag.UserModel = userModel;
            }
            else
            {
                userModel = filterContext.Controller.ViewBag.UserModel as UserModel;
            }
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                YiHeUser yiheUser = filterContext.HttpContext.User.GetYiHeUser();
                if (userModel != null)
                {
                    userModel.IsUserAuthenticated = yiheUser.IsAuthenticated;
                    userModel.UserName = yiheUser.DisplayName;
                    userModel.RoleName = yiheUser.RoleName;
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }

    public class UserModel
    {
        public bool IsUserAuthenticated { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
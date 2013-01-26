using System.Linq;
using System.Web.Mvc;
using YiHe.Data.Repositories.Navigation;
using YiHe.Model.Navigation;


namespace YiHe.Web.Helpers
{
    public static class ControllerHelper
    {
        public static int ActionMenuId(ControllerContext context, IMenuRepository menuRepository)
        {
            string controller = context.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            string action = context.Controller.ValueProvider.GetValue("action").RawValue.ToString();

            return ActionMenuId(menuRepository, controller, action);
        }

        public static int ActionMenuId(IMenuRepository menuRepository, string controller, string action)
        {
            Menu[] menus = menuRepository
                .GetMany(m => m.UrlController == controller && m.UrlAction == action)
                .ToArray();

            if (!menus.Any()) return -1;

            if (menus.Count() == 1)
                return menus.First().MenuId;

            return menus.First(m => m.Parent != null).MenuId;
        }
    }
}
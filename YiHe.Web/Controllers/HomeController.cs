using System;
using System.Linq;
using System.Web.Mvc;
using YiHe.Data.Repositories.Navigation;
using YiHe.Model.Navigation;
using YiHe.Web.Core.Extensions;


namespace YiHe.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Random RND = new Random();

        private readonly IMenuRepository menuRepository;

        private readonly string[] menuAnimMode =
            {
                "def",
                "fade",
                "seqFade",
                "horizontalSlide",
                "seqHorizontalSlide",
                "verticalSlide",
                "seqVerticalSlide",
                "verticalSlideAlt",
                "seqVerticalSlideAlt",
            };

        public HomeController(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var menusEnum = menuRepository.GetAllWithCategories(User.GetRoleID());
            Menu[] menus = menusEnum as Menu[] ?? menusEnum.ToArray();
            if (menus.Any())
            {
                Menu main = menus.SingleOrDefault(m => m.MenuId == 1);
                ViewBag.MainBackground = main != null ? main.BackgroundImage : "/Images/about/photo/consultingroom1.jpg";
                menus = menus.Where(m => m.MenuId != 1).ToArray();
            }

            ViewBag.AnimMode = menuAnimMode[RND.Next(menuAnimMode.Length)];

            return View(menus);
        }
    }
}
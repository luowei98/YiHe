using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using YiHe.Data.Repositories.Navigation;
using YiHe.Model.Navigation;
using YiHe.Web.Core.ActionFilters;
using YiHe.Web.Core.Authentication;
using YiHe.Web.Core.Models;


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
            var menusEnum = menuRepository.GetAllWithCategories();
            Menu[] menus = menusEnum as Menu[] ?? menusEnum.ToArray();
            if (menus.Any())
            {
                Menu main = menus.SingleOrDefault(m => m.MenuId == 1);
                ViewBag.MainBackground = main != null ? main.BackgroundImage : "/Images/about/photo/consultingroom1.jpg";
                menus = menus.Where(m => m.MenuId != 1).ToArray();
            }

            int role = 0;
            if (Request.IsAuthenticated)
            {
                // todo
                //User.Identity.Name
            }
            menus = menus.Where(m => m.Role <= role).ToArray();

            ViewBag.AnimMode = menuAnimMode[RND.Next(menuAnimMode.Length)];

            return View(menus);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
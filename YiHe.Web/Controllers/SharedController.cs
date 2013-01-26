using System;
using System.Linq;
using System.Web.Mvc;
using YiHe.Data.Repositories.Library;
using YiHe.Data.Repositories.Navigation;


namespace YiHe.Web.Controllers
{
    public class SharedController : Controller
    {

        private readonly IMenuRepository menuRepository;
        private readonly IOuterLinkRepository outerLinkRepository;
        private readonly ISliderRepository sliderRepository;
        private readonly IArticleRepository articleRepository;

        public SharedController(IMenuRepository menuRepository, 
                                IOuterLinkRepository outerLinkRepository,
                                ISliderRepository sliderRepository,
                                IArticleRepository articleRepository)
        {
            this.menuRepository = menuRepository;
            this.outerLinkRepository = outerLinkRepository;
            this.sliderRepository = sliderRepository;
            this.articleRepository = articleRepository;
        }

        [AllowAnonymous]
        public ActionResult _Menu(string controller, string action, string id)
        {
            var menus = menuRepository.GetAllWithCategories();

            ViewBag.ActiveController = controller;
            if (action.ToLower() == "article")// && id.Length > 0)
            {
                try
                {
                    int aid = int.Parse(id);
                    ViewBag.ActiveAction = "Category" +
                                           articleRepository.GetById(aid).Category.CategoryId.ToString();
                }
                catch
                {
                    ViewBag.ActiveAction = action + id;
                }
            }
            else
            {
                ViewBag.ActiveAction = action + id;
            }

            return PartialView(menus);
        }

        [AllowAnonymous]
        public ActionResult _Footer()
        {
            var links = outerLinkRepository.GetAllByOrder().ToList();

            return PartialView(links);
        }

        [AllowAnonymous]
        public ActionResult _Slider()
        {
            var sliders = sliderRepository.GetAllByOrder().ToList();

            return PartialView(sliders);
        }

    }
}

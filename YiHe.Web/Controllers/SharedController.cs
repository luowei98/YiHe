using System.Linq;
using System.Web.Mvc;
using YiHe.Data.Repositories.Navigation;


namespace YiHe.Web.Controllers
{
    public class SharedController : Controller
    {

        private readonly IMenuRepository menuRepository;
        private readonly IOuterLinkRepository outerLinkRepository;
        private readonly ISliderRepository sliderRepository;

        public SharedController(IMenuRepository menuRepository, 
                                IOuterLinkRepository outerLinkRepository,
                                ISliderRepository sliderRepository)
        {
            this.menuRepository = menuRepository;
            this.outerLinkRepository = outerLinkRepository;
            this.sliderRepository = sliderRepository;
        }

        [AllowAnonymous]
        public ActionResult _Menu(string controller, string action)
        {
            var menus = menuRepository.GetAllWithCategories();

            ViewBag.ActiveController = controller;
            ViewBag.ActiveAction = action;

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

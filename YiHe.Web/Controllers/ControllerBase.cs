using System.Web.Mvc;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;
using YiHe.Web.Helpers;


namespace YiHe.Web.Controllers
{
    //[CompressResponse]
    public class BaseController : Controller
    {
        public readonly IMenuRepository MenuRepository;
        public readonly IPartRepository PartRepository;

        public BaseController(IMenuRepository menuRepository,
                               IPartRepository partRepository)
        {
            MenuRepository = menuRepository;
            PartRepository = partRepository;
        }

        public virtual ActionResult Index()
        {
            return DefaultResult();
        }

        public virtual ActionResult DefaultResult()
        {
            int id = ControllerHelper.ActionMenuId(ControllerContext, MenuRepository);

            var part = PartRepository.GetByMenuId(id);

            if (part == null)
            {
                return new EmptyResult();
            }

            return View(part);
        }
    }
}
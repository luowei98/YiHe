using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YiHe.CommandProcessor.Dispatcher;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;
using YiHe.Web.Helpers;


namespace YiHe.Web.Controllers
{
    //[CompressResponse]
    public class ControllerBase : Controller
    {
        public readonly ICommandBus CommandBus;
        public readonly IMenuRepository MenuRepository;
        public readonly IPartRepository PartRepository;

        public ControllerBase(ICommandBus commandBus, 
                              IMenuRepository menuRepository,
                              IPartRepository partRepository)
        {
            CommandBus = commandBus;
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

            // ReSharper disable Mvc.ViewNotResolved
            return View(part);
            // ReSharper restore Mvc.ViewNotResolved
        }

        public IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }
    }
}
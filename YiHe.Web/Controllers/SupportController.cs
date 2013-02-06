using System.Web.Mvc;
using YiHe.CommandProcessor.Dispatcher;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;


namespace YiHe.Web.Controllers
{
    public class SupportController : ControllerBase
    {
        public SupportController(ICommandBus commandBus,
                                 IMenuRepository menuRepository,
                                 IPartRepository partRepository)
            : base(commandBus, menuRepository, partRepository)
        {
        }

        public ActionResult FQA()
        {
            return base.DefaultResult();
        }

        public ActionResult OfficeHours()
        {
            return base.DefaultResult();
        }

        public ActionResult Fees()
        {
            return base.DefaultResult();
        }

        public ActionResult Video()
        {
            return base.DefaultResult();
        }
    }
}
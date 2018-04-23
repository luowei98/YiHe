using YiHe.CommandProcessor.Dispatcher;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;


namespace YiHe.Web.Controllers
{
    using System.Web.Mvc;

    public class TrainController : ControllerBase
    {
        public TrainController(ICommandBus commandBus,
                               IMenuRepository menuRepository,
                               IPartRepository partRepository)
            : base(commandBus, menuRepository, partRepository)
        {
        }

        public ActionResult QA()
        {
            return base.DefaultResult();
        }
    }
}
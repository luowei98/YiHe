using YiHe.CommandProcessor.Dispatcher;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;


namespace YiHe.Web.Controllers
{
    public class ContactController : ControllerBase
    {
        public ContactController(ICommandBus commandBus,
                                 IMenuRepository menuRepository,
                                 IPartRepository partRepository)
            : base(commandBus, menuRepository, partRepository)
        {
        }
    }
}
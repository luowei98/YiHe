using System.Web.Mvc;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;


namespace YiHe.Web.Controllers
{
    public class ContactController : BaseController
    {
        public ContactController(IMenuRepository menuRepository,
                                 IPartRepository partRepository)
            : base(menuRepository, partRepository)
        {
        }
    }
}
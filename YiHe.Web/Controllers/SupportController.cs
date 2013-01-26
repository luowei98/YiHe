using System.Web.Mvc;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;


namespace YiHe.Web.Controllers
{
    public class SupportController : BaseController
    {
        public SupportController(IMenuRepository menuRepository,
                                 IPartRepository partRepository)
            : base(menuRepository, partRepository)
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
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;
using YiHe.Model.Material;
using YiHe.Web.Core.ActionFilters;
using YiHe.Web.Helpers;


namespace YiHe.Web.Controllers
{
    [CompressResponse]
    public class AboutController : Controller
    {
        private readonly IMenuRepository menuRepository;
        private readonly IOfficePhotoRepository officePhotoRepository;
        private readonly IPartRepository partRepository;
        private readonly IStaffRepository staffRepository;

        public AboutController(IMenuRepository menuRepository,
                               IPartRepository partRepository,
                               IStaffRepository staffRepository,
                               IOfficePhotoRepository officePhotoRepository)
        {
            this.menuRepository = menuRepository;
            this.partRepository = partRepository;
            this.staffRepository = staffRepository;
            this.officePhotoRepository = officePhotoRepository;
        }

        public ActionResult Index()
        {
            return result();
        }

        public ActionResult Staff()
        {
            return result();
        }

        public ActionResult _StaffList()
        {
            IEnumerable<Staff> staffs = staffRepository.GetAllByOrder();

            return PartialView(staffs);
        }

        public ActionResult Photo()
        {
            return result();
        }

        public ActionResult _Gallery(int position)
        {
            OfficePhoto photo = officePhotoRepository.GetByPosition(position);
            ViewBag.DivClass = position == 1 || position == 4 ? "gallery_v" : "gallery_h";

            return PartialView(photo);
        }

        public ActionResult News()
        {
            return result();
        }


        private ActionResult result()
        {
            int id = ControllerHelper.ActionMenuId(ControllerContext, menuRepository);
            IEnumerable<Part> parts = partRepository.GetMany(p => p.MenuId == id);

            Part[] partsarr = parts as Part[] ?? parts.ToArray();
            if (!partsarr.Any())
            {
                return new EmptyResult();
            }

            return View(partsarr.First());
        }
    }
}
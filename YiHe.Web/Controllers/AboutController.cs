using System.Collections.Generic;
using System.Web.Mvc;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;
using YiHe.Model.Material;
using YiHe.Web.Core.ActionFilters;
using YiHe.Web.Helpers;


namespace YiHe.Web.Controllers
{
    [CompressResponse]
    public class AboutController : BaseController
    {
        private readonly IOfficePhotoRepository officePhotoRepository;
        private readonly IStaffRepository staffRepository;

        public AboutController(IMenuRepository menuRepository,
                               IPartRepository partRepository,
                               IStaffRepository staffRepository,
                               IOfficePhotoRepository officePhotoRepository)
            : base(menuRepository, partRepository)
        {
            this.staffRepository = staffRepository;
            this.officePhotoRepository = officePhotoRepository;
        }

        public ActionResult Staff()
        {
            return base.DefaultResult();
        }

        public ActionResult _StaffList()
        {
            IEnumerable<Staff> staffs = staffRepository.GetAllByOrder();

            return PartialView(staffs);
        }

        public ActionResult Photo()
        {
            return base.DefaultResult();
        }

        public ActionResult _Gallery(int position)
        {
            OfficePhoto photo = officePhotoRepository.GetByPosition(position);
            ViewBag.DivClass = position == 1 || position == 4 ? "gallery_v" : "gallery_h";

            return PartialView(photo);
        }

        public ActionResult News()
        {
            return base.DefaultResult();
        }
    }
}
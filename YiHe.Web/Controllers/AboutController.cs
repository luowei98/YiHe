using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MvcPaging;
using YiHe.CommandProcessor.Dispatcher;
using YiHe.Data.Repositories.Material;
using YiHe.Data.Repositories.Navigation;
using YiHe.Domain.Commands.Material;
using YiHe.Model.Material;
using YiHe.Web.Core.Extensions;
using YiHe.Web.Core.FineUploader;
using YiHe.Web.Helpers;
using YiHe.Web.ViewModels.Material;
using YiHe.Core.Common;


namespace YiHe.Web.Controllers
{
    public class AboutController : ControllerBase
    {
        private readonly IOfficePhotoRepository officePhotoRepository;
        private readonly IStaffRepository staffRepository;
        private readonly INewsRepository newsRepository;

        public AboutController(ICommandBus commandBus,
                               IMenuRepository menuRepository,
                               IPartRepository partRepository,
                               IStaffRepository staffRepository,
                               IOfficePhotoRepository officePhotoRepository,
                               INewsRepository newsRepository)
            : base(commandBus, menuRepository, partRepository)
        {
            this.staffRepository = staffRepository;
            this.officePhotoRepository = officePhotoRepository;
            this.newsRepository = newsRepository;
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

        // News -------------------------------------------------------------------------------------------------------
        public ActionResult News()
        {
            return base.DefaultResult();
        }

        public ActionResult _NewsList(int? page)
        {
            int currPageIdx = page.HasValue ? page.Value - 1 : 0;

            IEnumerable<News> news = newsRepository.GetAll();

            var newsPaged = news
                .OrderByDescending(n => n.CreateTime)
                .ThenByDescending(n => n.NewsId)
                .ToPagedList(currPageIdx, PagerHelper.PAGE_SIZE);

            return PartialView(newsPaged);
        }

        public ActionResult CreateNews()
        {
            return View(new NewsFormModel());
        }

        public ActionResult EditNews(int newsId)
        {
            var news = newsRepository.GetById(newsId);
            var viewModel = Mapper.Map<News, NewsFormModel>(news);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNews(NewsFormModel form)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<NewsFormModel, CreateOrUpdateNewsCommand>(form);
                IEnumerable<ValidationResult> errors = CommandBus.Validate(command);
                ModelState.AddModelErrors(errors);

                if (ModelState.IsValid)
                {
                    var result = CommandBus.Submit(command);
                    if (result.Success)
                    {
                        return RedirectToAction("News");
                    }
                }
            }

            //if fail
            var view = form.NewsId == 0 ? "CreateNews" : "EditNews";
            return View(view, form);
        }

        [HttpPost]
        public ActionResult DeleteNews(int newsId, int page)
        {
             var command = new DeleteNewsCommand { NewsId = newsId };
            CommandBus.Submit(command);

            var news = newsRepository.GetAll();
            var newsPaged = news
                .OrderByDescending(n => n.CreateTime)
                .ToPagedList(page - 1, PagerHelper.PAGE_SIZE);

            return PartialView("_NewsList", newsPaged);
        }

        [HttpPost]
        public FineUploaderResult _UploadNewsPicture(FineUpload upload)
        {
            const string path = "/Images";

            var randomName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + Path.GetExtension(upload.Filename);
            var filePath = Server.MapPath(Path.Combine(path, PathHelper.NewsPicture(randomName)));
            try
            {
                upload.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                return new FineUploaderResult(false, error: ex.Message);
            }

            return new FineUploaderResult(true, new { fullfilename = path + "/" + PathHelper.NewsPicture(randomName), filename = randomName });
        }
    }
}
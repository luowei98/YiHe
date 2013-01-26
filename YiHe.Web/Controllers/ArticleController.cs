using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MvcPaging;
using YiHe.CommandProcessor.Dispatcher;
using YiHe.Data.Repositories.Library;
using YiHe.Domain.Commands.Library;
using YiHe.Model.Library;
using YiHe.Web.Helpers;
using YiHe.Web.Models.Library;


namespace YiHe.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ICommandBus commandBus;
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ITagRepository tagRepository;

        public ArticleController(
            ICommandBus commandBus, 
            IArticleRepository articleRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository)
        {
            this.commandBus = commandBus;
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
            this.tagRepository = tagRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(int? cid)
        {
            if (cid.HasValue)
            {
                var category = categoryRepository.GetById(cid.Value);
                if (category != null)
                    ViewBag.CategoryTitle = category.Name;
            }

            return View("Index");
        }

        public ActionResult Tag(int? tid)
        {
            if (tid.HasValue)
            {
                var tag = tagRepository.GetById(tid.Value);
                if (tag != null)
                    ViewBag.TagTitle = tag.Name;
            }

            return View("Index");
        }

        public JsonResult _TagsCloud()
        {
            var tags = new List<dynamic>();

            foreach (var t in tagRepository.GetTopUsed(20))
            {
                tags.Add(new
                {
                    text = t.Name,
                    weight = t.Used,
                    link = Url.Action("Tag", new { tid = t.TagId }),
                });
            }

            return Json(tags, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _ArticleList(int? page, int? cid, int? tid)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            IEnumerable<Article> articles;

            if (cid.HasValue && tid.HasValue)
            {
                articles = articleRepository.GetManyByCategoryIdTagId(cid.Value, tid.Value);
            }
            else if (cid.HasValue)
            {
                articles = articleRepository.GetManyByCategoryId(cid.Value);
            }
            else if (tid.HasValue)
            {
                articles = articleRepository.GetManyByTagId(tid.Value);
            }
            else
            {
                articles = articleRepository.GetAll();
            }

            var articlesPaged = articles
                .OrderByDescending(a => a.CreateTime)
                .ToPagedList(currentPageIndex, PagerHelper.PAGE_SIZE);

            return PartialView(articlesPaged);
        }

        public ActionResult Article(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var article = articleRepository.GetById(id.Value);

            if (article == null)
                return RedirectToAction("Index");

            var command = new AddBrowsetimesArticleCommand
                          {
                              ArticleId = article.ArticleId,
                          };
            commandBus.Submit(command);

            ViewBag.Keywords = string.Join(",", article.Tags.Select(t => t.Name).Concat(new[] { article.Category.Name }));

            var articleModel = Mapper.Map<Article, ArticleModel>(article);

            return View(articleModel);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult _HotArticle()
        {
            var articles = articleRepository.GetManyLastBy(a => a.BrowseTimes, 10);

            return PartialView("_ArticleTitles", articles);
        }

        public ActionResult _RelationArticle(int id)
        {
            var articles = articleRepository.GetRelationArticles(id, 10);

            return PartialView("_ArticleTitles", articles);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using YiHe.Data.Infrastructure;
using YiHe.Data.Repositories.Library;
using YiHe.Model.Navigation;


namespace YiHe.Data.Repositories.Navigation
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        private readonly ICategoryRepository categoryRepository;

        public MenuRepository(IDatabaseFactory databaseFactory, ICategoryRepository categoryRepository)
            : base(databaseFactory)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Menu> GetAllWithCategories()
        {
            var menus = GetMany(m => m.Parent == null).OrderBy(m => m.Position);

            Menu articleMenu = menus.SingleOrDefault(m => m.MenuId == 3); // 3 is 文章 id
            if (articleMenu != null)
            {
                var categroySubMenu = articleMenu.Children;
                if (categroySubMenu != null && categroySubMenu.Any())
                {
                    Menu allCategroySubMenu = categroySubMenu.First();

                    var categories = categoryRepository.GetAll();
                    foreach (var c in categories)
                    {
                        categroySubMenu.Add(new Menu
                                            {
                                                MenuText = c.Name,
                                                Position = c.CategoryId,
                                                UrlController = allCategroySubMenu.UrlController,
                                                UrlAction = "Category" + c.CategoryId.ToString(),
                                            });
                    }
                }
            }

            foreach (var m in menus)
            {
                m.Children = m.Children.OrderBy(o => o.Position).ToArray();
            }

            return menus;
        }
    }

    public interface IMenuRepository : IRepository<Menu>
    {
        IEnumerable<Menu> GetAllWithCategories();
    }
}
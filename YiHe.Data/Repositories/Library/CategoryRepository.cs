using YiHe.Data.Infrastructure;
using YiHe.Model.Library;


namespace YiHe.Data.Repositories.Library
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
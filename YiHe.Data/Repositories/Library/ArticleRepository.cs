using System.Collections.Generic;
using YiHe.Data.Infrastructure;
using YiHe.Model.Library;


namespace YiHe.Data.Repositories.Library
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        #region ICategoryRepository Members

        public IEnumerable<Article> GetArticle()
        {
            return GetAll();
        }

        #endregion
    }

    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetArticle();
    }
}
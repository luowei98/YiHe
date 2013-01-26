using System.Collections.Generic;
using YiHe.Data.Infrastructure;
using YiHe.Model.Library;
using System.Linq;


namespace YiHe.Data.Repositories.Library
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        #region ICategoryRepository Members

        public IEnumerable<Article> GetManyByCategoryId(int categoryId)
        {
            return GetMany(a => a.CategoryId == categoryId);
        }

        public IEnumerable<Article> GetManyByTagId(int tagId)
        {
            return GetMany(a => a.Tags.Any(t => t.TagId == tagId));
        }

        public IEnumerable<Article> GetManyByTags(IEnumerable<int> tags)
        {
            return GetMany(a => a.Tags.Select(t => t.TagId).Intersect(tags).Any());
        }

        public IEnumerable<Article> GetManyByCategoryIdTagId(int categoryId, int tagId)
        {
            return GetMany(a =>
                a.CategoryId == categoryId &&
                a.Tags.Any(t => t.TagId == tagId));
        }

        public IEnumerable<Article> GetRelationArticles(int id, int count)
        {
            var tagIds = GetById(id).TripTags.Select(t => t.TagId);

            return GetManyByTags(tagIds)
                .Where(a => a.ArticleId != id)
                .OrderByDescending(a => a.BrowseTimes)
                .Take(count);
        }

        #endregion
    }

    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetManyByCategoryId(int categoryId);
        IEnumerable<Article> GetManyByTagId(int tagId);
        IEnumerable<Article> GetManyByCategoryIdTagId(int categoryId, int tagId);
        IEnumerable<Article> GetManyByTags(IEnumerable<int> tags);
        IEnumerable<Article> GetRelationArticles(int id, int count);
    }
}
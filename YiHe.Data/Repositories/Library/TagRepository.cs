using System.Collections.Generic;
using YiHe.Data.Infrastructure;
using YiHe.Model.Library;


namespace YiHe.Data.Repositories.Library
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<Tag> GetTopUsed(int count)
        {
            return GetManyLastBy(t => t.Used, count);
        }
    }

    public interface ITagRepository : IRepository<Tag>
    {
        IEnumerable<Tag> GetTopUsed(int no);
    }
}
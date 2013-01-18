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
    }

    public interface ITagRepository : IRepository<Tag>
    {
    }
}
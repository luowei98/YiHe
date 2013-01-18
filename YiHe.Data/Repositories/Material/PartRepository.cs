using YiHe.Data.Infrastructure;
using YiHe.Model.Material;


namespace YiHe.Data.Repositories.Material
{
    public class PartRepository : RepositoryBase<Part>, IPartRepository
    {
        public PartRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IPartRepository : IRepository<Part>
    {
    }
}
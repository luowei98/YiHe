using System.Linq;
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

        public Part GetByMenuId(int mid)
        {
            return GetMany(p => p.MenuId == mid).FirstOrDefault();
        }
    }

    public interface IPartRepository : IRepository<Part>
    {
        Part GetByMenuId(int mid);
    }
}
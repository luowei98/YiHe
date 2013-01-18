using YiHe.Data.Infrastructure;
using YiHe.Model.Material;


namespace YiHe.Data.Repositories.Material
{
    public class ElementRepository : RepositoryBase<Element>, IElementRepository
    {
        public ElementRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IElementRepository : IRepository<Element>
    {
    }
}
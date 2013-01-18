using System.Collections.Generic;
using System.Linq;
using YiHe.Data.Infrastructure;
using YiHe.Model.Navigation;


namespace YiHe.Data.Repositories.Navigation
{
    public class OuterLinkRepository : RepositoryBase<OuterLink>, IOuterLinkRepository
    {
        public OuterLinkRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<OuterLink> GetAllByOrder()
        {
            return GetAll().OrderBy(l => l.Position);
        }
    }

    public interface IOuterLinkRepository : IRepository<OuterLink>
    {
        IEnumerable<OuterLink> GetAllByOrder();
    }
}
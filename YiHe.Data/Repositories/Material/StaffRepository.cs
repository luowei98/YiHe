using System.Collections.Generic;
using System.Linq;
using YiHe.Data.Infrastructure;
using YiHe.Model.Material;


namespace YiHe.Data.Repositories.Material
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<Staff> GetAllByOrder()
        {
            return GetAll().OrderBy(l => l.Position);
        }
    }

    public interface IStaffRepository : IRepository<Staff>
    {
        IEnumerable<Staff> GetAllByOrder();
    }
}
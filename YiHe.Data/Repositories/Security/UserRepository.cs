using YiHe.Data.Infrastructure;
using YiHe.Model.Security;


namespace YiHe.Data.Repositories.Security
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IUserRepository : IRepository<User>
    {
    }
}
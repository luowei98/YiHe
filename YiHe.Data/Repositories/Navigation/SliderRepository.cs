using System.Collections.Generic;
using System.Linq;
using YiHe.Data.Infrastructure;
using YiHe.Model.Navigation;


namespace YiHe.Data.Repositories.Navigation
{
    public class SliderRepository : RepositoryBase<Slider>, ISliderRepository
    {
        public SliderRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<Slider> GetAllByOrder()
        {
            return GetAll().OrderBy(l => l.Position);
        }
    }

    public interface ISliderRepository : IRepository<Slider>
    {
        IEnumerable<Slider> GetAllByOrder();
    }
}
using System.Collections.Generic;
using System.Linq;
using YiHe.Data.Infrastructure;
using YiHe.Model.Material;


namespace YiHe.Data.Repositories.Material
{
    public class OfficePhotoRepository : RepositoryBase<OfficePhoto>, IOfficePhotoRepository
    {
        public OfficePhotoRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public OfficePhoto GetByPosition(int position)
        {
            var photos = GetMany(p => p.Position == position);

            var photoarr = photos as OfficePhoto[] ?? photos.ToArray();
            if (photoarr.Any())
            {
                return photoarr.First();
            }

            return null;
        }
    }

    public interface IOfficePhotoRepository : IRepository<OfficePhoto>
    {
        OfficePhoto GetByPosition(int position);
    }
}
using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using NHibernate;

namespace GPMS.Core.Repositories
{
    public class CarouselRepository : BaseRepository<Carousel,int>, ICarouselRepository
    {
        public CarouselRepository(ISession session)
        {
            _session = session;
        }
    }
}

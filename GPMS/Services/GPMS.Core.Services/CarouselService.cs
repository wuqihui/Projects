using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public class CarouselService : ServiceBase<Carousel,int>, ICarouselService
    {
        public CarouselService(ICarouselRepository carouselRepository)
        {
            Repository = carouselRepository;
        }
    }
}

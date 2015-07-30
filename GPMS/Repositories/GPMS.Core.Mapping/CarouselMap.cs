using GPMS.Core.Entities;

namespace GPMS.Core.Mapping
{
    public class CarouselMap : BaseMap<Carousel, int>
    {
        public CarouselMap()
        {
            Table("Carousel");
            References(x => x.ImageObject).Column("ImageId").Cascade.All();
        }
    }
}

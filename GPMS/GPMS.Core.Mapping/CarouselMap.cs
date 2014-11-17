using FluentNHibernate.Mapping;
using GPMS.Core.Entities;

namespace GPMS.Core.Mapping
{
    public class CarouselMap : ClassMap<Carousel>
    {
        public CarouselMap()
        {
            Table("Carousel");
            Id(x => x.ID, "CarouselId").GeneratedBy.Identity();
            References(x => x.ImageObject).Column("ImageId").Cascade.All();
        }
    }
}

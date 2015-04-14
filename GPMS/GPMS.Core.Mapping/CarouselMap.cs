﻿using FluentNHibernate.Mapping;
using GPMS.Core.Entities;

namespace GPMS.Core.Mapping
{
    public class CarouselMap : ClassMap<Carousel>
    {
        public CarouselMap()
        {
            Table("Carousel");
            Id(x => x.Id, "CarouselId").GeneratedBy.Identity();
            References(x => x.ImageObject).Column("ImageId").Cascade.All();
        }
    }
}

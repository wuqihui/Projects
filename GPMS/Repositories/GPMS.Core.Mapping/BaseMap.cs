using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using GPMS.Core.Entities;

namespace GPMS.Core.Mapping
{
    public class BaseMap<TEntity, TPrimaryKey> : ClassMap<TEntity> where TEntity : BaseEntity<TPrimaryKey>
    {
        protected BaseMap()
        {
            Id(x => x.Id, "Id").GeneratedBy.Identity();
        }


    }
}

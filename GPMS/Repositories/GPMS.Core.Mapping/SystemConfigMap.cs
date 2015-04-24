using FluentNHibernate.Mapping;
using GPMS.Core.Entities;

namespace GPMS.Core.Mapping
{
    public class SystemConfigMap : ClassMap<SystemConfig>
    {
        public SystemConfigMap()
        {
            Table("SystemConfig");
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.PasswordErrorCount);
            Map(x => x.PasswordErrorTimesapn);

        }
    }
}

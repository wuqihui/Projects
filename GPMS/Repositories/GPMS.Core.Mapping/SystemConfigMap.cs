using FluentNHibernate.Mapping;
using GPMS.Core.Entities;

namespace GPMS.Core.Mapping
{
    public class SystemConfigMap : BaseMap<SystemConfig,int>
    {
        public SystemConfigMap()
        {
            Table("SystemConfig");
            Map(x => x.PasswordErrorCount);
            Map(x => x.PasswordErrorTimesapn);

        }
    }
}

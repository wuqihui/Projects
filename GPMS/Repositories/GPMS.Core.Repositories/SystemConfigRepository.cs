using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using NHibernate;

namespace GPMS.Core.Repositories
{
    public class SystemConfigRepository : BaseRepository<SystemConfig,int>, ISystemConfigRepository
    {
        public SystemConfigRepository(ISession session)
        {
            _session = session;
        }
    }
}

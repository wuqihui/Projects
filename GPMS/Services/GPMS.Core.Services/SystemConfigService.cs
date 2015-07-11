using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public abstract class SystemConfigService : ServiceBase<SystemConfig,int>, ISystemConfigService
    {
        private readonly ISystemConfigRepository _systemConfigRepository;

        protected SystemConfigService(ISystemConfigRepository systemConfigRepository)
        {
            Repository = systemConfigRepository;
            _systemConfigRepository = systemConfigRepository;
        }
    }
}

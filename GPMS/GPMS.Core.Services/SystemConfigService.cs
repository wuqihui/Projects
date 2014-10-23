using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public class SystemConfigService : ServiceBase<SystemConfig>, ISystemConfigService
    {
        private readonly ISystemConfigRepository _systemConfigRepository;
        public SystemConfigService(ISystemConfigRepository systemConfigRepository)
        {
            _repository = systemConfigRepository;
            _systemConfigRepository = systemConfigRepository;
        }
    }
}

using System;
using GPMS.Core.Entities;

namespace GPMS.Core.IRepositories
{
    public interface IUserBasicInfoRepository : IBaseRepository<UserBasicInfo, Guid>
    {
        UserBasicInfo FindUserByName(string userName);
    }
}

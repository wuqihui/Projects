using System;
using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public class UserService : ServiceBase<UserBasicInfo,Guid>, IUserService
    {
        private readonly IUserBasicInfoRepository _userRepository;
        public UserService(IUserBasicInfoRepository userRepository)
        {
            Repository = userRepository;
            _userRepository = userRepository;
        }

        public UserBasicInfo FindUserByName(string userName)
        {
            return _userRepository.FindUserByName(userName);
        }
    }
}

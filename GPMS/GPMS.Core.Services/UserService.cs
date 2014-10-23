using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
            _userRepository = userRepository;
        }

        public User FindUserByName(string userName)
        {
            return _userRepository.FindUserByName(userName);
        }
    }
}

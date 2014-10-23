using GPMS.Core.Entities;

namespace GPMS.Core.IServices
{
    public interface IUserService : IServiceBase<User>
    {
        User FindUserByName(string userName);
    }
}

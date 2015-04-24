using GPMS.Core.Entities;

namespace GPMS.Core.IRepositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User FindUserByName(string userName);
    }
}

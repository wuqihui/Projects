using System.Linq;
using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using NHibernate;
using NHibernate.Linq;

namespace GPMS.Core.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ISession session)
        {
            _session = session;
        }

        public User FindUserByName(string userName)
        { 
            return _session.Query<User>().FirstOrDefault(x => x.UserName.Equals(userName));
        }
    }
}

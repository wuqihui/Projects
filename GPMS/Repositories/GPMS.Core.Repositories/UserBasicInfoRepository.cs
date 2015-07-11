using System;
using System.Linq;
using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using NHibernate;
using NHibernate.Linq;

namespace GPMS.Core.Repositories
{
    public class UserBasicInfoRepository : BaseRepository<UserBasicInfo,Guid>, IUserBasicInfoRepository
    {
        public UserBasicInfoRepository(ISession session)
        {
            _session = session;
        }

        public UserBasicInfo FindUserByName(string userName)
        { 
            return _session.Query<UserBasicInfo>().FirstOrDefault(x => x.UserName.Equals(userName));
        }
    }
}

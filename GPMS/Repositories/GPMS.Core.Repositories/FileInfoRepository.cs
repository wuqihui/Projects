using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using NHibernate;

namespace GPMS.Core.Repositories
{
    public class FileInfoRepository : RepositoryBase<FileInfo>, IFileInfoRepository
    {
        public FileInfoRepository(ISession session)
        {
            _session = session;
        }
    }
}

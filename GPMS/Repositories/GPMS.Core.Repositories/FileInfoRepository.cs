using System;
using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using NHibernate;

namespace GPMS.Core.Repositories
{
    public class FileInfoRepository : BaseRepository<AttachmentInfo,Guid>, IAttachmentInfoRepository
    {
        public FileInfoRepository(ISession session)
        {
            _session = session;
        }
    }
}

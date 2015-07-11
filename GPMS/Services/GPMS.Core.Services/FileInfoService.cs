using System;
using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public class FileInfoService : ServiceBase<AttachmentInfo,Guid>, IFileInfoService
    {
        public FileInfoService(IAttachmentInfoRepository fileInfoRepository)
        {
            Repository = fileInfoRepository;
        }
    }
}

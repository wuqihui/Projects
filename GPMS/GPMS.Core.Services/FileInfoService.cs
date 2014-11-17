using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public class FileInfoService : ServiceBase<FileInfo>, IFileInfoService
    {
        public FileInfoService(IFileInfoRepository fileInfoRepository)
        {
            _repository = fileInfoRepository;
        }
    }
}

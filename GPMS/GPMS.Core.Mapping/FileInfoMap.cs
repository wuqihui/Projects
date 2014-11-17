using FluentNHibernate.Mapping;
using GPMS.Core.Entities;

namespace GPMS.Core.Mapping
{
    public class FileInfoMap : ClassMap<FileInfo>
    {
        public FileInfoMap()
        {
            Table("FileInfo");
            Id(x => x.ID, "FileId").GeneratedBy.Identity();
            Map(x => x.Filetype, "FileTypeId").CustomType<Filetype>();
            Map(x => x.Description);
            Map(x => x.Src);
            Map(x => x.Title);
        }
    }
}

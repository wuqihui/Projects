using System;
using FluentNHibernate.Mapping;
using GPMS.Core.Entities;

namespace GPMS.Core.Mapping
{
    public class AttachmentInfoMap:BaseMap<AttachmentInfo,Guid>
    {
        public AttachmentInfoMap():base()
        {
            Table("AttachmentInfo"); 
            Map(x => x.Filetype, "FileTypeId").CustomType<Filetype>();
            Map(x => x.Description);
            Map(x => x.Src);
            Map(x => x.Title);
        }
    }
}

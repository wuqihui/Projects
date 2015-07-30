using System;
using FluentNHibernate.Mapping;
using GPMS.Core.Entities;

namespace GPMS.Core.Mapping
{
    public class UserBasicInfoMap : BaseMap<UserBasicInfo, Guid>
    {
        public UserBasicInfoMap()
        {
            Table("UserInfo");
            Map(x => x.UserName);
            Map(x => x.Password);
            Map(x => x.Sex).CustomType<Sex>();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.EmailAddress);
            Map(x => x.CreateTime);
            Map(x => x.IsConfirmed);
            Map(x => x.LastLoginSuccessedDateTime).Nullable();
            Map(x => x.PasswordFailuresSinceLastSuccess);
            Map(x => x.LastPasswordFailureDate).Nullable();
            Map(x => x.PasswordChangedDate).Nullable();
        }
    }
}

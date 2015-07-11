
namespace GPMS.Core.Entities
{
    public class SystemConfig:BaseEntity<int>
    { 
        public virtual int PasswordErrorCount { get; set; }
        public virtual int PasswordErrorTimesapn { get; set; }
    }
}

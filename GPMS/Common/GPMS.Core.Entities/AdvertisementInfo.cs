using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPMS.Core.Entities.Enums;

namespace GPMS.Core.Entities
{
    /// <summary>
    /// 广告信息
    /// </summary>
    public class AdvertisementInfo : BaseEntity<Guid>
    {
        /// <summary>
        /// 类型
        /// </summary>
        public virtual AdvertisementTypes Type { get; set; }
    }
}

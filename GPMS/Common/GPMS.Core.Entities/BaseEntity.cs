using System; 

namespace GPMS.Core.Entities
{
    /// <summary>
    /// 可持久化到数据库的数据模型基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public class BaseEntity<TPrimaryKey>
    {
        protected BaseEntity()
        {
            IsDeleted = false;
            CreateTime = DateTime.Now;
        }
        #region 属性
        /// <summary>
        /// 获取或设置实体唯一标识，主键
        /// </summary>
        public TPrimaryKey Id { get; set; }
        /// <summary>
        /// 获取或设置 是否删除，逻辑上的删除，非物理的删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 获取或设置 版本控制标识，用于处理并发
        /// </summary>
        public long Timestamp { get; set; }

        #endregion

        #region 方法
        /// <summary>
        /// 判断两个实体是否是同一个数据记录的实体
        /// </summary>
        /// <param name="obj">要比较的实体信息</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            BaseEntity<TPrimaryKey> entity = obj as BaseEntity<TPrimaryKey>;
            if (entity == null)
            {
                return false;
            }
            return Id.Equals(entity.Id) && CreateTime.Equals(entity.CreateTime);
        }

        /// <summary>
        /// 用作特定类型的哈希函数。
        /// </summary>
        /// <returns>
        /// 当前 <see cref="T:System.Object"/> 的哈希代码。
        /// </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ CreateTime.GetHashCode();
        }
        #endregion
    }
}

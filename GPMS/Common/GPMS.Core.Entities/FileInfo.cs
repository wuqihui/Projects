
namespace GPMS.Core.Entities
{
    /// <summary>
    /// 文件信息，包括文档，图片
    /// </summary>
    public class FileInfo
    {
        public virtual long Id { get; set; }
        /// <summary>
        /// 文件类型，文档，图片
        /// </summary>
        public virtual Filetype Filetype { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public virtual string Src { get; set; }
        /// <summary>
        /// 文件描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 文件头
        /// </summary>
        public virtual string Title { get; set; }
    }
}

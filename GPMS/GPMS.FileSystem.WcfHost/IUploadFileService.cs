using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GPMS.FileSystem.WcfHost
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUploadFileService”。
    [ServiceContract]
    public interface IUploadFileService
    { 
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fs">上传的字节流</param>
        /// <param name="savePath">保存的目录</param>
        /// <param name="fileName">文件名</param>
        /// <param name="isWaterMark">是否打水印</param>
        /// <param name="isThumbnail">是否缩略图</param>
        /// <param name="thumbnailWidth">缩略图宽</param>
        /// <param name="thumbnailHeight">缩略图高度</param>
        /// <returns>上传之后的路径</returns>
        [OperationContract]
        string UploadImageThumbnail(byte[] fs, string savePath, string fileName, bool isWaterMark, bool isThumbnail,
            int? thumbnailWidth, int? thumbnailHeight);
    }
}

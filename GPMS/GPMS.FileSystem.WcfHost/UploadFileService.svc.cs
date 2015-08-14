using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using GPMS.Commnon.Utility.IO;

namespace GPMS.FileSystem.WcfHost
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UploadFileService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UploadFileService.svc 或 UploadFileService.svc.cs，然后开始调试。
    public class UploadFileService : IUploadFileService
    {
        private readonly string _imageWebSite =
            ConfigurationManager.AppSettings["ImageWebSite"].ToString(CultureInfo.InvariantCulture);

        private readonly string _rootPath =
            ConfigurationManager.AppSettings["FileRootPath"].ToString(CultureInfo.InvariantCulture);

        /// <summary>
        ///     上传图片
        /// </summary>
        /// <param name="fs">上传的字节流</param>
        /// <param name="savePath">保存的目录</param>
        /// <param name="fileName">文件名</param>
        /// <param name="isWaterMark">是否打水印</param>
        /// <param name="isThumbnail">是否缩略图</param>
        /// <param name="thumbnailWidth">缩略图宽</param>
        /// <param name="thumbnailHeight">缩略图高度</param>
        /// <returns>上传之后的路径</returns>
        public string UploadImageThumbnail(byte[] fs, string savePath, string fileName, bool isWaterMark,
            bool isThumbnail, int? thumbnailWidth, int? thumbnailHeight)
        {
            string fullFilePath = "";
            //保存图片
            if (SaveFile(fs, savePath, fileName, out fullFilePath))
            {
                if (isWaterMark)
                {
                    //打水印
                    ImageProcessor.BuildWaterMarkImage(System.Web.Hosting.HostingEnvironment.MapPath("Files/WaterMark.png"), fullFilePath);
                }
                if (isThumbnail && thumbnailWidth.HasValue && thumbnailHeight.HasValue)
                {
                    //生成略缩图
                    BuildThumbnailImage(fullFilePath, thumbnailWidth.Value, thumbnailHeight.Value);
                }
                return _imageWebSite + "/" + savePath + "/" + fileName;
            }
            return "";
        }

        /// <summary>
        ///     生成略缩图
        /// </summary>
        /// <param name="sourceFilePath">原图地址</param>
        /// <param name="width">略缩图的宽</param>
        /// <param name="height">略缩图的高</param>
        /// <returns>生成后的地址</returns>
        private string BuildThumbnailImage(string sourceFilePath, int width, int height)
        {
            try
            {
                int i = sourceFilePath.LastIndexOf(".", StringComparison.Ordinal);
                string thumbnailFullFileName = sourceFilePath.Substring(0, i) + "_S" + Path.GetExtension(sourceFilePath);

                //生成缩略图
                ImageProcessor.CreateThumbnail(sourceFilePath, thumbnailFullFileName, width, height, "");

                return thumbnailFullFileName;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog("生成缩略图异常", ex.Message);
                return "";
            }
        }

        #region 保存上传的文件

        /// <summary>
        ///     保存文件，返回文件上传保存成功与否
        /// </summary>
        /// <param name="fileBuffer">文件字节内容</param>
        /// <param name="saveDirectory">保存的目录</param>
        /// <param name="fileName">文件名字</param>
        /// <param name="fullFilePath">文件保存后的完整目录</param>
        /// <returns>是否成功</returns>
        private bool SaveFile(byte[] fileBuffer, string saveDirectory, string fileName, out string fullFilePath)
        {
            try
            {
                string fullDirectoryPath = Path.Combine(_rootPath, saveDirectory);
                if (!Directory.Exists(fullDirectoryPath))
                    Directory.CreateDirectory(fullDirectoryPath);

                //完整文件路径
                fullFilePath = Path.Combine(fullDirectoryPath, fileName);

                //定义并实例化一个内存流，以存放提交上来的字节数组。  
                var memoryStream = new MemoryStream(fileBuffer);

                //定义实际文件对象，保存上载的文件。  
                var fileStream = new FileStream(fullFilePath, FileMode.Create);

                //把内内存里的数据写入物理文件  
                memoryStream.WriteTo(fileStream);
                memoryStream.Close();
                fileStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                fullFilePath = "";
                //LogHelper.WriteLog("上传文件出错", ex.Message);
                return false;
            }
        }

        #endregion
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace GPMS.Commnon.Utility.IO
{
    /// <summary>
    ///     图片处理类
    /// </summary>
    public static class ImageProcessor
    {
        #region 添加水印

        /// <summary>
        ///     添加水印到图片
        /// </summary>
        /// <param name="waterMarkFilePath">水印的路径</param>
        /// <param name="sourceFileName">需要添加水印的图片</param>
        /// <param name="isBackUp">是否备份原图</param>
        public static void BuildWaterMarkImage(string waterMarkFilePath, string sourceFileName, bool isBackUp = true)
        {
            try
            {
                //复制图片
                string backUpFileName = sourceFileName + ".bak";
                if (!File.Exists(backUpFileName))
                    File.Move(sourceFileName, backUpFileName);
                else
                    File.Delete(sourceFileName);//这个需要删除,将加了水印的图片保存都原来的路径

                //加图片水印
                Image orgImage = Image.FromFile(backUpFileName);
                Image waterMarkImage = Image.FromFile(waterMarkFilePath);

                if (waterMarkImage.Width > orgImage.Width)
                    waterMarkImage = MakeThumbnail(waterMarkFilePath, orgImage.Width, orgImage.Height, "W");

                Graphics graphics = Graphics.FromImage(orgImage);

                //水印图放在最中间
                int x = orgImage.Width / 2 - waterMarkImage.Width / 2;
                int y = orgImage.Height / 2 - waterMarkImage.Height / 2;

                graphics.DrawImage(waterMarkImage, new Rectangle(x, y, waterMarkImage.Width, waterMarkImage.Height), 0,
                    0, waterMarkImage.Width, waterMarkImage.Height, GraphicsUnit.Pixel);
                graphics.Dispose();

                //保存加水印过后的图片
                orgImage.Save(sourceFileName);
                orgImage.Dispose();

                if (!isBackUp && File.Exists(backUpFileName))
                {
                    File.Delete(backUpFileName);
                }


            }
            catch (Exception ex)
            {
               // LogHelper.WriteLog("生成缩略图异常", ex.Message);
            }
        }

        #endregion

        #region 缩略图

        /// <summary>
        ///     生成略缩图保存到指定路径
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="savePath">略缩图保存的路径</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="mode">模式</param>
        public static void CreateThumbnail(string sourcePath, string savePath, int width, int height, string mode)
        {
            Image makedImage = MakeThumbnail(sourcePath, width, height, mode);
            makedImage.Save(savePath, GetFormat(savePath));
            makedImage.Dispose();
        }


        /// <summary>
        ///     生成略缩图，返回略缩图对象
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="mode">模式</param>
        /// <returns>略缩图对象</returns>
        public static Image MakeThumbnail(string sourcePath, int width, int height, string mode)
        {
            Image image = GetImage(sourcePath);
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num5 = image.Width;
            int num6 = image.Height;
            string str = mode;
            if ((str != null) && (str != "HW"))
            {
                if (str != "W")
                {
                    if (str == "H")
                    {
                        num = (image.Width * height) / image.Height;
                    }
                    else if (str == "Cut")
                    {
                        if ((image.Width / ((double)image.Height)) > (num / ((double)num2)))
                        {
                            num6 = image.Height;
                            num5 = (image.Height * num) / num2;
                            y = 0;
                            x = (image.Width - num5) / 2;
                        }
                        else
                        {
                            num5 = image.Width;
                            num6 = (image.Width * height) / num;
                            x = 0;
                            y = (image.Height - num6) / 2;
                        }
                    }
                }
                else
                {
                    num2 = (image.Height * width) / image.Width;
                }
            }
            if (mode == "")
            {
                decimal a = image.Width / (decimal)image.Height;
                decimal b = width / (decimal)height;

                if (b > a)
                {
                    num = (image.Width * height) / image.Height;
                }
                else
                {
                    num2 = (image.Height * width) / image.Width;
                }
            }
            Image thumbnailImage = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(thumbnailImage);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num5, num6),
                GraphicsUnit.Pixel);

            return thumbnailImage;
        }

        #endregion

        /// <summary>
        ///     根据文件名获取Image对象
        /// </summary>
        /// <param name="path">文件完整路径</param>
        /// <returns>Image对象</returns>
        private static Image GetImage(string path)
        {
            var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            var fileStreamBuffer = new byte[fileStream.Length];
            fileStream.Read(fileStreamBuffer, 0, Convert.ToInt32(fileStream.Length));
            fileStream.Close();

            var memoryStream = new MemoryStream(fileStreamBuffer, true);
            memoryStream.Write(fileStreamBuffer, 0, fileStreamBuffer.Length);
            var bitmap = new Bitmap(memoryStream);
            return bitmap;
        }

        /// <summary>
        ///     得到图片格式
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <returns>文件格式</returns>
        private static ImageFormat GetFormat(string name)
        {
            string ext = name.Substring(name.LastIndexOf(".", StringComparison.Ordinal) + 1);
            switch (ext.ToLower())
            {
                case "jpg":
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "bmp":
                    return ImageFormat.Bmp;
                case "png":
                    return ImageFormat.Png;
                case "gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Jpeg;
            }
        }
    }
}
using System;
using System.Web.Mvc;

namespace GPMS.Web.Extensions.ActionResults
{
    public class ImageResult : ActionResult
    {
        public ImageResult(byte[] byteStream)
        {
            this._byteStream = byteStream;
        }

        private byte[] _byteStream;
        //重写ExecuteResult

        public override void ExecuteResult(ControllerContext context)
        {

            // 设置响应设置

            context.HttpContext.Response.ContentType = "image/jpeg";

            context.HttpContext.Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);

            context.HttpContext.Response.BufferOutput = false;

            // 将图像流写入响应流中
            context.HttpContext.Response.OutputStream.Write(_byteStream, 0, Convert.ToInt32(_byteStream.Length));

        }
    }
}
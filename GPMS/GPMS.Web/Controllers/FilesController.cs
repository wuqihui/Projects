using System.Diagnostics;
using System.Web.Mvc;
using GPMS.Core.Entities;
using GPMS.Core.IServices;
using GPMS.Core.Setting;
using GPMS.Web.Extensions.ActionResults;

namespace GPMS.Web.Controllers
{
    public class FilesController : Controller
    {
        public FileResult GetImage(string id)
        {
            return null;

        }

        public ActionResult Image(Filetype filetype, long id, FormCollection collection)
        {
            string basePath = string.Empty;
            switch (filetype)
            {
                case Filetype.CarouselPicture:
                    basePath = PcSetting.CarouselBasePath;
                    break;
                case Filetype.LogoPicture:
                    basePath = PcSetting.LogoBasePath;
                    break;
                default: break;
            }

            string imageUrl = string.Format(@"{0}\{1}.png", Server.MapPath(basePath), id);

            if (!System.IO.File.Exists(imageUrl))
            {
                return null;
            }

            var fileStream = new System.IO.FileStream(imageUrl, System.IO.FileMode.Open);
            var bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();


            return new ImageResult(bytes);
        }
         
    }
}

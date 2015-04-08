using System.Collections.Generic;
using System.Web.Mvc;
using GPMS.Core.Entities;
using GPMS.Core.IServices;
using GPMS.Core.Setting;

namespace GPMS.Web.Controllers
{
    public class CarouselController : Controller
    {
        //
        // GET: /Carousel/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show()
        {
            //var carouselService = Ioc.Resolve<ICarouselService>();
            //var list = carouselService.FindAllEntityList();
            IList<Carousel> list=new Carousel[]
            {
                new Carousel(){ImageObject =new FileInfo(){Filetype = Filetype.CarouselPicture,Description = "ss",Src = ""} }
            };
            return PartialView(list);
        }
    } 
}


using System.Web.Mvc;
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
            var carouselService = Ioc.Resolve<ICarouselService>();
            var list = carouselService.FindAllEntityList();
            return PartialView(list);
        }
    } 
}


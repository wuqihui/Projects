using System.Web.Mvc;
using System.Web.Routing;
using GPMS.Core.Entities;

namespace GPMS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //忽略对.axd文件的Route，也就是和WebForm一样直接去访问.axd文件
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Files",
                url: "{controller}/{action}/{filetype}/{id}",
                defaults: new { controller = "Images", action = "Image", type = UrlParameter.Optional, id = UrlParameter.Optional }
            );
            routes.MapRoute(
                          name: "Default",// Route 的名称
                          url: "{controller}/{action}/{id}", // 带有参数的URL
                          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }// 设置默认的参数
                      );


        }
    }
}
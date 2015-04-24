using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GPMS.Setting;
using NHibernate.Context;

namespace GPMS.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            Ioc.Instance.StartUp(new Bootstrapper()); 
        } 

        protected void Application_BeginRequest()
        {
            var session = Ioc.Instance.SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        protected void Application_EndRequest()
        {
            CurrentSessionContext.Unbind(Ioc.Instance.SessionFactory);
        }

        protected void Application_OnEnd()
        {
            Ioc.Instance.Container.Dispose();
        }
    }
}
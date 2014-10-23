using System.Web;
using System.Web.Optimization;

namespace GPMS.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //注册js
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //MVC验证，依赖jquery.validate.unobtrusive，在model实体添加Atrributte
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(                     
                        "~/Scripts/jquery.validate*"));

            
            // 这里利用unobtrusive所以不需要这里用jquery.validate了
            //"~/Scripts/CustomerJs/jquery.validate.Messages_cn.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/Accounthelper").Include("~/Scripts/CustomerJs/Accounthelper.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //注册CSS
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                "~/Content/bootstrap.css"));

        }
    }
}
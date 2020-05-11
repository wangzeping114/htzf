using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WS.HTZF.MvcApp.App_Start;

namespace WS.HTZF.MvcApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.ConfigureContainer();
        }
    }
}

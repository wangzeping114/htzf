using System.Web.Http;
using static HTZF.Manage.Api.App_Start.AutofacConfig;
namespace HTZF.Manage.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureContainer();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

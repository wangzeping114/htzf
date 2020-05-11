using log4net.Config;
using System.Web.Http;
using static WS.HTZF.WebApi.App_Start.AutofacConfig;
namespace WS.HTZF.WebApi
{
    /// <summary>
    /// Program Start.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            ConfigureContainer();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //移除返回XML格式 仅仅前端接收JSON格式
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            XmlConfigurator.Configure();
        }
    }
}

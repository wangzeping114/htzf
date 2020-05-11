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
            //�Ƴ�����XML��ʽ ����ǰ�˽���JSON��ʽ
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            XmlConfigurator.Configure();
        }
    }
}

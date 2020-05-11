using System.Web.Http;
using System.Web.Http.Cors;
using WS.HTZF.WebApi.Filter;

namespace WS.HTZF.WebApi
{
    /// <summary>
    /// WebApi Config
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            //跨域配置 并不能保证所有前端浏览器都能跨域请求
            //如果个别浏览器不行，前端请求时加上jQuery.support.cors=true;（jQuery请求方式）
            config.EnableCors(new EnableCorsAttribute("*", "*", "*")); //全部请求不限制

            // Web API 配置和服务
            //全局拦截ModelState 模型验证
            config.Filters.Add(new ModelStateValidFitter());

            //全局拦截异常过滤器
            config.Filters.Add(new ApplicationExceptionFilter());
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

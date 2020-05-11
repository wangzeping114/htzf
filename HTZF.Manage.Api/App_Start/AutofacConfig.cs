using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using WS.HTZF.Ioc.AutofacModule;

namespace HTZF.Manage.Api.App_Start
{
    /// <summary>
    /// Autofac Config
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// Configure Container
        /// </summary>
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new RespositoryModule())
                .RegisterModule(new ServiceModule())
                .RegisterModule(new AutofacModule())
                .RegisterModule(new HandlerModule());

            var container = builder.Build();


            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
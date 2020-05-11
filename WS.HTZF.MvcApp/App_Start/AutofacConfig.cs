using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using WS.HTZF.Ioc.AutofacModule;

namespace WS.HTZF.MvcApp.App_Start
{
    public static class AutofacConfig
    {
        /// <summary>
        /// Configure Container
        /// </summary>
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            // Register dependencies in controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            builder.RegisterModule(new RespositoryModule())
                   .RegisterModule(new ServiceModule())
                   .RegisterModule(new AutofacModule())
                   .RegisterModule(new HandlerModule());

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
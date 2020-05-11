using Autofac;
using WS.HTZF.Application.Authentication;
using WS.HTZF.Application.Handlers;

namespace WS.HTZF.Ioc.AutofacModule
{
    public class HandlerModule : BaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            //regsiter Handlers...
            builder.RegisterType<PasswordHandler>().As<IPasswordHandler>();
            builder.RegisterType<JwtHandler>().As<IJwtHandler>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
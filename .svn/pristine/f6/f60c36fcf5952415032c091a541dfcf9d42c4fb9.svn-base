using Autofac;
using System.Data.Entity;
using WS.HTZF.Core.Repositories;
using WS.HTZF.Core.SeedWorks;
using WS.HTZF.Infrastructure;
using WS.HTZF.Infrastructure.Respositories;

namespace WS.HTZF.Ioc.AutofacModule
{
    public class RespositoryModule: BaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new HTZFDbContext()).As<DbContext>().As<IUnitOfWork>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(BaseRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
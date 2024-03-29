﻿using Autofac;
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
            builder.RegisterType<RoleRespository>().As<IRoleRespository>().InstancePerLifetimeScope();
            builder.RegisterType<MenuRespository>().As<IMenuRespository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleMenuRepository>().As<IRoleMenuRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CdyDetailRespository>().As<ICdyDetailRespository>().InstancePerLifetimeScope();
            builder.RegisterType<CdyRespository>().As<ICdyRespository>().InstancePerLifetimeScope();
            builder.RegisterType<CdyPirtureRespository>().As<ICdyPirtureRespository>().InstancePerLifetimeScope();
            builder.RegisterType<CdyDetailRespository>().As<ICdyDetailRespository>().InstancePerLifetimeScope();
            builder.RegisterType<StockRespository>().As<IStockRespository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRespository>().As<ICategoryRespository>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
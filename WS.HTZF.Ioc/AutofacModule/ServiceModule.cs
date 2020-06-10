﻿using Autofac;
using WS.HTZF.Application.Services;
using WS.HTZF.Application.Services.Sys;

namespace WS.HTZF.Ioc.AutofacModule
{
    public class ServiceModule: BaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PassportService>();
            builder.RegisterType<CdyportService>();
            builder.RegisterType<FileService>();
            base.Load(builder);
        }
    }
}
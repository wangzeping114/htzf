using AutoMapper;
using System.Reflection;
using WS.HTZF.Application.Dtos;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Application
{
    public static class MapperConfig
    {
        public static IMapper RegisterAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewAccountDto, Account>();
                //etc...
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}

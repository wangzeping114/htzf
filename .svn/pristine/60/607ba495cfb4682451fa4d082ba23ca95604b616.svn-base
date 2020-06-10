using AutoMapper;
using WS.HTZF.Application.Dtos;
using WS.HTZF.Application.Resources;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Application.MappingProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuProfile:Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MenuProfile()
        {
            CreateMap<MenuDto, Menu>()
                .ForMember(s => s.ParentId, o => o.Condition(s => s.ParentId > -1));

            CreateMap<Menu, MenuResource>();
        }
    }
}

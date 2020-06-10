using AutoMapper;
using WS.HTZF.Application.Dtos;
using WS.HTZF.Application.Resources;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Application.MappingProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleProfile:Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public RoleProfile()
        {
            CreateMap<ModifiyRoleDto, Role>()
                .ForMember(s => s.Name, o => o.Condition(s => string.IsNullOrWhiteSpace(s.Name)))
                .ForMember(s => s.Description, o => o.Condition(s => string.IsNullOrWhiteSpace(s.Description)))
                .ForMember(s => s.IsSuperAdmin, o => o.Condition(s => s.IsSuperAdmin == null));

            //CreateMap<ModfiyRoleMenuDto, Role>();
            CreateMap<ModfiyRoleMenuDto, Role>();
            CreateMap<AddRoleMenuDto, Role>();
            CreateMap<Role, RoleResource>();
            CreateMap<Role,RoleMenuResource>();
        }
    }
}

﻿using AutoMapper;
using WS.HTZF.Application.Dtos;
using WS.HTZF.Application.Resources;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Application.MappingProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AccountProfile()
        {
            CreateMap<NewAccountDto, Account>().ReverseMap();
            CreateMap<ModifiyAccountDto, Account>().ReverseMap();
            CreateMap<Account, AccountResource>()
                .ForMember(d=>d.RoleRemark,o=>o.MapFrom(s=>s.Role.Description))
                .ForMember(d=>d.IsSuperAdmin,o=>o.MapFrom(s=>s.Role.IsSuperAdmin))
                .ForMember(d=>d.RoleName,o=>o.MapFrom(s=>s.Role.Name));
        }
    }
}

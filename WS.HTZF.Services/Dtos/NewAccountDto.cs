﻿using System.ComponentModel.DataAnnotations;
using WS.HTZF.Application.MappingProfile;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 新增后台账号
    /// </summary>
    public class NewAccountDto
    {
        
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage ="用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage ="密码不能为空")]
        [MinLength(6,ErrorMessage ="密码最少要6位")]
        //[NoMap]
        public string Password { get; set; }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
    }
}
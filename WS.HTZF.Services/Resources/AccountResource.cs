using System;

namespace WS.HTZF.Application.Resources
{
    /// <summary>
    /// 后台管理员
    /// </summary>
    public class AccountResource
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }
 
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string RoleRemark { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>

        public string Remark { get; set; }

        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public bool IsSuperAdmin { get; set; }

        /// <summary>
        /// 账号是否停用
        /// </summary>
        public bool IsDisplay { get; set; }

        /// <summary>
        /// 账号创建时间
        /// </summary>
        public DateTime CreateAt { get; set; }
    }
}

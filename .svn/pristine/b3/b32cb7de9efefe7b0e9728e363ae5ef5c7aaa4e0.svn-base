using System.Collections;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role:Entity<int>
    {
        public Role()
        {
            //RoleMenus = new HashSet<RoleMenu>();
        }
        /// <summary>
        /// 角色名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        public bool IsSuperAdmin { get; set; } = false;
        /// <summary>
        /// 菜单列表
        /// </summary>
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public  virtual ICollection<Account> Accounts { get; set; }
     }
}

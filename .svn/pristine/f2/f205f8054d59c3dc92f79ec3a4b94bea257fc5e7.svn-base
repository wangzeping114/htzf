using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu:Entity<int>
    {
        public Menu()
        {
            Children = new HashSet<Menu>();
            RoleMenus = new HashSet<RoleMenu>();
        }
        /// <summary>
        /// 父类ID
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 菜单名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// l链接动作
        /// </summary>
        public string ActionSref { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public virtual Menu Parent { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual ICollection<Menu> Children { get; set; }

        /// <summary>
        /// 菜单列表
        /// </summary>
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }

        /// <summary>
        /// 路径 比如:首页/系统配置
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Level { get; set; } 
    }
}

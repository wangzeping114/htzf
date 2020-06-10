using System.Collections.Generic;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 添加角色菜单
    /// </summary>
    public class AddRoleMenuDto
    {
        /// <summary>
        /// 
        /// </summary>
        public AddRoleMenuDto()
        {
            MenusId = new List<int>();
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
        public List<int> MenusId { get; set; }
    }
}

using System.Collections.Generic;
using WS.HTZF.Application.MappingProfile;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 修改角色菜单
    /// </summary>
    public class ModfiyRoleMenuDto
    {
        /// <summary>
        /// 
        /// </summary>
        public ModfiyRoleMenuDto()
        {
            MenusId = new List<int>();
        }
        /// <summary>
        /// 角色Id
        /// </summary>
        //[NoMap]
        public int Id { get; set; }

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

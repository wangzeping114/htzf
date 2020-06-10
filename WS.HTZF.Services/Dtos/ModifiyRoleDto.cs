using System.ComponentModel.DataAnnotations;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 修改角色
    /// </summary>
    public class ModifiyRoleDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "要修改的角色ID不能为空!")]
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
        public bool? IsSuperAdmin { get; set; }
    }
}

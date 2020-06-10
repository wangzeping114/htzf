using System.ComponentModel.DataAnnotations;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 修改账号dto
    /// </summary>
    public class ModifiyAccountDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage ="用户ID不能为空!")]
        public int Id { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        public bool IsDisplay { get; set; } = false;

        /// <summary>
        /// 角色ID
        /// </summary>
        public int? RoleId { get; set; }
    }
}

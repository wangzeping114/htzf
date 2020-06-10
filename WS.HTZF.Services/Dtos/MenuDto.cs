using System.ComponentModel.DataAnnotations;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 菜单Dto
    /// </summary>
    public class MenuDto
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public MenuDto()
        {
            ParentId = -1;
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="菜单名不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 链接动作
        /// </summary>
        public string ActionSref { get; set; }

        /// <summary>
        /// path路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int Level { get; set; }
    }
}

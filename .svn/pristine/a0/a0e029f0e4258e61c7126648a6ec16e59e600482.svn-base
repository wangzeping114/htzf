using System.ComponentModel.DataAnnotations;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 修改分类
    /// </summary>
    public class ModifiyCategoryDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="要修改的分类Id不能为空")]
        public int Id { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsDisplay { get; set; } = true;
    }
}

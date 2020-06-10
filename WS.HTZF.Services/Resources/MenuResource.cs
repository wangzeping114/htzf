using System.Collections.Generic;

namespace WS.HTZF.Application.Resources
{
    /// <summary>
    /// 菜单资源
    /// </summary>
    public class MenuResource
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

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
        /// 子类
        /// </summary>

        public List<MenuResource> Children { get; set; }
    }
}

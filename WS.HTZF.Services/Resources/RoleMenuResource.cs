using System.Collections.Generic;

namespace WS.HTZF.Application.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleMenuResource:RoleResource
    {
        /// <summary>
        /// 
        /// </summary>
        public RoleMenuResource()
        {
            RoleMenuIds = new List<int>();
        }
        /// <summary>
        /// 
        /// </summary>
        public List<int> RoleMenuIds { get; set; }
    }
}

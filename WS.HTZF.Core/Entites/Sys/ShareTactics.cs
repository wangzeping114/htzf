using System;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 分享策略
    /// </summary>
    public class ShareTactics:Entity<int>
    {

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }




    }
}

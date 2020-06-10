using System;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 签到策略
    /// </summary>
    public class SignTractics:Entity<int>
    {

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 奖励积分
        /// </summary>
        public decimal AwardIntegral { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? SignId { get; set; }

        /// <summary>
        /// 签到
        /// </summary>
        public virtual ICollection<Sign> Signs { get; set; }
    }
}

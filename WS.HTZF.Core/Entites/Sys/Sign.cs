using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 签到
    /// </summary>
    public class Sign:Entity<int>
    {
        /// <summary>
        /// 每天签到
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 每天默认奖励
        /// </summary>
        public decimal AwardIntegral { get; set; }
    
        /// <summary>
        /// 策略集合
        /// </summary>
        public virtual SignTractics SignTractic { get; set; }
    }
}

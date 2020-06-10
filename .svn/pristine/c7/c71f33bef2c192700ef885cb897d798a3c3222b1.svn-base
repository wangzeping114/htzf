using System;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 积分策略
    /// </summary>
    public class IntegralTactics:Entity<int>
    {
        
        /// <summary>
        /// 名称，例如满50多少积分
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 赠送积分
        /// </summary>
        public decimal GiveIntegral { get; set; }
    
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
    
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

       /// <summary>
       /// 商品ID
       /// </summary>
        public int? CommodyId { get; set; }

        /// <summary>
        /// 商品列表ID
        /// </summary>
        public virtual ICollection<Commodity> Commodities { get; set; }
    }
}

using System;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 秒杀活动
    /// </summary>
    public class SecondsActivity:Entity<int>
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    
        /// <summary>
        /// 活动金额
        /// </summary>
        public decimal Money { get; set; }
    
        /// <summary>
        /// 商品ID
        /// </summary>
        public int CommodityId { get; set; } 

        /// <summary>
        /// 商品集合
        /// </summary>
        public virtual ICollection<Commodity> Commodities { get; set; }
    }
}

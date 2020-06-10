using System;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 团购
    /// </summary>
    public class TreamPurchase:Entity<Guid>
    {

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        public int UserNumber { get; set; }

        /// <summary>
        /// 面值
        /// </summary>
        public decimal Cash { get; set; }

        
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int CommdiyId { get; set; }

        /// <summary>
        /// 商品集合
        /// </summary>
        public virtual Commodity Commodity { get; set; }

       
    }
}

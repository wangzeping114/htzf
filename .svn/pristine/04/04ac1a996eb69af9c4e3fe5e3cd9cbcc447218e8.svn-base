using System;
using System.Collections;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 秒杀活动记录
    /// </summary>
    public class SecondOrder:Entity<int>
    {
        /// <summary>
        /// 秒杀结束时间
        /// </summary>
        public DateTime EndTimeAt { get; set; }
    
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
    
        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// 订单列表
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    
    }
}

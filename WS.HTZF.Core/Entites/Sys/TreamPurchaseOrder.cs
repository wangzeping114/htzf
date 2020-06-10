using System;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 团购订单
    /// </summary>
    public class TreamPurchaseOrder:Entity<int>
    {

        /// <summary>
        /// 团购结束时间
        /// </summary>
        public DateTime EndTimeAt { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// 订单列表
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 客户集合
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}

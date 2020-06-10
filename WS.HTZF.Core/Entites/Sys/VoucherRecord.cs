using System;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 代金卷领取记录
    /// </summary>
    public class VoucherRecord:Entity<int>
    {
        public VoucherRecord()
        {
            CreateOn = DateTime.Now;
        }

        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 客户集合
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 面额
        /// </summary>
        public decimal Cash { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }

    }
}

using System;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 签到记录
    /// </summary>
    public class SignRecord:Entity<int>
    {

        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 客户集合
        /// </summary>
        public virtual ICollection<Customer> Customers { get; set; }

        /// <summary>
        /// 签到时间
        /// </summary>
        public DateTime TimeAt { get; set; }


        /// <summary>
        /// 奖励积分
        /// </summary>
        public decimal AwardIntegral { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
    }
}

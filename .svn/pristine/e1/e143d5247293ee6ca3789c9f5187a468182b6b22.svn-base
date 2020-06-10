using System;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 分享记录
    /// </summary>
    public class ShareRecrod:Entity<int>
    {
        public ShareRecrod()
        {
            TimeAt = DateTime.Now;
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime TimeAt { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid CustomerId { get; set; }
        
        /// <summary>
        /// 获得金额
        /// </summary>
        public decimal GetMoney { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
    }
}

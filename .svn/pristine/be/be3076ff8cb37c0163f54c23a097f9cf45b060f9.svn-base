using System;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 推荐用户记录
    /// </summary>
    public class ToUserRecord:Entity<int>
    {
        public ToUserRecord()
        {
            CreateAt = DateTime.Now;
        }
        /// <summary>
        /// 推荐时间
        /// </summary>
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// 奖励金额
        /// </summary>
        public decimal RewardCash { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
        public Guid CoustomerId { get; set; }
        

        /// <summary>
        /// 推荐客户Id
        /// </summary>
        public Guid ToUserId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Source { get; set; }


    }
}

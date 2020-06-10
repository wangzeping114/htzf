using System;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 会员等级
    /// </summary>
    public class Grade:Entity<Guid>
    {
        public Grade()
        {
            OfAtDayTime = 365;
        }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 等级名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnName { get; set; }

        /// <summary>
        /// 多长时间失效   
        /// </summary>
        public int OfAtDayTime { get; set; }

        /// <summary>
        /// 推荐用户提成比例
        /// </summary>
        public decimal ToUserCommission { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 开通费
        /// </summary>
        public decimal OpeningFee { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

    }
}

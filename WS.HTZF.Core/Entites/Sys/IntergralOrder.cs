using System;
using WS.HTZF.Core.Enums;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 积分订单
    /// </summary>
    public class IntergralOrder:Entity<int>
    {
        public IntergralOrder()
        {
            CreatedOn = DateTime.Now;
            LatestUpdatedOn = DateTime.Now;
            OrderStatus = OrderStatus.新订单;
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 最近更新时间
        /// </summary>
        public DateTime LatestUpdatedOn { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public decimal Intergral { get; set; }

        /// <summary>
        /// 积分名称
        /// </summary>
        public string IntergralName { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }


        /// <summary>
        /// 订单数量
        /// </summary>
        public int OrderCount { get; set; }

        /// <summary>
        /// 积分策略Id
        /// </summary>
        public int IntegralTacticsId { get; set; }

        /// <summary>
        /// 订单地址Id
        /// </summary>
        public int OrderAddressId { get; set; }

        /// <summary>
        /// 积分策略
        /// </summary>
        public virtual IntegralTactics IntegralTactics { get; set; }

        /// <summary>
        /// 积分订单地址
        /// </summary>
        public virtual IntergralOrderAddress OrderAddress { get; set; }

    }
}

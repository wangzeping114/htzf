using System;
using System.Collections.Generic;
using WS.HTZF.Core.Enums;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    public class Order:Entity<long>
    {
        public Order()
        {
            CreatedOn = DateTime.Now;
            LatestUpdatedOn = DateTime.Now;
            OrderStatus = OrderStatus.新订单;
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderSerialNumber { get; set; }

        /// <summary>
        /// 最近更新时间
        /// </summary>
        public DateTime LatestUpdatedOn { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 订单总额
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }


        /// <summary>
        /// 客户ID
        /// </summary>
        public Guid CustomerId { get; set; }
    

        /// <summary>
        /// 订单地址
        /// </summary>
        public virtual OrderAddress OrderAddress { get; set; }


        /// <summary>
        /// 购物车
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// 支付记录
        /// </summary>
        public virtual ICollection<PaymentRecord> PaymentRecords { get; set; }

        /// <summary>
        /// 团购订单
        /// </summary>
        public virtual ICollection<TreamPurchaseOrder> TreamPurchaseOrders { get; set; }
    }
}

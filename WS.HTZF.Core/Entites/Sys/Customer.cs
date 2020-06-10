using System;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 客户
    /// </summary>
    public class Customer:Entity<Guid>
    {
        public Customer()
        {
            CreateOn = DateTime.Now;
            LastOn = DateTime.Now;
        }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 全名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 累计消费
        /// </summary>
        public decimal CountCashOut { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 累计收入
        /// </summary>
        public decimal CountCashIn { get; set; }

        /// <summary>
        /// 已提现
        /// </summary>
        public decimal CashWithdrawal { get; set; }

        /// <summary>
        /// 累计分享收入
        /// </summary>
        public decimal CountShareCashIn { get; set; }

        /// <summary>
        /// 累计积分
        /// </summary>
        public decimal CountIntegral { get; set; }

        /// <summary>
        /// 累计推荐金额
        /// </summary>
        public decimal CountToUserMoney { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastOn { get; set; }

        /// <summary>
        /// 微信客户
        /// </summary>
        public virtual WxCustomer WxCustomer { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        public virtual Grade  Grades { get; set; }


        /// <summary>
        /// 订单
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// 团购订单
        /// </summary>
        public virtual ICollection<TreamPurchaseOrder> TreamPurchaseOrders { get; set; }

        /// <summary>
        /// 默认下单地址ID
        /// </summary>
        public long? DefaultBillingAddressId { get; set; }

        /// <summary>
        /// 默认下单地址
        /// </summary>
        public virtual CustomerAddress DefaultBillingAddress { get; set; }

        /// <summary>
        /// 客户地址集合
        /// </summary>
        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }

        /// <summary>
        /// 代金卷记录
        /// </summary>
        public virtual ICollection<VoucherRecord> VoucherRecords { get; set; }

        
    }
}

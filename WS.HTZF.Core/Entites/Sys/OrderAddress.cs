﻿using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    public class OrderAddress:Entity<int>
    {
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// 地址栏(详情)
        /// </summary>
        public string AddressLine { get; set; }


        /// <summary>
        /// 订单地址ID
        /// </summary>
        public long? OrderId { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 地址ID
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual Address Address { get; set; }
    }
}

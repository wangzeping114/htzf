using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 积分订单地址
    /// </summary>
    public class IntergralOrderAddress:Entity<int>
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
        /// 
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// 积分订单
        /// </summary>
        public virtual IntergralOrder IntergralOrder { get; set; }

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

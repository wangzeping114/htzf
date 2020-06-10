using System;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    ///客户地址
    /// </summary>
    public class CustomerAddress:Entity<int>
    {
        
        public CustomerAddress()
        {
            CreateOn = DateTime.Now;
        }

        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 地址ID
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime CreateOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 代金卷
    /// </summary>
    public class Voucher : Entity<int>
    {
        /// <summary>
        /// 使用说明
        /// </summary>
        public string UseRemark { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 总量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 面值
        /// </summary>
        public decimal Cash { get; set; } 


        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImage { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int? CommoditiyId { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public virtual  Commodity Commodity { get; set; }


    }
}

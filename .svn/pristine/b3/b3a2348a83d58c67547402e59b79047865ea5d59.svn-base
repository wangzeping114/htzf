using System.Collections.Generic;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 商品详情
    /// </summary>
    public class CommodityDetail:Entity<int>
    {
        /// <summary>
        /// 商品
        /// </summary>
        public virtual Commodity Commodity { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图片列表
        /// </summary>
        public virtual ICollection<CommodityDetailPirture> CommodityDetailPirtures { get; set; }
   
    }
}

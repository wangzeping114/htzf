using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 商品详情图片列表
    /// </summary>
    public class CommodityDetailPirture:Entity<int>
    {
        public CommodityDetailPirture()
        {
            Sequence = 1;
        }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 商品详情ID
        /// </summary>
        public int? CommodityDetailId { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public virtual CommodityDetail CommodityDetail { get; set; }
    }
}

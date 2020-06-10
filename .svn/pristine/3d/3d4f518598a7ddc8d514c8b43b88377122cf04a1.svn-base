using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class OrderItem:Entity<long>
    {
        /// <summary>
        /// (小计/共计)
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int OrderCount { get; set; }

        /// <summary>
        /// 商品标题或名称
        /// </summary>
        public string TitileOrName { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string CommoditySerialNumber { get; set; }

        /// <summary>
        /// 购物车Id
        /// </summary>
        public long? OrderId { get; set; }

        public virtual Order Order { get; set; }


    }
}

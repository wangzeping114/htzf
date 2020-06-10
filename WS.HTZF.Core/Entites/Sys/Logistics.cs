using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 物流配置
    /// </summary>
    public class Logistics:Entity<int>
    {
        /// <summary>
        /// 物流名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商品地址
        /// </summary>
        public virtual Address CommdiyAddress { get; set; }

    }
}

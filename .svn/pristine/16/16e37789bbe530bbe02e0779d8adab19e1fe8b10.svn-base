using System;
using WS.HTZF.Core.Enums;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 积分商品
    /// </summary>
    public class IntergralComdity:Entity<int>
    {
        public IntergralComdity()
        {
            CreateTime = DateTime.Now;
            CommodityStatus = CommodityStatus.上架;
            Sequence = 1;
        }
        /// <summary>
        /// 商品标题或名称
        /// </summary>
        public string TitileOrName { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        public decimal Freight { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public CommodityStatus CommodityStatus { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public decimal Intergral { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 下架时间
        /// </summary>
        public DateTime? ShelfTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime AsOfTime { get; set; }

        /// <summary>
        /// 栏目ID
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// 栏目
        /// </summary>
        public virtual Category Category { get; set; }
        

    }
}

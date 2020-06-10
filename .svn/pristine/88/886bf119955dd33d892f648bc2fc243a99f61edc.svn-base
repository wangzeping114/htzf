using System;
using System.ComponentModel.DataAnnotations;
using WS.HTZF.Core.Enums;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 修改商品实体信息
    /// </summary>
    public class ModifyCdyDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商品标题或名称
        /// </summary>
        [Required(ErrorMessage = "商品名称不能为空")]
        [StringLength(200, ErrorMessage = "长度限制:不能超过200个字符")]
        [Display(Name = "商品标题或名称")]
        public string TitileOrName { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        //[RegularExpression()]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public CommodityStatus CommodityStatus { get; set; } = CommodityStatus.上架;

        /// <summary>
        /// 图片
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Required(ErrorMessage = "请输入商品价格")]
        [DataType(DataType.Currency, ErrorMessage = "输入的价格格式不正确")]
        public decimal Price { get; set; }
        /// <summary>
        /// 门市价
        /// </summary>
        [Required(ErrorMessage = "请输入商品市场价格")]
        [DataType(DataType.Currency, ErrorMessage = "输入的价格格式不正确")]
        public decimal MarketPrice { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sequence { get; set; } = 1;

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
        public int CategoryId { get; set; }

        ///// <summary>
        ///// 库存
        ///// </summary>
        public StockDto StockDto { get; set; }
    }
}

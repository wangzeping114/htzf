﻿using System.ComponentModel.DataAnnotations;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 库存dto
    /// </summary>
    public class StockDto
    {
        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "请输入库存数量")]
        public int Quantity { get; set; }

        /// <summary>
        /// 预留数
        /// </summary>
        public int ReservedQuantity { get; set; } = 0;
        /// <summary>
        /// 已销售数量
        /// </summary>
        public int HaveSalesQuantity { get; set; } = 0;
    }
}

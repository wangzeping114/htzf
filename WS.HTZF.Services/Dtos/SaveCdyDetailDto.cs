using System.Collections.Generic;

namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 添加商品详情
    /// </summary>
    public class SaveCdyDetailDto
    {

        /// <summary>
        /// 商品ID
        /// </summary>
        public int CommdiyId { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 商品详情图片dto
        /// </summary>
        public List<CdyDPrictureDto> CdyDPrictureDtos { get; set; }

    }
}

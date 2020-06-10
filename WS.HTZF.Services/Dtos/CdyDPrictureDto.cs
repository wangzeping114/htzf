namespace WS.HTZF.Application.Dtos
{
    /// <summary>
    /// 商品详情图片dto
    /// </summary>
    public class CdyDPrictureDto
    {
        /// <summary>
        /// 详情图片Id
        /// </summary>
        public int CdDId { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sequence { get; set; }
    }
}

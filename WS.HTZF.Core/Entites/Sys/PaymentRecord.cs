using WS.HTZF.Core.Enums;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 支付记录
    /// </summary>
    public class PaymentRecord:Entity<long>
    {
        public PaymentRecord()
        {
            PaymentType = PaymentType.WeChat;
        }
        /// <summary>
        /// 流水号
        /// </summary>
        public string PaymentSerialNumber { get; set; }

        /// <summary>
        /// 支付类型
        /// </summary>
        public PaymentType PaymentType { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 账单
        /// </summary>
        public virtual BillsFlow BillsFlow { get; set; }
    }
}

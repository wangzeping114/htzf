using WS.HTZF.Core.Enums;
using WS.HTZF.Core.SeedWorks;

namespace WS.HTZF.Core.Entites.Sys
{
    /// <summary>
    /// 流水账
    /// </summary>
    public class BillsFlow:Entity<long>
    {
        public BillsFlow()
        {
            BillsStatus = BillsStatus.未审核;
        }
        /// <summary>
        /// 支付ID
        /// </summary>
        public long PaymentRecordId { get; set; }

        /// <summary>
        /// 支付记录
        /// </summary>
        public virtual PaymentRecord PaymentRecord { get; set; }


        /// <summary>
        /// 账单状态
        /// </summary>
        public BillsStatus BillsStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }


        /// <summary>
        /// 审核账号
        /// </summary>
        public string AuditAccount { get; set; }

    }
}

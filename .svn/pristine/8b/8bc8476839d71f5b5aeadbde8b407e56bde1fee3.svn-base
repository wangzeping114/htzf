using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// 团购订单
    /// </summary>
    public class TreamPurchaseOrderConfiguration: EntityTypeConfiguration<TreamPurchaseOrder>
    {
        /// <summary>
        /// 
        /// </summary>
        public TreamPurchaseOrderConfiguration()
        {
            Property(c => c.EndTimeAt).IsRequired();
            HasRequired(c => c.Customer).WithMany(c => c.TreamPurchaseOrders).HasForeignKey(c => c.CustomerId);
            HasRequired(c => c.Order).WithMany(c => c.TreamPurchaseOrders).HasForeignKey(c => c.OrderId);
        }
    }
}

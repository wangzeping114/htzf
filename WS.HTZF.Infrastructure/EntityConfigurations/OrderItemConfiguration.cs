using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class OrderItemConfiguration: EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfiguration()
        {
            Property(c => c.SubTotal).IsRequired();
            Property(c => c.OrderCount).IsRequired();
            Property(c => c.TitileOrName).IsRequired();
            Property(c => c.CommoditySerialNumber).IsOptional().HasMaxLength(200);
            HasOptional(c => c.Order).WithMany(c => c.OrderItems).HasForeignKey(c => c.OrderId);
        }
    }
}

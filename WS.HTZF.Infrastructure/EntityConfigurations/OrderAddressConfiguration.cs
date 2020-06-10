using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class OrderAddressConfiguration : EntityTypeConfiguration<OrderAddress>
    {
        public OrderAddressConfiguration()
        {
            Property(c => c.ContactName).IsOptional().HasMaxLength(50);
            Property(c => c.Phone).IsOptional().HasMaxLength(50);
            Property(c => c.ZipCode).IsOptional().HasMaxLength(20);
            Property(c => c.AddressLine).IsOptional().HasMaxLength(100);
            Property(c => c.OrderId).IsOptional();
            HasOptional(c => c.Order).WithRequired(c => c.OrderAddress);
            HasKey(c => c.AddressId);
            HasOptional(c => c.Address).WithRequired(c => c.OrderAddress);
        }
    }
}

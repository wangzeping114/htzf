using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public  class IntergralOrderAddressConfiguration: EntityTypeConfiguration<IntergralOrderAddress>
    {
        public IntergralOrderAddressConfiguration()
        {
            Property(c => c.ContactName).IsOptional().HasMaxLength(50);
            Property(c => c.Phone).IsOptional().HasMaxLength(20);
            Property(c => c.ZipCode).IsOptional().HasMaxLength(10);
            Property(c => c.AddressLine).IsOptional().HasMaxLength(100);
            HasKey(c => c.AddressId);
            HasOptional(c => c.IntergralOrder).WithRequired(c => c.OrderAddress);
            HasOptional(c => c.Address).WithRequired(c => c.IntergralOrderAddress);

        }
    }
}

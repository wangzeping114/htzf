using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class WxCustomerConfiguration:EntityTypeConfiguration<WxCustomer>
    {
        public WxCustomerConfiguration()
        {
            Property(c => c.OpenId).IsRequired().HasMaxLength(200);

            Property(c => c.Avtar).IsOptional().HasMaxLength(200);

            Property(c => c.NickName).IsOptional().HasMaxLength(200);

            Property(c => c.Country).IsOptional().HasMaxLength(200);

            Property(c => c.Province).IsOptional().HasMaxLength(50);

            Property(c => c.City).IsOptional().HasMaxLength(100);

            Property(c => c.GenderType).IsOptional();

            HasKey(c => c.CustomerId);

            HasRequired(c => c.Customer).WithOptional(c => c.WxCustomer);

        }

    }
}

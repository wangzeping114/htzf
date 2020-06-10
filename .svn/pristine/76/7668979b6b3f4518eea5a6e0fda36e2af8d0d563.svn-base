using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public  class IntergralOrderConfiguration: EntityTypeConfiguration<IntergralOrder>
    {
        public IntergralOrderConfiguration()
        {
            Property(c => c.CustomerId).IsRequired();
            Property(c => c.Contact).IsRequired().HasMaxLength(50);
            Property(c => c.Phone).IsRequired().HasMaxLength(50);

        
        }
    }
}

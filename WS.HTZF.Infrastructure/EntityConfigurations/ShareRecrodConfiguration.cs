using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class ShareRecrodConfiguration: EntityTypeConfiguration<ShareRecrod>
    {
        public ShareRecrodConfiguration()
        {
            Property(c => c.TimeAt).IsRequired();
            Property(c => c.CustomerId).IsRequired();
            Property(c => c.GetMoney).IsRequired();
            Property(c => c.Source).IsRequired().HasMaxLength(200);
        }
    }
}

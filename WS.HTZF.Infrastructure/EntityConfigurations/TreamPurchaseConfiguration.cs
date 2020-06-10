using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class TreamPurchaseConfiguration: EntityTypeConfiguration<TreamPurchase>
    {
        public TreamPurchaseConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(100);
            Property(c => c.UserNumber).IsRequired();
            Property(c => c.Cash).IsRequired();
            Property(c => c.StartTime).IsRequired();
            Property(c => c.EndTime).IsRequired();
            HasOptional(c => c.Commodity).WithMany(c => c.TreamPurchases)
                .HasForeignKey(c => c.CommdiyId);
        }
    }
}

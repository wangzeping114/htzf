using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class ShareTacticsConfiguration: EntityTypeConfiguration<ShareTactics>
    {
        public ShareTacticsConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(200);
            Property(c => c.StartTime).IsRequired();
            Property(c => c.EndTime).IsRequired();
            Property(c => c.Money).IsRequired();
        }
    }
}

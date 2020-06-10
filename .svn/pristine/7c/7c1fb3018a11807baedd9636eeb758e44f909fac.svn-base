using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class SignTracticsConfiguration : EntityTypeConfiguration<SignTractics>
    {
        public SignTracticsConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(100);
            Property(c => c.StartTime).IsRequired();
            Property(c => c.AwardIntegral).IsRequired();
            HasMany(c => c.Signs).WithOptional(c => c.SignTractic).HasForeignKey(c => c.SignTractic.SignId);
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// 秒杀活动
    /// </summary>
    public class SecondsActivityConfiguration: EntityTypeConfiguration<SecondsActivity>
    {
        public SecondsActivityConfiguration()
        {
            Property(c => c.StartTime).IsRequired();
            Property(c => c.EndTime).IsRequired();
            Property(c => c.Money).IsRequired();
            HasMany(c => c.Commodities)
                .WithOptional(c => c.SecondsActivity)
                .HasForeignKey(c => c.SecondsActivity.CommodityId);
        }
    }
}

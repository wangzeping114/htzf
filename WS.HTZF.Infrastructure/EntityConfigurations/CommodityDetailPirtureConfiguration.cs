using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class CommodityDetailPirtureConfiguration: EntityTypeConfiguration<CommodityDetailPirture>
    {
        public CommodityDetailPirtureConfiguration()
        {
            Property(c => c.Path).IsOptional().HasMaxLength(200);

            Property(c => c.Sequence).IsOptional();

            ToTable($"tws_{nameof(CommodityDetailPirture)}");
        }
    }
}

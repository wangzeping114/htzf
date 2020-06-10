using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class CommodityDetailConfiguration: EntityTypeConfiguration<CommodityDetail>
    {
        public CommodityDetailConfiguration()
        {

            Property(c => c.Introduction)
                .IsOptional()
                .HasMaxLength(2000);

            Property(c => c.Description)
                .IsOptional()
                .HasMaxLength(2000);

            HasRequired(a => a.Commodity)
                .WithOptional(c => c.CommodityDetail)
                .WillCascadeOnDelete(); //级联删除;

            HasMany(c => c.CommodityDetailPirtures)
                .WithOptional(c => c.CommodityDetail)
                .HasForeignKey(c => c.CommodityDetailId)
                .WillCascadeOnDelete(); //级联删除

            ToTable($"tws_{nameof(CommodityDetail)}");
        }
    }
}

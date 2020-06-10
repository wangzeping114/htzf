using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// 
    /// </summary>
    public class VoucherConfiguration: EntityTypeConfiguration<Voucher>
    {
        public VoucherConfiguration()
        {
            Property(c => c.UseRemark)
                .IsOptional();

            Property(c => c.StartTime)
                .IsRequired();

            Property(c => c.EndTime)
                .IsRequired();

            Property(c => c.Count)
                .IsRequired();

            Property(c => c.Cash)
                .IsRequired();

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CoverImage)
                .IsOptional();

            HasOptional(c => c.Commodity)
                .WithMany(c => c.Vouchers)
                .HasForeignKey(c => c.Commodity);

            ToTable($"tws_{nameof(Voucher)}");
        }
    }
}

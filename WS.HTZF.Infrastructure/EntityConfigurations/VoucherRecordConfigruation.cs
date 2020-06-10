using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// 代金卷记录
    /// </summary>
    public class VoucherRecordConfigruation : EntityTypeConfiguration<VoucherRecord>
    {
        public VoucherRecordConfigruation()
        {
            Property(c => c.Cash).IsRequired();
            Property(c => c.Source).IsRequired()
                .HasMaxLength(200);
            HasOptional(c => c.Customer)
                .WithMany(c => c.VoucherRecords)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}

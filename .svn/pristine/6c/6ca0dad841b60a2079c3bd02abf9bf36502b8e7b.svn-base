using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class PaymentRecordConfiguration : EntityTypeConfiguration<PaymentRecord>
    {
        public PaymentRecordConfiguration()
        {
            Property(c => c.PaymentSerialNumber).IsOptional().HasMaxLength(200);
            Property(c => c.PaymentType).IsRequired();
            HasOptional(c => c.Order).WithMany(c => c.PaymentRecords).HasForeignKey(c => c.OrderId);
           
        }
    }
}

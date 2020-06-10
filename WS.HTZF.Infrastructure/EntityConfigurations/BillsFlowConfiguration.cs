using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class BillsFlowConfiguration: EntityTypeConfiguration<BillsFlow>
    {
        public BillsFlowConfiguration()
        {
            Property(c => c.BillsStatus);
            Property(c => c.Note).IsOptional();
            Property(c => c.AuditAccount).IsOptional();
            HasKey(c => c.PaymentRecordId);
            HasOptional(c => c.PaymentRecord).WithRequired(c => c.BillsFlow);
        }
    }
}

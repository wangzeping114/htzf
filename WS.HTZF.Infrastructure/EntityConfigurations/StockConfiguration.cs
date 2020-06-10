using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
   public class StockConfiguration: EntityTypeConfiguration<Stock>
    {
        public StockConfiguration()
        {
            Property(c => c.Quantity).IsRequired();
            Property(c => c.ReservedQuantity).IsOptional();
            Property(c => c.HaveSalesQuantity).IsOptional();
            HasRequired(c => c.Commodity).WithOptional(c => c.Stock);
            ToTable($"tws_{nameof(Stock)}");
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.Property(c => c.Name).IsRequired().HasMaxLength(200);
            Property(c => c.Icon).IsOptional().HasMaxLength(200);
            Property(c => c.IsDisplay);
            Property(c => c.Sequence).IsOptional();
            HasMany(c => c.Commoditys).WithOptional(c => c.Category).HasForeignKey(c => c.CategoryId);
            ToTable($"tws_{nameof(Category)}");
        }
    }
}

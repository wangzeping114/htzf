using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class MenuConfiguration: EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            this.Property(c => c.Name).IsRequired().HasMaxLength(200);
            this.Property(c => c.Path).IsOptional().HasMaxLength(100);
            this.Property(c => c.Level).IsOptional();
            this.Property(c => c.Icon).IsOptional().HasMaxLength(100);
            this.Property(c => c.ActionSref).IsRequired().HasMaxLength(200);
            this.HasMany(c => c.Children).WithRequired(c => c.Parent).HasForeignKey(c => c.ParentId);
            this.ToTable($"TWS_{nameof(Menu)}");
        }  
    }
}

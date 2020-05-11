using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class RoleMenuConfiguration: EntityTypeConfiguration<RoleMenu>
    {
        public RoleMenuConfiguration()
        {
            this.Property(c => c.Permission);
            this.HasRequired(c => c.Menu).WithMany(c => c.RoleMenus).HasForeignKey(c => c.MenuId);
            this.HasRequired(c => c.Role).WithMany(c => c.RoleMenus).HasForeignKey(c => c.RoleId);
            this.ToTable($"TWS_{nameof(RoleMenu)}");
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            this.Property(s => s.IsDisplay)
                .IsRequired();

            this.Property(s => s.FullName)
                .IsOptional()
                .HasMaxLength(50);

            this.Property(s => s.Password)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(s => s.UserName)
                .IsRequired()
                .HasMaxLength(100);

            this.HasRequired(c => c.Role)
                .WithMany(c => c.Accounts)
                .HasForeignKey(c => c.RoleId);

            this.ToTable($"TWS_{nameof(Account)}");
        }
    }
}
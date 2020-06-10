﻿using System.Data.Entity.ModelConfiguration;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Infrastructure.EntityConfigurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            this.Property(c => c.Name).IsRequired().HasMaxLength(100);
            this.Property(c => c.IsSuperAdmin).IsRequired();
            this.Property(c => c.Description).IsOptional().HasMaxLength(500);
            this.HasMany(c => c.Accounts)
                .WithOptional(c => c.Role)
                .HasForeignKey(c => c.RoleId);
            this.ToTable($"TWS_{nameof(Role)}");
        }
    }
}

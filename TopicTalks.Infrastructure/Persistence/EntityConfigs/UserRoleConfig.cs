using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Domain.Entities;

namespace TopicTalks.Infrastructure.Persistence.EntityConfigs
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> entity)
        {
            // Table and Key Configuration
            entity.ToTable("UserRoles", "auth");
            entity.HasKey(ur => new { ur.UserId, ur.RoleId });

            // Table and Key Configuration
            entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            entity.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Index Configuration
            entity.HasIndex(e => e.RoleId, "IX_UserRoles_RoleId");
            entity.HasIndex(e => e.UserId, "IX_UserRoles_UserId");
        }
    }
}

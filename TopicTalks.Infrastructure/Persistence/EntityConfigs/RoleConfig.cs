﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Domain.Entities;

namespace TopicTalks.Infrastructure.Persistence.EntityConfigs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            // Table Configuration
            entity.ToTable("Roles", "enum");
            entity.HasKey(e => e.RoleId);

            // Property Configuration
            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

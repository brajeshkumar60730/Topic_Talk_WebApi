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
    public class UserDetailConfig : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> entity)
        {
            // Table and Key Configuration
            entity.ToTable("UserDetails", "auth");
            entity.HasKey(e => e.UserDetailsId);

            // Property Configuration
            entity.Property(e => e.IdCardNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.InstituteName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Relationship Configuration
            entity.HasOne(d => d.User)
                .WithOne(p => p.UserDetails)
                .HasForeignKey<UserDetail>(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_UserDetails_Users");

            // Index Configuration
            entity.HasIndex(e => e.UserId, "IX_UserDetails_UserId");
        }
    }
}

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
    public class AnswerConfig : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> entity)
        {
            // Table and Key Configuration
            entity.ToTable("Answers", "post");
            entity.HasKey(x => x.AnswerId);

            // Property Configuration
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.Property(e => e.Explanation)
                .IsRequired();

            entity.Property(e => e.ParentAnswerId)
                .HasDefaultValue(0L);

            // Relationship Configuration
            entity.HasOne(d => d.User)
                .WithMany(p => p.Answers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Answers_Users");

            // Index Configuration
            entity.HasIndex(e => e.ParentAnswerId, "IX_Answers_ParentAnswerId");
            entity.HasIndex(e => e.QuestionId, "IX_Answers_QuestionId");
            entity.HasIndex(e => e.UserId, "IX_Answers_UserId");
        }
    }
}

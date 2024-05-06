﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopicTalks.Infrastructure.Persistence;

#nullable disable

namespace TopicTalks.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240423093228_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TopicTalks.Domain.Entities.Answer", b =>
                {
                    b.Property<long>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AnswerId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ParentAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("AnswerId");

                    b.HasIndex(new[] { "ParentAnswerId" }, "IX_Answers_ParentAnswerId");

                    b.HasIndex(new[] { "QuestionId" }, "IX_Answers_QuestionId");

                    b.HasIndex(new[] { "UserId" }, "IX_Answers_UserId");

                    b.ToTable("Answers", "post");

                    b.HasData(
                        new
                        {
                            AnswerId = 1L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(4011),
                            Explanation = "In C# 12, using record types with pattern matching and deconstruction in ASP.NET 8 code enhances readability and maintainability by providing a concise syntax for defining immutable data types and simplifying comparisons and extraction of property values. This approach, inspired by functional programming, allows for more expressive and type-driven code, making it easier to add new rules or modify existing ones without extensive refactoring. However, the immutability of records may introduce overhead in scenarios where mutable objects are preferred, potentially affecting performance. Despite this, the benefits of using records, such as improved code clarity and built-in support for value-based equality, often outweigh the performance considerations, especially in projects that prioritize immutability and pattern matching.",
                            ParentAnswerId = 0L,
                            QuestionId = 1L,
                            UserId = 2L
                        },
                        new
                        {
                            AnswerId = 2L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(4013),
                            Explanation = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam et fermentum dui. Ut orci quam, ornare sed lorem sed, hendrerit?",
                            ParentAnswerId = 1L,
                            QuestionId = 1L,
                            UserId = 1L
                        },
                        new
                        {
                            AnswerId = 3L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(4015),
                            Explanation = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam et.",
                            ParentAnswerId = 2L,
                            QuestionId = 1L,
                            UserId = 1L
                        },
                        new
                        {
                            AnswerId = 4L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(4017),
                            Explanation = "Lorem ipsum dolor sit amet, consectetur adipiscing.",
                            ParentAnswerId = 0L,
                            QuestionId = 1L,
                            UserId = 2L
                        },
                        new
                        {
                            AnswerId = 5L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(4018),
                            Explanation = "Lorem ipsum dolor sit amet.",
                            ParentAnswerId = 4L,
                            QuestionId = 1L,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.Question", b =>
                {
                    b.Property<long>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("QuestionId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("QuestionId");

                    b.HasIndex(new[] { "UserId" }, "IX_Questions_UserId");

                    b.ToTable("Questions", "post");

                    b.HasData(
                        new
                        {
                            QuestionId = 1L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(3904),
                            Explanation = "In C# 12, what are the advantages and trade-offs of using record types with pattern matching and deconstruction in ASP.NET 8 code, considering maintainability, readability, and potential performance implications?",
                            Topic = "C# 12, Code Syntax, Maintainability",
                            UserId = 1L
                        },
                        new
                        {
                            QuestionId = 2L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(3921),
                            Explanation = "With ASP.NET 8's improved request caching and HTTP caching strategies, in what scenarios could you effectively combine them to achieve optimal performance gains across different data access patterns (in-memory, database, external APIs)?",
                            Topic = "ASP.NET 8, HTTP Caching, Request Caching",
                            UserId = 1L
                        },
                        new
                        {
                            QuestionId = 3L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(3934),
                            Explanation = "What are the use cases for ASP.NET 8's hot reload capability, and how can it improve development workflow and reduce downtime in production environments?",
                            Topic = "ASP.NET 8, Development Workflow, Live Updates",
                            UserId = 1L
                        },
                        new
                        {
                            QuestionId = 4L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(3947),
                            Explanation = "As a C# developer comfortable with Microsoft ecosystem, is Spring Boot worth exploring even though it uses Java? When might switching make sense, if ever?",
                            Topic = "C#, Java, Developer Experience",
                            UserId = 1L
                        },
                        new
                        {
                            QuestionId = 5L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(3959),
                            Explanation = "When working with diverse data sources and integration needs, how do ASP.NET Core's Entity Framework Core and Spring Boot's Spring Data JPA compare in terms of ease of use, performance, and integration capabilities?",
                            Topic = "ASP.NET, Spring Boot, Data Persistence",
                            UserId = 1L
                        },
                        new
                        {
                            QuestionId = 6L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(3971),
                            Explanation = "How can you adapt React development for building mobile apps with React Native, desktop applications with Electron, or server-side rendering with Next.js?",
                            Topic = "React Ecosystem, Mobile Apps, Desktop Apps",
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles", "enum");

                    b.HasData(
                        new
                        {
                            RoleId = 1L,
                            RoleName = "Student"
                        },
                        new
                        {
                            RoleId = 2L,
                            RoleName = "Teacher"
                        },
                        new
                        {
                            RoleId = 3L,
                            RoleName = "Moderator"
                        });
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users", "auth");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(3444),
                            Email = "hello@rawfin.net",
                            PasswordHash = "AQAAAAIAAYagAAAAEH4sN4yXGhfbr83UweaRK6lW4ql9PztpEKWTR6SbkhWTiX1P0mWxRTm8gJr8O3SENg==",
                            Salt = "vFsYhyBIKKEYbGH4F5rQfR2Q5bAyZ4nH2Q0Vwo3kxxM="
                        },
                        new
                        {
                            UserId = 2L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(3458),
                            Email = "doe@email.net",
                            PasswordHash = "AQAAAAIAAYagAAAAEH4sN4yXGhfbr83UweaRK6lW4ql9PztpEKWTR6SbkhWTiX1P0mWxRTm8gJr8O3SENg==",
                            Salt = "vFsYhyBIKKEYbGH4F5rQfR2Q5bAyZ4nH2Q0Vwo3kxxM="
                        },
                        new
                        {
                            UserId = 3L,
                            CreatedAt = new DateTime(2024, 4, 23, 15, 2, 27, 998, DateTimeKind.Local).AddTicks(3460),
                            Email = "bob@email.net",
                            PasswordHash = "AQAAAAIAAYagAAAAEH4sN4yXGhfbr83UweaRK6lW4ql9PztpEKWTR6SbkhWTiX1P0mWxRTm8gJr8O3SENg==",
                            Salt = "vFsYhyBIKKEYbGH4F5rQfR2Q5bAyZ4nH2Q0Vwo3kxxM="
                        });
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.UserDetail", b =>
                {
                    b.Property<long>("UserDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserDetailsId"));

                    b.Property<string>("IdCardNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("InstituteName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("UserDetailsId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.HasIndex(new[] { "UserId" }, "IX_UserDetails_UserId")
                        .HasDatabaseName("IX_UserDetails_UserId1");

                    b.ToTable("UserDetails", "auth");

                    b.HasData(
                        new
                        {
                            UserDetailsId = 1L,
                            IdCardNumber = "20-42459-1",
                            InstituteName = "AIUB",
                            Name = "Rawfin",
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.UserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_UserRoles_RoleId");

                    b.HasIndex(new[] { "UserId" }, "IX_UserRoles_UserId");

                    b.ToTable("UserRoles", "auth");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            RoleId = 1L
                        },
                        new
                        {
                            UserId = 2L,
                            RoleId = 2L
                        },
                        new
                        {
                            UserId = 3L,
                            RoleId = 3L
                        });
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.Answer", b =>
                {
                    b.HasOne("TopicTalks.Domain.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopicTalks.Domain.Entities.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Answers_Users");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.Question", b =>
                {
                    b.HasOne("TopicTalks.Domain.Entities.User", "User")
                        .WithMany("Questions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Questions_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.UserDetail", b =>
                {
                    b.HasOne("TopicTalks.Domain.Entities.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("TopicTalks.Domain.Entities.UserDetail", "UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_UserDetails_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("TopicTalks.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopicTalks.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TopicTalks.Domain.Entities.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Questions");

                    b.Navigation("UserDetails");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}

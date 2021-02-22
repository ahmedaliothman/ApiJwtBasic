﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Api.Models.DB;

namespace Api.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    partial class ApiDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

           

            modelBuilder.Entity("Api.Models.DB.RefreshToken", b =>
                {
                    b.Property<int>("TokenId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Expires")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("('2021-01-27T09:49:18.9860934+03:00')");

                    b.Property<string>("ReplaceByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TokenId")
                        .HasName("PK_TokenId");

                    b.HasIndex(new[] { "UserId" }, "IX_RefreshTokens_UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Api.Models.DB.SystemRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("SystemRoles");
                });

            modelBuilder.Entity("Api.Models.DB.SystemUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(1)))");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "Email" }, "UN_Email")
                        .IsUnique();

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("Api.Models.DB.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("('2021-01-27T09:49:18.9769643+03:00')");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex(new[] { "UserId" }, "IX_UserRoles_UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Api.Models.DB.RefreshToken", b =>
                {
                    b.HasOne("Api.Models.DB.SystemUser", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_SystemUsers_RefreshTokens_UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Models.DB.UserRole", b =>
                {
                    b.HasOne("Api.Models.DB.SystemRole", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_SystemRoles_UserRoles_RoleId")
                        .IsRequired();

                    b.HasOne("Api.Models.DB.SystemUser", "UserNavigation")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_SystemUsers_UserRoles_UserId")
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("Api.Models.DB.SystemRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Api.Models.DB.SystemUser", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}

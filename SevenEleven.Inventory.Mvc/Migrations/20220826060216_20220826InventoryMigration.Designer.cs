﻿// <auto-generated />
using System;
using SevenEleven.Inventory.Mvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SevenEleven.Inventory.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220826060216_20220826InventoryMigration")]
    partial class _20220826InventoryMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Created_by")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ICreatedById")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ICreatedById");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Created_by")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("LCreatedById")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LCreatedById");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Created_by")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ItemCodeId")
                        .HasColumnType("integer");

                    b.Property<int?>("Item_code")
                        .HasColumnType("integer");

                    b.Property<int?>("LocIdId")
                        .HasColumnType("integer");

                    b.Property<int?>("Location_id")
                        .HasColumnType("integer");

                    b.Property<string>("Modified_by")
                        .HasColumnType("text");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.Property<string>("SCreatedById")
                        .HasColumnType("text");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<bool>("StockAvailable")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ItemCodeId");

                    b.HasIndex("LocIdId");

                    b.HasIndex("SCreatedById");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.StockAdjustment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Created_by")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("ItemCodeId")
                        .HasColumnType("integer");

                    b.Property<int?>("Item_code")
                        .HasColumnType("integer");

                    b.Property<int?>("LocIdId")
                        .HasColumnType("integer");

                    b.Property<int?>("Location_id")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedById")
                        .HasColumnType("text");

                    b.Property<string>("Modified_by")
                        .HasColumnType("text");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.Property<string>("SCreatedById")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("StockReferenceId")
                        .HasColumnType("integer");

                    b.Property<int>("Stock_Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemCodeId");

                    b.HasIndex("LocIdId");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("SCreatedById");

                    b.HasIndex("StockReferenceId");

                    b.ToTable("StockAdjustments");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.Item", b =>
                {
                    b.HasOne("Inventory_mvc_seven_eleven.Models.User", "ICreatedBy")
                        .WithMany("ICreatedBy")
                        .HasForeignKey("ICreatedById");

                    b.Navigation("ICreatedBy");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.Location", b =>
                {
                    b.HasOne("Inventory_mvc_seven_eleven.Models.User", "LCreatedBy")
                        .WithMany("LCreatedBy")
                        .HasForeignKey("LCreatedById");

                    b.Navigation("LCreatedBy");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.Stock", b =>
                {
                    b.HasOne("Inventory_mvc_seven_eleven.Models.Item", "ItemCode")
                        .WithMany("Itemcode")
                        .HasForeignKey("ItemCodeId");

                    b.HasOne("Inventory_mvc_seven_eleven.Models.Location", "LocId")
                        .WithMany("LocId")
                        .HasForeignKey("LocIdId");

                    b.HasOne("Inventory_mvc_seven_eleven.Models.User", "SCreatedBy")
                        .WithMany("SCreatedBy")
                        .HasForeignKey("SCreatedById");

                    b.Navigation("ItemCode");

                    b.Navigation("LocId");

                    b.Navigation("SCreatedBy");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.StockAdjustment", b =>
                {
                    b.HasOne("Inventory_mvc_seven_eleven.Models.Item", "ItemCode")
                        .WithMany()
                        .HasForeignKey("ItemCodeId");

                    b.HasOne("Inventory_mvc_seven_eleven.Models.Location", "LocId")
                        .WithMany()
                        .HasForeignKey("LocIdId");

                    b.HasOne("Inventory_mvc_seven_eleven.Models.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

                    b.HasOne("Inventory_mvc_seven_eleven.Models.User", "SCreatedBy")
                        .WithMany()
                        .HasForeignKey("SCreatedById");

                    b.HasOne("Inventory_mvc_seven_eleven.Models.Stock", "StockReference")
                        .WithMany("StockReference")
                        .HasForeignKey("StockReferenceId");

                    b.Navigation("ItemCode");

                    b.Navigation("LocId");

                    b.Navigation("ModifiedBy");

                    b.Navigation("SCreatedBy");

                    b.Navigation("StockReference");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Inventory_mvc_seven_eleven.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Inventory_mvc_seven_eleven.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory_mvc_seven_eleven.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Inventory_mvc_seven_eleven.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.Item", b =>
                {
                    b.Navigation("Itemcode");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.Location", b =>
                {
                    b.Navigation("LocId");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.Stock", b =>
                {
                    b.Navigation("StockReference");
                });

            modelBuilder.Entity("Inventory_mvc_seven_eleven.Models.User", b =>
                {
                    b.Navigation("ICreatedBy");

                    b.Navigation("LCreatedBy");

                    b.Navigation("SCreatedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
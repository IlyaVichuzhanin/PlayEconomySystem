﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Mango.Services.CouponAPI.Data;

#nullable disable

namespace Mango.Services.CouponAPIMigrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240603062443_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mango.Services.CouponAPI.Entities.Coupon", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("double precision");

                    b.Property<int>("MinAmount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("71ec16f2-28eb-4b70-b748-2eafedc82152"),
                            CouponCode = "GHU",
                            DiscountAmount = 0.58999999999999997,
                            MinAmount = 25
                        },
                        new
                        {
                            Id = new Guid("7fe38540-6964-4b7f-a65f-203ec1be9c42"),
                            CouponCode = "LOP",
                            DiscountAmount = 0.32000000000000001,
                            MinAmount = 74
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
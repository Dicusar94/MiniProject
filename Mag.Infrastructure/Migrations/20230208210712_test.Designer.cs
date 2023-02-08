﻿// <auto-generated />
using System;
using Mag.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mag.Infrastructure.Migrations
{
    [DbContext(typeof(MagContext))]
    [Migration("20230208210712_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mag.Domain.ProductAggregate.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Mag.Domain.ProductAggregate.Entities.Product", b =>
                {
                    b.OwnsOne("Mag.Domain.ProductAggregate.ValueObjects.ProductAvailability", "Availability", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("DaysOfValidity")
                                .HasColumnType("int");

                            b1.Property<DateTime>("ExpirationDate")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsExpired")
                                .HasColumnType("bit");

                            b1.Property<DateTime>("ProductionDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Mag.Domain.ProductAggregate.ValueObjects.ProductDiscount", "Discount", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("IsFiftyPercent")
                                .HasColumnType("bit");

                            b1.Property<bool>("IsOneHundredPercent")
                                .HasColumnType("bit");

                            b1.Property<bool>("IsTwentyPercent")
                                .HasColumnType("bit");

                            b1.Property<double>("Percent")
                                .HasColumnType("float");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Mag.Domain.ProductAggregate.ValueObjects.ProductPrice", "Pricing", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Sale")
                                .HasColumnType("float");

                            b1.Property<double>("Stock")
                                .HasColumnType("float");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Availability")
                        .IsRequired();

                    b.Navigation("Discount")
                        .IsRequired();

                    b.Navigation("Pricing")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

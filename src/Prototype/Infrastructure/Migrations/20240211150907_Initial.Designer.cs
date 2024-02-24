﻿// <auto-generated />
using System;
using Deiarts.Prototype.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deiarts.Prototype.Infrastructure.Migrations
{
    [DbContext(typeof(DeiartsDbContext))]
    [Migration("20240211150907_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Budgets", (string)null);
                });

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.BudgetProduct", b =>
                {
                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BudgetId", "ProductId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ProductId");

                    b.ToTable("BudgetProduct");
                });

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("PricePerUnit")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Materials", (string)null);
                });

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("LaborTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.ProductMaterial", b =>
                {
                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("MaterialId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductMaterial");
                });

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.BudgetProduct", b =>
                {
                    b.HasOne("Deiarts.Prototype.Domain.Entities.Budget", null)
                        .WithMany("BudgetProducts")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deiarts.Prototype.Domain.Entities.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deiarts.Prototype.Domain.Entities.Product", "Product")
                        .WithMany("BudgetProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.ProductMaterial", b =>
                {
                    b.HasOne("Deiarts.Prototype.Domain.Entities.Material", "Material")
                        .WithMany("ProductMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deiarts.Prototype.Domain.Entities.Product", "Product")
                        .WithMany("ProductMaterials")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.Budget", b =>
                {
                    b.Navigation("BudgetProducts");
                });

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.Material", b =>
                {
                    b.Navigation("ProductMaterials");
                });

            modelBuilder.Entity("Deiarts.Prototype.Domain.Entities.Product", b =>
                {
                    b.Navigation("BudgetProducts");

                    b.Navigation("ProductMaterials");
                });
#pragma warning restore 612, 618
        }
    }
}

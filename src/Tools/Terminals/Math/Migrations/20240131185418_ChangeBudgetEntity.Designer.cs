﻿// <auto-generated />
using System;
using Deiarts.Tools.Terminals.MathBudget.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deiarts.Tools.Terminals.MathBudget.Migrations
{
    [DbContext(typeof(MathBudgetDbContext))]
    [Migration("20240131185418_ChangeBudgetEntity")]
    partial class ChangeBudgetEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Deiarts.Tools.Terminals.MathBudget.Entities.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Code")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeServiceInMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Budgets", (string)null);
                });

            modelBuilder.Entity("Deiarts.Tools.Terminals.MathBudget.Entities.BudgetMaterial", b =>
                {
                    b.Property<int>("BudgetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaterialId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.HasKey("BudgetId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("BudgetMaterial");
                });

            modelBuilder.Entity("Deiarts.Tools.Terminals.MathBudget.Entities.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Code")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Materials", (string)null);
                });

            modelBuilder.Entity("Deiarts.Tools.Terminals.MathBudget.Entities.BudgetMaterial", b =>
                {
                    b.HasOne("Deiarts.Tools.Terminals.MathBudget.Entities.Budget", "Budget")
                        .WithMany("BudgetMaterials")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deiarts.Tools.Terminals.MathBudget.Entities.Material", "Material")
                        .WithMany("BudgetMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Deiarts.Tools.Terminals.MathBudget.Entities.Budget", b =>
                {
                    b.Navigation("BudgetMaterials");
                });

            modelBuilder.Entity("Deiarts.Tools.Terminals.MathBudget.Entities.Material", b =>
                {
                    b.Navigation("BudgetMaterials");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using FinanceTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceTracker.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230924210456_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FinanceTracker.Domain.Budgets.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Payday")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("FinanceTracker.Domain.Budgets.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FinanceTracker.Domain.Budgets.Source", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("FinanceTracker.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TaxationType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FinanceTracker.Domain.Budgets.Budget", b =>
                {
                    b.HasOne("FinanceTracker.Domain.Customers.Customer", null)
                        .WithMany("Budgets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanceTracker.Domain.Budgets.Category", b =>
                {
                    b.HasOne("FinanceTracker.Domain.Budgets.Budget", null)
                        .WithMany("Categories")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanceTracker.Domain.Budgets.Source", b =>
                {
                    b.HasOne("FinanceTracker.Domain.Budgets.Category", null)
                        .WithMany("Sources")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanceTracker.Domain.Budgets.Budget", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("FinanceTracker.Domain.Budgets.Category", b =>
                {
                    b.Navigation("Sources");
                });

            modelBuilder.Entity("FinanceTracker.Domain.Customers.Customer", b =>
                {
                    b.Navigation("Budgets");
                });
#pragma warning restore 612, 618
        }
    }
}

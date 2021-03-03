﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApplication.Data;

namespace TestApplication.Data.Migrations
{
    [DbContext(typeof(TestApplicationDbContext))]
    [Migration("20210302221527_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestApplication.Data.Entities.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("CardHolder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PaymentStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.HasIndex("PaymentStateId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("TestApplication.Data.Entities.PaymentState", b =>
                {
                    b.Property<Guid>("PaymentStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("PaymentStateId");

                    b.ToTable("PaymentStates");
                });

            modelBuilder.Entity("TestApplication.Data.Entities.Payment", b =>
                {
                    b.HasOne("TestApplication.Data.Entities.PaymentState", "PaymentState")
                        .WithOne("Payment")
                        .HasForeignKey("TestApplication.Data.Entities.Payment", "PaymentStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentState");
                });

            modelBuilder.Entity("TestApplication.Data.Entities.PaymentState", b =>
                {
                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}

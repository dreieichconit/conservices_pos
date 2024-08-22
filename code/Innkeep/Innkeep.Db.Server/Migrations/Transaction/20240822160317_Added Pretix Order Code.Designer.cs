﻿// <auto-generated />
using System;
using Innkeep.Db.Server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Innkeep.Db.Server.Migrations.Transaction
{
    [DbContext(typeof(InnkeepTransactionContext))]
    [Migration("20240822160317_Added Pretix Order Code")]
    partial class AddedPretixOrderCode
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Innkeep.Db.Server.Models.Transaction.TransactionModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<decimal>("AmountBack")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AmountGiven")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AmountRequested")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("EventId")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderSecret")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceiptJson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceiptType")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("RegisterId")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TssId")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TransactionModels");
                });
#pragma warning restore 612, 618
        }
    }
}

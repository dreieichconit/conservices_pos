﻿// <auto-generated />
using Innkeep.Db.Server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Innkeep.Db.Server.Migrations
{
    [DbContext(typeof(InnkeepServerContext))]
    [Migration("20240816101742_Added Checkin List Config")]
    partial class AddedCheckinListConfig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Innkeep.Db.Server.Models.FiskalyConfig", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApiSecret")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TseId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FiskalyConfigs");
                });

            modelBuilder.Entity("Innkeep.Db.Server.Models.FiskalyTseConfig", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("TseAdminPassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("TseId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TsePuk")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TseConfigs");
                });

            modelBuilder.Entity("Innkeep.Db.Server.Models.PretixConfig", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("PretixAccessToken")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<int>("SelectedCheckinListId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SelectedCheckinListName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("SelectedEventName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("SelectedEventSlug")
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("SelectedOrganizerName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("SelectedOrganizerSlug")
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PretixConfigs");
                });

            modelBuilder.Entity("Innkeep.Db.Server.Models.Register", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("RegisterDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegisterIdentifier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Registers");
                });
#pragma warning restore 612, 618
        }
    }
}

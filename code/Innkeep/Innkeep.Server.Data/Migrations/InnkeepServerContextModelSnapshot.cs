﻿// <auto-generated />
using System;
using Innkeep.Server.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Innkeep.Server.Data.Migrations
{
    [DbContext(typeof(InnkeepServerContext))]
    partial class InnkeepServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("Innkeep.Server.Data.Models.ApplicationSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrganizerInfo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SelectedEventId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SelectedOrganizerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SelectedEventId");

                    b.HasIndex("SelectedOrganizerId");

                    b.ToTable("ApplicationSettings");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.Authentication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authentications");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.CashFlow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MoneyAdded")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MoneyRemoved")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegisterId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("RegisterId");

                    b.ToTable("CashFlows");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.FiskalyApiSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Secret")
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TokenValidUntil")
                        .HasColumnType("TEXT");

                    b.Property<string>("TseId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FiskalySettings");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegisterName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeviceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Items")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PretixOrderNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TseToken")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("EventId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.ApplicationSetting", b =>
                {
                    b.HasOne("Innkeep.Server.Data.Models.Event", "SelectedEvent")
                        .WithMany()
                        .HasForeignKey("SelectedEventId");

                    b.HasOne("Innkeep.Server.Data.Models.Organizer", "SelectedOrganizer")
                        .WithMany()
                        .HasForeignKey("SelectedOrganizerId");

                    b.Navigation("SelectedEvent");

                    b.Navigation("SelectedOrganizer");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.CashFlow", b =>
                {
                    b.HasOne("Innkeep.Server.Data.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innkeep.Server.Data.Models.Register", "Register")
                        .WithMany()
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Register");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.Event", b =>
                {
                    b.HasOne("Innkeep.Server.Data.Models.Organizer", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("Innkeep.Server.Data.Models.Transaction", b =>
                {
                    b.HasOne("Innkeep.Server.Data.Models.Register", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innkeep.Server.Data.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innkeep.Server.Data.Models.Organizer", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Event");

                    b.Navigation("Organizer");
                });
#pragma warning restore 612, 618
        }
    }
}

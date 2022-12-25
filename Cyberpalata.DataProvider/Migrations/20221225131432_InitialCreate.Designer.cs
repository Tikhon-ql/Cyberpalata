﻿// <auto-generated />
using System;
using Cyberpalata.DataProvider.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221225131432_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cyberpalata.Common.Enums.GamingRoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GamingRoomType");
                });

            modelBuilder.Entity("Cyberpalata.Common.Enums.MenuItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MenuItemType");
                });

            modelBuilder.Entity("Cyberpalata.Common.Enums.PeripheryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PeripheryType");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GamingRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GamingRoomId");

                    b.ToTable("Devices");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Peripheral.Periphery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GamingRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamingRoomId");

                    b.HasIndex("TypeId");

                    b.ToTable("Peripheries");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Rooms.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("RoomId1");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.GameConsole", b =>
                {
                    b.HasBaseType("Cyberpalata.DataProvider.Models.Devices.Device");

                    b.Property<string>("ConsoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GameConsoleRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("GameConsoleRoomId");

                    b.ToTable("GameConsole", (string)null);
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.Pc", b =>
                {
                    b.HasBaseType("Cyberpalata.DataProvider.Models.Devices.Device");

                    b.Property<string>("Cpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gpu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hdd")
                        .HasColumnType("int");

                    b.Property<int>("RamCount")
                        .HasColumnType("int");

                    b.Property<string>("RamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ssd")
                        .HasColumnType("int");

                    b.ToTable("Pc", (string)null);
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Rooms.GameConsoleRoom", b =>
                {
                    b.HasBaseType("Cyberpalata.DataProvider.Models.Rooms.Room");

                    b.ToTable("GameConsoleRoom", (string)null);
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Rooms.GamingRoom", b =>
                {
                    b.HasBaseType("Cyberpalata.DataProvider.Models.Rooms.Room");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasIndex("TypeId");

                    b.ToTable("GamingRoom", (string)null);
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.Device", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Rooms.GamingRoom", null)
                        .WithMany("Devices")
                        .HasForeignKey("GamingRoomId");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.MenuItem", b =>
                {
                    b.HasOne("Cyberpalata.Common.Enums.MenuItemType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Peripheral.Periphery", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Rooms.GamingRoom", null)
                        .WithMany("Peripheries")
                        .HasForeignKey("GamingRoomId");

                    b.HasOne("Cyberpalata.Common.Enums.PeripheryType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Price", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Rooms.Room", null)
                        .WithMany("Prices")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Seat", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Rooms.Room", null)
                        .WithMany("AllSeats")
                        .HasForeignKey("RoomId");

                    b.HasOne("Cyberpalata.DataProvider.Models.Rooms.Room", null)
                        .WithMany("FreeSeats")
                        .HasForeignKey("RoomId1");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.GameConsole", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Rooms.GameConsoleRoom", null)
                        .WithMany("Consoles")
                        .HasForeignKey("GameConsoleRoomId");

                    b.HasOne("Cyberpalata.DataProvider.Models.Devices.Device", null)
                        .WithOne()
                        .HasForeignKey("Cyberpalata.DataProvider.Models.Devices.GameConsole", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.Pc", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Devices.Device", null)
                        .WithOne()
                        .HasForeignKey("Cyberpalata.DataProvider.Models.Devices.Pc", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Rooms.GameConsoleRoom", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Rooms.Room", null)
                        .WithOne()
                        .HasForeignKey("Cyberpalata.DataProvider.Models.Rooms.GameConsoleRoom", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Rooms.GamingRoom", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Rooms.Room", null)
                        .WithOne()
                        .HasForeignKey("Cyberpalata.DataProvider.Models.Rooms.GamingRoom", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cyberpalata.Common.Enums.GamingRoomType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Rooms.Room", b =>
                {
                    b.Navigation("AllSeats");

                    b.Navigation("FreeSeats");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Rooms.GameConsoleRoom", b =>
                {
                    b.Navigation("Consoles");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Rooms.GamingRoom", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("Peripheries");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Headphone"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Keypad"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mouse"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Screen"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Chair"
                        });
                });

            modelBuilder.Entity("Cyberpalata.Common.Enums.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoomType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lounge"
                        },
                        new
                        {
                            Id = 2,
                            Name = "GameConsoleRoom"
                        },
                        new
                        {
                            Id = 3,
                            Name = "GamingRoom"
                        });
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Begining")
                        .HasColumnType("time");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HoursCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.GameConsole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ConsoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("GameConsoles");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.Pc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Cpu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gpu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Hdd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ram")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ssd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("Pcs");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Identity.ApiUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivate")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Identity.UserRefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RefreshToken")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Peripheral.Periphery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("TypeId");

                    b.ToTable("Peripheries");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("IsVip")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Rooms", t =>
                        {
                            t.HasCheckConstraint("IsVip", "IsVip = 0 or(IsVip = 1 and TypeId between 2 and 3)");
                        });
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("SeatsBookings", b =>
                {
                    b.Property<Guid>("BookingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeatsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingsId", "SeatsId");

                    b.HasIndex("SeatsId");

                    b.ToTable("SeatsBookings");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Booking", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.ApiUser", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.GameConsole", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Room", "ConsoleRoom")
                        .WithMany("Consoles")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsoleRoom");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Devices.Pc", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Room", "Room")
                        .WithOne("Pc")
                        .HasForeignKey("Cyberpalata.DataProvider.Models.Devices.Pc", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Game", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Booking", null)
                        .WithMany("GamesToDownloadBefore")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Identity.UserRefreshToken", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.ApiUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Peripheral.Periphery", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Room", "GamingRoom")
                        .WithMany("Peripheries")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cyberpalata.Common.Enums.PeripheryType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GamingRoom");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Room", b =>
                {
                    b.HasOne("Cyberpalata.Common.Enums.RoomType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Seat", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Room", "Room")
                        .WithMany("Seats")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("SeatsBookings", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Seat", null)
                        .WithMany()
                        .HasForeignKey("SeatsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Booking", b =>
                {
                    b.Navigation("GamesToDownloadBefore");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Identity.ApiUser", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Consoles");

                    b.Navigation("Pc")
                        .IsRequired();

                    b.Navigation("Peripheries");

                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}

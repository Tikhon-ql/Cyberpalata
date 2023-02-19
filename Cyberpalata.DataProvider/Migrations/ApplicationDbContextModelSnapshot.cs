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
                        .HasColumnType("uniqueidentifier");

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
                        .HasColumnType("uniqueidentifier");

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
                        .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.HtmlContent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Html")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Htmls");

                    b.HasData(
                        new
                        {
                            Id = "ResetPasswordHtml",
                            Html = "<html>\r\n                                    <div>\r\n                                        <a href='http://localhost:3000/passwordReset' class='btn btn-outline-dark btn-sm text-white w-50 m-1'>Reset password</a>\r\n                                    </div>\r\n                                </html>"
                        },
                        new
                        {
                            Id = "EmailVerificationHtml",
                            Html = "<html>\r\n                                <div>\r\n                                    <h1>Your verification code:</h1>\r\n                                    <div><b></b></div>\r\n                                </div>\r\n                            </html>"
                        });
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75a632ac-495b-4725-849d-b79d87130a7e"),
                            Name = "User"
                        },
                        new
                        {
                            Id = new Guid("5f94420d-63db-4716-a55f-55e7191a9f93"),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
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
                        .HasColumnType("uniqueidentifier");

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
                        .HasColumnType("uniqueidentifier");

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
                        .HasColumnType("uniqueidentifier");

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
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Batle", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FirstTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FirstTeamScore")
                        .HasColumnType("int");

                    b.Property<Guid?>("RoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SecondTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SecondTeamScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("RoundId");

                    b.HasIndex("SecondTeamId");

                    b.ToTable("Batle");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Prize", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Round", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("TeamsMaxCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsHiring")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.TeamMember", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCaptain")
                        .HasColumnType("bit");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Tournament", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamsMaxCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
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

            modelBuilder.Entity("TeamsTournaments", b =>
                {
                    b.Property<Guid>("TeamsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TournamentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TeamsId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("TeamsTournaments");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Booking", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", "User")
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
                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", "User")
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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Batle", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamId");

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Round", null)
                        .WithMany("Batles")
                        .HasForeignKey("RoundId");

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId");

                    b.Navigation("FirstTeam");

                    b.Navigation("SecondTeam");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Prize", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Tournament", null)
                        .WithMany("Prizes")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Round", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Tournament", null)
                        .WithMany("Rounds")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.TeamMember", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Tournament", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("TeamsTournaments", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Booking", b =>
                {
                    b.Navigation("GamesToDownloadBefore");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Identity.User", b =>
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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Round", b =>
                {
                    b.Navigation("Batles");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Team", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Tournament", b =>
                {
                    b.Navigation("Prizes");

                    b.Navigation("Rounds");
                });
#pragma warning restore 612, 618
        }
    }
}

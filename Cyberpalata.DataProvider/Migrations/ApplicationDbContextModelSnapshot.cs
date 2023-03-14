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

            modelBuilder.Entity("Cyberpalata.Common.Enums.JoinRequestState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JoinRequestState");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "InProgress"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Accepted"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rejected"
                        },
                        new
                        {
                            Id = 4,
                            Name = "None"
                        });
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

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CaptainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserToJoinId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CaptainId");

                    b.HasIndex("UserToJoinId");

                    b.ToTable("Chats");
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

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("TeamId");

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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
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

                    b.Property<bool>("IsFirstTeamApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSecondTeamApproved")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("SecondTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("SecondTeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Batle");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.BatleResult", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BatleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BatleId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WinnerId");

                    b.ToTable("BatleResults");
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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHiring")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WinCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.TeamJoinRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TeamMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("TeamId");

                    b.HasIndex("TeamMemberId");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
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

                    b.Property<bool>("IsGone")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoundsCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Tournaments");
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

                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Chat", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", "Captain")
                        .WithMany()
                        .HasForeignKey("CaptainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", "UserToJoin")
                        .WithMany()
                        .HasForeignKey("UserToJoinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Captain");

                    b.Navigation("UserToJoin");
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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Identity.User", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Role");

                    b.Navigation("Team");
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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Message", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Notification", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", "User")
                        .WithMany("Notifications")
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

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId");

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Tournament", "Tournament")
                        .WithMany("Batles")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstTeam");

                    b.Navigation("SecondTeam");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.BatleResult", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Batle", "Batle")
                        .WithMany()
                        .HasForeignKey("BatleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Tournament", null)
                        .WithMany("BatleResults")
                        .HasForeignKey("TournamentId");

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batle");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Prize", b =>
                {
                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Tournament", null)
                        .WithMany("Prizes")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.TeamJoinRequest", b =>
                {
                    b.HasOne("Cyberpalata.Common.Enums.JoinRequestState", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.TeamMember", null)
                        .WithMany("JoinRequests")
                        .HasForeignKey("TeamMemberId");

                    b.HasOne("Cyberpalata.DataProvider.Models.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");

                    b.Navigation("Team");

                    b.Navigation("User");
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
                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", null)
                        .WithMany("Tournaments")
                        .HasForeignKey("TeamId");

                    b.HasOne("Cyberpalata.DataProvider.Models.Tournaments.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Winner");
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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Identity.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Notifications");
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

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Team", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.TeamMember", b =>
                {
                    b.Navigation("JoinRequests");
                });

            modelBuilder.Entity("Cyberpalata.DataProvider.Models.Tournaments.Tournament", b =>
                {
                    b.Navigation("BatleResults");

                    b.Navigation("Batles");

                    b.Navigation("Prizes");
                });
#pragma warning restore 612, 618
        }
    }
}

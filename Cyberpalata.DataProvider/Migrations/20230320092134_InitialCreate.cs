using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JoinRequestState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinRequestState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeripheryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeripheryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WinCount = table.Column<int>(type: "int", nullable: false),
                    IsRecruting = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    IsVip = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.CheckConstraint("IsVip", "IsVip = 0 or(IsVip = 1 and TypeId between 2 and 3)");
                    table.ForeignKey(
                        name: "FK_Rooms_RoomType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoundsCount = table.Column<int>(type: "int", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsGone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Teams_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pcs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hdd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ssd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pcs_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peripheries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peripheries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peripheries_PeripheryType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PeripheryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Peripheries_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SecondTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsFirstTeamApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsSecondTeamApproved = table.Column<bool>(type: "bit", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batle_Teams_FirstTeamId",
                        column: x => x.FirstTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Batle_Teams_SecondTeamId",
                        column: x => x.SecondTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Batle_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Begining = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoursCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserToJoinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaptainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Users_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_Users_UserToJoinId",
                        column: x => x.UserToJoinId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCaptain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Users_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeatsBookings",
                columns: table => new
                {
                    BookingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatsBookings", x => new { x.BookingsId, x.SeatsId });
                    table.ForeignKey(
                        name: "FK_SeatsBookings_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeatsBookings_Seats_SeatsId",
                        column: x => x.SeatsId,
                        principalTable: "Seats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    TeamMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_JoinRequestState_StateId",
                        column: x => x.StateId,
                        principalTable: "JoinRequestState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_TeamMembers_TeamMemberId",
                        column: x => x.TeamMemberId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JoinRequestState",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "InProgress" },
                    { 2, "Accepted" },
                    { 3, "Rejected" },
                    { 4, "None" }
                });

            migrationBuilder.InsertData(
                table: "PeripheryType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Headphone" },
                    { 2, "Keypad" },
                    { 3, "Mouse" },
                    { 4, "Screen" },
                    { 5, "Chair" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("18c33c27-bb46-4faf-9786-6c365901065d"), "Admin" },
                    { new Guid("95d4a21c-58d7-40c3-ba4b-3ca771a0952d"), "User" }
                });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lounge" },
                    { 2, "GameConsoleRoom" },
                    { 3, "GamingRoom" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "IsVip", "Name", "TypeId" },
                values: new object[,]
                {
                    { new Guid("18a70963-2821-475b-810b-516fb057f970"), true, "Generated room 4", 3 },
                    { new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46"), true, "Generated room 5", 3 },
                    { new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b"), true, "Generated room 6", 3 },
                    { new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8"), true, "Generated room 7", 3 },
                    { new Guid("6d1a110d-2792-4de2-8f23-b047b568878e"), true, "Generated room 9", 3 },
                    { new Guid("7edd1cb4-6dba-4623-b298-27404475bef6"), true, "Generated room 3", 3 },
                    { new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666"), true, "Generated room 1", 3 },
                    { new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3"), true, "Generated room 10", 3 },
                    { new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4"), true, "Generated room 8", 3 },
                    { new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d"), true, "Generated room 2", 3 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RoomId" },
                values: new object[,]
                {
                    { new Guid("001231de-50f8-4eb2-b069-0be68cb0a09c"), 30, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("01b5ba61-f916-4d63-8440-4a1f7d1af2a1"), 30, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("02e4b656-a305-443b-a814-93e875925170"), 5, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("0315547e-aab6-474e-b2e0-b926d6299f55"), 2, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("03b281b6-f472-46c4-986d-fcdc7c474631"), 3, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("0421add1-3323-4efa-94f4-7f5e8356ea0c"), 14, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("0579ed4a-77e1-4be3-a579-47c43bd68532"), 15, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("06d8cb9a-ea48-419d-92cb-0601beb646df"), 2, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("073ccc66-7bab-4702-8072-2d43c27ec39d"), 26, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("0825d3d2-5a03-4bcb-8f59-31f0f9d31a59"), 4, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("0cc30e31-c99a-4857-971c-e09f89169249"), 6, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("0dee29a1-7199-4c33-9feb-3f9ae4720e4c"), 10, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("10df742d-caab-4e74-8838-b9842d862a41"), 6, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("11d332fd-016d-458a-8769-4b53c9128bd6"), 1, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("1423aec1-1655-4508-8595-eb70d031cea9"), 19, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("14609670-6b5c-4324-ba7d-6189a6fe7768"), 25, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("164985fb-c3f8-4df3-a769-57ebcc5c2432"), 14, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("17777e4d-2bd0-4140-8f2e-3105a8f211b3"), 26, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("17967fe7-8411-4592-b895-ca1d5d05ffe4"), 3, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("17ab4767-eb79-4171-a46f-74dcbf1f4350"), 28, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("18ca482c-e2d4-4215-bdea-07a3e632643d"), 5, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("18f77586-b784-4382-9615-306921e9a422"), 10, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("1b81ca0d-ee29-421d-8352-8fc277b73058"), 18, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("1d59fefd-08be-441b-962f-6fe52856ec13"), 11, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("1db1032b-891b-459c-a78e-5aeebf24f014"), 10, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("1e73df8f-4d74-4bc4-90e3-a9b8bb6567b6"), 5, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("22b177a5-7814-4842-a790-7ca9babd703a"), 11, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("232f9f43-ae7d-49fb-b334-12b462871375"), 26, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("297349b6-44dd-4ff9-b2ea-b44ebe268ed4"), 22, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("2a3cbb60-e6a7-478a-b1cc-d6060e4789ca"), 17, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("2a4f2dde-488a-4edd-88d6-319e5c2f422e"), 10, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("2acb7e1b-ab23-4863-872c-89019dcfdad0"), 4, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("2bb8f5c1-4d15-4d90-b37f-64f58b5b7141"), 14, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("2d5b2f80-f23c-41af-9e14-f6b4a83b2efb"), 10, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("2e1ada9e-802a-4711-b3a6-693ec376e19e"), 10, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("2e3eaacd-684e-434e-b92c-a2d157f13dab"), 8, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("31204aba-38da-4999-89ed-9c592f6596f5"), 12, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("3178d9cf-b8c6-4d31-a192-d274ac036085"), 28, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("31c7efe1-51bc-48e2-a0c9-3297a8fea4b5"), 23, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("324cc5ee-523e-4617-9db5-26128f399242"), 30, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("34e20179-6885-4217-919b-6dcf431c9c9f"), 13, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("3539efca-414d-45cd-bc34-6822a1d9bf9b"), 13, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("3577e465-a35b-4839-931b-53950f79bc0f"), 3, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("358104e6-6355-47e4-ab12-8fc86918bd31"), 20, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("35ccf696-0c57-4759-92ff-ccafb8f23705"), 18, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("37a3ad88-a430-4e9e-b6ba-f88e1ca47953"), 6, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("38706694-712d-4e54-9c61-995fd5a6a13f"), 13, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("387dfbd0-b158-47ed-abd5-6c96d6fc33a1"), 11, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("397d1332-4bd1-49e0-a7be-c2ec051c90ab"), 15, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("3abadcd1-d580-476c-b897-3ba931a6ff41"), 21, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("3abe73b9-3a5b-4586-b59b-c2700f8b2de3"), 14, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("3afe4ca2-720c-44a3-8e67-db8bf012f0e0"), 11, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("3b64d82e-9218-4295-a2d1-2f6145352059"), 29, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("3b9c34cc-0eac-441a-b3ab-0b61820c8479"), 1, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("3c04ef46-b265-4dd8-a881-14e780ea774c"), 18, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("3d8798ab-8696-4202-a033-04be0b3eef15"), 10, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("3e9ac423-487d-43a1-94da-38bb97883e0f"), 16, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("3ec64901-5e01-4b95-9290-3deb3d6402d8"), 27, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("3f1e261b-985f-44cd-a29b-5eba7099ab0e"), 21, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("40747ad2-2103-4c2d-8058-beec746d3e11"), 2, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("4268dedd-485c-413e-930e-2f6af6886663"), 9, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("4394b406-adec-432b-ae15-b7c7f15c288f"), 26, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("43c377ba-91df-4404-bd0c-4a147fbdc522"), 28, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("4489f427-ff69-42f0-bd50-b99358b0926e"), 28, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("45bab75b-cdde-475c-b4bd-03bee5b01b24"), 28, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("45eef07d-0fb2-40d4-a5e9-bc06adf499c7"), 15, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("461477a1-0381-4768-b0e1-f54731f6ee8a"), 9, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("463d5b2a-01b8-4cf7-afa2-5cc928a82375"), 13, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("46c99059-868c-4940-88b1-2bdc90f40196"), 6, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("48b6ccd9-6307-4e80-b160-177ac587a0aa"), 29, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("48fad61c-9194-46e4-89f4-33c042bc94a2"), 14, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("49897b18-9388-46e7-8047-7031b14f3e34"), 7, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("4a157846-74be-416f-9f69-066fdcb3703c"), 22, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("4b2b908b-d0b3-4324-b2b3-10416fb309e9"), 21, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("4b3c3701-d600-46bc-925b-a2f413e8a826"), 16, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("4ea4efc2-e34d-46da-8301-71b68c4beb70"), 30, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("4ed6f09a-a819-47f9-aa06-66bd6ffab5da"), 2, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("4f3930e2-d207-486d-b3bd-02e08bb1b500"), 10, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("4fdab9cb-91b3-4fa6-9799-3621bc07bb3d"), 1, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("509103be-803e-4162-9108-4f12521d1651"), 6, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("5097bdc6-8856-4be7-b7b0-141ab069770a"), 20, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("50ce64e5-f7ef-4fac-8a05-df8d792ec675"), 1, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("50f26f17-c832-4bc2-bc3a-bd80e9bf9f86"), 25, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("519fd12a-59d2-40e5-8030-2a90f92d6c06"), 9, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("53b8b89c-fcc7-4793-a96d-93e02315a5ec"), 9, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("545534ca-7196-4933-87d3-525bdce3ba94"), 23, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("55c70488-f9e4-4508-aa5d-da1fff78cc66"), 22, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("5714144d-d74f-43e4-84ae-e391ab9984cb"), 19, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("575b6ce5-f9cd-46c3-a94f-d4fc2ee8e178"), 18, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("596968c4-7883-4043-8a2c-f961c2940573"), 5, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("59e8ea57-6721-4049-889f-63ca572d5b6e"), 21, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("5adc81a3-0cec-4fd6-94e1-d787e01765e5"), 16, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("5c9efe7a-aeb6-4ac1-9fcd-588979f09393"), 26, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("5e93aeea-ee7d-45d2-82ca-a223acf7e0eb"), 12, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("5ee7e663-d71f-484d-9f20-a40ecd580e09"), 15, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("5f0b5c41-8ce8-47a4-95a9-acb69bc00395"), 27, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("5f5e9985-b442-447d-8712-d214654ce634"), 3, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("5f7d75c8-bfea-4890-8ba5-a6f1415bb914"), 23, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("603d275c-9b34-413d-b3fc-91fde521fb0a"), 6, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("60e95c8b-c941-40ec-8b3a-c40d3218c6ee"), 10, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("644f220b-334f-4ab8-8538-fc052f3a3b3d"), 4, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("64a205fe-9e95-4561-bca3-07562dbb0480"), 28, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("64cd2eae-be91-4d95-ad0a-6170c17e1b81"), 23, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("6544d9d2-264c-42d3-b0ef-67097da516c0"), 14, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("65dfc2be-c1da-4a88-adb6-fa1aff7b56ab"), 25, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("6673250a-7cdb-4e44-8570-bd60c95648a3"), 13, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("66a20dbe-53b4-46b8-8674-165928870b92"), 1, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("6863e0c2-2244-46c8-b451-183f37c44d50"), 13, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("6afffe61-1f1a-4eaa-a65c-f0e2daa17f2c"), 29, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("6c138037-eb60-42be-9048-9bc25d83398b"), 24, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("6c282096-007c-438e-b5db-8615ba8c0bcd"), 16, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("6de78158-6b00-4664-88de-cafb8997e785"), 6, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("6ec7563b-a7b0-4026-992d-04edbf02a2ac"), 23, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("6efa6dae-4e19-4ea0-b2e5-2b651b75c59d"), 23, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("6f5e63b6-39d3-4588-9674-cb3c846f7394"), 27, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("6f971be9-e8a5-4046-b27a-28554fac550d"), 18, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("70851256-ae8e-4b94-af50-f4a753f77061"), 5, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("7086a8c2-dc10-4f17-a649-fd3e544a6f7d"), 30, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("71d3a157-eee1-4e1c-9470-a35b52d08e9e"), 26, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("720a75fd-10ad-48d0-93ed-f11b7ce2a5f9"), 5, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("726f1f33-1f3b-4bba-804e-4ec103f36fdd"), 25, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("744e5d50-b70a-4e17-8d51-d380e0a8ff95"), 30, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("7489793d-ecef-42ce-9090-16f46a943443"), 29, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("75e98ba4-a7af-4b71-8f5b-45fce30f6d29"), 4, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("75fef63f-de3f-473a-b1f6-de7fc41f70c9"), 21, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("770c8196-dd7c-4eec-b547-5474beda59b3"), 1, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("77aba72b-505e-45dc-950a-130523891be8"), 15, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("786e1184-98e8-43e2-922e-4d35bf3a1c74"), 2, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("7a073328-338a-4787-b42d-31991fc9f935"), 23, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("7a4003ea-f700-4e10-ba3e-a83ee7174850"), 17, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("7c716d34-104a-4132-85cf-bc0e9f56e084"), 7, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("7cce5047-d0de-4123-9b0e-e5446df43bea"), 5, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("7ee82faa-8f8c-4b27-8ca3-45fe8af24ae5"), 15, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("7f9f1c70-30e8-4882-a114-0d4c7f1d620f"), 11, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("7fea183b-2cfa-4947-b98a-38428690d0ef"), 8, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("82927fdb-11d0-45f3-8253-c8abc515f36f"), 9, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("837e53b5-c73a-47a0-bbcb-35f556efe4cb"), 28, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("85b8cb4b-061e-4fc8-adf2-3812c5327931"), 13, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("8781a558-75dc-46ab-9fe0-20909ed1ff0a"), 9, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("87da7e96-a6d7-49b3-a8b4-fa5341048932"), 7, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("88479f78-beb8-4db7-941c-01516f885274"), 16, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("88893b2a-6229-424d-824f-6b6a26e11570"), 29, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("892c8606-1d6a-463b-9562-6d4a6772e973"), 26, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("8a1c513c-3352-4740-911d-d8b20033f360"), 7, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("8a25a1f2-7081-4db2-83b4-fab0643223d8"), 12, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("8c69b053-4167-40a8-9b74-d1cdfda6c06c"), 28, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("8d22dc7d-5483-43c6-aa9d-7841bed03d22"), 7, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("8e16aec0-262f-48f4-b211-33cf0a2eca39"), 5, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("8edb4ff4-b968-455a-9046-dc26d048129f"), 17, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("8efa7add-0702-4f37-8ded-e490f4c03b36"), 24, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("901ed2de-5693-4ae3-b25b-b661ce07467c"), 3, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("90d83a9c-228d-445b-8957-b8a20d70bf8b"), 27, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("9212798a-c31d-4b72-b4e6-7642f278f73b"), 30, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("9257f302-4438-4d8a-b26f-a5c6e02708d0"), 18, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("945d5aac-9da3-4433-b6e1-65a1fc4dd921"), 3, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("947c3788-6da2-47ff-bdd6-3de3fdd8a831"), 11, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("94af6d20-0e45-4275-9f0e-18fbef5b011e"), 24, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("95053b11-21ff-4df3-bb3c-bf8b9d9c10c3"), 25, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("95dd5e0c-6763-44a7-996c-72b07c776b55"), 21, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("95f2084e-d3b8-4b29-ad4a-4514256593c3"), 30, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("96e88837-8a7c-48ad-983d-c33ec6e89270"), 1, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("98b7cfd0-8b79-4c4c-87bd-6d03e80a8fd6"), 29, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("9980ee9e-511c-4115-8bbe-05936c997407"), 13, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("9a37cb02-42f2-4ce1-9427-4e803da2d334"), 18, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("9b27c0e8-7493-4ef0-9e13-d17096ecd3c1"), 12, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("9bcaa143-b395-4b32-90aa-4db600e04c68"), 27, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("9c0286e9-62e5-4909-a5b6-903e45671149"), 4, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("9c2d96f0-046e-4723-bd2e-e60b86258559"), 10, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("9c4b8253-b357-4304-bec8-1af4fc476d0e"), 5, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("9d16e62b-68df-4732-9871-93d3628d77b3"), 15, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("9d5630ce-9de3-414d-937e-ead6e2681f0a"), 12, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("9dfbdf92-cd24-49a3-ac5e-aa347ae57ef2"), 13, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("9e5e2855-61bf-4b76-899f-23bbb51577dd"), 2, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("9f3cf9ee-b27c-4907-879c-d4f6c7da35fa"), 24, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("a1ca5c8a-39e6-48a3-b3cf-d8f17037f56b"), 14, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("a35ce768-9f88-4be1-9e16-902835f95bab"), 11, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("a36511d2-351b-42b2-8e83-89b7c308744e"), 18, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("a4398f2b-9717-4c1b-bf58-67409eb26ee5"), 9, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("a4505325-f0e5-4677-ae7e-f9b36478eca0"), 17, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("a4566d5c-6b21-4495-9014-85c4248355e6"), 8, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("a69b0d8e-4808-4775-a725-7629a4c7a08d"), 21, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("a7573499-18bd-4816-86e9-a489e8ec84ce"), 4, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("a8d70555-d679-49dd-94b7-0bbe38b74f36"), 16, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("aa7e4e7b-135b-4133-8d73-90ed73d903c3"), 4, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("aab3e242-c0b6-4003-aadd-bd8d50c29b14"), 25, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("ab32e72e-0c4e-4a73-a470-860aa4e8afe2"), 17, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("ac528fbd-a52a-45ff-8e22-f2833164393a"), 17, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("ad490879-f632-4840-8814-7728ddf3dd9c"), 4, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("ada63bf5-8ad1-49be-a4a6-c27933d30606"), 20, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("b060e5db-f68a-41b3-b572-d64531bf8feb"), 14, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("b0807b16-eb20-4dad-ad20-c409cb9a47d1"), 21, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("b318484b-4e1b-49f4-b237-e8c0339556c3"), 25, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("b3985fbb-77cb-4773-852e-b2dc5a261b0d"), 18, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("b40086cf-b35f-4015-bcb0-a6eb4b91950f"), 27, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("b5f57621-324a-464b-aaa1-cda6353a7973"), 19, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("b722bb6d-3aac-4325-941b-69d1dca96030"), 15, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("b7cdf2b9-33da-4845-8e51-7b5f9c933f9b"), 24, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("b7f95594-0cde-4055-9041-b80352558b37"), 8, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("b7fe12cf-e735-4da7-99ba-bc700a680d69"), 29, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("b80d4480-f9a4-4648-be6c-9ba3f5eed9d4"), 24, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("b8475c7f-df4d-459d-bc1b-f1e4d3648349"), 23, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("b855f523-d4cc-4a0e-ae81-1e594afeedd8"), 22, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("b9c78ddc-ec0e-44fb-8ab5-3accd823e118"), 17, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("ba5922c7-419e-47d1-b543-bf0ae019b6c2"), 11, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("ba5e2ced-f0ed-470d-8e56-eddd8f58f7ab"), 20, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("bad1dc9a-e494-417c-ba8b-b640f605e947"), 19, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("bb918357-e41d-473c-b93c-cc87a83a1ddf"), 2, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("bc2e0c19-53d8-466f-b55a-221344feae7a"), 24, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("bca96896-fda3-446c-bcd8-af17e58ba30e"), 26, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("bdb41440-6e20-4649-9fd9-3099e1ce0435"), 16, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("bea517f3-c80d-4315-809d-ef0e16b7d157"), 15, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("bef765f8-bf82-4d2e-a207-33ed7f5ec336"), 7, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("bfef0daa-de0b-4cff-a735-9d67a37e7136"), 8, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("c187ff6f-3cbb-405d-9120-c985dba15994"), 22, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("c196ed03-d29e-49cc-92b0-85086aec5b05"), 17, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("c2bb12dc-866a-4469-9398-b04f6813986f"), 24, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("c2c32a83-875c-4c85-a790-c4d9e649cc89"), 28, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("c42bb28d-874b-4311-95ac-1cd2a5edad7b"), 19, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("c4fd2b28-416d-46e3-ac7d-84b4af118f70"), 29, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("c57e711f-0773-4b2f-bca4-1bed9caf0c97"), 19, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("c69f4163-49b7-4919-893b-3d6f0b40ed66"), 30, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("c77b38e1-5321-48c4-8fdd-c73a8b0d5cdb"), 27, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("c920f7d6-6b01-4da4-9943-fe1af204af63"), 17, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("c95eebd1-84e8-4670-b2aa-6fec1f36ed2d"), 16, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("c9b413de-bfb9-43e9-b289-a7b9c0a1091c"), 14, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("c9c1f090-0663-4bcb-a3fb-91a0df23e441"), 2, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("c9e467ba-aa59-44aa-a0a3-4c5e2411ade3"), 8, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("ca1d47b2-cb2e-4ce8-b64b-7c6b8dbd7fa1"), 11, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("ca8ea08e-932d-48f2-95bd-70160f32a855"), 7, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("cbd16346-c521-48bb-a896-332d4367cf96"), 12, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("cc6fa2a7-4ccf-490a-b570-badffcf8238f"), 12, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("ccc37c14-3dae-44be-86ef-b1f6c10bac7d"), 12, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("cd404f84-755f-4b32-a48b-19a72eaaa062"), 22, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("cdab2f7e-cce4-492f-abea-5cc5ca690267"), 15, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("ce82238b-38c3-4abd-a5d4-68e42e605be6"), 1, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("cfddf25c-d74a-4ff2-b785-f873b45fae40"), 5, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("d05ab256-fda2-492f-8098-7f3e5889fb24"), 29, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("d1e59be5-03d0-4776-b466-6849a8554f6f"), 25, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("d29f47a6-ec27-4009-bb7c-5473fba726a0"), 17, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("d36fe439-beed-41aa-8d1f-18484ff2cece"), 9, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("d65e777b-875e-4915-a11f-6c9e46c4626f"), 4, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("d6badb42-93e2-43e4-bacc-65c72e864718"), 6, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("d6f2893a-fd17-4d4c-a762-4e8c564fad68"), 12, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("d756000e-9927-4ec0-93f0-318f17e6ab14"), 8, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("d7a0c2b7-f2db-4153-b90c-8abb4938505c"), 27, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("d7aefb81-fda2-4671-b46d-470279bdb909"), 20, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("d7e4e1fb-03db-4c9a-be5e-69d38f0b5608"), 11, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("d8079e2a-5c18-4c66-85a5-32545c74c08b"), 23, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("d87f17e4-d979-41c8-8774-d031dcdc2d40"), 2, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("d8a666c2-7f64-44b1-ab78-d32796d65cfc"), 20, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("d9218fe0-8188-49c6-8aea-00e698a3ea56"), 1, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("d9f42d17-8d9c-46db-84c5-c797ca39e939"), 27, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("dab4eda0-acc9-483a-9418-b50a3f5ed524"), 19, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("db4bc22d-920c-4602-a8f3-bd464e8956a2"), 25, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("ded163f8-e748-4d4c-93d9-3b0d68e91dcd"), 9, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("df27c618-05a3-471e-80d4-144ab582c37b"), 3, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("e051beeb-97da-47cf-a22a-2aa7cc457819"), 3, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("e09a0b0a-60f5-4f8c-9a9f-4a7b89024761"), 19, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("e0b892cf-5afd-4e85-92f0-d703d45d0353"), 26, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("e0d1bae0-76ec-47c7-acd7-8f9431e9a7c6"), 14, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("e1e72837-738d-4f9c-812b-b4fd4c8704d4"), 7, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("e27a803e-a929-4785-bac5-320dcae1a4b4"), 16, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("e2fb1738-6512-46f7-b4a8-ddc6c446d68d"), 22, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("e3513927-8a5f-4322-9a5d-9be51141d7f0"), 9, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("e353eec8-5c23-463c-bfc1-c9ec6a96844a"), 21, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("e5393a4d-adea-4481-9fce-aaf8e1bf430a"), 29, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("e647d0b1-28ef-4b92-bfe6-cb111feb6028"), 3, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("e6833610-0fed-4650-b9fe-b88cc99e08a7"), 6, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("e68673ac-4db0-47b2-9846-4275b1a08ba6"), 24, new Guid("18a70963-2821-475b-810b-516fb057f970") },
                    { new Guid("e72e3767-220f-4e6c-a784-c07e95e8aa30"), 16, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("e9aaebba-d974-4a4d-85f5-000bbfb70d75"), 24, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("e9c1e027-d555-4538-bc8a-540d32c72eb7"), 20, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("ea994d8e-7695-431f-bf87-498abe71f556"), 26, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("eb01ae78-3550-43e4-a3fe-f9ca0bf4c6d4"), 2, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("eb0fb502-7a29-457f-961e-ddd02fb68e6f"), 12, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("ebcd9f7b-2e73-421c-bff2-0e26086bd609"), 7, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("ec8ee27f-4c21-4493-bddd-769e7a238187"), 19, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("eda19e8e-2940-4fd1-b9b2-a4c42538c7cd"), 22, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("edd84d41-4981-4cc9-85da-585420183e41"), 20, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("ee00fa88-31f8-4bde-ad69-f11bb73f0ddf"), 20, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("ee0dbb3f-50e7-4ab0-a227-8c2f2d75ca24"), 3, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("f021e294-7230-4037-a05f-26842f967c5c"), 1, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("f11f9627-0735-40a9-a02a-0c09d6600c80"), 4, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("f161403e-85e4-4952-abfb-c4c5b17a388e"), 21, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("f3533a66-be25-418d-8f7b-d20ccfd40c74"), 23, new Guid("55b19099-bfc2-4ddb-bc71-eb5ba0db2af8") },
                    { new Guid("f45484d3-cf5c-43cd-ba48-2a2ceb4496ab"), 22, new Guid("cb2692d0-6147-4b92-b023-55fc30a587d3") },
                    { new Guid("f49ea592-8fb6-448c-bfb5-b0cd01ae3239"), 22, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("f4e68eb3-60f2-42b9-b87c-7c57509c4c36"), 20, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("f4eaf478-77ac-4aa0-9d7d-f3e61e4933db"), 7, new Guid("fe004f30-4ed8-41d4-a609-c056bec9491d") },
                    { new Guid("f53d7212-d1d2-4d6b-9dad-b40edb7a1c47"), 19, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("f696ff9a-487b-4b38-8ab2-9b88eaac3bd3"), 8, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("f72a031e-b4fa-414b-9d13-1e7f60fce646"), 25, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("f8b564da-795f-47fa-aa6a-347e48c0f65a"), 27, new Guid("4eddd119-419d-4082-9a95-e8d1596eaa46") },
                    { new Guid("f9ef4c3b-acf7-41e4-a567-d660eebfec79"), 6, new Guid("546d8406-f1ba-4b2a-ba61-3b9303ea790b") },
                    { new Guid("fb12f937-5324-4ab2-a18f-1b06b9d1de96"), 13, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("fbc1abfc-fa8a-47b1-8f3f-7128a6f3b69b"), 18, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") },
                    { new Guid("fbf49434-c6d5-4c68-9316-24c28d10a3c2"), 28, new Guid("6d1a110d-2792-4de2-8f23-b047b568878e") },
                    { new Guid("fc4970e5-b674-4157-a266-733c70ac3795"), 8, new Guid("e57d4b5a-baa8-45f9-8ce0-d69a09cb04d4") },
                    { new Guid("fe9be179-8e01-4f4b-a962-cb828e628a08"), 8, new Guid("7edd1cb4-6dba-4623-b298-27404475bef6") },
                    { new Guid("ff64cc29-a385-43f6-8c95-892f68405fa1"), 30, new Guid("a536d2d9-13a7-422a-8c1f-875cafd2d666") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batle_FirstTeamId",
                table: "Batle",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Batle_SecondTeamId",
                table: "Batle",
                column: "SecondTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Batle_TournamentId",
                table: "Batle",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_CaptainId",
                table: "Chats",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserToJoinId",
                table: "Chats",
                column: "UserToJoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_BookingId",
                table: "Games",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcs_RoomId",
                table: "Pcs",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peripheries_RoomId",
                table: "Peripheries",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Peripheries_TypeId",
                table: "Peripheries",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_RefreshToken",
                table: "RefreshTokens",
                column: "RefreshToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StateId",
                table: "Requests",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TeamId",
                table: "Requests",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TeamMemberId",
                table: "Requests",
                column: "TeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TypeId",
                table: "Rooms",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RoomId",
                table: "Seats",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatsBookings_SeatsId",
                table: "SeatsBookings",
                column: "SeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_MemberId",
                table: "TeamMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_WinnerId",
                table: "Tournaments",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batle");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Pcs");

            migrationBuilder.DropTable(
                name: "Peripheries");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "SeatsBookings");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "PeripheryType");

            migrationBuilder.DropTable(
                name: "JoinRequestState");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}

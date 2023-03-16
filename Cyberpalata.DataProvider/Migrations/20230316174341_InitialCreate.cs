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
                name: "Htmls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Htmls", x => x.Id);
                });

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
                    IsHiring = table.Column<bool>(type: "bit", nullable: false)
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
                name: "GameConsoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameConsoles_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "BatleResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatleResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatleResults_Batle_BatleId",
                        column: x => x.BatleId,
                        principalTable: "Batle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatleResults_Teams_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatleResults_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
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
                table: "Htmls",
                columns: new[] { "Id", "Html" },
                values: new object[,]
                {
                    { "EmailVerificationHtml", "<html>\r\n                                <div>\r\n                                    <h1>Your verification code:</h1>\r\n                                    <div><b></b></div>\r\n                                </div>\r\n                            </html>" },
                    { "ResetPasswordHtml", "<html>\r\n                                    <div>\r\n                                        <a href='http://localhost:3000/passwordReset' class='btn btn-outline-dark btn-sm text-white w-50 m-1'>Reset password</a>\r\n                                    </div>\r\n                                </html>" }
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
                    { new Guid("660cbc6c-493b-4873-82b0-636dd4206350"), true, "Generated room 10", 3 },
                    { new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648"), true, "Generated room 1", 3 },
                    { new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c"), true, "Generated room 7", 3 },
                    { new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a"), true, "Generated room 5", 3 },
                    { new Guid("a5d28688-eed2-4395-a346-0599504d8a46"), true, "Generated room 9", 3 },
                    { new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6"), true, "Generated room 6", 3 },
                    { new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5"), true, "Generated room 2", 3 },
                    { new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f"), true, "Generated room 4", 3 },
                    { new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4"), true, "Generated room 3", 3 },
                    { new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad"), true, "Generated room 8", 3 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RoomId" },
                values: new object[,]
                {
                    { new Guid("00d8486e-a678-4840-9ac7-459a4a4e574a"), 25, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("054a09d4-0271-4b7d-ab54-0e202186e2d0"), 21, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("05f23f8d-4a85-4ec9-b092-6b201fe606e4"), 29, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("06d46bf7-b01c-41de-b291-83beb757c089"), 3, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("0790463f-9e38-4162-a18d-8485f8cdfe05"), 12, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("085cc9e6-f2dc-420c-958b-fc2350b461dc"), 22, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("08bea344-a0bf-4b4a-a08c-ee0ef0ab4789"), 1, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("0b51b0b5-57a5-417d-8ca9-7808c39805b9"), 16, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("0bffa655-c10f-4fad-9ad0-22a99b3c0caa"), 18, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("0d7e97cd-cb94-4cd9-a108-498501015444"), 2, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("0ddecff9-3cc1-4ecf-b86f-1e734c552f59"), 27, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("0df23b25-8e17-4b6b-9629-cf615fd7dd0a"), 28, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("10317e17-c812-4297-ba81-e7b747b0d078"), 20, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("10d04b37-6d8a-4931-8188-35a02308e890"), 9, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("12239025-eba1-4caf-a756-1173e70d1740"), 22, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("12851112-cd64-4305-a91b-ace7cfa6e33f"), 26, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("1328a75f-8c4f-456f-be7b-e0f08081310f"), 30, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("166a13e7-bf30-44e9-a9e8-755a8297cdeb"), 11, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("16e08279-588d-4be7-86e9-3615fe386e52"), 4, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("175ed0d7-b27e-4b09-8749-cfb163178d09"), 11, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("192c8ba2-90c2-4f2a-92cc-542f0bc9edee"), 10, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("1968b8a7-69df-45fa-b9d8-0cdb1614ae1b"), 21, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("1a2cb6c8-f072-49ff-81cc-84cff7920c1a"), 17, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("1a9d2033-fcf5-4d56-a23c-2e88dfb7f939"), 27, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("1ab6f381-684e-4ca1-a4ef-505a29c5b367"), 18, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("1b57620e-d572-4cf6-8f3f-61f332ac722a"), 24, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("1ba608c8-f36a-48cb-bfc7-6f154cd08a5a"), 5, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("1f17cf3a-f806-4724-8cd1-49255fb22a18"), 11, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("20605660-bbd6-4b26-bdbd-9e1ce64df934"), 17, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("22c5eabf-3cde-4fdf-840f-2fbd8eec9f6f"), 27, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("23078619-4645-4e51-82ad-2faf7dfa3e77"), 13, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("23d72776-a02f-4f9b-9bf0-e82fb792d198"), 10, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("26211434-1e59-458d-8562-e0166a3aaf5b"), 9, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("270f4aa3-405b-47ff-ba72-42650ad08fac"), 19, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("272aec54-ed49-4414-88fe-f204929ae0e1"), 2, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("278d8868-9032-441f-8853-849e8d05d56e"), 8, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("27fff0ba-05eb-40c2-a0e5-ecd742b3fd26"), 20, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("28c97e21-dc72-4a24-b66e-2324e79806f5"), 16, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("29335f7a-e4fb-4725-90ea-76a5ea97f436"), 11, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("2997e26d-772d-4d0c-b4ea-02f18187ed91"), 21, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("29bc9a2a-3f37-4eae-bf84-0a4a803911b7"), 11, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("29df3b21-05dc-47d5-80d2-349d3df5cd28"), 19, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("2b94ec55-d779-42a5-8fe0-7cbf5ed0bf25"), 18, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("2c4158aa-8cd5-4a07-9e67-88c83900ba67"), 13, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("2cd9b8d6-dc96-432e-b0f9-a438d214bc44"), 18, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("2e916d84-b916-4b4e-b357-96b5192da351"), 28, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("2eb6a375-2d1a-41d4-b81d-59a495fa2624"), 11, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("2f198268-04d6-48ba-aa17-9fee7be88a0f"), 12, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("3055460b-f8a2-452b-be24-d73ed201c224"), 5, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("3127a597-d8dc-49f5-a887-5a7def7f2289"), 10, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("326edc0d-6108-47cf-b2b7-540aea2c2cab"), 29, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("3304cefc-597f-4e84-9dca-89729ad6c5b6"), 21, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("339e3422-e4df-4c34-bf13-053ff5da1bcb"), 7, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("3476d0d4-29e9-48f6-992e-bcb4b08e8ddb"), 20, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("347e61e0-731d-4913-bf49-228b2387d4cf"), 8, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("3481deb2-0b17-40cc-bf9a-73558923faf7"), 15, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("34b4bc56-d06f-4a3b-b304-fefe42384aba"), 7, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("35303b50-7e8c-449c-9ea7-4a3a94c837f8"), 2, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("3566ff7c-0524-4b76-a1dd-90eaf5af03ae"), 10, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("3579a7bd-f523-4ae4-8c6a-23cbd71fa3bc"), 5, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("357cc176-85ad-466e-acd5-a3f93d97bcc7"), 23, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("3590fcb8-3194-494a-81ef-b6eb9c8c471d"), 24, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("35c39db7-1bff-4c96-a8d3-5cf8bcdf87e2"), 13, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("35f28794-b573-4b3c-90dd-79e08d43a795"), 14, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("369cfb93-ec4c-4321-ac4d-362dff90dc1c"), 15, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("386b7fdd-b46e-4abf-8c29-a4fb7e6c6248"), 3, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("39ba2d67-9e48-482b-85cb-5b8eb6570369"), 16, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("39d19374-cc33-445f-96f0-5543e5a97384"), 9, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("3b142de2-4863-4c99-a1ec-461fc5bb902d"), 25, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("3ddd575c-6d9b-4629-a811-3fc53262aee8"), 6, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("3e52ba61-e928-4bfa-b235-f16d8b5b7535"), 10, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("3e7cd403-76ae-4841-8484-1fca0bd95934"), 17, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("3eccb0f8-a753-48be-b16c-07ae51d8a279"), 25, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("404a153c-32b7-4e60-a7da-1a8ff0d758ed"), 21, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("40605223-cd6e-4274-ae15-664be07582cd"), 9, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("4068d9f0-df2e-4639-a56d-b5ad820e8fa8"), 29, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("424414a4-d553-4aa2-ae98-41991598fee8"), 8, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("424657a5-fb4d-41e6-9e09-ae456a4f17fa"), 26, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("4358b4c3-e82c-40b2-ae91-d773bec4590d"), 20, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("43d70a9c-ba18-43b0-8281-c23b89aa2d3e"), 14, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("45994a5f-2ccf-4821-9ee3-9753a440fb37"), 7, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("45aac916-906c-4fd4-988e-5dd05707bc22"), 4, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("468b5721-fd91-48a6-afa9-095084672013"), 27, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("46a1e4ea-e916-45b2-8b5d-ec9f6c0e9db5"), 30, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("4a3962bd-042d-4f39-814e-fd3f70948d8c"), 9, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("4aa3f2cb-9661-45bc-ab7a-9e52af904cad"), 19, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("4ab30917-10b0-474f-9b00-7a9a300ee9b1"), 23, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("4acb5cea-5697-441d-9d55-196a15e167dc"), 15, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("4af27ab3-eca0-4d5d-8627-eb1e7f0f597e"), 29, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("4cd068cd-a9c4-43be-9d45-c424c9988e7f"), 5, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("4cf493b4-a3ac-490a-98d0-c2c6c2b2f3e4"), 3, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("4d06124b-4b26-4b61-a1de-79243219b3e0"), 21, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("4dc89eb0-1fe4-4379-89ea-30ba724c007a"), 17, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("4e6a039e-6118-4c56-a958-8cce1b423c7b"), 11, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("4e81eaff-5869-48d6-9802-f364e5d53700"), 28, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("4ecac675-fa79-4381-94eb-5c63994d2893"), 28, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("4ef09fd1-0e66-4f8d-ad59-ca1dcdbef1da"), 3, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("4f5670db-c611-43a5-9a39-46c3a16d16c1"), 3, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("50d95360-65ad-4908-8443-0c5bde45eab2"), 13, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("548b8b2d-3aa4-4289-9045-f53ee2d4efef"), 13, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("55007796-1266-4360-89d1-fa1463f543e6"), 8, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("56336692-dd1d-4bd2-87ab-831fe1e6092f"), 6, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("576fcc84-57af-4aa2-b45f-288f0c00baa7"), 28, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("58924a4b-3b64-49e8-8674-643031156519"), 8, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("58b616d2-8693-4a0e-90b7-17fa539c8d9d"), 18, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("58ebe545-9eac-4a99-8276-6c217a4460a2"), 5, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("5931f8b1-27af-4706-bfa5-d43c7cc555c0"), 6, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("5a409cfc-cf6f-436a-b00c-c5ea25236142"), 8, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("5a58a416-8267-47a3-8b93-8a59ff1b152f"), 20, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("5c86fcb7-0407-4dab-849b-8774dc855f8d"), 16, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("5d9c85ff-be29-4b8c-bf40-77de23e997c0"), 7, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("620fcf9d-f0e1-409c-af43-62fb601d87dc"), 23, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("63484a19-112b-410c-84bd-59df5af28ad8"), 6, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("647568ec-b0fc-48be-8317-b5ee5c1f4ffb"), 18, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("67379334-98bc-44c8-8d17-660392932970"), 25, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("679646ce-ff91-43c7-8a18-22e236ecd5fd"), 20, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("681dbf2a-5923-4f53-b0e3-8679a921283d"), 8, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("69e13821-3d85-402f-810f-1f4d92878d77"), 10, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("6ae7d7e0-3a0c-4b55-96aa-0c4717e73c8a"), 13, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("6b641d04-2ac0-422b-92ee-66c0108a41f4"), 1, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("6b940ad7-38e7-404b-8097-277ea4268c56"), 15, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("6cdc87f6-c719-407e-8ae2-b4e80f86d76d"), 25, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("6f4db0f0-18a2-472f-b27c-7a1e7252295c"), 23, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("71221e56-9b16-460b-9b30-f13bbdf69d11"), 14, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("7183e6db-3f82-4467-b2a8-3db27cb5caf1"), 16, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("719213d6-ac3f-48ec-b1af-c23eecad83f4"), 17, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("7498235d-f75d-44c2-8b66-af3054977bf2"), 6, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("74f1b954-674f-4771-a445-d6db0a61605b"), 22, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("750c02e4-29e8-4e0d-8716-7421b05ec577"), 29, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("753334c5-4aa3-4ca9-81ea-a3b377a75d39"), 6, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("767daa4e-f3e6-4905-bea6-0fe6d35ee9f7"), 14, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("77113b8c-3004-441b-b8f3-03e93ba40797"), 25, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("77ad49e7-4bc8-4c7a-9f80-146506da554d"), 14, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("7815356b-b785-4233-96a7-6183856d05fc"), 14, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("791cefa8-c9c4-4dee-9e32-aa00d782277c"), 7, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("796f0002-4a64-4e9d-a532-088493ba5f2d"), 25, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("79e81d92-1e9c-4a8e-9b76-7366253968e1"), 24, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("7a40c3b9-926a-450a-837d-905b99e480b4"), 12, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("7c0a8142-4387-4bbc-a203-62e9f9eeaf88"), 15, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("7ce2d574-a522-45df-9f66-65033e707cec"), 13, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("7d4c6c48-567a-4844-88db-5c3495794412"), 10, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("7db6b016-6fb2-4233-b3b9-9bba03cbca36"), 23, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("7e301aad-840e-4e82-9861-f287b5a95367"), 20, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("7eba5f0c-010d-4dbe-854d-6e02c5e531b1"), 22, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("7f5210ee-ad74-48ad-8e32-efdc4bed4835"), 23, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("7fb2954f-9d18-4828-a433-5c18d9f3ad06"), 4, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("7fcf49f6-5148-4d10-8cb1-13b0541521a1"), 28, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("8054cd34-53b1-4260-8b7a-a1b3fa17d6b0"), 7, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("817c7b85-d08c-486b-9976-6a3f1ae1d526"), 21, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("818e74ec-cccd-4919-9185-bbefe8be3725"), 7, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("833c9ba9-50cd-4c4d-9fa7-257855b95657"), 6, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("838e1041-55e6-45c8-8602-e6cb2d592beb"), 17, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("83907b3c-6f7b-4e1b-9d2f-02add49ffca9"), 6, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("83ab75b3-82bc-406e-9d34-97fb9c09e8ae"), 5, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("83d9bfd4-5023-4f83-96c9-10ac5d79aaef"), 15, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("84a03f06-20ee-41d8-a4a8-9ac49b619df8"), 4, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("85772921-bb80-48e3-afe5-d1e978a103d3"), 29, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("86ee810c-45b3-44f7-a2ff-a383d453d145"), 22, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("871ee261-d23d-4bcf-a1eb-dd3ac6faf2f5"), 15, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("874fcbc2-0fca-4c38-a576-0d8b4a2084be"), 20, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("8764c4d4-3ef8-45f8-b48c-cdebece711ae"), 25, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("8771f513-3052-448a-b138-136b45f23663"), 11, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("8803af44-cf7b-4213-a9a7-a549a8969d6b"), 28, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("8a3d3b49-9b6a-45d8-817e-f414d03707ee"), 7, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("8ab5a9dd-c25a-4c1d-9e49-ae30c807a643"), 19, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("8ae4461f-b3b1-4adf-b7b4-4e3682440d32"), 29, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("8b028d79-087c-4712-a5f7-ae3652718485"), 27, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("8b5446bb-aa1d-4347-b890-038868a4a9b3"), 10, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("8cb9fb1c-7a5a-4cfd-b965-dba921ab6d74"), 30, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("8e59afdf-981c-4d6c-bfae-2f2fc1ab222e"), 26, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("8e631c57-9829-4fe5-bbe5-770cc87cee89"), 8, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("8e96daf1-8b68-4e08-8b63-4d4a728aa0f2"), 27, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("8ecd9667-8f17-4dde-9e7c-d4362865f1a4"), 12, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("8f594b24-1a6d-4764-832a-9291898af0ad"), 2, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("907a787f-6f09-448a-bba3-f566391b97c4"), 16, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("90e9372c-09f0-4e92-bf71-93b6e1b9d23e"), 21, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("918cc798-4cf2-40c4-8dde-0124bc1f48a0"), 2, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("93861d0e-2760-4ae8-b52d-84150e39fabc"), 14, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("9465064d-d22d-48aa-a702-a6c07d43a8cd"), 24, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("96895d8a-f5ef-488b-845a-a76a9694fc9b"), 1, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("970becd5-6847-4ec0-befa-579ee1710528"), 11, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("971441e2-3a76-4b9f-9c43-b3f4301ce3f2"), 26, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("97a4efc4-0a88-4052-a475-6cbd6c371a50"), 27, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("97bc01f1-ec58-42e9-bd55-00f83b298ff0"), 2, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("9818a16d-3de5-4be7-9dda-a644e1b8d37f"), 18, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("98ab88b0-7a76-4634-b8ad-c0a87797d845"), 6, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("98b42b2e-aa19-4ac9-aec7-257b88a2e7a4"), 3, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("9904cc77-7357-4d30-ad87-a31694031419"), 24, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("998eef2a-7bc9-4ee9-911e-b7fbcf0d0d5f"), 15, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("99a296c3-e6fa-4d6f-81d5-9c61aff900ba"), 19, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("99a89f0c-9829-405d-829c-5ca7aa216144"), 4, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("99f25eab-b525-4b95-a329-f1084533da59"), 22, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("9b5a10a9-8ba3-47ef-8ac7-27a9df8ce5c2"), 2, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("9c572aa4-b0ab-46d2-9d4a-6107a2f17df4"), 23, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("9c62b753-9152-41e1-8d7f-52fe587fcbd3"), 26, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("9f30cfaf-d98d-4893-8b19-c7f0dd6dca76"), 30, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("9f980bba-c6d2-4819-9fcf-9bf691f4990b"), 30, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("a0283ee1-961f-4a2a-9875-7f55064eeb2c"), 13, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("a21ed7b3-85a5-4dd2-ad2f-8ae5d06e941c"), 29, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("a24f5eb9-2310-4c26-96cc-4a1ef59e4409"), 4, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("a353d1c5-35f6-44cf-a672-f6c8897c3053"), 30, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("a476894c-2287-4c50-8ee3-5c720a6da814"), 23, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("a5d19fff-9e2b-4815-9e2b-8883f99d7b51"), 6, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("a61e2f4e-0f37-4d2c-828c-a0ea90623add"), 22, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("a66e3a9d-348c-49c9-b804-2ab51150d87f"), 14, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("a885ae71-fb7c-40b4-a5b4-8037cd5ba6d2"), 5, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("a8a9b385-f2e1-4fce-9f84-4ec8ae6febb4"), 24, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("a8cc3342-6b30-464d-a1f5-e636b78196e6"), 8, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("a9048ed3-7601-437a-b286-a29f486f54d7"), 26, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("a9e9cdae-196c-4b9d-8d72-cd30b296a3e3"), 24, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("aa800c72-dac0-4944-97ea-51e14560368e"), 2, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("aab0fc00-e041-4612-9c21-4c761680b12b"), 1, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("ac432241-703b-4ec0-9446-e8488e2336fb"), 7, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("acd197b2-0b3f-402e-a35b-a73505022338"), 22, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("af2f44be-adab-4d06-8c00-563607b00795"), 3, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("afa5c873-e2f6-44e8-92af-df989d1b2940"), 10, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("b11bb3b5-98b4-48d8-95df-c9891a231299"), 1, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("b236cf00-1605-4fda-9cc0-d8dc5f022765"), 28, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("b2abe1be-7815-47ec-a769-8e3ec49ef928"), 12, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("b2e9c106-dd34-4b77-87a9-a1f15f5c4c23"), 9, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("b3d8d38c-6aeb-4a46-8983-2296fd43bcd2"), 16, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("b57deceb-3c79-41ef-894e-5effcb669b4d"), 12, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("b6a240a5-339f-46d1-b824-53ea7958d2a7"), 27, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("bd2c3d70-554e-48c0-8f7c-4546b44a54a0"), 12, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("bdc80e1f-7805-4143-949f-e7cae4fda183"), 30, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("bea87a85-6eca-42d6-9b69-16b121b4b6f8"), 22, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("c0f44e47-2c64-417a-a5e0-9d0b82c93b3a"), 12, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("c25f3a06-da40-4ab8-a451-6cc645aac7c0"), 1, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("c283a83d-a8c2-406a-a84b-8f5c45b6dbd1"), 7, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("c3722925-585a-4d89-9381-dc5de3e23c1f"), 24, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("c4cf5e56-80dd-4684-a678-879aeef1b8a2"), 14, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("c6320c05-b56d-470b-b123-ace7197ae635"), 1, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("c923ccea-25c2-4cee-b756-f052b9b87784"), 26, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("c944879e-7a01-4769-8aa6-cc45e69279db"), 18, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("ca955ddc-a8cb-48d2-93c1-5dcf69b74e4e"), 1, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("caa19039-635d-4b42-9ac3-5146a9f48378"), 1, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("cacf9d9e-2008-4fbf-9fe0-6d7b5e954ddb"), 20, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("cb0a9db7-a126-4476-a466-9aff8603bade"), 12, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("cb709dad-6293-4b22-8c14-62d33cbc8b28"), 30, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("cbee41db-9890-4808-9c96-fa71a5686716"), 25, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("cc2ab8b2-bb32-413f-a601-e15ebe776152"), 24, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("ce6a82a5-2b39-40c1-be6e-1c04806842cf"), 14, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("cec60ff9-7bf1-432e-b713-b2738ccd6d70"), 16, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("cf1b8942-2a89-4178-9d0d-f11d6948fd3f"), 11, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("d0279763-64ad-471d-ad75-2c3dd4e5bbf7"), 16, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("d0ad3c59-3ad2-4e40-9b9b-209a45e1f1ae"), 26, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("d0f9942f-bf81-406d-b605-879345ebc63a"), 24, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("d172bda5-5433-4af4-a779-0205d26dfa0a"), 4, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("d459ffd9-9faa-450e-b48b-6a0cbac31539"), 25, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("d4b672dd-2fe5-4c9c-a282-f08bf6a4a88f"), 1, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("d4beff9b-7325-44bd-b487-5e449dd0fa5d"), 17, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("d4d8294d-ab39-4903-94a2-a8187b342062"), 19, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("d5a9c5f6-5377-472d-a9f8-a006db887b3b"), 5, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("d6321076-0657-4070-bb37-e45df66a531f"), 2, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("d67e9a21-13a4-46e1-b120-7bfb6f4094c2"), 30, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("d68af1e0-57cf-4c16-923b-62f7c8084a30"), 4, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("d8dffa24-968b-42d1-a694-751fef26a23e"), 19, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("da5e14f2-b288-49f2-befb-4ed07c5ccc67"), 28, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("daf58587-50ef-4281-a11c-c628ebd5cf8b"), 3, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("dc0cdcd8-2d34-4769-b7a7-2b8134b805b8"), 23, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("dcb11650-2a6f-49a7-9193-a4a58ae14274"), 16, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("dcc73270-5730-4dd3-8610-d56c7324a010"), 15, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("e01a789d-9bcd-4ffb-bcfc-9aff4369ba1f"), 4, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("e1039d88-7883-448e-88ec-458be494be54"), 18, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("e12b27e5-6c9b-4baf-8d33-7542e6666eb6"), 22, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("e1eb7681-8cf8-4f74-88b9-c04720855cbc"), 19, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("e2a5c810-d49d-4f58-8402-09f35b711046"), 9, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("e2daa170-9a81-46f8-8235-bcc1797fe8c9"), 2, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("e39a4ff7-9cb6-499e-b64c-30b462aefb1c"), 3, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("e3fdc94b-1fca-4e16-93d0-ddc943cc1312"), 5, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") },
                    { new Guid("e446405d-de81-4fc2-9999-5780b0d10e5b"), 19, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("e5ad3f57-1d8a-45bc-9c7b-2d823208fdd4"), 28, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("e6c2bb0d-6d3b-4714-97b1-cdd4da073998"), 9, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("e6f8cd79-4771-4a1d-b689-9a6839c63aed"), 18, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("e702f2aa-4dbc-4209-983b-2f44ddc7723c"), 10, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("e8621897-6ff7-4d35-9e67-d0deca753ad9"), 4, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("e95cd249-9721-4c0b-bb57-ac59506d51d0"), 23, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("e98a9a62-2e32-4436-bf7f-ec6834d131ec"), 17, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("eb0cbc22-dd3e-461d-b0ec-fb31e9f6e26a"), 12, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("ee651c71-9363-4f90-b6f7-2f26e60eb5d8"), 19, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("ee98574e-8a3b-4d4a-a7d9-7bfc9f42f3c2"), 15, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("ef26e22c-848a-4bdc-ac26-4d2cda884a1e"), 8, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("ef4398b0-f9c8-4698-ab6d-6c57eeedd089"), 9, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("f105f6db-ccf2-4465-8528-c0aadb39f4ad"), 29, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("f279e993-8041-46d9-bc2b-fca3d9c0d3b9"), 30, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("f2ec42b6-aa75-4492-92d1-82b2e5c106bc"), 3, new Guid("f1b737d0-6abb-464a-b93f-c4199da3d3ad") },
                    { new Guid("f3f444b8-7015-441e-a2b8-978c680553e3"), 29, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("f48f130b-a678-45c9-854c-71fc9ae2121d"), 20, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("f50a2ab4-6c97-40c6-8ae9-3e5a16b1b6c6"), 13, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("f5f40a1c-0177-4fce-abff-ecb12fa511cd"), 5, new Guid("f08bd2bb-c700-4c45-b5b5-ecd15a0d3ca4") },
                    { new Guid("f72c55f1-bb3b-4ec8-89a7-6a34c79ac322"), 21, new Guid("75ceb72f-3bb5-4f85-ba21-f96978b42b8c") },
                    { new Guid("f7402172-e040-4add-bf03-e2b2cb74588f"), 17, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("fb6cc91e-0b49-407c-a64f-60c1ca2d2220"), 27, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("fbd75667-e273-4c28-9e21-9db643813e0a"), 17, new Guid("a5d28688-eed2-4395-a346-0599504d8a46") },
                    { new Guid("fbe5eec0-b361-4a4f-9839-1bc4db4aff86"), 9, new Guid("dfba430c-68e9-4cc4-a454-0a56476b511f") },
                    { new Guid("fc0eab5c-0c2c-40d0-96b7-868f24436ebc"), 13, new Guid("ada08eef-ecec-48dd-9380-dbcd4fd604f6") },
                    { new Guid("fc4626f1-4312-4d57-9c04-37aa39e74270"), 27, new Guid("6b09f67e-f12e-4b1d-ae0f-12f59f179648") },
                    { new Guid("fd835fdc-e3e8-4dc6-ab5c-ac04ec10afb8"), 26, new Guid("660cbc6c-493b-4873-82b0-636dd4206350") },
                    { new Guid("fead611f-34cc-4d7e-b2c8-3cdcd4687e76"), 26, new Guid("a1abdc68-5a6f-4a72-bb4c-1af06029f18a") },
                    { new Guid("ffe0045d-ab5a-4819-b3d4-155646dcb08b"), 21, new Guid("def7fd6b-09e5-416b-8c01-6a4b7929abe5") }
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
                name: "IX_BatleResults_BatleId",
                table: "BatleResults",
                column: "BatleId");

            migrationBuilder.CreateIndex(
                name: "IX_BatleResults_TournamentId",
                table: "BatleResults",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_BatleResults_WinnerId",
                table: "BatleResults",
                column: "WinnerId");

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
                name: "IX_GameConsoles_RoomId",
                table: "GameConsoles",
                column: "RoomId");

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
                name: "BatleResults");

            migrationBuilder.DropTable(
                name: "GameConsoles");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Htmls");

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
                name: "Batle");

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
                name: "Tournaments");

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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class EditingTournaments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batle_Round_RoundId",
                table: "Batle");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "TeamsTournaments");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d4e6695f-9591-401c-87e8-7ea968ce31b4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e9631d62-f546-4d86-9c0e-7fc7a1aeea76"));

            migrationBuilder.DropColumn(
                name: "FirstTeamScore",
                table: "Batle");

            migrationBuilder.DropColumn(
                name: "SecondTeamScore",
                table: "Batle");

            migrationBuilder.RenameColumn(
                name: "RoundId",
                table: "Batle",
                newName: "TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Batle_RoundId",
                table: "Batle",
                newName: "IX_Batle_TournamentId");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Tournaments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BatleResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstScore = table.Column<int>(type: "int", nullable: false),
                    SecondScore = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatleResults", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7ecf845f-98f6-44e8-bf83-b7cc3c432887"), "User" },
                    { new Guid("a56b27bd-e4c9-4285-99ab-79c66f583bec"), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TeamId",
                table: "Tournaments",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_BatleResults_TournamentId",
                table: "BatleResults",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_BatleResults_WinnerId",
                table: "BatleResults",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batle_Tournaments_TournamentId",
                table: "Batle",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Teams_TeamId",
                table: "Tournaments",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batle_Tournaments_TournamentId",
                table: "Batle");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Teams_TeamId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "BatleResults");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_TeamId",
                table: "Tournaments");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7ecf845f-98f6-44e8-bf83-b7cc3c432887"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a56b27bd-e4c9-4285-99ab-79c66f583bec"));

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Tournaments");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "Batle",
                newName: "RoundId");

            migrationBuilder.RenameIndex(
                name: "IX_Batle_TournamentId",
                table: "Batle",
                newName: "IX_Batle_RoundId");

            migrationBuilder.AddColumn<int>(
                name: "FirstTeamScore",
                table: "Batle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondTeamScore",
                table: "Batle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TeamsMaxCount = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamsTournaments",
                columns: table => new
                {
                    TeamsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsTournaments", x => new { x.TeamsId, x.TournamentsId });
                    table.ForeignKey(
                        name: "FK_TeamsTournaments_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamsTournaments_Tournaments_TournamentsId",
                        column: x => x.TournamentsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d4e6695f-9591-401c-87e8-7ea968ce31b4"), "Admin" },
                    { new Guid("e9631d62-f546-4d86-9c0e-7fc7a1aeea76"), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Round_TournamentId",
                table: "Round",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsTournaments_TournamentsId",
                table: "TeamsTournaments",
                column: "TournamentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batle_Round_RoundId",
                table: "Batle",
                column: "RoundId",
                principalTable: "Round",
                principalColumn: "Id");
        }
    }
}

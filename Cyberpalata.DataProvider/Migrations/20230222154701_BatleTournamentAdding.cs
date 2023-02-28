using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class BatleTournamentAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batle_Tournaments_TournamentId",
                table: "Batle");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7ecf845f-98f6-44e8-bf83-b7cc3c432887"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a56b27bd-e4c9-4285-99ab-79c66f583bec"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TournamentId",
                table: "Batle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4c46e056-67d7-4620-ae37-11db3f797cce"), "Admin" },
                    { new Guid("970b07f6-5a54-4b3e-90dc-1cf65ad16acb"), "User" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Batle_Tournaments_TournamentId",
                table: "Batle",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batle_Tournaments_TournamentId",
                table: "Batle");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c46e056-67d7-4620-ae37-11db3f797cce"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("970b07f6-5a54-4b3e-90dc-1cf65ad16acb"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TournamentId",
                table: "Batle",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7ecf845f-98f6-44e8-bf83-b7cc3c432887"), "User" },
                    { new Guid("a56b27bd-e4c9-4285-99ab-79c66f583bec"), "Admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Batle_Tournaments_TournamentId",
                table: "Batle",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");
        }
    }
}

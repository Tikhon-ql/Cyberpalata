using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Discriminator", "Name" },
                values: new object[] { new Guid("399ce32f-1610-44dd-b634-4ffdc223038b"), "GameConsoleRoom", "ConsoleRoom1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("399ce32f-1610-44dd-b634-4ffdc223038b"));
        }
    }
}

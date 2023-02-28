using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class BatleEditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ac48cfd1-5450-4857-96a5-002fde51048d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f66069c9-be82-4199-9686-7975d86093c7"));

            migrationBuilder.AddColumn<int>(
                name: "RoundNumber",
                table: "Batle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a326f0d4-32fa-4f52-b299-24e5a0790af5"), "Admin" },
                    { new Guid("a81348a6-94a4-496f-a548-a8456d7fe5dd"), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a326f0d4-32fa-4f52-b299-24e5a0790af5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a81348a6-94a4-496f-a548-a8456d7fe5dd"));

            migrationBuilder.DropColumn(
                name: "RoundNumber",
                table: "Batle");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ac48cfd1-5450-4857-96a5-002fde51048d"), "Admin" },
                    { new Guid("f66069c9-be82-4199-9686-7975d86093c7"), "User" }
                });
        }
    }
}

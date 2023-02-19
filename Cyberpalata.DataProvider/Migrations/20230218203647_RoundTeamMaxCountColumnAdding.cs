using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class RoundTeamMaxCountColumnAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("123e9616-9769-408e-a88c-b0c8b82a6e13"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7238ad4e-be86-45c2-84bb-d3400bde5664"));

            migrationBuilder.AddColumn<int>(
                name: "TeamsMaxCount",
                table: "Round",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5276fca9-bc29-491f-9904-45cbd9b59533"), "User" },
                    { new Guid("7ba43f4d-280c-4e4d-abd0-8c9845c7cd10"), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5276fca9-bc29-491f-9904-45cbd9b59533"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7ba43f4d-280c-4e4d-abd0-8c9845c7cd10"));

            migrationBuilder.DropColumn(
                name: "TeamsMaxCount",
                table: "Round");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("123e9616-9769-408e-a88c-b0c8b82a6e13"), "Admin" },
                    { new Guid("7238ad4e-be86-45c2-84bb-d3400bde5664"), "User" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class RoundIdAutoGenerationAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("41d0ad47-f0d2-43ea-a5a9-0b600c9d67b4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7c704268-e191-4e0d-ab24-197f9cf6178c"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("123e9616-9769-408e-a88c-b0c8b82a6e13"), "Admin" },
                    { new Guid("7238ad4e-be86-45c2-84bb-d3400bde5664"), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("123e9616-9769-408e-a88c-b0c8b82a6e13"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7238ad4e-be86-45c2-84bb-d3400bde5664"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("41d0ad47-f0d2-43ea-a5a9-0b600c9d67b4"), "User" },
                    { new Guid("7c704268-e191-4e0d-ab24-197f9cf6178c"), "Admin" }
                });
        }
    }
}

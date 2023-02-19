using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class TeamMemberIdAutoGenerationAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5276fca9-bc29-491f-9904-45cbd9b59533"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7ba43f4d-280c-4e4d-abd0-8c9845c7cd10"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5f94420d-63db-4716-a55f-55e7191a9f93"), "Admin" },
                    { new Guid("75a632ac-495b-4725-849d-b79d87130a7e"), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5f94420d-63db-4716-a55f-55e7191a9f93"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75a632ac-495b-4725-849d-b79d87130a7e"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5276fca9-bc29-491f-9904-45cbd9b59533"), "User" },
                    { new Guid("7ba43f4d-280c-4e4d-abd0-8c9845c7cd10"), "Admin" }
                });
        }
    }
}

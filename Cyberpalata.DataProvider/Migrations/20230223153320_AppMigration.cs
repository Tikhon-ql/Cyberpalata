using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class AppMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c46e056-67d7-4620-ae37-11db3f797cce"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("970b07f6-5a54-4b3e-90dc-1cf65ad16acb"));

            migrationBuilder.DropColumn(
                name: "FirstScore",
                table: "BatleResults");

            migrationBuilder.DropColumn(
                name: "SecondScore",
                table: "BatleResults");

            migrationBuilder.AddColumn<Guid>(
                name: "BatleId",
                table: "BatleResults",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ac48cfd1-5450-4857-96a5-002fde51048d"), "Admin" },
                    { new Guid("f66069c9-be82-4199-9686-7975d86093c7"), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatleResults_BatleId",
                table: "BatleResults",
                column: "BatleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatleResults_Batle_BatleId",
                table: "BatleResults",
                column: "BatleId",
                principalTable: "Batle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatleResults_Batle_BatleId",
                table: "BatleResults");

            migrationBuilder.DropIndex(
                name: "IX_BatleResults_BatleId",
                table: "BatleResults");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ac48cfd1-5450-4857-96a5-002fde51048d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f66069c9-be82-4199-9686-7975d86093c7"));

            migrationBuilder.DropColumn(
                name: "BatleId",
                table: "BatleResults");

            migrationBuilder.AddColumn<int>(
                name: "FirstScore",
                table: "BatleResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondScore",
                table: "BatleResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4c46e056-67d7-4620-ae37-11db3f797cce"), "Admin" },
                    { new Guid("970b07f6-5a54-4b3e-90dc-1cf65ad16acb"), "User" }
                });
        }
    }
}

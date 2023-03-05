using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class JoinRequestDataPopulating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JoinRequests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "InProgress" },
                    { 2, "Accepted" },
                    { 3, "Rejected" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JoinRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JoinRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JoinRequests",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

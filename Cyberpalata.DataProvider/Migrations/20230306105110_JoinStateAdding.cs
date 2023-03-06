using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class JoinStateAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
              table: "JoinRequestState",
              keyColumn: "Id",
              keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JoinRequestState",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JoinRequestState",
                keyColumn: "Id",
                keyValue: 3);
            migrationBuilder.DeleteData(
                table: "JoinRequestState",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

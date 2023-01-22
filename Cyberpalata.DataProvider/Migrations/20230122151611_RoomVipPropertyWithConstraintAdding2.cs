using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class RoomVipPropertyWithConstraintAdding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "IsVip",
                table: "Rooms");

            migrationBuilder.AddCheckConstraint(
                name: "IsVip",
                table: "Rooms",
                sql: "TypeId = 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "IsVip",
                table: "Rooms");

            migrationBuilder.AddCheckConstraint(
                name: "IsVip",
                table: "Rooms",
                sql: "Type = 3");
        }
    }
}

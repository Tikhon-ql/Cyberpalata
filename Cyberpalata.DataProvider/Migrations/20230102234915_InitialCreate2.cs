using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameConsoles_Room_ConsoleRoomId",
                table: "GameConsoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Room_RoomId",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Room_RoomId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameConsoles_Rooms_ConsoleRoomId",
                table: "GameConsoles",
                column: "ConsoleRoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Rooms_RoomId",
                table: "Prices",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Rooms_RoomId",
                table: "Seat",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameConsoles_Rooms_ConsoleRoomId",
                table: "GameConsoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Rooms_RoomId",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Rooms_RoomId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameConsoles_Room_ConsoleRoomId",
                table: "GameConsoles",
                column: "ConsoleRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Room_RoomId",
                table: "Prices",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Room_RoomId",
                table: "Seat",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

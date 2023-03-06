using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Editing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_CaptainIdId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Messages",
                newName: "MessageText");

            migrationBuilder.RenameColumn(
                name: "CaptainIdId",
                table: "Chats",
                newName: "CaptainId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_CaptainIdId",
                table: "Chats",
                newName: "IX_Chats_CaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_CaptainId",
                table: "Chats",
                column: "CaptainId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_CaptainId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "MessageText",
                table: "Messages",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "CaptainId",
                table: "Chats",
                newName: "CaptainIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_CaptainId",
                table: "Chats",
                newName: "IX_Chats_CaptainIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_CaptainIdId",
                table: "Chats",
                column: "CaptainIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

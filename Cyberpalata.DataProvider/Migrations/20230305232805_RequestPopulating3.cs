using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class RequestPopulating3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_JoinRequestState_StateId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_JoinRequestState_StateId",
                table: "Requests",
                column: "StateId",
                principalTable: "JoinRequestState",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_JoinRequestState_StateId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_JoinRequestState_StateId",
                table: "Requests",
                column: "StateId",
                principalTable: "JoinRequestState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

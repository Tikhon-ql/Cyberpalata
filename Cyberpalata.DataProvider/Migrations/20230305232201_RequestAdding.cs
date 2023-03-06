using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class RequestAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JoinRequestState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinRequestState", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StateId",
                table: "Requests",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_JoinRequestState_StateId",
                table: "Requests",
                column: "StateId",
                principalTable: "JoinRequestState",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_JoinRequestState_StateId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "JoinRequestState");

            migrationBuilder.DropIndex(
                name: "IX_Requests_StateId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Requests");
        }
    }
}

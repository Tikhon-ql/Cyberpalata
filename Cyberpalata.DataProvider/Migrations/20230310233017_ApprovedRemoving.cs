using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class ApprovedRemoving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstTeamApproved",
                table: "Batle");

            migrationBuilder.DropColumn(
                name: "IsSecondTeamApproved",
                table: "Batle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirstTeamApproved",
                table: "Batle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSecondTeamApproved",
                table: "Batle",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

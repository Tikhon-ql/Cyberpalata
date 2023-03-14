using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class TournamentIsGoneProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGone",
                table: "Tournaments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGone",
                table: "Tournaments");
        }
    }
}

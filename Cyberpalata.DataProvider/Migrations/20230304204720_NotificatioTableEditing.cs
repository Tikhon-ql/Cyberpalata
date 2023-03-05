using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class NotificatioTableEditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Notifications",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "Notifications",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Notifications",
                newName: "Date");

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

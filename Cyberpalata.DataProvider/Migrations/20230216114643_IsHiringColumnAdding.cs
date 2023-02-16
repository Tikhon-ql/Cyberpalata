using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cyberpalata.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class IsHiringColumnAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHiring",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Htmls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Htmls", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Htmls",
                columns: new[] { "Id", "Html" },
                values: new object[,]
                {
                    { "EmailVerificationHtml", "<html>\r\n                                <div>\r\n                                    <h1>Your verification code:</h1>\r\n                                    <div><b></b></div>\r\n                                </div>\r\n                            </html>" },
                    { "ResetPasswordHtml", "<html>\r\n                                    <div>\r\n                                        <a href='http://localhost:3000/passwordReset' class='btn btn-outline-dark btn-sm text-white w-50 m-1'>Reset password</a>\r\n                                    </div>\r\n                                </html>" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Htmls");

            migrationBuilder.DropColumn(
                name: "IsHiring",
                table: "Teams");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LST.Repository.EF.All.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraFieldsToApiResponseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "ApiResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "ApiResponses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Translated",
                table: "ApiResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Translation",
                table: "ApiResponses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "ApiResponses");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "ApiResponses");

            migrationBuilder.DropColumn(
                name: "Translated",
                table: "ApiResponses");

            migrationBuilder.DropColumn(
                name: "Translation",
                table: "ApiResponses");
        }
    }
}

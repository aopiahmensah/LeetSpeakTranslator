using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LST.Repository.EF.All.Migrations
{
    /// <inheritdoc />
    public partial class LinkApiResponseToApiRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApiResponseId",
                table: "ApiRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiRequests_ApiResponseId",
                table: "ApiRequests",
                column: "ApiResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiRequests_ApiResponses_ApiResponseId",
                table: "ApiRequests",
                column: "ApiResponseId",
                principalTable: "ApiResponses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiRequests_ApiResponses_ApiResponseId",
                table: "ApiRequests");

            migrationBuilder.DropIndex(
                name: "IX_ApiRequests_ApiResponseId",
                table: "ApiRequests");

            migrationBuilder.DropColumn(
                name: "ApiResponseId",
                table: "ApiRequests");
        }
    }
}

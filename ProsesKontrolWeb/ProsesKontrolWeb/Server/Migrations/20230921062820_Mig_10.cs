using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsesKontrolWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class Mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProsesModelId",
                table: "ProsesKontrolModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProsesKontrolModels_ProsesModelId",
                table: "ProsesKontrolModels",
                column: "ProsesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProsesKontrolModels_ProsesModels_ProsesModelId",
                table: "ProsesKontrolModels",
                column: "ProsesModelId",
                principalTable: "ProsesModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProsesKontrolModels_ProsesModels_ProsesModelId",
                table: "ProsesKontrolModels");

            migrationBuilder.DropIndex(
                name: "IX_ProsesKontrolModels_ProsesModelId",
                table: "ProsesKontrolModels");

            migrationBuilder.DropColumn(
                name: "ProsesModelId",
                table: "ProsesKontrolModels");
        }
    }
}

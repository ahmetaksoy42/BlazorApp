using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsesKontrolWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class mig_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProsesId",
                table: "ProsesKontrolModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProsesId",
                table: "ProsesKontrolModels",
                type: "int",
                nullable: true);
        }
    }
}

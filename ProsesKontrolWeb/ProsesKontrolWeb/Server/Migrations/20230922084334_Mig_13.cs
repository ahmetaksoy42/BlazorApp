using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsesKontrolWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class Mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UniteModelId",
                table: "ProsesModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UniteModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KosulNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniteModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProsesModels_UniteModelId",
                table: "ProsesModels",
                column: "UniteModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProsesModels_UniteModels_UniteModelId",
                table: "ProsesModels",
                column: "UniteModelId",
                principalTable: "UniteModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProsesModels_UniteModels_UniteModelId",
                table: "ProsesModels");

            migrationBuilder.DropTable(
                name: "UniteModels");

            migrationBuilder.DropIndex(
                name: "IX_ProsesModels_UniteModelId",
                table: "ProsesModels");

            migrationBuilder.DropColumn(
                name: "UniteModelId",
                table: "ProsesModels");
        }
    }
}

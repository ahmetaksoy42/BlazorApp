using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsesKontrolWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProsesKontrolModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "ImageModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueStrId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableId = table.Column<int>(type: "int", nullable: true),
                    TableInsideId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageModels");

            migrationBuilder.InsertData(
                table: "ProsesKontrolModels",
                columns: new[] { "Id", "HataTipi", "KontrolMetodu", "Operator", "OperatorKontrol", "ProsesId", "ProsesKontrolSorumlusu", "ProsesSorumlusuKontrol", "Standart" },
                values: new object[] { 1, "1", "KM", true, "sda", null, false, "sdasda", "Standart" });
        }
    }
}

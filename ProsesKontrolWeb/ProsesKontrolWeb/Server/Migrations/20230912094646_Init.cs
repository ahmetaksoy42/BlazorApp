using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsesKontrolWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProsesKontrolModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProsesId = table.Column<int>(type: "int", nullable: true),
                    HataTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Standart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontrolMetodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<bool>(type: "bit", nullable: true),
                    OperatorKontrol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProsesKontrolSorumlusu = table.Column<bool>(type: "bit", nullable: true),
                    ProsesSorumlusuKontrol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProsesKontrolModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProsesKontrolModels",
                columns: new[] { "Id", "HataTipi", "KontrolMetodu", "Operator", "OperatorKontrol", "ProsesId", "ProsesKontrolSorumlusu", "ProsesSorumlusuKontrol", "Standart" },
                values: new object[] { 1, "1", "KM", true, "sda", null, false, "sdasda", "Standart" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProsesKontrolModels");
        }
    }
}

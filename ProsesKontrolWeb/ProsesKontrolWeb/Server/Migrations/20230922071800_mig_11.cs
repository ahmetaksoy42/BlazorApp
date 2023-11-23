using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProsesKontrolWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProsesModels",
                newName: "Isim");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "ProsesModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Birim",
                table: "ProsesModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IsSuresi",
                table: "ProsesModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KalipAyarSuresi",
                table: "ProsesModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaatlikUretimMiktari",
                table: "ProsesModels",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "ProsesModels");

            migrationBuilder.DropColumn(
                name: "Birim",
                table: "ProsesModels");

            migrationBuilder.DropColumn(
                name: "IsSuresi",
                table: "ProsesModels");

            migrationBuilder.DropColumn(
                name: "KalipAyarSuresi",
                table: "ProsesModels");

            migrationBuilder.DropColumn(
                name: "SaatlikUretimMiktari",
                table: "ProsesModels");

            migrationBuilder.RenameColumn(
                name: "Isim",
                table: "ProsesModels",
                newName: "Name");
        }
    }
}

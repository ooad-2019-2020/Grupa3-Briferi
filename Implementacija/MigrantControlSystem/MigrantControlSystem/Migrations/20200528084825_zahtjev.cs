using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrantControlSystem.Migrations
{
    public partial class zahtjev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dodatniRokIzvrsenja",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "drzava",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hapsenje_dodatniRokIzvrsenja",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "policijskaStanicaid",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Premjestanje_dodatniRokIzvrsenja",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "dolazniMigrantskiCentarid",
                table: "Zahtjev",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Zahtjev",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_policijskaStanicaid",
                table: "Zahtjev",
                column: "policijskaStanicaid");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_dolazniMigrantskiCentarid",
                table: "Zahtjev",
                column: "dolazniMigrantskiCentarid");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_PolicijskaStanica_policijskaStanicaid",
                table: "Zahtjev",
                column: "policijskaStanicaid",
                principalTable: "PolicijskaStanica",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_MigrantskiCentar_dolazniMigrantskiCentarid",
                table: "Zahtjev",
                column: "dolazniMigrantskiCentarid",
                principalTable: "MigrantskiCentar",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_PolicijskaStanica_policijskaStanicaid",
                table: "Zahtjev");

            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_MigrantskiCentar_dolazniMigrantskiCentarid",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_policijskaStanicaid",
                table: "Zahtjev");

            migrationBuilder.DropIndex(
                name: "IX_Zahtjev_dolazniMigrantskiCentarid",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "dodatniRokIzvrsenja",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "drzava",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Hapsenje_dodatniRokIzvrsenja",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "policijskaStanicaid",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Premjestanje_dodatniRokIzvrsenja",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "dolazniMigrantskiCentarid",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Zahtjev");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrantControlSystem.Migrations
{
    public partial class centri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "brojRegistrovanih",
                table: "MigrantskiCentar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "brojZatvorenih",
                table: "MigrantskiCentar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "standardniPeriodZadrzavanjaMigranta",
                table: "MigrantskiCentar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MigrantskiCentar",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brojRegistrovanih",
                table: "MigrantskiCentar");

            migrationBuilder.DropColumn(
                name: "brojZatvorenih",
                table: "MigrantskiCentar");

            migrationBuilder.DropColumn(
                name: "standardniPeriodZadrzavanjaMigranta",
                table: "MigrantskiCentar");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MigrantskiCentar");
        }
    }
}

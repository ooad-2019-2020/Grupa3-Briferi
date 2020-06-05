using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrantControlSystem.Migrations
{
    public partial class migracija11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "y",
                table: "Lokacija",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "x",
                table: "Lokacija",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "y",
                table: "Lokacija",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "x",
                table: "Lokacija",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

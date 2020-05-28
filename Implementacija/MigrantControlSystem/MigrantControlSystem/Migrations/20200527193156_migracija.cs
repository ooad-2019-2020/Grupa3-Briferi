using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrantControlSystem.Migrations
{
    public partial class migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    x = table.Column<int>(nullable: false),
                    y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MigrantskiCentar",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(nullable: true),
                    kapacitet = table.Column<int>(nullable: false),
                    lokacijaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MigrantskiCentar", x => x.id);
                    table.ForeignKey(
                        name: "FK_MigrantskiCentar_Lokacija_lokacijaid",
                        column: x => x.lokacijaid,
                        principalTable: "Lokacija",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicijskaStanica",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(nullable: true),
                    lokacijaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicijskaStanica", x => x.id);
                    table.ForeignKey(
                        name: "FK_PolicijskaStanica_Lokacija_lokacijaid",
                        column: x => x.lokacijaid,
                        principalTable: "Lokacija",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Migrant",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    drzavaPorijekla = table.Column<string>(nullable: true),
                    datumRegistracije = table.Column<DateTime>(nullable: false),
                    migrantskiCentarid = table.Column<int>(nullable: true),
                    policijskaStanicaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Migrant", x => x.id);
                    table.ForeignKey(
                        name: "FK_Migrant_MigrantskiCentar_migrantskiCentarid",
                        column: x => x.migrantskiCentarid,
                        principalTable: "MigrantskiCentar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Migrant_PolicijskaStanica_policijskaStanicaid",
                        column: x => x.policijskaStanicaid,
                        principalTable: "PolicijskaStanica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    migrantid = table.Column<int>(nullable: true),
                    migrantskiCentarid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.id);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Migrant_migrantid",
                        column: x => x.migrantid,
                        principalTable: "Migrant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtjev_MigrantskiCentar_migrantskiCentarid",
                        column: x => x.migrantskiCentarid,
                        principalTable: "MigrantskiCentar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Migrant_migrantskiCentarid",
                table: "Migrant",
                column: "migrantskiCentarid");

            migrationBuilder.CreateIndex(
                name: "IX_Migrant_policijskaStanicaid",
                table: "Migrant",
                column: "policijskaStanicaid");

            migrationBuilder.CreateIndex(
                name: "IX_MigrantskiCentar_lokacijaid",
                table: "MigrantskiCentar",
                column: "lokacijaid");

            migrationBuilder.CreateIndex(
                name: "IX_PolicijskaStanica_lokacijaid",
                table: "PolicijskaStanica",
                column: "lokacijaid");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_migrantid",
                table: "Zahtjev",
                column: "migrantid");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_migrantskiCentarid",
                table: "Zahtjev",
                column: "migrantskiCentarid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropTable(
                name: "Migrant");

            migrationBuilder.DropTable(
                name: "MigrantskiCentar");

            migrationBuilder.DropTable(
                name: "PolicijskaStanica");

            migrationBuilder.DropTable(
                name: "Lokacija");
        }
    }
}

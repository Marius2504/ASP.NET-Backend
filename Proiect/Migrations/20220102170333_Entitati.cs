using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class Entitati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antrenors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    varsta = table.Column<int>(type: "int", nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Optiuni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recenzii = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Optiuni = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Judet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GymId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresas_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AntrenorGym",
                columns: table => new
                {
                    AntrenorId = table.Column<int>(type: "int", nullable: false),
                    GymId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntrenorGym", x => new { x.GymId, x.AntrenorId });
                    table.ForeignKey(
                        name: "FK_AntrenorGym_Antrenors_AntrenorId",
                        column: x => x.AntrenorId,
                        principalTable: "Antrenors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AntrenorGym_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Varsta = table.Column<int>(type: "int", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntrenorsId = table.Column<int>(type: "int", nullable: true),
                    GymsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oms_Antrenors_AntrenorsId",
                        column: x => x.AntrenorsId,
                        principalTable: "Antrenors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oms_Gyms_GymsId",
                        column: x => x.GymsId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresas_GymId",
                table: "Adresas",
                column: "GymId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AntrenorGym_AntrenorId",
                table: "AntrenorGym",
                column: "AntrenorId");

            migrationBuilder.CreateIndex(
                name: "IX_Oms_AntrenorsId",
                table: "Oms",
                column: "AntrenorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Oms_GymsId",
                table: "Oms",
                column: "GymsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresas");

            migrationBuilder.DropTable(
                name: "AntrenorGym");

            migrationBuilder.DropTable(
                name: "Oms");

            migrationBuilder.DropTable(
                name: "Antrenors");

            migrationBuilder.DropTable(
                name: "Gyms");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulama1.Migrations
{
    /// <inheritdoc />
    public partial class migrationreinstall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HayvanTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HayvanTurleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hayvanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HayvanAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    HayvanTuruId = table.Column<int>(type: "int", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hayvanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hayvanlar_HayvanTurleri_HayvanTuruId",
                        column: x => x.HayvanTuruId,
                        principalTable: "HayvanTurleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hayvanlar_HayvanTuruId",
                table: "Hayvanlar",
                column: "HayvanTuruId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hayvanlar");

            migrationBuilder.DropTable(
                name: "HayvanTurleri");
        }
    }
}

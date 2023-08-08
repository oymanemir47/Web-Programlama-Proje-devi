using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulama1.Migrations
{
    /// <inheritdoc />
    public partial class SahiplenmelerTablosuEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sahiplenmeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    HayvanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sahiplenmeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sahiplenmeler_Hayvanlar_HayvanId",
                        column: x => x.HayvanId,
                        principalTable: "Hayvanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sahiplenmeler_HayvanId",
                table: "Sahiplenmeler",
                column: "HayvanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sahiplenmeler");
        }
    }
}

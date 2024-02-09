using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serino = table.Column<int>(type: "int", nullable: false),
                    resim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CihazAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fiyat = table.Column<double>(type: "float", nullable: false),
                    stok = table.Column<int>(type: "int", nullable: false),
                    ozellik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    durum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kategoriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_urunler_kategoriler_kategoriId",
                        column: x => x.kategoriId,
                        principalTable: "kategoriler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefon = table.Column<int>(type: "int", nullable: true),
                    rolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_roller_rolId",
                        column: x => x.rolId,
                        principalTable: "roller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_urunler_kategoriId",
                table: "urunler",
                column: "kategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_users_rolId",
                table: "users",
                column: "rolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "urunler");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "kategoriler");

            migrationBuilder.DropTable(
                name: "roller");
        }
    }
}

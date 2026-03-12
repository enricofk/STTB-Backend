using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace STTB.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddAkademikLanjutan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ketua_Prodi_Id",
                table: "Program_Studis",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dosens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama_Lengkap = table.Column<string>(type: "text", nullable: false),
                    Bidang_Keahlian = table.Column<string>(type: "text", nullable: false),
                    Pendidikan_Terakhir = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mata_Kuliahs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama_Mk = table.Column<string>(type: "text", nullable: false),
                    Kategori_Mk = table.Column<string>(type: "text", nullable: false),
                    Detail_Perincian = table.Column<string>(type: "text", nullable: false),
                    Prodi_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mata_Kuliahs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mata_Kuliahs_Program_Studis_Prodi_Id",
                        column: x => x.Prodi_Id,
                        principalTable: "Program_Studis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dosen_Prodis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dosen_Id = table.Column<int>(type: "integer", nullable: false),
                    Prodi_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosen_Prodis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dosen_Prodis_Dosens_Dosen_Id",
                        column: x => x.Dosen_Id,
                        principalTable: "Dosens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dosen_Prodis_Program_Studis_Prodi_Id",
                        column: x => x.Prodi_Id,
                        principalTable: "Program_Studis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Program_Studis_Ketua_Prodi_Id",
                table: "Program_Studis",
                column: "Ketua_Prodi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dosen_Prodis_Dosen_Id",
                table: "Dosen_Prodis",
                column: "Dosen_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dosen_Prodis_Prodi_Id",
                table: "Dosen_Prodis",
                column: "Prodi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mata_Kuliahs_Prodi_Id",
                table: "Mata_Kuliahs",
                column: "Prodi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Program_Studis_Dosens_Ketua_Prodi_Id",
                table: "Program_Studis",
                column: "Ketua_Prodi_Id",
                principalTable: "Dosens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Program_Studis_Dosens_Ketua_Prodi_Id",
                table: "Program_Studis");

            migrationBuilder.DropTable(
                name: "Dosen_Prodis");

            migrationBuilder.DropTable(
                name: "Mata_Kuliahs");

            migrationBuilder.DropTable(
                name: "Dosens");

            migrationBuilder.DropIndex(
                name: "IX_Program_Studis_Ketua_Prodi_Id",
                table: "Program_Studis");

            migrationBuilder.DropColumn(
                name: "Ketua_Prodi_Id",
                table: "Program_Studis");
        }
    }
}

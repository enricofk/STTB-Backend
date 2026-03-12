using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace STTB.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori_Beritas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama_Kategori = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori_Beritas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beritas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Judul = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Konten = table.Column<string>(type: "text", nullable: false),
                    Thumbnail_Url = table.Column<string>(type: "text", nullable: false),
                    Tanggal_Publikasi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Kategori_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beritas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beritas_Kategori_Beritas_Kategori_Id",
                        column: x => x.Kategori_Id,
                        principalTable: "Kategori_Beritas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beritas_Kategori_Id",
                table: "Beritas",
                column: "Kategori_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beritas");

            migrationBuilder.DropTable(
                name: "Kategori_Beritas");
        }
    }
}

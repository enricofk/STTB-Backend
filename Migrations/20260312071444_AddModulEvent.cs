using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace STTB.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddModulEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori_Kegiatans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama_Kategori = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori_Kegiatans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kegiatans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama_Kegiatan = table.Column<string>(type: "text", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Tanggal_Mulai = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tanggal_Selesai = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Lokasi = table.Column<string>(type: "text", nullable: false),
                    Kategori_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kegiatans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kegiatans_Kategori_Kegiatans_Kategori_Id",
                        column: x => x.Kategori_Id,
                        principalTable: "Kategori_Kegiatans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kegiatans_Kategori_Id",
                table: "Kegiatans",
                column: "Kategori_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kegiatans");

            migrationBuilder.DropTable(
                name: "Kategori_Kegiatans");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace STTB.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddPendaftaranModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Program_Studis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tingkat = table.Column<string>(type: "text", nullable: false),
                    Nama_Prodi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program_Studis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Form_Pendaftarans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    First_Name = table.Column<string>(type: "text", nullable: false),
                    Last_Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone_Number = table.Column<string>(type: "text", nullable: false),
                    Statement_Of_Faith = table.Column<string>(type: "text", nullable: false),
                    Church_Affiliation = table.Column<string>(type: "text", nullable: false),
                    Tanggal_Submit = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Program_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form_Pendaftarans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Form_Pendaftarans_Program_Studis_Program_Id",
                        column: x => x.Program_Id,
                        principalTable: "Program_Studis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Form_Pendaftarans_Program_Id",
                table: "Form_Pendaftarans",
                column: "Program_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Form_Pendaftarans");

            migrationBuilder.DropTable(
                name: "Program_Studis");
        }
    }
}

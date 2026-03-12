using Microsoft.EntityFrameworkCore;
using STTB.Backend.Models;

namespace STTB.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Kategori_Berita> Kategori_Beritas { get; set; }
        public DbSet<Berita> Beritas { get; set; }
        public DbSet<Program_Studi> Program_Studis { get; set; }
        public DbSet<Form_Pendaftaran> Form_Pendaftarans { get; set; }
        public DbSet<Dosen> Dosens { get; set; }
        public DbSet<Mata_Kuliah> Mata_Kuliahs { get; set; }
        public DbSet<Dosen_Prodi> Dosen_Prodis { get; set; }
        public DbSet<Kategori_Kegiatan> Kategori_Kegiatans { get; set; }
        public DbSet<Kegiatan> Kegiatans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Fasilitas> Fasilitas { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Dokumen_Unduhan> Dokumen_Unduhans { get; set; }
    }
}
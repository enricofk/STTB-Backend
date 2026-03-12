using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STTB.Backend.Models
{
    public class Berita
    {
        [Key]
        public int Id { get; set; }
        public string Judul { get; set; }
        public string Slug { get; set; }
        public string Konten { get; set; }
        public string Thumbnail_Url { get; set; }
        public DateTime Tanggal_Publikasi { get; set; }

        // Foreign Key ke tabel Kategori_Berita
        [ForeignKey("Kategori_Berita")]
        public int Kategori_Id { get; set; }

        // Navigation property
        public Kategori_Berita Kategori_Berita { get; set; }
    }
}
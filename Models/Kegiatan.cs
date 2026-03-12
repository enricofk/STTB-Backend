using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STTB.Backend.Models
{
    public class Kegiatan
    {
        [Key]
        public int Id { get; set; }
        public string Nama_Kegiatan { get; set; }
        public string Deskripsi { get; set; }

        // Kita butuh tanggal mulai dan selesai untuk keperluan Kalender
        public DateTime Tanggal_Mulai { get; set; }
        public DateTime Tanggal_Selesai { get; set; }
        public string Lokasi { get; set; }

        // Foreign Key ke tabel Kategori_Kegiatan
        [ForeignKey("Kategori_Kegiatan")]
        public int Kategori_Id { get; set; }

        // Navigation property
        public Kategori_Kegiatan? Kategori_Kegiatan { get; set; }
    }
}
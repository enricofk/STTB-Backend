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

        public DateTime Tanggal_Mulai { get; set; }
        public DateTime Tanggal_Selesai { get; set; }
        public string Lokasi { get; set; }

        [ForeignKey("Kategori_Kegiatan")]
        public int Kategori_Id { get; set; }

        public Kategori_Kegiatan? Kategori_Kegiatan { get; set; }
    }
}
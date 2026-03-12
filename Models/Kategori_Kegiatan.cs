using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace STTB.Backend.Models
{
    public class Kategori_Kegiatan
    {
        [Key]
        public int Id { get; set; }
        public string Nama_Kategori { get; set; }

        // Relasi One-to-Many ke tabel Kegiatan
        [JsonIgnore] // Mencegah infinite loop JSON seperti biasa
        public ICollection<Kegiatan>? Kegiatans { get; set; }
    }
}
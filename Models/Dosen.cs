using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace STTB.Backend.Models
{
    public class Dosen
    {
        [Key]
        public int Id { get; set; }
        public string Nama_Lengkap { get; set; }
        public string Bidang_Keahlian { get; set; }
        public string Pendidikan_Terakhir { get; set; }

        // Relasi Many-to-Many ke Program Studi lewat tabel perantara
        [JsonIgnore]
        public ICollection<Dosen_Prodi>? Dosen_Prodis { get; set; }
    }
}   
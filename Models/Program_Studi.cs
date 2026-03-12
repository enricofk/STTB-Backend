using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace STTB.Backend.Models
{
    public class Program_Studi
    {
        [Key]
        public int Id { get; set; }
        public string Tingkat { get; set; }
        public string Nama_Prodi { get; set; }

        // (Kamu bisa tambahkan properti lain seperti penjelasan_umum, biaya_tuition, dll nanti)

        // Relasi One-to-Many ke tabel Form_Pendaftaran
        [JsonIgnore] // Mencegah object cycle seperti kasus Berita tadi
        public ICollection<Form_Pendaftaran> Form_Pendaftarans { get; set; }

        // --- TAMBAHAN BARU UNTUK MODUL AKADEMIK ---

        // Relasi ke Ketua Prodi (Dosen)
        // Kita pakai int? (Nullable) agar data prodi lama tidak error saat di-update
        public int? Ketua_Prodi_Id { get; set; }
        [ForeignKey("Ketua_Prodi_Id")]
        public Dosen? Ketua_Prodi { get; set; }

        // Relasi ke tabel Mata Kuliah
        [JsonIgnore]
        public ICollection<Mata_Kuliah>? Mata_Kuliahs { get; set; }

        // Relasi ke tabel Dosen_Prodi
        [JsonIgnore]
        public ICollection<Dosen_Prodi>? Dosen_Prodis { get; set; }
    }
}
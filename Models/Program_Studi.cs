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


        [JsonIgnore] 
        public ICollection<Form_Pendaftaran> Form_Pendaftarans { get; set; }


        public int? Ketua_Prodi_Id { get; set; }
        [ForeignKey("Ketua_Prodi_Id")]
        public Dosen? Ketua_Prodi { get; set; }

        [JsonIgnore]
        public ICollection<Mata_Kuliah>? Mata_Kuliahs { get; set; }

        // Relasi ke tabel Dosen_Prodi
        [JsonIgnore]
        public ICollection<Dosen_Prodi>? Dosen_Prodis { get; set; }
    }
}
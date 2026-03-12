using System.ComponentModel.DataAnnotations;

namespace STTB.Backend.Models
{
    public class Kategori_Berita
    {
        [Key]
        public int Id { get; set; }
        public string Nama_Kategori { get; set; }

        // Relasi One-to-Many: Satu Kategori bisa punya banyak Berita
        public ICollection<Berita> Beritas { get; set; }
    }
}
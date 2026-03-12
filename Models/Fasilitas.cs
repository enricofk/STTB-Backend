using System.ComponentModel.DataAnnotations;

namespace STTB.Backend.Models
{
    public class Fasilitas
    {
        [Key]
        public int Id { get; set; }
        public string Nama_Fasilitas { get; set; }
        public string Deskripsi { get; set; }

        public string Foto_Url { get; set; }
    }
}
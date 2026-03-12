using System.ComponentModel.DataAnnotations;

namespace STTB.Backend.Models
{
    public class Dokumen_Unduhan
    {
        [Key]
        public int Id { get; set; }
        public string Nama_Dokumen { get; set; }

        public string Link_File { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STTB.Backend.Models
{
    public class Mata_Kuliah
    {
        [Key]
        public int Id { get; set; }
        public string Nama_Mk { get; set; }
        public string Kategori_Mk { get; set; }
        public string Detail_Perincian { get; set; }

        // Foreign Key ke Program_Studi
        [ForeignKey("Program_Studi")]
        public int Prodi_Id { get; set; }
        public Program_Studi? Program_Studi { get; set; }
    }
}
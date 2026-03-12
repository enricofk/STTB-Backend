using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STTB.Backend.Models
{
    public class Dosen_Prodi
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Dosen")]
        public int Dosen_Id { get; set; }
        public Dosen? Dosen { get; set; }

        [ForeignKey("Program_Studi")]
        public int Prodi_Id { get; set; }
        public Program_Studi? Program_Studi { get; set; }
    }
}
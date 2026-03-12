using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STTB.Backend.Models
{
    public class Form_Pendaftaran
    {
        [Key]
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Statement_Of_Faith { get; set; }
        public string Church_Affiliation { get; set; }

        // Otomatis terisi waktu saat ini ketika form di-submit
        public DateTime Tanggal_Submit { get; set; } = DateTime.UtcNow;

        // Foreign Key ke tabel Program_Studi
        [ForeignKey("Program_Studi")]
        public int Program_Id { get; set; }

        // Navigation property
        public Program_Studi? Program_Studi { get; set; }
    }
}
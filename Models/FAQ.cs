using System.ComponentModel.DataAnnotations;

namespace STTB.Backend.Models
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }
        public string Pertanyaan { get; set; }
        public string Jawaban { get; set; }
    }
}
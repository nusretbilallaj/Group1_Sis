using System.ComponentModel.DataAnnotations.Schema;

namespace Group1_Sis.Models
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }

        public int KomunaId { get; set; }
        [ForeignKey("KomunaId")]
        public Komuna Komuna { get; set; }
    }
}

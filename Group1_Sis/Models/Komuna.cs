using System.ComponentModel.DataAnnotations.Schema;

namespace Group1_Sis.Models
{
    [Table("Komuna")]
    public class Komuna
    {
        public int Id { get; set; }
        public string Emri { get; set; }
    }
}

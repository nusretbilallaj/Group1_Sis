using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Group1_Sis.Models
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ju lutem plotesoni emrin!")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Ju lutem plotesoni mbiemrin!")]
        public string Mbiemri { get; set; }
        [Required(ErrorMessage = "Ju lutem plotesoni mbiemrin!")]
        [Range(1,30,ErrorMessage = "Ju lutem zgjidhni komunen")]
        public int KomunaId { get; set; }
        [ForeignKey("KomunaId")]
        [ValidateNever]
        public Komuna Komuna { get; set; }
    }
}

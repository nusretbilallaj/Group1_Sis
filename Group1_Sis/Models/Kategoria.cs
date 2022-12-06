using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Group1_Sis.Models
{
    [Table("Kategoria")]
    public class Kategoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ju lutem plotesoni emrin!")]
        public string Emri { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GPI.Dtos
{
    public class CategorieUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Libelle { get; set; }
    }
}
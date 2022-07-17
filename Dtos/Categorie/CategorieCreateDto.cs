using System.ComponentModel.DataAnnotations;

namespace GPI.Dtos
{
    public class CategorieCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Libelle { get; set; }
        
    }
}
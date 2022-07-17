using System.ComponentModel.DataAnnotations;

namespace GPI.Dtos
{
    public class CentreCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string NomCentre { get; set; }
        
        [Required]
        public string Adresse { get; set; }
        
        [Required]
        public string Telephone { get; set; }

        public int IdVille {get; set; }
    }
}
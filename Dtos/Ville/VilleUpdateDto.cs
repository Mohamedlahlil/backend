using System.ComponentModel.DataAnnotations;

namespace GPI.Dtos
{
    public class VilleUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string NomVille { get; set; }
    }
}
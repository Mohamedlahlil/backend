using System.ComponentModel.DataAnnotations;

namespace GPI.Dtos
{
    public class FournisseurCreateDto
    {

        [Required]
        [MaxLength(250)]
        public string NomFournisseur { get; set; }
        [Required]
        public string RefFournisseur { get; set; }
    }
}
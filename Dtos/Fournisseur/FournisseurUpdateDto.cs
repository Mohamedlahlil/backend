using System.ComponentModel.DataAnnotations;

namespace GPI.Dtos
{
    public class FournisseurUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string NomFournisseur { get; set; }
        
        [Required]
        public string RefFournisseur { get; set; }
    }
}
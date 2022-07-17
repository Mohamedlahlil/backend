using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Models;

namespace GPI.Models
{
    public class Fournisseur
    {
        [Key]
        public int IdFournisseur { get; set; }

        [Required]
        [MaxLength(250)]
        public string NomFournisseur { get; set; }
        [Required]
        public string RefFournisseur { get; set; }
        public IEnumerable<Reparation> Reparations { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}